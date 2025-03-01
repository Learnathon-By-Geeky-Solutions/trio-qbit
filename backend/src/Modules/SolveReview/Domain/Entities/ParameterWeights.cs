namespace backend.src.Modules.SolveReview.Domain.Entities
{
    public class ParameterWeights
    {      
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? UserId { get; set; } // Null for global weights, FK to User for personal weights
        public float ThinkingTimeWeight { get; set; }
        public float LearningTimeWeight { get; set; }
        public float IsCodeCopiedWeight { get; set; }
        public float CodingTimeWeight { get; set; }
        public float SubmissionAttemptsWeight { get; set; }
        public float RevisionCountWeight { get; set; }
        public float LastRevisionWeight { get; set; }


    }
}