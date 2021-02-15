using System.Threading.Tasks;
using CWebService.Application.Interfaces;
using CWebService.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CWebService.Api.Controllers
{
    [ApiController]
    [Route("v1/vehicles")]
    public class VehiclesController : ControllerBase
    {

        private readonly IVehicleService vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return this.Ok(await this.vehicleService.GetAll());
        }

        [HttpGet]
        [Authorize]
        [Route("{vehicleID}")]
        public async Task<IActionResult> GetSingle(long vehicleId)
        {
            return this.Ok(await this.vehicleService.GetSingle(vehicleId));
        }

        [HttpDelete]
        [Authorize]
        [Route("{vehicleID}")]
        public async Task<IActionResult> Delete(long vehicleId)
        {
            return this.Ok(await this.vehicleService.Delete(vehicleId));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] VehicleModel model)
        {
            try {
                return Ok(await this.vehicleService.Create(model));
            } catch {
                return BadRequest();
            }
        }

        [HttpPut]
        [Authorize]
        [Route("{vehicleID}")]
        public async Task<IActionResult> Update([FromBody] VehicleModel model)
        {
            try {
                return Ok(await this.vehicleService.Update(model));
            } catch {
                return BadRequest();
            }
        }
    }
}
