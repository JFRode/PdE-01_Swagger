using Microsoft.EntityFrameworkCore;
using PdE_01_BrazilianCitiesAPI.Models;

namespace PdE_01_BrazilianCitiesAPI.Infrastructure.Contexts
{
    public class BrazilianCitiesApiDbContext : DbContext
    {
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }

        public BrazilianCitiesApiDbContext(DbContextOptions<BrazilianCitiesApiDbContext> options) : base(options)
        {
        }
    }
}