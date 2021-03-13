using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FluentAssertions;
using FluentMigrator.Runner;
using ANPAdmin.Business;
using ANPAdmin.Data;

namespace ANPAdmin.UnitTests
{
    public class TestesAuth
    {
        private static readonly string _connectionStringSQLite;
        private readonly Auth _auth;

        #region Dados Usuário Normal
        private const string NAME_USER_NORMAL = "testenormal";
        private const string EMAIL_USER_NORMAL = "testenormal@azurenapratica.com";
        private const string PASSWORD_USER_NORMAL = "senhanormal01!";
        #endregion

        #region Dados Usuário Inativo
        private const string NAME_USER_INATIVO = "testeusrinativo";
        private const string EMAIL_USER_INATIVO = "testeusrinativo@azurenapratica.com";
        private const string PASSWORD_USER_INATIVO = "senhainativo99!";
        #endregion

        #region Inicialização Dados para Testes
        static TestesAuth()
        {
            _connectionStringSQLite =
                $"Data Source=./auth-anpadmin-{DateTime.Now:yyyyMMdd-HHmmss}.db";

            var services = new ServiceCollection();
            
            services.AddLogging(configure => configure.AddConsole());

            services.AddFluentMigratorCore()
                .ConfigureRunner(cfg => cfg
                    .AddSQLite()
                    .WithGlobalConnectionString(_connectionStringSQLite)
                    .ScanIn(typeof(UserRepositorySQLite).Assembly).For.Migrations()
                )
                .AddLogging(cfg => cfg.AddFluentMigratorConsole());

            services.AddSingleton<AuthContext>(new AuthContext()
            {
                ConnectionString = _connectionStringSQLite
            });
            
            services.AddTransient<AuthInitializer>();

            var initilializer = services.BuildServiceProvider()
                .GetService<AuthInitializer>();
            initilializer.RunMigrations();
            initilializer.InsertUser(
                NAME_USER_NORMAL, EMAIL_USER_NORMAL, PASSWORD_USER_NORMAL, true);
            initilializer.InsertUser(
                NAME_USER_INATIVO, EMAIL_USER_INATIVO, PASSWORD_USER_INATIVO, false);
        }
        #endregion

        public TestesAuth()
        {
            _auth = new Auth(new UserRepositorySQLite(
                _connectionStringSQLite));
        }

        [Fact]
        public void TestarUsuarioExistente()
        {
            var resultado = _auth.Login(
                EMAIL_USER_NORMAL, PASSWORD_USER_NORMAL);
            resultado.Name.Should().Be(NAME_USER_NORMAL);
            resultado.Email.Should().Be(EMAIL_USER_NORMAL);
        }

        [Fact]
        public void TestarUsuarioSenhaInvalida()
        {
            var resultado = _auth.Login(
                EMAIL_USER_NORMAL, "senhainvalida");
            resultado.Should().BeNull(
                "* null e o retorno esperado ao informar uma senha invalida *");
        }

        [Fact]
        public void TestarUsuarioInexistente()
        {
            var resultado = _auth.Login(
                "inexistente@azurenapratica.com", "inexistente01");
            resultado.Should().BeNull(
                "* null e o retorno esperado para um usuario inexistente *");
        }

        [Fact]
        public void TestarUsuarioInativo()
        {
            var resultado = _auth.Login(
                EMAIL_USER_INATIVO, PASSWORD_USER_INATIVO);
            resultado.Should().BeNull("* null e o retorno esperado para um usuario inativo *");
        }
    }
}