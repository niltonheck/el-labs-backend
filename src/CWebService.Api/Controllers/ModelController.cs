using System.Collections.Generic;
using System.Threading.Tasks;
using CWebService.Application.Interfaces;
using CWebService.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CWebService.Api.Controllers
{
    [ApiController]
    [Route("v1/models")]
    public class ModelController : ControllerBase
    {

        private readonly IModelService modelService;
        private readonly IVehicleService vehicleService;

        public ModelController(IModelService modelService, IVehicleService vehicleService)
        {
            this.modelService = modelService;
            this.vehicleService = vehicleService;
        }

        [ProducesResponseType(typeof(IList<ModelModel>), StatusCodes.Status200OK)]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return this.Ok(await this.modelService.GetAll());
        }

        [ProducesResponseType(typeof(ModelModel), StatusCodes.Status200OK)]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] ModelModel model)
        {
            return this.Ok(await this.modelService.Create(model));
        }

        [ProducesResponseType(typeof(ModelModel), StatusCodes.Status200OK)]
        [HttpGet]
        [Authorize]
        [Route("{modelID}")]
        public async Task<IActionResult> Update([FromBody] ModelModel model)
        {
            return this.Ok(await this.modelService.Update(model));
        }

        [ProducesResponseType(typeof(ModelModel), StatusCodes.Status200OK)]
        [HttpPut]
        [Authorize]
        [Route("{modelID}")]
        public async Task<IActionResult> GetSingle(long modelId)
        {
            return this.Ok(await this.modelService.GetSingle(modelId));
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [HttpDelete]
        [Authorize]
        [Route("{modelID}")]
        public async Task<IActionResult> Delete(long modelId)
        {
            return this.Ok(await this.modelService.Delete(modelId));
        }

        [ProducesResponseType(typeof(IList<VehicleModel>), StatusCodes.Status200OK)]
        [HttpGet]
        [Authorize]
        [Route("{modelID}/vehicles")]
        public async Task<IActionResult> GetVehiclesByModel(long modelId)
        {
            return this.Ok(await this.vehicleService.GetByModel(modelId));
        }

        [ProducesResponseType(typeof(IList<VehicleModel>), StatusCodes.Status200OK)]
        [HttpGet]
        [Authorize]
        [Route("{modelID}/vehicles/{vehicleID}")]
        public async Task<IActionResult> GetVehiclesByModel(long modelId, long vehicleId)
        {
            return this.Ok(await this.vehicleService.GetSingle(vehicleId));
        }
    }
}
