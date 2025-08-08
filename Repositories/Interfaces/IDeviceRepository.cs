using SmartHomeHub.API.Entites;

namespace SmartHomeHub.API.Repositories.Interfaces
{
    public interface IDeviceRepository
    {
        Task CreateAsync(Device device);
        Task<List<Device>> GetAllAsync();
        Task<Device?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);

    }
}
