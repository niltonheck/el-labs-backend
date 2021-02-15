using CWebService.Domain.Entities;
using CWebService.Infrastructure.Contexts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CWebService.Infrastructure.Contexts {
    public class VehicleContext : DbContext, IVehicleContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options)
        : base(options)
        {
        }
        public DbSet<Vehicle> Vehicles { get; set; }
        void IVehicleContext.Remove(Vehicle vehicle)
        {
            this.Remove(vehicle);
        }
        void IVehicleContext.SaveChanges()
        {
            this.SaveChanges();
        }
    }
}