using backend.src.Modules.SolveReview.Domain.DTOs;
using backend.src.Modules.SolveReview.Application.Interfaces;
using backend.src.Modules.SolveReview.Domain.Entities;
using backend.src.Modules.SolveReview.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Modules.SolveReview.Infrastructure.Repositories
{
    public class SolveRepository : ISolveRepository
    {
        private readonly SolveReviewDbContext _context;

        public SolveRepository(SolveReviewDbContext context)
        {
            _context = context;
        }

        public async Task<Solve> CreateAsync(SolveDto solve)
        {   
            var newSolve = new Solve(solve);
            _context.Solves.Add(newSolve);
            await _context.SaveChangesAsync();
            return newSolve;
        }

        public async Task<Boolean?> UpdateAsync(SolveDto solve, Guid solveId)
        {
            var existingSolve = await _context.Solves.FirstOrDefaultAsync(s => s.Id == solveId);
            if (existingSolve == null)
            {
                return null;
            }
            
            existingSolve.SolveUpdate(solve);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Solve?> GetByIdAsync(Guid solveId)
        {
            var solve = await _context.Solves.FirstOrDefaultAsync(s => s.Id == solveId);
            if (solve == null)
            {
                return null;
            }
            return solve;
        }

        public async Task<List<Solve>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Solves.Where(s => s.UserId == userId).ToListAsync();
        }
        
        public async Task<Boolean?> DeleteAsync(Guid solveId)
        {
            var solve = await _context.Solves.FirstOrDefaultAsync(s => s.Id == solveId);
            if (solve == null)
            {
                return null;
            }
            _context.Solves.Remove(solve);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}