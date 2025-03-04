using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.src.Modules.SolveReview.Application.DTOs
{
    public class UpdateSolveDTO
    {
        public string? ProblemUrl { get; set; }
        public int? ThinkingTime { get; set; } 
        public int? LearningTime { get; set; } 
        public bool? IsCodeCopied { get; set; }
        public int? CodingTime { get; set; } 
        public string[]? ProblemTags { get; set; }
        public float? TagImpact {get; set;}
        public int? SubmissionAttempts { get; set; }
        public int? RevisionCount { get; set; }
        public DateTime? LastRevision { get; set; }
        public double? Priority { get; set; }
    }
}