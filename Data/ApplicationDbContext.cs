using SmartHomeHub.API.Entites;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace SmartHomeHub.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                    : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Device> Devices { get; set; }

    }
}
