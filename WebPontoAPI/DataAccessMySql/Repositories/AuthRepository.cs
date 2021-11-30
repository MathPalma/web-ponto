using Dapper;
using DataAccessMySql.Interfaces;
using Domain.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading.Tasks;

namespace DataAccessMySql.Repositories
{
    public class AuthRepository : BaseRepository, IAuthRepository
    {
        private MySqlConnection db;
        public AuthRepository(string connectionString) : base(connectionString) 
        {
            db = GetMySqlConnection();
        }

        public async Task<UsuarioModel> ValidarCredenciais(string usuario)
        {
            string query = @"SELECT ID, Usuario, Nome, Email, Telefone, RefreshToken, RefreshTokenTempoExpiracao
                            FROM Colaborador
                            WHERE Usuario = @Usuario";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Usuario", usuario, DbType.String);

            return await db.QueryFirstOrDefaultAsync<UsuarioModel>(query, parameters, commandType: CommandType.Text);
        }
        public async Task<UsuarioModel> ValidarCredenciais(string usuario, string senha)
        {
            string query = @"SELECT ID, Usuario, Nome, Email, Telefone, RefreshToken, RefreshTokenTempoExpiracao
                            FROM Colaborador
                            WHERE Usuario = @Usuario and Senha = @Senha";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Usuario", usuario, DbType.String);
            parameters.Add("@Senha", senha, DbType.String);

            return await db.QueryFirstOrDefaultAsync<UsuarioModel>(query, parameters, commandType: CommandType.Text);
        }

        public async Task AtualizarInfoUsuario(int id, string refreshToken)
        {
            string query = @"UPDATE Colaborador SET RefreshToken = @RefreshToken
                             WHERE ID = @ID";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            parameters.Add("@RefreshToken", refreshToken, DbType.String);

            await db.ExecuteAsync(query, parameters, commandType: CommandType.Text);
        }

        public async Task<bool> RevogarToken(string usuario)
        {
            UsuarioModel user = await ValidarCredenciais(usuario);
            if (user is null) return false;

            string query = @"UPDATE Colaborador SET RefreshToken = NULL WHERE ID = @ID";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", user.ID, DbType.Int32);

            await db.ExecuteAsync(query, parameters, commandType: CommandType.Text);
            return true;
        }

    }
}
