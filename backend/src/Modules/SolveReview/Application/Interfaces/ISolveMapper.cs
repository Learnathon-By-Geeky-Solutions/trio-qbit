using backend.src.Modules.SolveReview.Application.DTOs;
using backend.src.Modules.SolveReview.Domain.Entities;

namespace backend.src.Modules.SolveReview.Application.Interfaces
{
    public interface ISolveMapper
    {
        
        Solve ToSolveEntity(CreateSolveDTO createDto);

        Solve UpdateEntity(Solve solve, UpdateSolveDTO updateDto);

        SolveDTO ToSolveDTO(Solve solve);
        
    }
}