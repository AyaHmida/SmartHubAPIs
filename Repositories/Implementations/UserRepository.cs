using Microsoft.EntityFrameworkCore;
using SmartHomeHub.API.Data;
using SmartHomeHub.API.Entites;
using SmartHomeHub.API.Repositories.Interfaces;

namespace SmartHomeHub.API.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetByResetTokenAsync(string token)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.ResetToken == token && u.ResetTokenExpiry > DateTime.UtcNow);
        }
        public async Task SaveResetTokenAsync(int userId, string token, DateTime expiry)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return;

            user.ResetToken = token;
            user.ResetTokenExpiry = expiry;

            await _context.SaveChangesAsync();
        }
        public async Task UpdatePasswordAsync(int userId, string passwordHash)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return;

            user.PasswordHash = passwordHash;
            user.ResetToken = null;
            user.ResetTokenExpiry = null;

            await _context.SaveChangesAsync();
        }

    }
}
