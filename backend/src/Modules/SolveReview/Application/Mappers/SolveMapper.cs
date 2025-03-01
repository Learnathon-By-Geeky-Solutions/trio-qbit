using backend.src.Modules.SolveReview.Application.DTOs;
using backend.src.Modules.SolveReview.Application.Interfaces;
using backend.src.Modules.SolveReview.Domain.Entities;

namespace backend.src.Modules.SolveReview.Application.Mappers
{
    public class SolveMapper : ISolveMapper
    {
        public Solve ToSolveEntity(CreateSolveDTO createDto)
        {
            if (createDto == null) throw new ArgumentNullException(nameof(createDto));

            return new Solve
            {
                // Id is auto-generated (Guid.NewGuid()) in the entity constructor
                ProblemUrl = createDto.ProblemUrl,
                UserId = createDto.UserId, // From message broker
                ThinkingTime = createDto.ThinkingTime,
                LearningTime = createDto.LearningTime,
                IsCodeCopied = createDto.IsCodeCopied,
                CodingTime = createDto.CodingTime,
                ProblemTags = createDto.ProblemTags,
                SubmissionAttempts = createDto.SubmissionAttempts,
                RevisionCount = createDto.RevisionCount,
                LastRevision = createDto.LastRevision,
                Priority = createDto.Priority
                // CreatedAt defaults to DateTime.UtcNow in the entity constructor
            };
        }
        public Solve UpdateEntity(Solve solve, UpdateSolveDTO updateDto)
        {
            if (solve == null) throw new ArgumentNullException(nameof(solve));
            if (updateDto == null) throw new ArgumentNullException(nameof(updateDto));

            // Only update fields that are provided (non-null)
            if (updateDto.ProblemUrl != null) solve.ProblemUrl = updateDto.ProblemUrl;
            if (updateDto.ThinkingTime.HasValue) solve.ThinkingTime = updateDto.ThinkingTime.Value;
            if (updateDto.LearningTime.HasValue) solve.LearningTime = updateDto.LearningTime.Value;
            if (updateDto.IsCodeCopied.HasValue) solve.IsCodeCopied = updateDto.IsCodeCopied.Value;
            if (updateDto.CodingTime.HasValue) solve.CodingTime = updateDto.CodingTime.Value;
            if (updateDto.ProblemTags != null) solve.ProblemTags = updateDto.ProblemTags;
            if (updateDto.SubmissionAttempts.HasValue) solve.SubmissionAttempts = updateDto.SubmissionAttempts.Value;
            if (updateDto.RevisionCount.HasValue) solve.RevisionCount = updateDto.RevisionCount.Value;
            if (updateDto.LastRevision.HasValue) solve.LastRevision = updateDto.LastRevision.Value;
            if (updateDto.Priority.HasValue) solve.Priority = updateDto.Priority.Value;
            // Id, UserId, and CreatedAt are immutable and not updated
            return solve;
        }

        public SolveDTO ToSolveDTO(Solve solve) {
            if (solve == null) throw new ArgumentNullException(nameof(solve));

            return new SolveDTO
            {
                Id = solve.Id,
                ProblemUrl = solve.ProblemUrl,
                UserId = solve.UserId,
                ThinkingTime = solve.ThinkingTime,
                LearningTime = solve.LearningTime,
                IsCodeCopied = solve.IsCodeCopied,
                CodingTime = solve.CodingTime,
                ProblemTags = solve.ProblemTags,
                SubmissionAttempts = solve.SubmissionAttempts,
                RevisionCount = solve.RevisionCount,
                LastRevision = solve.LastRevision,
                CreatedAt = solve.CreatedAt,
                Priority = solve.Priority
            };
        }

    }
}