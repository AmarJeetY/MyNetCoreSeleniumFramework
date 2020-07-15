using OpenQA.Selenium;

namespace Zoopla.Selenium.Framework.Interfaces
{
    public interface ISeleniumDriver
    {
        IWebDriver GetWebDriver { get; }
        void NavigateToUrl(string url);
        void CloseWebDriverInstance();
        void SetBrowser(string browser);
    }
}
