using SmartHomeHub.API.Dtos;
using SmartHomeHub.API.Entites;

namespace SmartHomeHub.API.Services.Interfaces
{
    public interface IHousesService
    {
        Task<House> CreateHouseAsync(CreateHouseDto dto);
        Task<IEnumerable<House>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<House?> GetByIdAsync(int id);

        Task<House?> UpdateAsync(int id, UpdateHouseDto dto);

    }
}
