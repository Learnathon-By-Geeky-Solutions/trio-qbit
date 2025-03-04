using backend.src.Modules.SolveReview.Application.Interfaces;
using backend.src.Modules.SolveReview.Domain.Entities;

namespace backend.src.Modules.SolveReview.Application.Services
{
    public class ParameterWeightsService : IParameterWeightsService
    {
        private readonly IParameterWeightsRepository _repository;

        public ParameterWeightsService(IParameterWeightsRepository repository) {
            _repository = repository;
        }

        public async Task<ParameterWeights?> GetParameterWeightsAsync(Guid? UserId) {
            return await _repository.GetWeightsByUserId(UserId);
        }
    }
}