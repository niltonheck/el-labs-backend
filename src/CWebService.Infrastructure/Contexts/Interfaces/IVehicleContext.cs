using CWebService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CWebService.Infrastructure.Contexts.Interfaces {
    public interface IVehicleContext {
        DbSet<Vehicle> Vehicles { get; set; }
        void SaveChanges();
        void Remove(Vehicle vehicle);
    }
}
