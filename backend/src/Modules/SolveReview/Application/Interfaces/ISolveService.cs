using backend.src.Modules.SolveReview.Application.DTOs;

namespace backend.src.Modules.SolveReview.Application.Interfaces
{
    public interface ISolveService
    {
        Task<bool> Add(CreateSolveDTO createSolveDTO);
    }
}