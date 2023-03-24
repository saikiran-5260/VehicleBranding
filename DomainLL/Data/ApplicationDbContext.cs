using DomainLL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {

        }
        public DbSet<VehicleModel> Vehicle { get; set; }
        public DbSet<VehicleColorMapping> VehicleColorMapping { get; set; }
        public DbSet<VehicleDetails> vehicleDetails { get; set; }

    }
}
