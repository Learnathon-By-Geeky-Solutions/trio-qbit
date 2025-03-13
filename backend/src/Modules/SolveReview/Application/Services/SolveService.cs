using backend.src.Modules.SolveReview.Application.DTOs;
using backend.src.Modules.SolveReview.Application.Interfaces;
using backend.src.Modules.SolveReview.Domain.Entities;

namespace backend.src.Modules.SolveReview.Application.Services
{
    public class SolveService : ISolveService
    {
        private readonly ISolveRepository _Solverepository;
        private readonly ISolveMapper _Solvemapper;
        private readonly ITagWeightsService _TagWeightsservice;
        private readonly IParameterWeightsService _ParameterWeightsservice;
        public SolveService(ISolveRepository repository, ISolveMapper mapper, ITagWeightsService tagWeightsService, IParameterWeightsService parameterWeightsService){
            _Solverepository = repository;
            _Solvemapper = mapper;
            _TagWeightsservice = tagWeightsService;
            _ParameterWeightsservice  = parameterWeightsService;
        }

        public async Task<bool> Add(CreateSolveDTO createSolveDTO) {

           var solve =  _Solvemapper.ToSolveEntity(createSolveDTO); 
           solve.LastRevision = DateTime.UtcNow;
           solve.CreatedAt = DateTime.UtcNow;
           solve.RevisionCount = 1;
           var solves = await _Solverepository.GetByUserIdAsync(createSolveDTO.UserId); 
           
           if(solves.Count() == 0) {
              float sum = 0.0f;
              float decayImpact =  1.0f; // e^0 = 1
              string[] tags = solve.ProblemTags == null? [] : solve.ProblemTags;
              if(tags.Length > 0){
                foreach(string tag in tags) {
                   var tagWeights = await _TagWeightsservice.GetWeightsAsync(tag,null);
                   sum += tagWeights.TagWeight;
                }
              }
              solve.TagImpact = sum;
              var parameterWeights = await _ParameterWeightsservice.GetParameterWeightsAsync(null);
              solve.Priority = (solve.CodingTime * parameterWeights.CodingTimeWeight) +
                               (solve.IsCodeCopied ==  true? parameterWeights.IsCodeCopiedWeight : 0) +
                               (solve.LearningTime * parameterWeights.LearningTimeWeight) +
                               (solve.ThinkingTime * parameterWeights.ThinkingTimeWeight) +
                               (solve.SubmissionAttempts * parameterWeights.SubmissionAttemptsWeight) +
                               (solve.RevisionCount * parameterWeights.RevisionCountWeight) +
                               (decayImpact * parameterWeights.LastRevisionWeight) +
                                (double) solve.TagImpact;

                Console.WriteLine("Kuk");
             return await _Solverepository.AddAsync(solve);

           }

        Solve solveAf = await RecalculatePriority(solves, solve, null);
        return  await _Solverepository.AddAsync(solveAf);            

        }
        public async Task<Solve> RecalculatePriority(List<Solve> solves,Solve solve, Guid? UserId) {
            solves.Append(solve);
            Dictionary<string, int> tagFrequency = new Dictionary<string, int>();
            Dictionary<string, int> parameterMaxs = new Dictionary<string, int>
            {
                { "ThinkingTimeMax", 0 },
                { "LearningTimeMax", 0 },
                { "CodingTimeMax", 0 },
                { "SubmissionAttemptsMax", 0 },
                { "RevisionCountMax", 0 }
            };
            
            solves.ForEach( s => 
            {
                string[]? tags = s.ProblemTags;
                if (tags?.Length > 0)  
                {
                    foreach (string tag in tags)
                    {
                        tagFrequency.TryGetValue(tag, out int count);
                        tagFrequency[tag] = count + 1;
                    }
                }
                parameterMaxs["ThinkingTimeMax"] = Math.Max(parameterMaxs["ThinkingTimeMax"], s.ThinkingTime);
                parameterMaxs["LearningTimeMax"] = Math.Max(parameterMaxs["LearningTimeMax"], s.LearningTime);
                parameterMaxs["CodingTimeMax"] = Math.Max(parameterMaxs["CodingTimeMax"], s.CodingTime);
                parameterMaxs["SubmissionAttemptsMax"] = Math.Max(parameterMaxs["SubmissionAttemptsMax"], s.SubmissionAttempts);
                parameterMaxs["RevisionCountMax"] = Math.Max(parameterMaxs["RevisionCountMax"], s.RevisionCount);
            });
            solves.Remove(solve);
            async Task ProcessSolvesAsync()
            {
                await Task.WhenAll(solves.Select(async s =>
                {
                    string[]? tags = s.ProblemTags;
                    float sum = 0.0f;
                    int maxFreq = tagFrequency.Values.Max();
                    if ( tags?.Length > 0)
                    {
                        foreach (string tag in tags)
                        {
                            
                            var tagWeight = await _TagWeightsservice.GetWeightsAsync(tag, UserId);
                            sum += 1 - (tagFrequency[tag] * tagWeight.TagWeight/maxFreq);
    
                        }
                    }
                    var parameterWeights = await _ParameterWeightsservice.GetParameterWeightsAsync(UserId);
                    double decayWeight = -1.0*(double)(s.LastRevision - s.CreatedAt).TotalMinutes;

                    double decayImpact = Math.Exp(decayWeight);
                    s.TagImpact = sum;
                    s.Priority = (s.ThinkingTime * parameterWeights.ThinkingTimeWeight/parameterMaxs["ThinkingTimeMax"]) +
                                 (s.CodingTime * parameterWeights.CodingTimeWeight/parameterMaxs["CodingTimeMax"]) +
                                 (s.LearningTime * parameterWeights.LearningTimeWeight/parameterMaxs["LearningTimeMax"]) +
                                 (s.SubmissionAttempts * parameterWeights.SubmissionAttemptsWeight/parameterMaxs["SubmissionAttemptsMax"]) +
                                 (s.RevisionCount * parameterWeights.RevisionCountWeight / parameterMaxs["RevisionCountMax"]) +
                                 (s.IsCodeCopied == true? parameterWeights.IsCodeCopiedWeight : 0) +
                                 decayImpact + sum; 
                    Console.WriteLine("kuk_async");
                }));
            }
            await ProcessSolvesAsync();
            Console.WriteLine("kuk_af_Async");
            _Solverepository.UpdateBulk(solves);
            Console.WriteLine("kuk_af_Bulk");
            string[]? tags = solve.ProblemTags;
            float sum = 0.0f;
            int maxFreq = tagFrequency.Values.Max();
            if ( tags?.Length > 0)
                {
                    foreach (string tag in tags)
                    {
                        
                        var tagWeight = await _TagWeightsservice.GetWeightsAsync(tag, UserId);
                        sum += 1 - (tagFrequency[tag] * tagWeight.TagWeight/maxFreq);

                    }
                }
                var parameterWeights = await _ParameterWeightsservice.GetParameterWeightsAsync(UserId);
                double decayWeight = -1.0*(double)(solve.LastRevision - solve.CreatedAt).TotalMinutes;

                double decayImpact = Math.Exp(decayWeight);
                solve.TagImpact = sum;
                solve.Priority = (solve.ThinkingTime * parameterWeights.ThinkingTimeWeight/parameterMaxs["ThinkingTimeMax"]) +
                                (solve.CodingTime * parameterWeights.CodingTimeWeight/parameterMaxs["CodingTimeMax"]) +
                                (solve.LearningTime * parameterWeights.LearningTimeWeight/parameterMaxs["LearningTimeMax"]) +
                                (solve.SubmissionAttempts * parameterWeights.SubmissionAttemptsWeight/parameterMaxs["SubmissionAttemptsMax"]) +
                                (solve.RevisionCount * parameterWeights.RevisionCountWeight / parameterMaxs["RevisionCountMax"]) +
                                (solve.IsCodeCopied == true? parameterWeights.IsCodeCopiedWeight : 0) +
                                decayImpact + sum; 

                Console.WriteLine("kuk_Final");
                return solve;
        }
    }
}