using Application.DTO;
using Application.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDotNet.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginService loginService;

        public AuthController(ILoginService loginService)
        {
            this.loginService = loginService;
        }
        [HttpPost("/")]
        public IActionResult Signin([FromBody] UserDTO userDTO)
        {
            if (userDTO == null) return BadRequest("Invalid client request");
            var token = loginService.ValidateCredentials(userDTO);
            if (token == null) return Unauthorized();
            return Ok(token);
        }
    }
}
