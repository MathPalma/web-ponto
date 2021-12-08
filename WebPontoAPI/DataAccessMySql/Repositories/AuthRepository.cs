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
            db.Close();

            return await db.QueryFirstOrDefaultAsync<UsuarioModel>(query, parameters, commandType: CommandType.Text);
        }
        public async Task<UsuarioModel> ValidarCredenciais(string user, string password)
        {
            string query = @"SELECT ID, Usuario, Nome, Email, Telefone, RefreshToken, RefreshTokenTempoExpiracao
                            FROM Colaborador
                            WHERE Usuario = @User and Senha = @Password";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@User", user, DbType.String);
            parameters.Add("@Password", password, DbType.String);
            db.Close();

            return await db.QueryFirstOrDefaultAsync<UsuarioModel>(query, parameters, commandType: CommandType.Text);
        }

        public async Task AtualizarInfoUsuario(int id, string refreshToken)
        {
            string query = @"UPDATE Colaborador SET RefreshToken = @RefreshToken
                             WHERE ID = @ID";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", id, DbType.Int32);
            parameters.Add("@RefreshToken", refreshToken, DbType.String);
            db.Close();

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
            db.Close();

            return true;
        }

        public async Task RegistrarUsuario(UsuarioModel usuario)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Usuario", usuario.Usuario, DbType.String);
            parameters.Add("@Nome", usuario.Nome, DbType.String);
            parameters.Add("@Senha", usuario.Senha, DbType.String);
            parameters.Add("@Email", usuario.Email, DbType.String);

            string query = @"INSERT INTO Colaborador
                            (Usuario, Senha, Nome, Email)
                            VALUES(@Usuario, @Senha, @Nome, @Email)";

            await db.ExecuteAsync(query, parameters, commandType: CommandType.Text);
            db.Close();
        }

    }
}
