using System.Linq;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.MarkupUtils;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace Zoopla.Selenium.Tests.Hooks
{
    
        [Binding]
        public sealed class Hooks
        {
            private static SpecFlowReport _specFlowReport;

            [BeforeTestRun]
            public static void BeforeTestRun()
            {
                _specFlowReport = new SpecFlowReport();
                Reporter.SetupExtentReports();
            }

            [BeforeFeature]
            public static void BeforeFeature(FeatureContext featureContext)
            {
                featureContext.Set<SpecFlowFeature>(new SpecFlowFeature(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description));
            }

            [BeforeScenario]
            public static void BeforeScenario(ScenarioContext scenarioContext)
            {
                
                scenarioContext.Set(new SpecFlowScenario(scenarioContext.ScenarioInfo.Title));
                
            }

            [BeforeStep]
            public static void BeforeStep(ScenarioContext scenarioContext)
            {
                switch (scenarioContext.StepContext.StepInfo.StepDefinitionType)
                {
                    case StepDefinitionType.Given:
                        scenarioContext.Get<SpecFlowScenario>().Steps.Add(new SpecFlowStep(scenarioContext.StepContext.StepInfo.Text, StepDefinitionType.Given));
                        break;
                    case StepDefinitionType.When:
                        scenarioContext.Get<SpecFlowScenario>().Steps.Add(new SpecFlowStep(scenarioContext.StepContext.StepInfo.Text, StepDefinitionType.When));
                        break;
                    case StepDefinitionType.Then:
                        scenarioContext.Get<SpecFlowScenario>().Steps.Add(new SpecFlowStep(scenarioContext.StepContext.StepInfo.Text, StepDefinitionType.Then));
                        break;
                }
            }

            [AfterStep]
            public static void AfterStep(ScenarioContext scenarioContext)
            {
                
                scenarioContext.Get<SpecFlowScenario>().Steps.Last().StepStatus = Status.Pass;
                if (scenarioContext.TestError != null)
                {
                    scenarioContext.Get<SpecFlowScenario>().Steps.Last().StepStatus = Status.Error;
                    scenarioContext.Get<SpecFlowScenario>().Steps.Last().Exception = scenarioContext.TestError;
                }
            }

            [AfterScenario]
            public static void AfterScenario(ScenarioContext scenarioContext, FeatureContext featureContext)
            {
                scenarioContext.ScenarioInfo.Tags.ToList().ForEach(tag => scenarioContext.Get<SpecFlowScenario>().Categories.Add(tag));
                scenarioContext.Get<SpecFlowScenario>().Categories.Add("All_tests");
                featureContext.Get<SpecFlowFeature>().Scenarios.Add(scenarioContext.Get<SpecFlowScenario>());
                
            }

            [AfterFeature]
            public static void AfterFeature(FeatureContext featureContext)
            {
                _specFlowReport.Features.Add(featureContext.Get<SpecFlowFeature>());
                foreach (var feature in _specFlowReport.Features)
                {
                    Reporter.Feature = Reporter.Report.CreateTest<Feature>(feature.Title, feature.Description);
                    foreach (var scenario in feature.Scenarios)
                    {
                        Reporter.Scenario = Reporter.Feature.CreateNode<Scenario>(scenario.Title);
                        scenario.Categories.Sort();
                        scenario.Categories.ForEach(category => Reporter.Scenario.AssignCategory(category));
                        foreach (var step in scenario.Steps)
                        {
                            switch (step.StepType)
                            {
                                case StepDefinitionType.Given:
                                    Reporter.Step = Reporter.Scenario.CreateNode<Given>(step.Title);
                                    break;
                                case StepDefinitionType.When:
                                    Reporter.Step = Reporter.Scenario.CreateNode<When>(step.Title);
                                    break;
                                case StepDefinitionType.Then:
                                    Reporter.Step = Reporter.Scenario.CreateNode<Then>(step.Title);
                                    break;
                            }
                            if (step.StepStatus is Status.Error)
                            {
                                string[,] data = new string[4, 2]
                                {
                                { "Exception", $"{step.Exception.Message}"},
                                { "StackTrace", $"{step.Exception.StackTrace}"},
                                { "URL", $"<a href=\"{step.URL}\">{step.URL}</a>"},
                                { "PageSource", $"<a href=\"{step.PageSource}\">{step.PageSource}</a>"}
                                };
                                Reporter.Step.Fail(MarkupHelper.CreateTable(data));
                            }
                            if (step.ScreenShot != null) Reporter.Step.Log(Status.Info, MediaEntityBuilder.CreateScreenCaptureFromPath(step.ScreenShot).Build());
                        }
                    }
                }
                _specFlowReport = new SpecFlowReport();
                Reporter.Report.Flush();
            }

            [AfterTestRun]
            public static void AfterTestRun()
            {
                Reporter.Report.Flush();
            }
        }
    }
