using Microsoft.EntityFrameworkCore;
using VinylSeliing.Data;
using VinylSeliing.Data.Models;
using VinylSeliing.DTO;
using VinylSeliing.Interfaces;

namespace VinylSeliing.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly VinylSellingDbContext _dbContext;

        public AuthorRepository(VinylSellingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<List<AuthorDto>> GetAll()
        {
            return await _dbContext.Authors
                .AsNoTracking()
                .Include(a => a.Vinyls)
                .Select(a => new AuthorDto()
                {
                    AuthorId = a.Id,
                    AuthorName = a.Name,
                    Vinyls = a.Vinyls
                })
                .ToListAsync();
        }
        
        public async Task<AuthorDto?> GetById(uint id)
        {
            return await _dbContext.Authors
                .AsNoTracking()
                .Where(a => a.Id == id)
                .Include(a => a.Vinyls)
                .Select(a => new AuthorDto()
                {
                    AuthorId = a.Id,
                    AuthorName = a.Name,
                    Vinyls = a.Vinyls
                })
                .FirstOrDefaultAsync();
        }
        
        public async Task Create(string name)
        {
            var author = new Author
            {
                Name = name
            };

            await _dbContext.AddAsync(author);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task Update(uint id, string name)
        {
            await _dbContext.Authors
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(s =>
                    s.SetProperty(a => a.Name, name));
        }
        
        public async Task Delete(uint id)
        {
            await _dbContext.Authors
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
        }
    }
    
}

