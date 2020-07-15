using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
namespace Zoopla.Selenium.Tests.Pages
{
    internal class MyAccount
    {
        [FindsBy(How = How.ClassName, Using = "myaccount-tile-header")]
        private IWebElement _recentSearchesElement;

        [FindsBy(How = How.XPath, Using = "//a[@class='myaccount-alert-action'][contains(.,'View')]")]
        private IWebElement _viewSavedSearchElement;
        
        [FindsBy(How = How.ClassName, Using = "listing-results")]
        private List<IWebElement> _listOfSearchResultsElement;
        
        private void SelectRecentSearch() => _recentSearchesElement.Click();
        private void ViewRecentSearch() => _viewSavedSearchElement.Click();
        public void RetrieveSavedSearchResults()
        {
            SelectRecentSearch();
            ViewRecentSearch();
        }
    }
}
