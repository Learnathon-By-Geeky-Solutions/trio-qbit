using backend.src.Modules.SolveReview.Domain.DTOs;
using backend.src.Modules.SolveReview.Domain.Entities;

namespace backend.src.Modules.SolveReview.Application.Interfaces
{
    public interface ISolveRepository
    {
        Task<Solve> CreateAsync(SolveDto solve);
        Task<Boolean?> UpdateAsync(SolveDto sovle, Guid solveId);
        Task<Solve?> GetByIdAsync(Guid solveId);
        Task<List<Solve>> GetByUserIdAsync(Guid userId);
        Task<Boolean?>DeleteAsync(Guid solveId);
        
    }
}