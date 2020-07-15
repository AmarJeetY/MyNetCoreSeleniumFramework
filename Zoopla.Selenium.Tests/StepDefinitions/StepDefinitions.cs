using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestProject.SDK.PageObjects;
using Xunit;
using Zoopla.Selenium.Framework.Interfaces;
using Zoopla.Selenium.Tests.Hooks;
using Zoopla.Selenium.Tests.Pages;

namespace Zoopla.Selenium.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitions : StepBase
    {
        private readonly ISeleniumConfig _configuration;
        private IWebDriver _driver;
        private Home _searchToRentPropertyPage;
        private EmailAlerts _registerEmailAlertsPage;
        private TravelTime _travelTimePage;
        private MyAccount _myAccountPage;
        private RegisterUser _registerUserPage;
        private Dictionary<string, string> _searchParameters;
        public StepDefinitions(ISeleniumConfig configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        [BeforeScenario]
        public new void BeforeScenario()
        {
            base.BeforeScenario();
            _seleniumDriver.SetBrowser(_configuration.Browser);
            _driver = _seleniumDriver.GetWebDriver;
        }

        [AfterScenario]
        public new void AfterScenario()
        {
            base.AfterScenario();
        }

        [BeforeFeature]
        public new static void BeforeFeatureStep(FeatureContext featureContext)
        {
            StepBase.BeforeFeatureStep(featureContext);
        }

        [Given(@"I have registered on Zoopla with (.*) and logged in")]
        public void RegisterAndLogIn(string userProfile)
        {
            _driver.Navigate().GoToUrl(_configuration.RegisterUserUrl);
            _registerUserPage = new RegisterUser();
            PageFactory.InitElements(_driver, _registerUserPage);
            _registerUserPage.RegisterAsNewUser(_parsonDetails.EmailAddress(), _parsonDetails.Password(), userProfile);
        }

        [Given(@"I browse to travel search page")]
        public void VisitTravelSearchPage()
        {
            _driver.Navigate().GoToUrl(_configuration.TravelTimeUrl);
            _travelTimePage = new TravelTime();
            PageFactory.InitElements(_driver, _travelTimePage);
        }

        [Then(@"I am able to save search and register for saved search in form of email alerts with frequency of (.*)")]
        public void GetAlertsForChosenFrequency(string alertFrequency)
        {
            _registerEmailAlertsPage = new EmailAlerts();
            PageFactory.InitElements(_driver, _registerEmailAlertsPage);
            _registerEmailAlertsPage.CreateNewEmailAlert(alertFrequency);
        }

        [Then(@"I am able to update to new email frequency of (.*)")]
        public void UpdateEmailUpdateFrequency(string newAlertFrequency)
        {
            _registerEmailAlertsPage = new EmailAlerts();
            PageFactory.InitElements(_driver, _registerEmailAlertsPage);
            _registerEmailAlertsPage.UpdateExistingEmailAlert(newAlertFrequency);
        }

        [Given(@"I am on Zoopla home page")]
        public void VisitZooplaHomePage()
        {
            _driver.Navigate().GoToUrl(_configuration.HomePage);
            _searchToRentPropertyPage = new Home();
            PageFactory.InitElements(_driver, _searchToRentPropertyPage);
            _searchToRentPropertyPage.AcceptCookies();
        }

        [When(@"I try to search property described in (.*)")]
        public void SearchProperty(string testCase)
        {
            _searchParameters = _testData.GetTestParameters(testCase, _configuration.DataFile);
            _driver.Navigate().GoToUrl(_configuration.HomePage);
            _searchToRentPropertyPage = new Home();
            PageFactory.InitElements(_driver, _searchToRentPropertyPage);
            _searchToRentPropertyPage.SearchToRentProperty(_searchParameters);
            
        }

        [When(@"I try to search property based on travel time described in (.*)")]
        public void SearchPropertyBasedOnTravelTime(string testCase)
        {
            _searchParameters = _testData.GetTestParameters(testCase, _configuration.DataFile);
            _driver.Navigate().GoToUrl(_configuration.TravelTimeUrl);
            PageFactory.InitElements(_driver, _travelTimePage);
            _travelTimePage.SearchPropertyBasedOnTravelTime(_searchParameters);

        }

        [Then(@"I am able to see my custom searched property appears first in list")]
        public void VerifyCustomSearch()
        {
            var customPropertySearchText = _searchParameters["SearchArea"];
            var firstResultText = _searchToRentPropertyPage.GetFirstResultText(_driver);
            Assert.True(firstResultText.Contains(customPropertySearchText),"First result does not contain unique custom search string");
        }

        [Then(@"I can confirm that the properties in search results have specified feature attached to them")]
        public void VerifyPropertiesWithGarage()
        {
            var propertyKeywords = _searchParameters["Keywords"];
            bool doesPropertySearchContainsKeyword =
                _searchToRentPropertyPage.SearchForKeywordInAllResults(_driver, propertyKeywords);
            
            // Currently commented because full description of the property which contains keywords
            // Is not available in search page. To get full description each property needs to be opened 
            // and description needs to be checked which is extremely inefficient.

            // Assert.True(doesPropertySearchContainsKeyword, $"One or more search results does not have expected keyword :  {propertyKeywords}");
        }

        [Then(@"I am able to retrieve results in saved search")]
        public void VerifyRetrievalOfSavedSearchResults()
        {
            _driver.Navigate().GoToUrl(_configuration.MyAccountUrl);
            _myAccountPage = new MyAccount();
            PageFactory.InitElements(_driver, _myAccountPage);
            _myAccountPage.RetrieveSavedSearchResults();
        }


    }
}
