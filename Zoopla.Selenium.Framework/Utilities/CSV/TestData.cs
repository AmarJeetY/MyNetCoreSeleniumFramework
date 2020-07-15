using System;
using System.Collections.Generic;
using System.IO;
using Zoopla.Selenium.Framework.Interfaces;

namespace Zoopla.Selenium.Framework.Utilities.CSV
{
    class TestData : ITestData
    {
        private readonly ITestCaseParser _testCaseRepository;
        private readonly IDataReader _dataReader;

        public TestData(IDataReader dataReader, ITestCaseParser testCaseRepository)
        {
            _testCaseRepository = testCaseRepository ?? throw new ArgumentNullException(nameof(testCaseRepository));
            _dataReader = dataReader ?? throw new ArgumentNullException(nameof(dataReader));
        }
        public Dictionary<string, string> GetTestParameters(string testCase, string csvFile)
        {
            var dir = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location);
            var csvFilePath = dir + csvFile;
            using var testData = _dataReader.ReadData(csvFilePath);
            return _testCaseRepository.GetTestParameters(testData, testCase);
        }
    }
}