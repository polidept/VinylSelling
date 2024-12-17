using VinylSeliing.Data.Models;

namespace VinylSeliing.Interfaces
{
    public interface IUserRepository
    {
        Task Add(User user);
        Task<User> GetByEmail(string email);
    }
    
}

