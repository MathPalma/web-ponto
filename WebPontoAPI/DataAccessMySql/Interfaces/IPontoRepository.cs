using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessMySql.Interfaces
{
    public interface IPontoRepository
    {
        Task InserirPonto(string usuario, string tipo);
        Task<List<DateTime>> VerificarTipo(DateTime dataInicio, DateTime dataFim, string usuario);
    }
}
