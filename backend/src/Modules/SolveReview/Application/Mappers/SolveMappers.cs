using backend.src.Modules.SolveReview.Domain.DTOs;
using backend.src.Modules.SolveReview.Domain.Entities;

namespace backend.src.Modules.SolveReview.Application.Mappers
{
    public static class SolveMappers
    {
        public static SolveDto ToSolveDto(this Solve solve)
        {
            return new SolveDto
            {
                Id = solve.Id,
                ProblemUrl = solve.ProblemUrl,
                TimeSpentLogic = solve.TimeSpentLogic,
                TimeSpentLearning = solve.TimeSpentLearning,
                IsCodeCopied = solve.IsCodeCopied,
                TimeSpentCoding = solve.TimeSpentCoding,
                Tags = solve.Tags,
                SubmissionAttempts = solve.SubmissionAttempts,
                CreatedAt = solve.CreatedAt,
                UpdatedAt = solve.UpdatedAt,
                RevisionCount = solve.RevisionCount,
                UserId = solve.UserId
            };
        }
    
        public static SolveDto ToSolveDtoFromCreateSolveRequest (this CreateSolveRequestDto request)
        {
            return new SolveDto
            {
                ProblemUrl = request.ProblemUrl,
                TimeSpentLogic = request.TimeSpentLogic,
                TimeSpentLearning = request.TimeSpentLearning,
                IsCodeCopied = request.IsCodeCopied,
                TimeSpentCoding = request.TimeSpentCoding,
                Tags = request.Tags,
                SubmissionAttempts = request.SubmissionAttempts,
                UserId = request.UserId
            };
        }

        public static SolveDto ToSolveDtoFromUpdateSolveRequest (this UpdateSolveRequestDto request)
        {
            return new SolveDto
            {
                TimeSpentLogic = request.TimeSpentLogic,
                TimeSpentLearning = request.TimeSpentLearning,
                IsCodeCopied = request.IsCodeCopied,
                TimeSpentCoding = request.TimeSpentCoding,
                SubmissionAttempts = request.SubmissionAttempts,
            };
        }

        public static SolveResponseDto ToSolveResponseDto(this Solve solve)
        {
            return new SolveResponseDto
            {
                Id = solve.Id,
                ProblemUrl = solve.ProblemUrl,
                TimeSpentLogic = solve.TimeSpentLogic,
                TimeSpentLearning = solve.TimeSpentLearning,
                IsCodeCopied = solve.IsCodeCopied,
                TimeSpentCoding = solve.TimeSpentCoding,
                Tags = solve.Tags,
                SubmissionAttempts = solve.SubmissionAttempts,
                UpdatedAt = solve.UpdatedAt,
                Priority = solve.Priority,
                RevisionCount = solve.RevisionCount,
                UserId = solve.UserId
            };
        }

    }
}