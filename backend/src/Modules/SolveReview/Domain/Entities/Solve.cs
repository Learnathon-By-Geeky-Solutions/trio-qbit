namespace backend.src.Modules.SolveReview.Domain.Entities
{
    public class Solve
    
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ProblemUrl { get; set; }
        public Guid UserId { get; set; } // Foreign key to a User entity (assumed elsewhere)
        public int ThinkingTime { get; set; } // Minutes
        public int LearningTime { get; set; } // Minutes
        public bool IsCodeCopied { get; set; }
        public int CodingTime { get; set; } // Minutes
        public string[]? ProblemTags { get; set; } // JSON in Postgres
        public int SubmissionAttempts { get; set; }
        public int RevisionCount { get; set; }
        public DateTime LastRevision { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public float Priority { get; set; } // Calculated based on weightsx
    }
}