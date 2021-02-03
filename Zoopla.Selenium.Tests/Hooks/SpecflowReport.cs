using System;
using System.Collections.Generic;
using AventStack.ExtentReports;
using TechTalk.SpecFlow.Bindings;

namespace Zoopla.Selenium.Tests.Hooks
{
    public class SpecFlowReport
    {
        public SpecFlowReport()
        {
            Features = new List<SpecFlowFeature>();
        }
        public List<SpecFlowFeature> Features { get; }
    }

    public class SpecFlowFeature
    {
        public SpecFlowFeature(string title, string description)
        {
            Title = title;
            Description = description;
            Scenarios = new List<SpecFlowScenario>();
        }
        public string Title { get; }
        public string Description { get; }
        public List<SpecFlowScenario> Scenarios { get; }
    }
    public class SpecFlowScenario
    {
        public SpecFlowScenario(string title)
        {
            Title = title;
            Steps = new List<SpecFlowStep>();
            Categories = new List<string>();
        }
        public string Title { get; }
        public List<string> Categories { get; }
        public List<SpecFlowStep> Steps { get; }

    }
    public class SpecFlowStep
    {
        public SpecFlowStep(string title, StepDefinitionType stepType)
        {
            Title = title;
            StepType = stepType;
        }
        public SpecFlowStep(string title, StepDefinitionType stepType, Status stepStatus)
        {
            Title = title;
            StepType = stepType;
            StepStatus = stepStatus;
        }
        public string Title { get; }
        public StepDefinitionType StepType { get; }
        public Status StepStatus { get; set; }
        public string URL { get; set; }
        public string PageSource { get; set; }
        public string ScreenShot { get; set; }
        public Exception Exception { get; set; }
    }
}
