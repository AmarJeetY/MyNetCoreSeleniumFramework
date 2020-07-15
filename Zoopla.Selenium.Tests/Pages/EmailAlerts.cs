using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Zoopla.Selenium.Tests.Pages
{
    internal class EmailAlerts
    {
        [FindsBy(How = How.Id, Using = "alert-btn-create")]
        private IWebElement _createAlertElement;

        [FindsBy(How = How.Id, Using = "frequency_0")]
        private IWebElement _selectInstantAlertElement;

        [FindsBy(How = How.Id, Using = "frequency_1")]
        private IWebElement _selectDailyAlertElement;

        [FindsBy(How = How.Id, Using = "frequency_3")]
        private IWebElement _selectThreeDaysAlertElement;

        [FindsBy(How = How.Id, Using = "frequency_7")]
        private IWebElement _selectWeeklyAlertElement;

        [FindsBy(How = How.Id, Using = "frequency_none")]
        private IWebElement _selectNoAlertElement;

        [FindsBy(How = How.Name, Using = "action:save")]
        private IWebElement _saveAlertElement;

        [FindsBy(How = How.CssSelector, Using = "#alerts-buttons-edit")]
        private IWebElement _editExistingAlertElement;

        private void CreateEmailAlert() => _createAlertElement.Click();
        private void SetAlertFrequency(string alertFrequency)
        {
            switch (alertFrequency)
            {
                case "Instant":
                    _selectInstantAlertElement.Click();
                    break;
                case "Daily":
                    _selectDailyAlertElement.Click();
                    break;
                case "ThreeDays":
                    _selectThreeDaysAlertElement.Click();
                    break;
                case "Weekly":
                    _selectWeeklyAlertElement.Click();
                    break;
                case "None":
                    _selectNoAlertElement.Click();
                    break;
                default:
                    _selectNoAlertElement.Click();
                    break;
            }
        }
        public void SaveEmailAlert() => _saveAlertElement.Click();
        private void EditExistingAlert() => _editExistingAlertElement.Click();
        public void CreateNewEmailAlert(string alertFrequency)
        {
            CreateEmailAlert();
            SetAndSaveAlert(alertFrequency);
        }
        public void UpdateExistingEmailAlert(string alertFrequencyToUpdate)
        {
            System.Threading.Thread.Sleep(3000);
            EditExistingAlert();
            SetAndSaveAlert(alertFrequencyToUpdate);
        }
        private void SetAndSaveAlert(string alertFrequency)
        {
            SetAlertFrequency(alertFrequency);
            SaveEmailAlert();
        }
    }
}