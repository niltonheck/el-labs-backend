using System.Collections.Generic;
using System.Threading.Tasks;
using CWebService.Domain.Entities;

namespace CWebService.Domain.Repositories
{
    public interface IVehicleRepository
    {
        Task<IList<Vehicle>>        Get();
        Task<Vehicle>     GetSingle(long vehicleId);
        Task<bool>     Delete(long vehicleId);
        Task<bool>        InsertIntoDatabase(Vehicle vehicle);
        Task<bool>        UpdateIntoDatabase(Vehicle vehicle);
        Task<IList<Vehicle>>        GetByModel(long modelID);
    }
}