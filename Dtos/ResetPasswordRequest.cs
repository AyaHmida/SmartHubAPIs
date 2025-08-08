using System.ComponentModel.DataAnnotations;

namespace SmartHomeHub.API.Dtos
{
    public class ResetPasswordRequest
    {
        [Required]
        public string Token { get; set; }
        [Required]
        [StringLength(8, ErrorMessage = "Max 8 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{1,8}$",
            ErrorMessage = "Password must have 1 uppercase, 1 lowercase, 1 digit, and 1 special character.")]
        public string NewPassword { get; set; }
    }
}
