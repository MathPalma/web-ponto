using Dapper;
using DataAccessMySql.Interfaces;
using Domain.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessMySql.Repositories
{
    public class RelatorioRepository : BaseRepository, IRelatorioRepository
    {
        private MySqlConnection db;
        public RelatorioRepository(string connectionString) : base(connectionString)
        {
            db = GetMySqlConnection();
        }

        public async Task BuscarPorDia(RelatorioDiaViewModel relatorioDia)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Usuario", relatorioDia.Usuario, DbType.String);
            parameters.Add("@DataInicio", new DateTime(relatorioDia.Data.Day, relatorioDia.Data.Month, relatorioDia.Data.Year) , DbType.DateTime);
            parameters.Add("@DataFim", DateTime.Now, DbType.DateTime);

        }
    }
}
