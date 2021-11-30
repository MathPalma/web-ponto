using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebPontoAPI.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IActionResult> MarcarPonto([FromBody] string usuario)
        {
            await _pontoService.MarcarPonto(usuario);
            return Ok();
        }
    }
}
