namespace backend.src.Modules.SolveReview.Domain.DTOs
{
    public class UpdateSolveRequestDto
    {
        public int TimeSpentLogic { get; set; }
        public int TimeSpentLearning { get; set; }
        public bool IsCodeCopied { get; set; }
        public int TimeSpentCoding { get; set; }
        public int SubmissionAttempts { get; set; }
    }
}