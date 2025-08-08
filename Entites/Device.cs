using DevAPI.Entities;
using SmartHomeHub.API.Enums;

namespace SmartHomeHub.API.Entites
{
    public class Device : BaseEntity
    {
        public string Name { get; set; }
        public DeviceType Type { get; set; }
        public string Status { get; set; } 
        public int HouseId { get; set; }

        public House? House { get; set; }
    }
}
