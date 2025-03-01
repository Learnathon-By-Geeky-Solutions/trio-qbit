using backend.src.Modules.SolveReview.Application.DTOs;
using backend.src.Modules.SolveReview.Domain.Entities;

namespace backend.src.Modules.SolveReview.Application.Interfaces
{
    public interface ISolveRepository
    {
        /// <summary>
        /// Adds a new Solve entity to the data store.
        /// </summary>
        /// <param name="solve">The Solve entity to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<bool> AddAsync(Solve solve);

        /// <summary>
        /// Retrieves a Solve entity by its ID.
        /// </summary>
        /// <param name="id">The Guid ID of the Solve entity.</param>
        /// <returns>The Solve entity if found; otherwise, null.</returns>
        Task<Solve?> GetByIdAsync(Guid id);

        /// <summary>
        /// Retrieves all Solve entity by UserId
        /// </summary>
        /// <param name="id"> The Guid UserId of the User entity.</param>
        /// <returns>The Solve entity if found; otherwise, null.</returns>
        Task<List<Solve>> GetByUserIdAsync(Guid userId);

        /// <summary>
        /// Retrieves all Solve entities, optionally filtered by parameters.
        /// </summary>
        /// <returns>A collection of Solve entities.</returns>
        Task<List<Solve>> GetAllAsync();

        /// <summary>
        /// Updates an existing Solve entity in the data store.
        /// </summary>
        /// <param name="solve">The Solve entity to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<bool> UpdateAsync(Solve solve);

        /// <summary>
        /// Deletes a Solve entity from the data store.
        /// </summary>
        /// <param name="id">The Guid ID of the Solve entity.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task<bool> DeleteAsync(Guid id);
    }
}