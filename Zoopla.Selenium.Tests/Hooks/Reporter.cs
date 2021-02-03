using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace Zoopla.Selenium.Tests.Hooks
{
    public static class Reporter
    {
        private const string reportTitle = "Test Report";
        private const string reportName = "SpecFlow Tests";
        private static readonly string configFileName = $"{Path.Combine(Path.GetFullPath(Directory.GetCurrentDirectory()), "..", "..", "..", "Config", "extentReportConfig.xml")}";
        private static ExtentHtmlReporter htmlReporter;
        private static ExtentKlovReporter klov;
        private static ExtentReports report;
        private static ExtentTest feature;
        private static ExtentTest scenario;
        private static ExtentTest step;

        public static readonly string ReportDir = $"{Path.Combine(Path.GetFullPath(Directory.GetCurrentDirectory()), "..", "..", "..", "Report")}";
        public static ExtentTest Step { get => step; set => step = value; }
        public static ExtentTest Scenario { get => scenario; set => scenario = value; }
        public static ExtentTest Feature { get => feature; set => feature = value; }
        public static ExtentReports Report { get => report; set => report = value; }

        public static void SetupExtentReports()
        {
            InitHtmlReporter(new ExtentHtmlReporter($"{Path.Combine(ReportDir, "index.html")}"));
            InitExtentReport(new ExtentReports());
            CleanReportDir(new DirectoryInfo(ReportDir));
        }

        private static void CleanReportDir(DirectoryInfo directoryInfo)
        {
            foreach (FileInfo file in directoryInfo.GetFiles()) file.Delete();
        }

        private static void InitHtmlReporter(ExtentHtmlReporter extentHtmlReporter)
        {
            htmlReporter = extentHtmlReporter;
            htmlReporter.LoadConfig(configFileName);
        }

        private static void InitExtentReport(ExtentReports extentReports)
        {
            Report = extentReports;
            Report.AttachReporter(htmlReporter);
            Report.AddSystemInfo("OS", System.Environment.OSVersion.ToString());
            Report.AnalysisStrategy = AnalysisStrategy.BDD;
        }
    }
}
