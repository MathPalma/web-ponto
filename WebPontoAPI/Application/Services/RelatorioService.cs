using Application.Interfaces;
using DataAccessMySql.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RelatorioService : IRelatorioService
    {
        
        private readonly IRelatorioRepository _relatorioRepository;
        public RelatorioService(IRelatorioRepository relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;
        }

        public async Task<List<RelatorioGeralModel>> BuscarTodas(string usuario)
        {
            try
            {
                var relatorios = await _relatorioRepository.BuscarTodos(usuario);
                List<RelatorioGeralModel> relatorioGeral = new List<RelatorioGeralModel>();

                for (int i = 0; i < relatorios.Count; i += 2)
                {
                    var data = relatorios[i].Data;


                    relatorioGeral.Add(new RelatorioGeralModel
                    {
                        Dia = data.Date,
                        Entrada = data,
                        Saida = relatorios[i + 1].Data
                    });
                    
                }
                return relatorioGeral;
            }
            catch (Exception)
            {

            }

            return null;
        }
        
    }
}
