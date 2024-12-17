using Microsoft.AspNetCore.Mvc;
using VinylSeliing.Interfaces;
using VinylSeliing.Services;
using VinylSeliing.Data.Models;
using VinylSeliing.DTO;

namespace VinylSeliing.EndPoints
{
    public static class OrderEndpoints
    {
        public static IEndpointRouteBuilder MapOrderEndpoints(this IEndpointRouteBuilder app)
        {
            var adminAccess = app.MapGroup("order")
                .RequireAuthorization("AdminOnly");

            adminAccess.MapGet(string.Empty, GetAllOrders);
            adminAccess.MapGet("/orders/{id}", GetByIdOrder);
            adminAccess.MapDelete("/orders/{id}", DeleteOrder);

            var userAccess = app.MapGroup("order")
                .RequireAuthorization("UserOnly");

            userAccess.MapPost(string.Empty, CreateOrder);

            return app;
        }


        private static async Task<IResult> GetAllOrders(IOrderService orderService)
        {
            var orders = await orderService.GetAllOrders();
            return Results.Ok(orders);
        }

        private static async Task<IResult> GetByIdOrder(uint id, IOrderService orderService)
        {
            var order = await orderService.GetByIdOrder(id);
            return order is not null ? Results.Ok(order) : Results.NotFound($"Order with ID {id} not found.");
        }

        
        private static async Task<IResult> DeleteOrder(uint id, IOrderService orderService)
        {
            await orderService.DeleteOrder(id);
            return Results.Ok();
        }
        private static async Task<IResult> CreateOrder(uint vinylId, uint userId, IOrderService orderService)
        {
            await orderService.CreateOrder(vinylId, userId);
            return Results.Ok();
        }

    }
}

