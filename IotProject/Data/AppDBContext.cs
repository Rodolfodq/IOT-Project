using IotProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
