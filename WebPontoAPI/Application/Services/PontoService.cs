using Application.Interfaces;
using DataAccessMySql.Interfaces;
using System;
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
                await _pontoRepository.InserirPonto(usuario);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
