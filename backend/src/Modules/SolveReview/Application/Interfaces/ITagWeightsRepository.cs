using backend.src.Modules.SolveReview.Domain.Entities;

namespace backend.src.Modules.SolveReview.Application.Interfaces
{
    public interface ITagWeightsRepository
    {
        Task<TagWeights?> GetWeights(string TagName, Guid? UserId);
    }
}