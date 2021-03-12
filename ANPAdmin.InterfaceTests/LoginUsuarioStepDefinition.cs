using ANPAdmin.InterfaceTests.PageObjects;
using TechTalk.SpecFlow;
using Xunit;

namespace ANPAdmin.InterfaceTests
{
    [Binding]
    public sealed class LoginUsuarioStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private TelaLogin _telaLogin;

        public LoginUsuarioStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _telaLogin = new TelaLogin(_scenarioContext.ScenarioInfo.Title);
            _telaLogin.CarregarPagina();

        }

        [Given("que o usuario digite o email (.*)")]
        public void QueOUsuarioDigiteOEmail(string email)
        {
            _telaLogin.PreencherCampo("email", email);
        }

        [Given("a senha (.*)")]
        public void GivenTheSecondNumberIs(string senha)
        {
            _telaLogin.PreencherCampo("password", senha);
        }

        [When("o usuario clicar no botão login")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _telaLogin.EfetuarLogin();
        }

        [Then("mostra uma mensagem de erro na tela")]
        public void ThenTheResultShouldBe()
        {
            var resultado = _telaLogin.ObterMensagemDeErro();
            Assert.Equal("", resultado);
        }
    }
}
