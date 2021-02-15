using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CWebService.Application.Interfaces;
using CWebService.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CWebService.Api.Controllers
{
    [ApiController]
    [Route("v1/brands")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService brandService;
        private readonly IModelService modelService;
        private readonly IVehicleService vehicleService;

        public BrandController(
                IBrandService brandService,
                IModelService modelService,
                IVehicleService vehicleService
            )
        {
            this.brandService = brandService;
            this.modelService = modelService;
            this.vehicleService = vehicleService;
        }

        [ProducesResponseType(typeof(IList<BrandModel>), StatusCodes.Status200OK)]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            return Ok((await this.brandService.GetAll()).ToArray());
        }

        [ProducesResponseType(typeof(BrandModel), StatusCodes.Status200OK)]
        [HttpGet]
        [Authorize]
        [Route("{brandID}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            return Ok(await this.brandService.GetSingle(long.Parse(id)));
        }

        [ProducesResponseType(typeof(BrandModel), StatusCodes.Status200OK)]
        [HttpDelete]
        [Authorize]
        [Route("{brandID}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try {
                var action = await this.brandService.Delete(long.Parse(id));
                return Ok(action);
            } catch {
                return NotFound();
            }
            
            
        }

        [ProducesResponseType(typeof(BrandModel), StatusCodes.Status201Created)]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] BrandModel brand)
        {
            try {
                return Ok(await this.brandService.Create(brand));
            } catch {
                return BadRequest();
            }
        }

        [ProducesResponseType(typeof(BrandModel), StatusCodes.Status200OK)]
        [HttpPut]
        [Authorize]
        [Route("{brandID}")]
        public async Task<ActionResult> Update([FromBody] BrandModel brand)
        {
            try {
                return Ok(await this.brandService.Update(brand));
            } catch {
                return BadRequest();
            }
        }
        
        [ProducesResponseType(typeof(IList<ModelModel>), StatusCodes.Status200OK)]
        [HttpGet]
        [Authorize]
        [Route("{brandID}/models")]
        public async Task<IActionResult> GetModelsByBrand([FromRoute] string id)
        {
            return Ok(await this.modelService.GetByBrand(long.Parse(id)));
        }

        [ProducesResponseType(typeof(ModelModel), StatusCodes.Status200OK)]
        [HttpGet]
        [Authorize]
        [Route("{brandID}/models/{modelID}")]
        public async Task<IActionResult> GetModelDetails([FromRoute] string branchID, [FromRoute] string modelID)
        {
            return Ok(await this.modelService.GetSingle(long.Parse(modelID)));
        }

        [ProducesResponseType(typeof(ModelModel), StatusCodes.Status200OK)]
        [HttpGet]
        [Authorize]
        [Route("{brandID}/models/{modelID}/vehicles")]
        public async Task<IActionResult> GetVehiclesByModel([FromRoute] string branchID, [FromRoute] string modelID)
        {
            return Ok(await this.vehicleService.GetByModel(long.Parse(modelID)));
        }

        [ProducesResponseType(typeof(ModelModel), StatusCodes.Status200OK)]
        [HttpGet]
        [Authorize]
        [Route("{brandID}/models/{modelID}/vehicles/{vehicleID}")]
        public async Task<IActionResult> GetVehicleDetails([FromRoute] string branchID, [FromRoute] string modelID, [FromRoute] string vehicleID)
        {
            return Ok(await this.vehicleService.GetSingle(long.Parse(modelID)));
        }
    }
}
