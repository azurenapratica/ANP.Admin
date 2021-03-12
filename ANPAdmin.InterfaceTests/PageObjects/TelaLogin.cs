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
            chromeOptions.AddArgument("--headless");

            chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.Off);
            chromeOptions.SetLoggingPreference(LogType.Driver, LogLevel.Off);

            if (!string.IsNullOrWhiteSpace("CaminhoDriverChrome"))
                _driver = new ChromeDriver("CaminhoDriverChrome", chromeOptions);
            else
                _driver = new ChromeDriver(chromeOptions);
        }

        public void CarregarPagina()
        {
            _driver.LoadPage(
                TimeSpan.FromSeconds(Convert.ToInt32("")), "");
        }
    }
}
