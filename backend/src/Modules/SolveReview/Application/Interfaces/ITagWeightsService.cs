using backend.src.Modules.SolveReview.Domain.Entities;

namespace backend.src.Modules.SolveReview.Application.Interfaces
{
    public interface ITagWeightsService
    {
        public Task<TagWeights?> GetWeightsAsync(string TagName, Guid? UserId);
    }
}