using VinylSeliing.Data.Models;

namespace VinylSeliing.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
    
}

