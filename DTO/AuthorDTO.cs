using VinylSeliing.Data.Models;

namespace VinylSeliing.DTO
{
    public class AuthorDto
    {
        public uint AuthorId { get; set; }
        public string AuthorName { get; set; }
        public List<Vinyl> Vinyls { get; set; } = new List<Vinyl>();
    }
    
}

