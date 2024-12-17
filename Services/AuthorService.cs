using VinylSeliing.DTO;
using VinylSeliing.Interfaces;

namespace VinylSeliing.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<AuthorDto>> GetAllAuthors()
        {
            return await _authorRepository.GetAll();
        }

        public async Task<AuthorDto> GetByIdAuthor(uint id)
        {
            return await _authorRepository.GetById(id);
        }

        public async Task CreateAuthor(string name)
        {
            await _authorRepository.Create(name);
        }

        public async Task UpdateAuthor(uint id, string name)
        {
            await _authorRepository.Update(id, name);
        }

        public async Task DeleteAuthor(uint id)
        {
            await _authorRepository.Delete((id));
        }
    }
}

