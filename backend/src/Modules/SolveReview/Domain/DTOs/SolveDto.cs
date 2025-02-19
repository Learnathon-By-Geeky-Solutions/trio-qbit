namespace backend.src.Modules.SolveReview.Domain.DTOs
{
    public class SolveDto
    {
        public Guid Id { get;  set; }
        public string ProblemUrl { get;  set; }
        public int TimeSpentLogic { get;  set; }
        public int TimeSpentLearning { get;  set; }
        public bool IsCodeCopied { get;  set; }
        public int TimeSpentCoding { get;  set; }
        public List<string> Tags { get;  set; }
        public int SubmissionAttempts { get;  set; }
        public DateTime CreatedAt { get;  set; }
        public DateTime UpdatedAt { get;  set; }
        public int RevisionCount { get;  set; }
        public Guid UserId { get;  set; } 
    }
}