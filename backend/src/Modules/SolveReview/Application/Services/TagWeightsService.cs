using backend.src.Modules.SolveReview.Application.Interfaces;
using backend.src.Modules.SolveReview.Domain.Entities;

namespace backend.src.Modules.SolveReview.Application.Services
{
    public class TagWeightsService : ITagWeightsService
    {
        private readonly ITagWeightsRepository _repository;

        public TagWeightsService( ITagWeightsRepository repository) {
            _repository = repository;
        }

        public async Task<TagWeights?> GetWeightsAsync(string TagName, Guid? UserId) {
            return await _repository.GetWeights(TagName, UserId);
        }
    }
}