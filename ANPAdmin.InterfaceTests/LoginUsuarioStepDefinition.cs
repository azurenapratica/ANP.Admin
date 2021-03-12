using ANPAdmin.InterfaceTests.PageObjects;
using TechTalk.SpecFlow;

namespace ANPAdmin.InterfaceTests
{
    [Binding]
    public sealed class LoginUsuarioStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public LoginUsuarioStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var telaLogin = new TelaLogin(_scenarioContext.ScenarioInfo.Title);
            telaLogin.CarregarPagina();

        }

        [Given("que o usuario digite o email (.*)")]
        public void QueOUsuarioDigiteOEmail(string email)
        {
        }

        [Given("a senha (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata 
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            _scenarioContext.Pending();
        }

        [When("o usuario clicar no botão login")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //TODO: implement act (action) logic

            _scenarioContext.Pending();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic

            _scenarioContext.Pending();
        }
    }
}
