using backend.src.Modules.SolveReview.Application.DTOs;
using backend.src.Modules.SolveReview.Domain.Entities;

namespace backend.src.Modules.SolveReview.Application.Interfaces
{
    public class ISolveMapper
    {
        
        /// <summary>
        /// Maps a CreateSolveDTO to a Solve entity.
        /// </summary>
        /// <param name="createDto">The DTO containing data to create a Solve entity.</param>
        /// <returns>A new Solve entity.</returns>
        Solve ToSolveEntity(CreateSolveDTO createDto);

        /// <summary>
        /// Updates an existing Solve entity with data from an UpdateSolveDTO.
        /// </summary>
        /// <param name="solve">The existing Solve entity to update.</param>
        /// <param name="updateDto">The DTO containing updated data.</param>
        /// <returns>The updated Solve entity.</returns>
        Solve UpdateEntity(Solve solve, UpdateSolveDTO updateDto);

        /// <summary>
        /// Maps a Solve entity to a SolveDTO.
        /// </summary>
        /// <param name="solve">The Solve entity to map.</param>
        /// <returns>A SolveDTO representing the entity.</returns>
        SolveDTO ToSolveDTO(Solve solve);
        
    }
}