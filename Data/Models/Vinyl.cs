namespace VinylSeliing.Data.Models
{
    public class Vinyl
    {
        public uint Id { get; set; }
        public string Title { get; set; }
        public uint RecordedYear { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } = 0;
        public uint AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}

