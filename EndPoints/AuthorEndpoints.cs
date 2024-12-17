using VinylSeliing.Interfaces;

namespace VinylSeliing.EndPoints
{
    public static class AuthorEndpoints
    {
        public static IEndpointRouteBuilder MapAuthorEndpoints(this IEndpointRouteBuilder app)
        {
            var openAccess = app.MapGroup("author");

            openAccess.MapGet(string.Empty, GetAllAuthors);
            openAccess.MapGet("/authors/{id}", GetByIdAuthor);

            var securedAccess = app.MapGroup("author")
                .RequireAuthorization("AdminOnly");
            
            securedAccess.MapPost(string.Empty, CreateAuthor);
            securedAccess.MapPut("/authors/{id}", UpdateAuthor);
            securedAccess.MapDelete("/authors/{id}", DeleteAuthor);

            return app;
        }

        private static async Task<IResult> GetAllAuthors(IAuthorService authorService)
        {
            var authors = await authorService.GetAllAuthors();
            return Results.Ok(authors);
        }

        private static async Task<IResult> GetByIdAuthor(uint id, IAuthorService authorService)
        {
            var author = await authorService.GetByIdAuthor(id);
            return author is not null ? Results.Ok(author) : Results.NotFound($"Author with ID {id} not found.");
        }
        

        private static async Task<IResult> CreateAuthor(string name, IAuthorService authorService)
        {
            await authorService.CreateAuthor(name);
            return Results.Ok();
        }

        private static async Task<IResult> UpdateAuthor(uint id, string name, IAuthorService authorService)
        {
            await authorService.UpdateAuthor(id, name);
            return Results.Ok();
        }

        private static async Task<IResult> DeleteAuthor(uint id, IAuthorService authorService)
        {
            await authorService.DeleteAuthor(id);
            return Results.Ok();
        }
    }
}