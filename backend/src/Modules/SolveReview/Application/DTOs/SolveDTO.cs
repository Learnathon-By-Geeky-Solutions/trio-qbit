using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.src.Modules.SolveReview.Application.DTOs
{
    public class SolveDTO
    {
        public Guid Id { get; set; }
        public string ProblemUrl { get; set; }
        public Guid UserId { get; set; }
        public int ThinkingTime { get; set; } // Minutes
        public int LearningTime { get; set; } // Minutes
        public bool IsCodeCopied { get; set; }
        public int CodingTime { get; set; } // Minutes
        public string[]? ProblemTags { get; set; }
        public float? TagImpact {get; set;}
        public int SubmissionAttempts { get; set; }
        public int RevisionCount { get; set; }
        public DateTime LastRevision { get; set; }
        public DateTime CreatedAt { get; set; }
        public double Priority { get; set; }
    }
}