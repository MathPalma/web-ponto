using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPontoService
    {
        Task MarcarPonto(string usuario);
    }
}
