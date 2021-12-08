using Application.Interfaces;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPontoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioService _relatorioService;
        public RelatorioController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> BuscarTodos(string username)
        {
            var listaRelatorio = await _relatorioService.BuscarTodas(username);
            return Ok(listaRelatorio);
        }
    }
}
