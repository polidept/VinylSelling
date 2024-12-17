using Microsoft.EntityFrameworkCore;
using VinylSeliing.Data;
using VinylSeliing.Data.Models;
using VinylSeliing.DTO;
using VinylSeliing.Interfaces;
using AutoMapper;

namespace VinylSeliing.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly VinylSellingDbContext _context;
        
        public UserRepository(VinylSellingDbContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            var newUser = new User()
            {
                Id = user.Id,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                Email = user.Email
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception();
        }
        
    }

}

