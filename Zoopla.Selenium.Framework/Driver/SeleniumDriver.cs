using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Zoopla.Selenium.Framework.Interfaces;

namespace Zoopla.Selenium.Framework.Driver
{
    public class SeleniumDriver : ISeleniumDriver
    {
        private IWebDriver _webDriver;
        private string _browser;

        private IWebDriver InitialiseWebDriver()
        {
            _webDriver = _browser.ToLower() switch
            {
                "chrome" => (IWebDriver)new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                "ie" => new InternetExplorerDriver(),
                _ => new ChromeDriver()
            };

            // Adding implicit wait of 10 seconds based on page loading times
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _webDriver.Manage().Window.Maximize();

            return _webDriver;
        }

        public IWebDriver GetWebDriver => InitialiseWebDriver();

        public void NavigateToUrl(string url)
        {
            GetWebDriver.Url = url;
        }
        
        public void SetBrowser(string browser) => _browser = browser;
        public void CloseWebDriverInstance()
        {
            if (_webDriver == null) return;
            _webDriver.Close();
            _webDriver.Quit();
            _webDriver.Dispose();
            _webDriver = null;
        }
    }
}