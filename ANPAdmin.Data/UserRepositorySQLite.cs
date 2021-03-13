using ANPAdmin.Data.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SQLite;

namespace ANPAdmin.Data
{
    public class UserRepositorySQLite : IUserRepository
    {
        private string _connectionString;


        public UserRepositorySQLite(string connectionString)
        {
            _connectionString = connectionString;
        }

        public UserModel ObterPorEmailESenha(string email, string senha)
        {
            using (var conexao = new SQLiteConnection(_connectionString))
            {
                return conexao.QueryFirstOrDefault<UserModel>(
                    "SELECT * FROM Usuario " +
                    "WHERE email = @email and senha = @senha " +
                    "ORDER BY Id DESC " +
                    "LIMIT 1",
                    new { email, senha });
            }
        }
    }
}