using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRelatorioService
    {
        Task<List<RelatorioGeralModel>> BuscarTodas(string usuario);
    }
}
