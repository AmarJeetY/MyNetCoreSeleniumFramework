using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Zoopla.Selenium.Tests.Pages
{
    internal class RegisterUser
    {
        [FindsBy(How = How.ClassName, Using = "ui-button-secondary")]
        private IWebElement _acceptCookiesElement;

        [FindsBy(How = How.Id, Using = "register_email")]
        private IWebElement _emailElement;

        [FindsBy(How = How.Id, Using = "register_password")]
        private IWebElement _passwordElement;

        [FindsBy(How = How.Id, Using = "sender_property_status")]
        private IWebElement _requiredPropertyElement;

        [FindsBy(How = How.Id, Using = "register_submit")]
        private IWebElement _submitRegistrationRequestElement;

        [FindsBy(How = How.Id, Using = "fancybox-close")]
        private IWebElement _closeSocialMediaChoicesElement;

        private void AcceptCookies() => _acceptCookiesElement.Click();
        private void TypeEmailAddress(string email) => _emailElement.SendKeys(email + Keys.Tab);
        private void TypePassword(string password) => _passwordElement.SendKeys(password + Keys.Tab);

        private void SelectUserProfile(string userProfile)
        {
            var selectElement = new SelectElement(_requiredPropertyElement);
            selectElement.SelectByText(userProfile);
        }
        private void ClickSubmitRegistration() => _submitRegistrationRequestElement.Click();
        private void SelectSocialMediaChoicesPopup() => _closeSocialMediaChoicesElement.Click();
        public void RegisterAsNewUser(string email, string password, string userProfile)
        {
            AcceptCookies();
            TypeEmailAddress(email);
            TypePassword(password);
            SelectUserProfile(userProfile);
            ClickSubmitRegistration();
            SelectSocialMediaChoicesPopup();
        }
    }
}