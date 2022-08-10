namespace LabelPlace.Domain.Entities
{
    public class Subproject
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string PartOfSourceText { get; set; }

        public string LabeledText { get; set; }

        public int ProjectId { get; set; }
    }
}