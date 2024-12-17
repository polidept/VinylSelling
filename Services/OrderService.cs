using VinylSeliing.DTO;
using VinylSeliing.Interfaces;

namespace VinylSeliing.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderDTO>> GetAllOrders()
        {
            return await _orderRepository.GetAll();
        }

        
        public async Task<OrderDTO> GetByIdOrder(uint id)
        {
            return await _orderRepository.GetById(id);
        }
        
        public async Task CreateOrder(uint vinylId, uint userId)
        {
            await _orderRepository.Create(vinylId, userId);
        }
        
        public async Task DeleteOrder(uint id)
        {
            await _orderRepository.Delete(id);
        }
    }
    
}

