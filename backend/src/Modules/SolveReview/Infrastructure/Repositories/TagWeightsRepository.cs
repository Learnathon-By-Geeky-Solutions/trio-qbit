using backend.src.Modules.SolveReview.Application.Interfaces;
using backend.src.Modules.SolveReview.Domain.Entities;
using backend.src.Modules.SolveReview.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Modules.SolveReview.Infrastructure.Repositories
{
    public class TagWeightsRepository : ITagWeightsRepository
    {
        private readonly SolveReviewDbContext _context;
        
        public TagWeightsRepository(SolveReviewDbContext context) {
            
            _context = context;

        }
        public async Task<TagWeights?> GetWeights(string TagName, Guid? UserId) {
                
            return await _context.TagWeights.FirstOrDefaultAsync(tw => tw.TagName == TagName && tw.UserId == UserId);

        }
    }
}