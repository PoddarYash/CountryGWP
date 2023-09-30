using CountryGWP.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CountryGWP.API.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<GWPByCountry>().HasKey(_ => new { _.Country, _.LineOfBusiness });
        }

        public DbSet<GWPByCountry> GWPsByCountry { get; set; }
    }
}
