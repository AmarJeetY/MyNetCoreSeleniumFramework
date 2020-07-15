using System.Collections.Generic;
using Castle.Core.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Zoopla.Selenium.Tests.Pages
{
    internal class TravelTime
    {

        [FindsBy(How = How.ClassName, Using = "ui-button-secondary")]
        private IWebElement _acceptCookiesElement;

        [FindsBy(How = How.Id, Using = "section_to_rent")]
        private IWebElement _toRentElement;
        
        [FindsBy(How = How.Id, Using = "search-input-location")]
        private IWebElement _searchLocationInputElement;

        [FindsBy(How = How.Id, Using = "duration")]
        private IWebElement _durationElement;

        [FindsBy(How = How.Id, Using = "transport_type")]
        private IWebElement _transportTypeElement;

        [FindsBy(How = How.CssSelector, Using = ".search-advanced-toggle > span")]
        private IWebElement _advanceSearchOptionsElement;

        [FindsBy(How = How.Id, Using = "search-submit")]
        private IWebElement _searchSubmitElement;

        [FindsBy(How = How.Id, Using = "alert-btn-save")]
        private IWebElement _saveSearchElement;
        private void SearchCriteria() => _toRentElement.Click();
        private void SelectAdvanceSearchOptions() => _advanceSearchOptionsElement.Click();
        private void TypeAreaToSearchFor(string area)
        {
            if (area.IsNullOrEmpty()) return;
            _searchLocationInputElement.Clear();
            _searchLocationInputElement.SendKeys(area);
            System.Threading.Thread.Sleep(3000);
            _searchLocationInputElement.Click();
            _searchLocationInputElement.SendKeys(Keys.ArrowDown);
            _searchLocationInputElement.SendKeys(Keys.Tab);
        }
        private void SelectMaxTravelTime(string travelTime)
        {
            if (travelTime.IsNullOrEmpty()) return;
            var selectElement = new SelectElement(_durationElement);
            selectElement.SelectByText(travelTime);
        }
        private void SelectMethodOfTransport(string transportMethod)
        {
            if (transportMethod.IsNullOrEmpty()) return;
            var selectElement = new SelectElement(_transportTypeElement);
            selectElement.SelectByText(transportMethod);
        }
        private void SubmitSearch() => _searchSubmitElement.Click();
        public void SaveSearch() => _saveSearchElement.Click();
        public void SearchPropertyBasedOnTravelTime(Dictionary<string, string> searchParameters)
        {
            SearchCriteria();
            SelectAdvanceSearchOptions();
            TypeAreaToSearchFor(searchParameters["SearchArea"]);
            SelectMaxTravelTime(searchParameters["TravelTime"]);
            SelectMethodOfTransport(searchParameters["TransportMethod"]);
            SubmitSearch();
        }
    }
}