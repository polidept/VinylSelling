using VinylSeliing.DTO;

namespace VinylSeliing.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<AuthorDto>> GetAll();
        Task<AuthorDto> GetById(uint id);
        Task Create(string name);
        Task Update(uint id, string name);
        Task Delete(uint id);
    }
}

