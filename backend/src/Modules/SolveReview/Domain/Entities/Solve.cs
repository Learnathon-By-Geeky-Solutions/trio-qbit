using backend.src.Modules.SolveReview.Domain.DTOs;

namespace backend.src.Modules.SolveReview.Domain.Entities
{
    public class Solve
    {
               // Configurable weights
        private static int LogicWeight = 3;
        private static int LearningWeight = 2;
        private static int CodingWeight = 1;
        private static int SubmissionWeight = 2;
        private static int CopiedPenalty = 5;

        private static readonly Dictionary<string, int> TagWeights = new()
        {
            { "Greedy", 2 },
            { "Number Theory", 3 },
            { "Implementation", 1 },
            { "Math", 2 },
            { "Dynamic Programming", 5 },
            { "Graph", 4 },
            { "Tree", 4 },
            { "HashTable", 2 },
            { "Constructive Algorithm", 3 },
        };

        public Guid Id { get; private set; }
        public string ProblemUrl { get; private set; }
        public int TimeSpentLogic { get; private set; }
        public int TimeSpentLearning { get; private set; }
        public bool IsCodeCopied { get; private set; }
        public int TimeSpentCoding { get; private set; }
        public List<string> Tags { get; private set; }
        public int SubmissionAttempts { get; private set; }
        public int Priority { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public int RevisionCount { get; private set; }
        public Guid UserId { get; private set; } 
        private Solve() { } // EF Core

        public Solve(SolveDto solveDto)
        {
            Id = Guid.NewGuid();
            ProblemUrl = solveDto.ProblemUrl;
            TimeSpentLogic = solveDto.TimeSpentLogic;
            TimeSpentLearning = solveDto.TimeSpentLearning;
            IsCodeCopied = solveDto.IsCodeCopied;
            TimeSpentCoding = solveDto.TimeSpentCoding;
            Tags = solveDto.Tags;
            SubmissionAttempts = solveDto.SubmissionAttempts;
            Priority = CalculatePriority();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            RevisionCount = 0;
            UserId = solveDto.UserId;
        }

        public void SolveUpdate(SolveDto solve)
        {
            this.TimeSpentLogic = solve.TimeSpentLogic;
            this.TimeSpentLearning = solve.TimeSpentLearning;
            this.IsCodeCopied = solve.IsCodeCopied;
            this.TimeSpentCoding = solve.TimeSpentCoding;
            this.SubmissionAttempts = solve.SubmissionAttempts;
            this.Priority = CalculatePriority();
            this.UpdatedAt = DateTime.UtcNow;
            this.RevisionCount++;            
        }
        private int CalculatePriority()
        {
            int basePriority = (TimeSpentLogic * LogicWeight) + 
                               (TimeSpentLearning * LearningWeight) + 
                               (TimeSpentCoding * CodingWeight) + 
                               (SubmissionAttempts * SubmissionWeight);

            if (IsCodeCopied)
                basePriority -= CopiedPenalty;  // Reduce priority if solution was copied

            basePriority += Tags.Sum(tag => TagWeights.ContainsKey(tag) ? TagWeights[tag] : 0); 

            return Math.Max(basePriority, 1); // Ensure priority is at least 1
        }

                public static void SetWeights(int logic, int learning, int coding, int submission, int copiedPenalty)
        {
            LogicWeight = logic;
            LearningWeight = learning;
            CodingWeight = coding;
            SubmissionWeight = submission;
            CopiedPenalty = copiedPenalty;
        }

        public static void SetTagWeights(Dictionary<string, int> tagWeights)
        {
            foreach (var tag in tagWeights)
            {
                TagWeights[tag.Key] = tag.Value;
            }
        }

    }
}