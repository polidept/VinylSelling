using VinylSeliing.DTO.Users;
using VinylSeliing.Services;

namespace VinylSeliing.EndPoints
{
    public static class UserEndpoints
    {
        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("register", Register);
            app.MapPost("login", Login);

            return app;
        }

        private static async Task<IResult> Register(RegisterDTO request, UserService userService)
        {
            await userService.Register(request.UserName, request.Email, request.Password);
            
            return Results.Ok();
        }
        
        private static async Task<IResult> Login(LoginDTO request, UserService userService, HttpContext context)
        {
            var token = await userService.Login(request.Email, request.Password);
            
            context.Response.Cookies.Append("hz-cookies", token);
            
            return Results.Ok(token);
        }
    }
    
}

