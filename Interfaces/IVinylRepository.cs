using VinylSeliing.DTO;

namespace VinylSeliing.Interfaces
{
    public interface IVinylRepository
    {
        Task<List<VinylDto>> GetAll();
        Task<VinylDto> GetById(uint id);
        Task Create(string title, uint authorId, uint recordedYear, string description, decimal price);
        Task Update(uint id, string title, uint authorId, uint recordedYear, string description, decimal price);
        Task Delete(uint id);
    }
}