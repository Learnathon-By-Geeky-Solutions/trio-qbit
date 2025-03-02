using backend.src.Modules.SolveReview.Domain.Entities;

namespace backend.src.Modules.SolveReview.Application.Interfaces
{
    public interface IParameterWeightsService
    {
        public Task<ParameterWeights?> GetParameterWeightsAsync(Guid? UserId);
    }
}