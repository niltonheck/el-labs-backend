using System.Threading.Tasks;
using CWebService.Application.Models;
using CWebService.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CWebService.Api.Controllers
{
    [ApiController]
    [Route("simulate")]
    public class SimulateController : ControllerBase
    {

        private readonly VehicleService vehicleService;

        public SimulateController(VehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Get([FromBody] SimulateRequestModel model)
        {
            var vehicle = await this.vehicleService.GetSingle(model.VehicleId);

            return this.Ok(new SimulateModel{ 
                Vehicle = vehicle,
                NumberOfHours = model.NumberOfHours,
                Total = vehicle.SimulateCost(model.NumberOfHours)
            });
        }
    }
}
