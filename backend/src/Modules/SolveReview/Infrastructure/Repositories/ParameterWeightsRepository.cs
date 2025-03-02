using backend.src.Modules.SolveReview.Application.Interfaces;
using backend.src.Modules.SolveReview.Infrastructure.Persistence;
using backend.src.Modules.SolveReview.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Modules.SolveReview.Infrastructure.Repositories
{
    public class ParameterWeightsRepository : IParameterWeightsRepository
    {
        private readonly SolveReviewDbContext _context;
        
        public ParameterWeightsRepository(SolveReviewDbContext context) {
            
            _context = context;

        }

        public async Task<ParameterWeights?> GetWeightsByUserId(Guid? UserId) { 
            return await _context.ParameterWeights.FirstOrDefaultAsync(pw => pw.UserId == UserId);
        }
    }
}