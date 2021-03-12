using ANPAdmin.InterfaceTests.Utils;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace ANPAdmin.InterfaceTests.PageObjects
{
    public class TelaLogin
    {
        private readonly IConfiguration _configuration;
        private ChromeDriver _driver;
        private readonly string _envHomologUrl = Environment.GetEnvironmentVariable("APP_URL");

        public TelaLogin(IConfiguration configuration)
        {
            _configuration = configuration;

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");

            chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.Off);
            chromeOptions.SetLoggingPreference(LogType.Driver, LogLevel.Off);

            if (!string.IsNullOrWhiteSpace("C:\\ChromeDriver\\"))
                _driver = new ChromeDriver("C:\\ChromeDriver\\", chromeOptions);
            else
                _driver = new ChromeDriver(chromeOptions);
        }

        public void CarregarPagina()
        {
            _driver.LoadPage(
                TimeSpan.FromSeconds(5), _envHomologUrl);
        }

        public void PreencherCampo(string idCampo, string valor)
        {
            _driver.SetText(By.Id(idCampo), valor);
        }

        public void EfetuarLoginComErro()
        {
            _driver.Submit(By.Id("btnSubmitForm"));

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(By.Id("div-error")) != null);
        }

        public void EfetuarLoginComSucesso()
        {
            _driver.Submit(By.Id("btnSubmitForm"));

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(By.XPath("/html/body/div/div[1]/div[1]/div/div/div/div[2]/a/span[2]/span")) != null);
        }

        public string ObterMensagemDeErro()
        {
            return _driver.GetText(By.Id("div-error"));
        }

        public string ObterEmailLogado()
        {
            return _driver.GetText(By.XPath("/html/body/div/div[1]/div[1]/div/div/div/div[2]/a/span[2]/span"));
        }

        public void Fechar()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
