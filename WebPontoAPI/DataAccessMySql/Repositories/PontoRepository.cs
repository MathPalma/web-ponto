using Dapper;
using DataAccessMySql.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Data;
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

        public async Task InserirPonto(string usuario)
        {
            string query = @"INSERT INTO MarcacaoPonto(Usuario, Data)
                                VALUES(@Usuario, @Data)";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Usuario", usuario, DbType.String);
            parameters.Add("@Data", DateTime.Now, DbType.DateTime);

            await db.ExecuteAsync(query, parameters, commandType: CommandType.Text);
        }
    }
}
