using VinylSeliing.DTO;

namespace VinylSeliing.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDTO>> GetAllOrders();
        Task<OrderDTO> GetByIdOrder(uint id);
        Task CreateOrder(uint vynilId, uint userId);
        Task DeleteOrder(uint id);
    }
    
}