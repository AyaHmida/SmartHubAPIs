using Microsoft.EntityFrameworkCore;
using SmartHomeHub.API.Data;
using SmartHomeHub.API.Dtos;
using SmartHomeHub.API.Entites;
using SmartHomeHub.API.Enums;
using SmartHomeHub.API.Repositories.Implementations;
using SmartHomeHub.API.Repositories.Interfaces;
using SmartHomeHub.API.Services.Interfaces;
using System;

namespace SmartHomeHub.API.Services.Implementations
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _DeviceRepository;
        private readonly ApplicationDbContext _context;


        public DeviceService(IDeviceRepository repo, ApplicationDbContext context)
        {
            _DeviceRepository = repo;
            _context = context;

        }

        private bool IsValidStatus(DeviceType type, string status)
        {
            return type switch
            {
                DeviceType.Light => status == "On" || status == "Off",
                DeviceType.TemperatureSensor => status.EndsWith("°C"),
                DeviceType.DoorLock => status == "Locked" || status == "Unlocked",
                DeviceType.Fan => status == "On" || status == "Off",
                DeviceType.Thermostat => status.EndsWith("°C") && int.TryParse(status.Replace("°C", ""), out _),
                _ => false
            };
        }

        public async Task CreateDevice(DeviceCreateDto dto)
        {
            var houseExists = await _context.Houses.AnyAsync(h => h.Id == dto.HouseId);
            if (!houseExists)
                throw new ArgumentException("Maison introuvable : HouseId invalide.");
            if (!IsValidStatus(dto.Type, dto.Status))
                throw new ArgumentException("Invalid status for device type");
            var device = new Device
            {
                Name = dto.Name,
                Type = dto.Type,
                Status = dto.Status,
                HouseId = dto.HouseId

            };

            await _DeviceRepository.CreateAsync(device);
        }
        public async Task<List<Device>> GetAllDevices() {  
            return await _DeviceRepository.GetAllAsync();
        }
        public async Task<Device?> GetDeviceById(int id) {
            return await _DeviceRepository.GetByIdAsync(id);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _DeviceRepository.DeleteAsync(id);
        }
    }
}
