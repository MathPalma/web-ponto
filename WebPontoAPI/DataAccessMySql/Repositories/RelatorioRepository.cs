using Dapper;
using DataAccessMySql.Interfaces;
using Domain.Models;
using Domain.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public async Task<List<RelatorioModel>> BuscarTodos(string usuario)
        {
            string query = @"SELECT Data, Tipo FROM MarcacaoPonto
                            WHERE Usuario = @Usuario
                            ORDER BY Data";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Usuario", usuario, DbType.String);

            var result = await db.QueryAsync<RelatorioModel>(query, parameters, commandType: CommandType.Text);
            db.Close(); 
            return result.ToList();
        }
    }
}
