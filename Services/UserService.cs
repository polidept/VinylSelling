using VinylSeliing.Data.Models;
using VinylSeliing.Interfaces;
using VinylSeliing;

namespace VinylSeliing.Services
{
    public class UserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        

        public UserService(IUserRepository userRepository ,IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }
        public async Task Register(string userName, string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var user = new User()
            {
                UserName = userName,
                Email = email,
                PasswordHash = hashedPassword
            };
            
            await _userRepository.Add(user);
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmail(email);

            var result = _passwordHasher.Verify(password, user.PasswordHash);

            if (result == false)
            {
                throw new Exception("Failed login");
            }
            
            var token = _jwtProvider.GenerateToken(user);
            
            return token;
        }
    }
    
}

