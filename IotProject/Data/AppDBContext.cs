using IotProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IotProject.Data
{
    public class AppDBContext: IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> opt) : base (opt)
        {

        }

        public DbSet<Device> Device { get; set; }

        public DbSet<Sensor> Sensor { get; set; }

        public DbSet<Record> Record { get; set; }
    }
}
