using CarparkApi.Models;
using CarParkG2D2.Models;
using Microsoft.EntityFrameworkCore;

namespace CarparkApi.Data
{
    public class CarparkContext:DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Make> Manufacturor { get; set; }
        public DbSet<Model> Models { get; set; }

        public CarparkContext(DbContextOptions options):base(options)
        {

        }
    }
}
