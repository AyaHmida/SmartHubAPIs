using SmartHomeHub.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartHomeHub.API.Dtos
{
    public class DeviceCreateDto
    {
        [Required]

        public string Name { get; set; }
        [Required]

        public DeviceType Type { get; set; }
        [Required]

        public string Status { get; set; }

        [Required]
        public int HouseId { get; set; }
    }
}
