using SmartHomeHub.API.Entites;

namespace SmartHomeHub.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<bool> EmailExistsAsync(string email);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByResetTokenAsync(string token);
        Task SaveResetTokenAsync(int userId, string token, DateTime expiry);
        Task UpdatePasswordAsync(int userId, string passwordHash);



    }
}
