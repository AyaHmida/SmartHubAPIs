using SmartHomeHub.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace DevAPI.DTOs
{
    public class UserRegisterDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "Max 8 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{1,8}$",
            ErrorMessage = "Password must have 1 uppercase, 1 lowercase, 1 digit, and 1 special character.")]
        public string Password { get; set; }
        [Required]
        public UserRole Role { get; set; }
    }
}
