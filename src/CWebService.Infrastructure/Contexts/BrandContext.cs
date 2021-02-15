using CWebService.Domain.Entities;
using CWebService.Infrastructure.Contexts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CWebService.Infrastructure.Contexts {
    public class BrandContext : DbContext, IBrandContext
    {
        public BrandContext(DbContextOptions<BrandContext> options)
        : base(options)
        {
        }
        public DbSet<Brand> Brands { get; set; }

        void IBrandContext.Remove(Brand brand)
        {
            this.Remove(brand);
        }

        void IBrandContext.SaveChanges()
        {
            this.SaveChanges();
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        //     => options.UseSqlite("Data Source=C:\\Users\\Nilton Heck\\source\\repos\\c-web-service\\cwebservice.db");
    }
}