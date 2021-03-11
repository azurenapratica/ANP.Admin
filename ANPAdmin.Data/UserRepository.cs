using ANPAdmin.Data.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace ANPAdmin.Data
{
    public class UserRepository : IUserRepository
    {
        private IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public UserModel ObterPorEmailESenha(string email, string senha)
        {
            using (SqlConnection conexao = new SqlConnection(_configuration.GetConnectionString("BaseComm")))
            {
                var dados = conexao.QueryFirstOrDefault<UserModel>(
                    "SELECT TOP 1 * FROM dbo.Usuario WHERE email = @email and senha = @senha", new { email, senha });
                return dados;
            }
        }
    }
}
