using backend.src.Modules.SolveReview.Domain.Entities;

namespace backend.src.Modules.SolveReview.Application.Interfaces
{
    public interface IParameterWeightsRepository
    {
        
        Task<ParameterWeights?>GetWeightsByUserId(Guid? UserId);
        
    }
}