using backend.src.Modules.SolveReview.Domain.Entities;

namespace backend.src.Modules.SolveReview.Application.Interfaces
{
    public interface ISolveRepository
    {

        Task<bool> AddAsync(Solve solve);

        Task<Solve?> GetByIdAsync(Guid id);

        Task<List<Solve>> GetByUserIdAsync(Guid userId);

        Task<List<Solve>> GetAllAsync();

        Task<bool> UpdateAsync(Solve solve);
        Task<bool> DeleteAsync(Guid id);
        bool UpdateBulk(List<Solve> solves);

    }
}