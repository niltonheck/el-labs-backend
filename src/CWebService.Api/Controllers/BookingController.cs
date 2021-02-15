using System.IO;
using System.Threading.Tasks;
using CWebService.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CWebService.Api.Controllers
{
    [ApiController]
    [Route("v1/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly BookingService bookingService;

        public BookingController(BookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [ProducesResponseType(typeof(BookingModel), StatusCodes.Status201Created)]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] BookingRequestModel booking)
        {
            try {
                return Ok(await this.bookingService.Create(booking, int.Parse(User.Identity.Name)));
            } catch {
                return BadRequest();
            }
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(BookingModel), StatusCodes.Status200OK)]
        [Route("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try {
                return Ok(await this.bookingService.GetSingle(id));
            } catch {
                return BadRequest();
            }
        }

        [HttpPut]
        [Authorize]
        [ProducesResponseType(typeof(BookingModel), StatusCodes.Status200OK)]
        [Route("{id}/return")]
        public async Task<IActionResult> ActionReturn([FromBody] BookingReturnRequestModel returnRequest)
        {
            try {
                return Ok(await this.bookingService.ActionReturn(returnRequest));
            } catch {
                return BadRequest();
            }
        }

        [HttpGet]
        [Authorize]
        [Produces("application/pdf")]
        [Route("{id}/contract")]
        public async Task<IActionResult> GetContract(long id)
        {
            try {
                Response.Headers.Add("Content-disposition", "attachment; filename=\"contract-" + id + ".pdf\"");
                return Ok(await this.bookingService.GetContract(id));
            } catch {
                return BadRequest();
            }
        }
    }
}
