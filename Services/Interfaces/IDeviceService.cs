using SmartHomeHub.API.Dtos;
using SmartHomeHub.API.Entites;

namespace SmartHomeHub.API.Services.Interfaces
{
    public interface IDeviceService
    {
        Task CreateDevice(DeviceCreateDto dto);
        Task<List<Device>> GetAllDevices();
        Task<Device?> GetDeviceById(int id);
        Task<bool> DeleteAsync(int id);
    }
}
