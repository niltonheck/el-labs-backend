using CWebService.Api.Models;
using Microsoft.AspNetCore.Mvc;
using CWebService.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace CWebService.Api.Controllers {

    [ApiController]
    [Route("v1/account")]
    public class AuthenticationController: ControllerBase {
        
        private readonly IUserService userService;
        private readonly IAuthService authService;

        public AuthenticationController(
                IUserService userService,
                IAuthService authService
            )
        {
            this.userService = userService;
            this.authService = authService;
        }
        
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] AuthenticateRequest model)
        {
            try {
                var user = await this.userService.Authenticate(model.Username, model.Password);
                    user.Password = "";

                var token = this.authService.GenerateToken(user);

                return this.Ok(new
                {
                    user = user,
                    token = token
                });
            } catch {
                return this.NotFound();
            }
        }
    } 
}