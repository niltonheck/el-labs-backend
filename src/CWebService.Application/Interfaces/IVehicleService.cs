using System.Collections.Generic;
using System.Threading.Tasks;
using CWebService.Application.Models;

namespace CWebService.Application.Interfaces {
    public interface IVehicleService {
        Task<IList<VehicleModel>>      GetAll();
        Task<VehicleModel>      GetSingle(long vehicleId);
        Task<bool>      Create(VehicleModel vehicle);
        Task<bool>      Update(VehicleModel vehicle);
        Task<bool>      Delete(long id);
        Task<IList<VehicleModel>>      GetByModel(long modelId);
    }
}