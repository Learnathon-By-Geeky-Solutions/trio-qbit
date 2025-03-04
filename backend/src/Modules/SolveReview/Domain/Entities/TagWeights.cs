namespace backend.src.Modules.SolveReview.Domain.Entities
{
    public class TagWeights
    {   
        public int TagId {get; set;}
        public string TagName {get; set;}
        public Guid? UserId {get; set;}

        public float TagWeight {get; set;}

    }
}