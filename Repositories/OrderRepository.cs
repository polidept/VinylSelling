using Microsoft.EntityFrameworkCore;
using VinylSeliing.Data;
using VinylSeliing.Data.Models;
using VinylSeliing.DTO;
using VinylSeliing.Interfaces;

namespace VinylSeliing.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly VinylSellingDbContext _dbContext;

        public OrderRepository(VinylSellingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OrderDTO>> GetAll()
        {
            return await _dbContext.Orders
                .AsNoTracking()
                .Include(o => o.User)
                .Include(o => o.Vinyl)
                .Select(o => new OrderDTO()
                {
                    OrderId = o.Id,
                    UserName = o.User.UserName,
                    VinylTitle = o.Vinyl.Title,
                    VinylAuthor = o.Vinyl.Author.Name,
                    VinylPrice = o.Vinyl.Price,
                    OrderDate = o.OrderDate
                })
                .OrderBy(o => o.OrderId)
                .ToListAsync();
        }

        public async Task<OrderDTO> GetById(uint id)
        {
            return await _dbContext.Orders
                .AsNoTracking()
                .Include(o => o.User)
                .Include(o => o.Vinyl)
                .Where(o => o.Id == id)
                .Select(o => new OrderDTO()
                {
                    UserName = o.User.UserName,
                    VinylTitle = o.Vinyl.Title,
                    VinylAuthor = o.Vinyl.Author.Name,
                    VinylPrice = o.Vinyl.Price,
                    OrderDate = o.OrderDate
                })
                .FirstOrDefaultAsync();
        }

        public async Task Create(uint vinylId, uint userId)
        {
            var order = new Order()
            {
                VinylId = vinylId,
                UserId = userId,
                OrderDate = DateTime.UtcNow
            };

            await _dbContext.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(uint id)
        {
            var order = await _dbContext.Orders.FindAsync(id);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
