using Domain.Models;
using System.Threading.Tasks;

namespace DataAccessMySql.Interfaces
{
    public interface IAuthRepository
    {
        Task<UsuarioModel> ValidarCredenciais(string username);
        Task<UsuarioModel> ValidarCredenciais(string username, string password);
        Task AtualizarInfoUsuario(int id, string refreshToken);
        Task<bool> RevogarToken(string usuario);
    }
}
