using VinylSeliing.DTO;

namespace VinylSeliing.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<OrderDTO>> GetAll();
        Task<OrderDTO> GetById(uint id);
        Task Create(uint vinylId, uint userId);
        Task Delete(uint id);
    }
    
}

