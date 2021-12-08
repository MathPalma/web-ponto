using Dapper;
using DataAccessMySql.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessMySql.Repositories
{
    public class PontoRepository: BaseRepository, IPontoRepository
    {
        private MySqlConnection db;
        public PontoRepository(string connectionString) : base(connectionString) 
        {
            db = GetMySqlConnection();
        }

        public async Task InserirPonto(string usuario, string tipo)
        {
            string query = @"INSERT INTO MarcacaoPonto(Usuario, Data, Tipo)
                                VALUES(@Usuario, @Data, @Tipo)";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Usuario", usuario, DbType.String);
            parameters.Add("@Data", DateTime.Now, DbType.DateTime);
            parameters.Add("@Tipo", tipo, DbType.String);


            await db.ExecuteAsync(query, parameters, commandType: CommandType.Text);
            db.Close();
        }

        public async Task<List<DateTime>> VerificarTipo(DateTime dataInicio, DateTime dataFim, string usuario)
        {
            string query = @"SELECT Data FROM MarcacaoPonto
                            WHERE Data BETWEEN @DataInicio AND @DataFim
                            AND Usuario = @Usuario";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Usuario", usuario, DbType.String);
            parameters.Add("@DataInicio", dataInicio, DbType.DateTime);
            parameters.Add("@DataFim", dataFim, DbType.DateTime);

            var result = await db.QueryAsync<DateTime>(query, parameters, commandType: CommandType.Text);
            db.Close();
            return result.ToList();
        }
    }
}
