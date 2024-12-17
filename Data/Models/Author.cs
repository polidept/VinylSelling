namespace VinylSeliing.Data.Models
{
    public class Author
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public List<Vinyl> Vinyls { get; set; } = [];
    }
}