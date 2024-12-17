using VinylSeliing.DTO;

namespace VinylSeliing.Interfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorDto>> GetAllAuthors();
        Task<AuthorDto> GetByIdAuthor(uint id);
        Task CreateAuthor(string name);
        Task UpdateAuthor(uint id, string name);
        Task DeleteAuthor(uint id);
    }
    
}

