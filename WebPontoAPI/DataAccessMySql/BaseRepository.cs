using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessMySql
{
    public class BaseRepository
    {
        /*protected string _connectionString { get; }
        private readonly IDbConnection conn;
        protected BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
            conn = new MySqlConnection(_connectionString);
        }

        public void Dispose()
        {
            conn.Close();
        }

        public List<int> SearchCidades(string nome)
        {
            nome = "Juiz de Fora";

            if (string.IsNullOrEmpty(nome))
                return conn.Quer

            nome = nome.Trim();

            return _db.Query<Cidade>("SELECT * FROM GLB_Cidade WHERE Nome LIKE @Nome ORDER BY Nome ASC LIMIT 10", new { Nome = string.Format("%{0}%", nome) }).ToList();
        }

        protected async Task<int> ExecuteAsync(string query, object param = null, CommandType? commandType = null)
        {
            return await conn.Query
        }
        protected async Task<T> QueryFirstOrDefaultAsync<T>(string query, object param = null, CommandType? commandType = null)
        {
            using IDbConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            return await conn.QueryFirstOrDefaultAsync<T>(query, param, commandType: commandType);
        }
        protected async Task<IEnumerable<T>> QueryAsync<T>(string query, object param = null, CommandType? commandType = null)
        {
            using IDbConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            return await conn.QueryAsync<T>(query, param, commandType: commandType);
        }
    }*/
}
}
