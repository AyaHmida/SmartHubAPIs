using SmartHomeHub.API.Dtos;
using SmartHomeHub.API.Entites;
using SmartHomeHub.API.Repositories.Interfaces;
using SmartHomeHub.API.Services.Interfaces;

namespace SmartHomeHub.API.Services.Implementations
{
    public class HousesService : IHousesService
    {
        private readonly IHousesRepository _housesRepository;

        public HousesService(IHousesRepository housesRepository)
        {
            _housesRepository = housesRepository;
        }
        public async Task<House> CreateHouseAsync(CreateHouseDto dto)
        {
            var house = new House
            {
                Name = dto.Name,
                Address = dto.Address,
                UserId = dto.UserId
            };

            return await _housesRepository.CreateHouseAsync(house);
        }

        public async Task<IEnumerable<House>> GetAllAsync()
        {
            return await _housesRepository.GetAllAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _housesRepository.DeleteAsync(id);
        }
        public async Task<House?> GetByIdAsync(int id)
        {
            return await _housesRepository.GetByIdAsync(id);
        }

        public async Task<House?> UpdateAsync(int id, UpdateHouseDto dto)
        {
            return await _housesRepository.UpdateAsync(id, dto);
        }


    }
}
