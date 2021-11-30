using Application.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPontoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioService _relatorioService;
        public RelatorioController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        /*[HttpGet]
        [Route("Pordia")]
        public async Task<IActionResult> BuscarPorDia([FromBody] RelatorioDiaViewModel requisicaoRelatorio)
        {
            await _pontoService.MarcarPonto(usuario);
            return Ok();
        }*/
    }
}
