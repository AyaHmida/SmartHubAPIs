using Microsoft.EntityFrameworkCore;
using SmartHomeHub.API.Data;
using SmartHomeHub.API.Entites;
using SmartHomeHub.API.Repositories.Interfaces;
using System;

namespace SmartHomeHub.API.Repositories.Implementations
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly ApplicationDbContext _context;

        public DeviceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Device device)
        {
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Device>> GetAllAsync() => await _context.Devices.ToListAsync();

        public async Task<Device?> GetByIdAsync(int id) => await _context.Devices.FindAsync(id);

        public async Task<bool> DeleteAsync(int id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device == null)
                return false;

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
