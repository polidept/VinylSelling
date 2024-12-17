using VinylSeliing.Interfaces;

namespace VinylSeliing.EndPoints
{
    public static class VinylEndpoints
    {
        public static IEndpointRouteBuilder MapVinylEndpoints(this IEndpointRouteBuilder app)
        {
            var openAccess = app.MapGroup("vinyl");
                
            openAccess.MapGet(string.Empty, GetAllVinyls);
            openAccess.MapGet("/vinyls/{id}", GetVinylById);

            var securedAccess = app.MapGroup("vinyl")
                .RequireAuthorization("AdminOnly");
            
            securedAccess.MapPost(string.Empty, CreateVinyl);
            securedAccess.MapPut("/vinyls/{id}", UpdateVinyl);
            securedAccess.MapDelete("/vinyls/{id}", DeleteVinyl);

            return app;
        }

        private static async Task<IResult> GetAllVinyls(IVinylService vinylService)
        {
            var vinyls = await vinylService.GetAllVinyls();
            return Results.Ok(vinyls);
        }

        private static async Task<IResult> GetVinylById(uint id, IVinylService vinylService)
        {
            var vinyl = await vinylService.GetByIdVinyl(id);
            return vinyl is not null ? Results.Ok(vinyl) : Results.NotFound($"Vinyl with ID {id} not found.");
        }

        private static async Task<IResult> CreateVinyl(string title, uint authorId, uint recordedYear, string description, decimal price, IVinylService vinylService)
        {
            await vinylService.CreateVinyl(title, authorId, recordedYear, description, price);
            return Results.Ok();
        }

        private static async Task<IResult> UpdateVinyl(uint id, string title, uint authorId, uint recordedYear, string description, decimal price, IVinylService vinylService)
        {
            await vinylService.UpdateVinyl(id, title, authorId, recordedYear, description, price);
            return Results.Ok();
        }

        private static async Task<IResult> DeleteVinyl(uint id, IVinylService vinylService)
        {
            await vinylService.DeleteVinyl(id);
            return Results.Ok();
        }
    }
}