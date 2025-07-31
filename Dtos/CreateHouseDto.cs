using System.ComponentModel.DataAnnotations;

namespace SmartHomeHub.API.Dtos
{
    public class CreateHouseDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
