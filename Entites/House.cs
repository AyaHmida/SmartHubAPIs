using DevAPI.Entities;

namespace SmartHomeHub.API.Entites
{
    public class House : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }            
        public User User { get; set; } = null!;
    }
}
