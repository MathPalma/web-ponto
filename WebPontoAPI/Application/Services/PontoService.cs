using Application.Interfaces;
using DataAccessMySql.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PontoService : IPontoService
    {
        private readonly IPontoRepository _pontoRepository;
        public PontoService(IPontoRepository pontoRepository)
        {
            _pontoRepository = pontoRepository;
        }

        public async Task MarcarPonto(string usuario)
        {
            try
            {
                DateTime data = DateTime.Today;
                DateTime dataFim = data.AddHours(23);
                dataFim = dataFim.AddMinutes(59);
                dataFim = dataFim.AddSeconds(59);

                var verificarTipo = await _pontoRepository.VerificarTipo(data, dataFim, usuario);

                if (!verificarTipo.Any())
                {
                    await _pontoRepository.InserirPonto(usuario, "entrada");
                }
                if (verificarTipo.Count == 1)
                {
                    await _pontoRepository.InserirPonto(usuario, "saida");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
