using System;
using System.Data.SQLite;
using Microsoft.Extensions.Logging;
using FluentMigrator.Runner;
using Dapper;
using Dapper.Contrib.Extensions;

namespace ANPAdmin.UnitTests
{
    public class AuthInitializer
    {
        private readonly ILogger<AuthInitializer> _logger;
        private readonly IMigrationRunner _migrationRunner;
        private readonly AuthContext _context;

        public AuthInitializer(ILogger<AuthInitializer> logger,
            IMigrationRunner migrationRunner,
            AuthContext context)
        {
            _logger = logger;
            _migrationRunner = migrationRunner;
            _context = context;
        }

        public void RunMigrations()
        {
            _logger.LogInformation("Iniciando a execucao das Migrations...");

            try
            {
                _migrationRunner.MigrateUp();
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"Erro durante a execucao das Migrations: {ex.Message} | {ex.GetType().Name}");
            }

            _logger.LogInformation("Verificacao das Migrations concluida.");
        }

        public void InsertUser(
            string name, string email, string password, bool isActive)
        {
            using (var conexao =
                new SQLiteConnection(_context.ConnectionString))
            {
                conexao.Execute(
                    "INSERT INTO Usuario(Nome, Email, Senha, Ativo) " +
                    "VALUES (@name, @email, @password, @isActive) ",
                    new { name, email, password, isActive });
            }
        }
    }
}