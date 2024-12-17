using Microsoft.EntityFrameworkCore;
using VinylSeliing.Data;
using VinylSeliing.Data.Models;
using VinylSeliing.DTO;
using VinylSeliing.Interfaces;

namespace VinylSeliing.Repositories
{
    public class VinylRepository : IVinylRepository
    {
        private readonly VinylSellingDbContext _dbContext;

        public VinylRepository(VinylSellingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<VinylDto>> GetAll()
        {
            return await _dbContext.Vinyls
                .AsNoTracking()
                .Include(v => v.Author)
                .Select(v => new VinylDto()
                {
                    VinylId = v.Id,
                    VinylTitle = v.Title,
                    AuthorName = v.Author.Name,
                    RecordedYear = v.RecordedYear,
                    Description = v.Description,
                    VinylPrice = v.Price
                })
                .OrderBy(v => v.VinylTitle)
                .ToListAsync();
        }
        
        public async Task<VinylDto> GetById(uint id)
        {
            return await _dbContext.Vinyls
                .AsNoTracking()
                .Include(v => v.Author)
                .Where(v => v.Id == id)
                .Select(v => new VinylDto()
                {
                    VinylTitle = v.Title,
                    AuthorName = v.Author.Name,
                    RecordedYear = v.RecordedYear,
                    Description = v.Description,
                    VinylPrice = v.Price
                })
                .FirstOrDefaultAsync();
        }

        public async Task Create(string title, uint authorId, uint recordedYear, string description,
            decimal price)
        {
            var vinyl = new Vinyl
            {
                Title = title,
                AuthorId = authorId,
                RecordedYear = recordedYear,
                Description = description,
                Price = price
            };

            await _dbContext.AddAsync(vinyl);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task Update(uint id, string title, uint authorId, uint recordedYear, string description,
            decimal price)
        {
            await _dbContext.Vinyls
                .Where(v => v.Id == id)
                .ExecuteUpdateAsync(s =>
                    s.SetProperty(v => v.Title, title)
                        .SetProperty(v => v.AuthorId, authorId)
                        .SetProperty(v => v.RecordedYear, recordedYear)
                        .SetProperty(v => v.Description, description)
                        .SetProperty(v => v.Price, price));
        }
        
        public async Task Delete(uint id)
        {
            await _dbContext.Vinyls
                .Where(v => v.Id == id)
                .ExecuteDeleteAsync();
        }
    }
    
}

