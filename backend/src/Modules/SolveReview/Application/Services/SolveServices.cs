// using backend.src.Modules.SolveReview.Domain.DTOs;
// using backend.src.Modules.SolveReview.Application.Interfaces;
// using backend.src.Modules.SolveReview.Domain.Entities;

// namespace backend.src.Modules.SolveReview.Application.Services
// {
//     public class SolveServices
//     {
//         public readonly ISolveRepository _solveRepository;
        

//         public SolveServices(ISolveRepository solveRepository){
//             _solveRepository = solveRepository;
//         }

//         public async Task<List<Solve>> GetSolvesByUserId(Guid userId){
//             return await _solveRepository.GetByUserIdAsync(userId);
//         }

//         public async Task<Solve?> GetSolveById(Guid solveId){
//             return await _solveRepository.GetByIdAsync(solveId);
//         }

//         public async Task<Solve> CreateSolve(SolveDto solve){
//             return await _solveRepository.CreateAsync(solve);
//         }

//         public async Task<Boolean?> UpdateSolve(SolveDto solve, Guid solveId){
//             return await _solveRepository.UpdateAsync(solve, solveId);
//         }

//         public async Task<Boolean?> DeleteSolve(Guid solveId){
//             return await _solveRepository.DeleteAsync(solveId);
//         }
//     }
// }