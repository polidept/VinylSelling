using Microsoft.AspNetCore.Identity;

namespace VinylSeliing.Data.Models
{
    public class User : IdentityUser<uint>
    {
        public string Role { get; set; } = "user";
    }
    
}

