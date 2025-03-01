using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.src.Modules.SolveReview.Application.DTOs
{
    public class CreateSolveDTO
    {
        public string ProblemUrl { get; set; }
        public Guid UserId { get; set; } // Provided by message broker
        public int ThinkingTime { get; set; } // Minutes
        public int LearningTime { get; set; } // Minutes
        public bool IsCodeCopied { get; set; }
        public int CodingTime { get; set; } // Minutes
        public string[]? ProblemTags { get; set; }
        public int SubmissionAttempts { get; set; }
        public int RevisionCount { get; set; }
        public DateTime LastRevision { get; set; }
        public float Priority { get; set; }
    }
}