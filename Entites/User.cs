using DevAPI.Entities;
using SmartHomeHub.API.Enums;

namespace SmartHomeHub.API.Entites
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }


        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpiry { get; set; }

    }
}
