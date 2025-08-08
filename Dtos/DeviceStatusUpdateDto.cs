using System.ComponentModel.DataAnnotations;

namespace SmartHomeHub.API.Dtos
{
    public class DeviceStatusUpdateDto
    {
        [Required]
        public string Status { get; set; } 

    }
}
