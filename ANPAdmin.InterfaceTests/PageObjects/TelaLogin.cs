using ANPAdmin.InterfaceTests.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace ANPAdmin.InterfaceTests.PageObjects
{
    public class TelaLogin
    {
        private readonly string _cenario;
        private ChromeDriver _driver;

        public TelaLogin(string cenario)
        {
            _cenario = cenario;

            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("--headless");

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
                TimeSpan.FromSeconds(5), "https://anpcomm-admin-exemplo-homolog.azurewebsites.net/Login");
        }

        public void PreencherCampo(string idCampo, string valor)
        {
            _driver.SetText(By.Id(idCampo), valor);
        }

        public void EfetuarLogin()
        {
            _driver.Submit(By.Id("btnSubmitForm"));

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => d.FindElement(By.Id("div-error")) != null);
        }

        public string ObterMensagemDeErro()
        {
            return _driver.GetText(By.Id("div-error"));
        }

        public void Fechar()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
