using Microsoft.AspNetCore.Http.HttpResults;
using VinylSeliing.Repositories;
using VinylSeliing.Interfaces;
using VinylSeliing.Data.Models;
using VinylSeliing.DTO;

namespace VinylSeliing.Services
{
    public class VinylService : IVinylService
    {
        private readonly IVinylRepository _vinylRepository;

        public VinylService(IVinylRepository vinylRepository)
        {
            _vinylRepository = vinylRepository;
        }

        public async Task<List<VinylDto>> GetAllVinyls()
        {
            return await _vinylRepository.GetAll();
        }

        public async Task<VinylDto> GetByIdVinyl(uint id)
        {
            return await _vinylRepository.GetById(id);
        }

        public async Task CreateVinyl(string title, uint authorId, uint recordedYear, string description, decimal price)
        {
            await _vinylRepository.Create(title, authorId, recordedYear, description, price);
        }

        public async Task UpdateVinyl(uint id, string title, uint authorId, uint recordedYear, string description,
            decimal price)
        {
            await _vinylRepository.Update(id, title, authorId, recordedYear, description, price);
        }

        public async Task DeleteVinyl(uint id)
        {
            await _vinylRepository.Delete(id);
        }
    }
    
}

