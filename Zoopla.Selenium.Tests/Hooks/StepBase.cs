using TechTalk.SpecFlow;
using Zoopla.Selenium.Framework.Container;
using Zoopla.Selenium.Framework.Interfaces;

namespace Zoopla.Selenium.Tests.Hooks
{
    public abstract class StepBase : Steps
    {
        protected ISeleniumDriver _seleniumDriver;
        protected ITestData _testData;
        protected IPerson _parsonDetails;

        public void BeforeScenario()
        {
            _seleniumDriver = IOC.Resolve<ISeleniumDriver>(FeatureContext.FeatureContainer);
            _testData = IOC.Resolve<ITestData>(FeatureContext.FeatureContainer);
            _parsonDetails = IOC.Resolve<IPerson>(FeatureContext.FeatureContainer);
        }
        public static void BeforeFeatureStep(FeatureContext featureContext)
        {
            IOC.Register(featureContext.FeatureContainer);
        }
        public void AfterScenario()
        {
           _seleniumDriver.CloseWebDriverInstance();
        }
    }
}