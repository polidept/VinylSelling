using VinylSeliing.Interfaces;

namespace VinylSeliing
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string password) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool Verify(string password, string passwordHasher) =>
            BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHasher);
    }
}

