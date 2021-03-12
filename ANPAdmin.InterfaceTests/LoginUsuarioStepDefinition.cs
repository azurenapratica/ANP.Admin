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
        private string _email;
        private string _senha;
        private string _resultadoTeste;

        public LoginUsuarioStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("que o usuario digite o email (.*)")]
        public void DadoQueOUsuarioDigiteOEmail(string email)
        {            
            _email = email;
        }

        [Given("a senha (.*)")]
        public void DadoQueOUsuarioDigiteASenha(string senha)
        {            
            _senha = senha;
        }

        [When("o usuario clicar no botão login com dados invalidos")]
        public void QuandoOUsuarioClicarNoBotaoLoginComDadosInvalidos()
        {
            var _telaLogin = new TelaLogin();
            _telaLogin.CarregarPagina();

            _telaLogin.PreencherCampo("email", _email);
            _telaLogin.PreencherCampo("password", _senha);
            _telaLogin.EfetuarLoginComErro();

            _resultadoTeste = _telaLogin.ObterMensagemDeErro();

            //_telaLogin.Fechar();
        }

        [When("o usuario clicar no botão login com dados validos")]
        public void QuandoOUsuarioClicarNoBotaoLoginComDadosValidos()
        {
            var _telaLogin = new TelaLogin();
            _telaLogin.CarregarPagina();

            _telaLogin.PreencherCampo("email", _email);
            _telaLogin.PreencherCampo("password", _senha);
            _telaLogin.EfetuarLoginComSucesso();

            _resultadoTeste = _telaLogin.ObterEmailLogado();

            //_telaLogin.Fechar();
        }

        [Then("mostra uma mensagem de erro na tela")]
        public void EntaoDeveExibirMensagemDeErro()
        {           
            Assert.Equal("Usuário ou senha inválidos.", _resultadoTeste);
        }

        [Then("redireciona o usuario para a página inicial")]
        public void EntaoDeveRedirecionarParaPaginaInicial()
        {
            Assert.Equal(_email, _resultadoTeste);
        }
    }
}
