using ANPAdmin.InterfaceTests.PageObjects;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;
using Xunit;

namespace ANPAdmin.InterfaceTests
{
    [Binding]
    public sealed class LoginUsuarioStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly TelaLogin _telaLogin;
        private string _email;

        public LoginUsuarioStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            _telaLogin = new TelaLogin();
            _telaLogin.CarregarPagina();
        }

        [Given("que o usuario digite o email (.*)")]
        public void DadoQueOUsuarioDigiteOEmail(string email)
        {
            _telaLogin.PreencherCampo("email", email);
            _email = email;
        }

        [Given("a senha (.*)")]
        public void DadoQueOUsuarioDigiteASenha(string senha)
        {
            _telaLogin.PreencherCampo("password", senha);
        }

        [When("o usuario clicar no botão login com dados invalidos")]
        public void QuandoOUsuarioClicarNoBotaoLoginComDadosInvalidos()
        {
            _telaLogin.EfetuarLoginComErro();
        }

        [When("o usuario clicar no botão login com dados validos")]
        public void QuandoOUsuarioClicarNoBotaoLoginComDadosValidos()
        {
            _telaLogin.EfetuarLoginComSucesso();
        }

        [Then("mostra uma mensagem de erro na tela")]
        public void EntaoDeveExibirMensagemDeErro()
        {
            var resultado = _telaLogin.ObterMensagemDeErro();
            _telaLogin.Fechar();
            
            Assert.Equal("Usuário ou senha inválidos.", resultado);
        }

        [Then("redireciona o usuario para a página inicial")]
        public void EntaoDeveRedirecionarParaPaginaInicial()
        {
            var resultado = _telaLogin.ObterEmailLogado();
            _telaLogin.Fechar();

            Assert.Equal(_email, resultado);
        }
    }
}
