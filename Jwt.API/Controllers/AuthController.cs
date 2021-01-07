using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jwt.Business.Abstract;
using Jwt.Core.Plugins.Authentication;
using Jwt.Models.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var result = await _service.LoginAsync(loginModel);
            if (result.Success) return Ok(result);
            return Unauthorized(result.Message);
        }

        [HttpPost("LoginByRefreshToken")]
        public async Task<IActionResult> LoginByRefreshToken([FromBody] RefreshTokenModel model)
        {
            var result = await _service.LoginByRefreshTokenAsync(model);
            return Ok(result);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok(await _service.LogoutAsync());
        }
    }
}