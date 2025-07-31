using Microsoft.EntityFrameworkCore;
using SmartHomeHub.API.Data;
using SmartHomeHub.API.Dtos;
using SmartHomeHub.API.Entites;
using SmartHomeHub.API.Repositories.Interfaces;
using System;

namespace SmartHomeHub.API.Repositories.Implementations
{
    public class HousesRepository : IHousesRepository
    {
        private readonly ApplicationDbContext _context;
        public HousesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<House> CreateHouseAsync(House house)
        {
            _context.Houses.Add(house);
            await _context.SaveChangesAsync();
            return house;
        }
        public async Task<IEnumerable<House>> GetAllAsync()
        {
            return await _context.Houses.ToListAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var house = await _context.Houses.FindAsync(id);
            if (house == null) return false;

            _context.Houses.Remove(house);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<House?> GetByIdAsync(int id)
        {
            return await _context.Houses.FindAsync(id);
        }

        public async Task<House?> UpdateAsync(int id, UpdateHouseDto dto)
        {
            var house = await _context.Houses.FindAsync(id);
            if (house == null) return null;

            house.Name = dto.Name;
            house.Address = dto.Address;

            await _context.SaveChangesAsync();
            return house;
        }



    }
}
