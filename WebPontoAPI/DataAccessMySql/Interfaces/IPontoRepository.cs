using System.Threading.Tasks;

namespace DataAccessMySql.Interfaces
{
    public interface IPontoRepository
    {
        Task InserirPonto(string usuario);
    }
}
