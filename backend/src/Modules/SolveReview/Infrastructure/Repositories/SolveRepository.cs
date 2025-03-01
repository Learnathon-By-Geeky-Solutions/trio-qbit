using backend.src.Modules.SolveReview.Application.DTOs;
using backend.src.Modules.SolveReview.Application.Interfaces;
using backend.src.Modules.SolveReview.Application.Mappers;
using backend.src.Modules.SolveReview.Domain.Entities;
using backend.src.Modules.SolveReview.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Modules.SolveReview.Infrastructure.Repositories
{
    public class SolveRepository : ISolveRepository
    {
            private readonly SolveReviewDbContext _context;
            public SolveRepository(SolveReviewDbContext context) {
                
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }
            public async Task<bool> AddAsync(Solve solve) {
                if (solve == null) throw new ArgumentNullException(nameof(solve));
                    try
                    {
                        await _context.Solves.AddAsync(solve);
                        await _context.SaveChangesAsync();
                        return true;

                    }
                    catch (Exception)
                    {
                        return false;
                    }
            }
            public async Task<Solve?> GetByIdAsync(Guid id) {

                return await _context.Solves.FindAsync(id);
           
            }
            public async Task<List<Solve>> GetByUserIdAsync(Guid userId) {

                return await _context.Solves.Where(s=> s.UserId == userId).ToListAsync();
            }

            public async Task<List<Solve>> GetAllAsync() {
                return await _context.Solves.ToListAsync();
            }
            
            public async Task<bool> UpdateAsync(Solve solve){
                var existingSolve = await _context.Solves.FindAsync(solve.Id);

                if(existingSolve == null) {
                    return false;
                }
                try {

                    _context.Entry(existingSolve).CurrentValues.SetValues(solve);
                    await _context.SaveChangesAsync();
                    return true;

                } catch (Exception) {
                    return false;
                }
            }
            public async Task<bool> DeleteAsync(Guid id) {

                var existingSolve = await _context.Solves.FindAsync(id);

                if(existingSolve == null) {
                    return false;
                }
                try {

                    _context.Solves.Remove(existingSolve);
                    await _context.SaveChangesAsync();
                    return true;

                } catch (Exception) {
                    return false;
                }
            }

    }
}