using Application.DTO;
using Application.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDotNet.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginService loginService;
        private IRegisterService _registerService;

        public AuthController(ILoginService loginService, IRegisterService registerService)
        {
            this.loginService = loginService;
            _registerService = registerService;
        }

        [HttpPost("/login")]
        public IActionResult Signin([FromBody] UserDTO userDTO)
        {
            if (userDTO == null) return BadRequest("Invalid client request");
            var token = loginService.ValidateCredentials(userDTO);
            if (token == null) return Unauthorized();
            return Ok(token);
        }
        [HttpPost("/register")]
        public IActionResult Create([FromBody] RegisterDTO registerDTO)
        {
            _registerService.Create(registerDTO);
            return Ok();
        }
        [HttpPost("/refresh")]
        public IActionResult Refresh([FromBody] AccessDTO tokenDTO)
        {
            if (tokenDTO == null) return BadRequest("Invalid client request");
            var token = loginService.ValidateCredentials(tokenDTO);
            if (token == null) return BadRequest("Invalid client request");
            return Ok(token);

        }
        [HttpGet("/revoke")]
        [Authorize("Bearer")]
        public IActionResult Revoke()
        {
            var username = User.Identity.Name;
            var result = loginService.RevokeToken(username);
            if (!result == null) return BadRequest("Invalid client request");
            return NoContent();

        }
    }
}
