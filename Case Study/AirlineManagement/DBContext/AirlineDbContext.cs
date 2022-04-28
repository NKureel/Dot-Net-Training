using AirlineManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineManagement.DBContext
{
    public class AirlineDbContext:DbContext
    {

        public AirlineDbContext(DbContextOptions<AirlineDbContext> options):base(options)
        {

        }

        
        public DbSet<AirlineTbl> airlineTbls { get; set; }
        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
        }

    }
}
