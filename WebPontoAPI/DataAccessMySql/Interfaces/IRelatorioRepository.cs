using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessMySql.Interfaces
{
    public interface IRelatorioRepository
    {
        Task<List<RelatorioModel>> BuscarTodos(string usuario);
    }
}
