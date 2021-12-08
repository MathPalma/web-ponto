using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebPontoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PontoController : ControllerBase
    {
        private readonly IPontoService _pontoService;
        public PontoController(IPontoService pontoService)
        {
            _pontoService = pontoService;
        }

        [HttpPost]
        [Route("marcar")]
        public async Task<IActionResult> MarcarPonto(Username user)
        {
            await _pontoService.MarcarPonto(user.username);
            return Ok();
        }
    }
}
