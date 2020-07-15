using System.Collections.Generic;
using System.Data;

namespace Zoopla.Selenium.Framework.Interfaces
{
    public interface ITestCaseParser
    {
        Dictionary<string, string> GetTestParameters(DataTable testData, string testCase);
    }
}
