using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebPontoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> Signin([FromBody] AuthUserModel user)
        {
            if (user == null) return BadRequest("Invalid client request");
            TokenModel token = await _authService.ValidarCredenciais(user);
            if (token == null) return Unauthorized();
            return Ok(token);
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenModel tokenViewModel)
        {
            if (tokenViewModel == null) return BadRequest("Invalid client request");
            var token = await _authService.ValidarCredenciais(tokenViewModel);
            if (token == null) return BadRequest("Invalid client request");
            return Ok(token);
        }

        [HttpGet]
        [Route("revoke")]
        [Authorize("Bearer")]
        public async Task<IActionResult> Revogar()
        {
            var usuario = User.Identity.Name;
            var result = await _authService.RevovarToken(usuario);

            if (!result) return BadRequest("Invalid client request");
            return NoContent();
        }
    }
}
