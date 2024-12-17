using VinylSeliing.DTO;

namespace VinylSeliing.Interfaces;

public interface IVinylService
{
    Task<List<VinylDto>> GetAllVinyls();
    Task<VinylDto> GetByIdVinyl(uint id);
    Task CreateVinyl(string title, uint authorId, uint recordedYear, string description, decimal price);
    Task UpdateVinyl(uint id, string title, uint authorId, uint recordedYear, string description, decimal price);
    Task DeleteVinyl(uint id);
}