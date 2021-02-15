using CWebService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CWebService.Infrastructure.Contexts.Interfaces {
    public interface IBrandContext {
        DbSet<Brand> Brands { get; set; }
        void SaveChanges();
        void Remove(Brand brand);
    }
}
