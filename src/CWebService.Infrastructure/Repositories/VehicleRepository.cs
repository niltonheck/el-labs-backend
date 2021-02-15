using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CWebService.Domain.Entities;
using CWebService.Domain.Repositories;
using CWebService.Infrastructure.Contexts.Interfaces;

namespace CWebService.Infrastructure.Repositories {
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IVehicleContext dbContext;

        public VehicleRepository(IVehicleContext dbContext) {
            this.dbContext = dbContext;
        }

        public async Task<IList<Vehicle>> Get()
        {
            return await Task.Run(() => {
                return this.dbContext.Vehicles.ToList();
            });
        }

        public async Task<IList<Vehicle>> GetByModel(long modelID)
        {
            return await Task.Run(() => {
                return this.dbContext.Vehicles.Where(vehicle => vehicle.Model.Id == modelID).ToList();
            });
        }

        public async Task<bool> Delete(long vehicleID)
        {
            return await Task.Run(() => {
                var query = this.dbContext.Vehicles.Where(vehicle => vehicle.Id == vehicleID).First();
                this.dbContext.Remove(query);
                this.dbContext.SaveChanges();
                return true;
            });
        }

        public async Task<Vehicle> GetSingle(long vehicleId)
        {
            return await Task.Run(() => {
                return this.dbContext.Vehicles.Where<Vehicle>(vehicle => vehicle.Id == vehicleId).First();
            });
        }

        public async Task<bool> InsertIntoDatabase(Vehicle vehicle)
        {
            return await Task.Run(() => {
               return true;
            });
        }

        public async Task<bool> UpdateIntoDatabase(Vehicle vehicle)
        {
            return await Task.Run(() => {
               return true;
            });
        }
    }
}