using SmartHomeHub.API.Dtos;
using SmartHomeHub.API.Entites;

namespace SmartHomeHub.API.Repositories.Interfaces
{
    public interface IHousesRepository
    {
        Task<House> CreateHouseAsync(House house);
        Task<IEnumerable<House>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<House?> GetByIdAsync(int id);

        Task<House?> UpdateAsync(int id, UpdateHouseDto dto);


    }
}
