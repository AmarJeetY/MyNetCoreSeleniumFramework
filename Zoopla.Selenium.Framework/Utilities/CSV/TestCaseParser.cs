using System;
using System.Collections.Generic;
using System.Data;
using Zoopla.Selenium.Framework.Interfaces;

namespace Zoopla.Selenium.Framework.Utilities.CSV
{
    public class TestCaseParser : ITestCaseParser
    {
        public Dictionary<string, string> GetTestParameters(DataTable testData, string testCase)
        {
            var rowOfTestCase = FindNamedRow(testCase, testData);
            if (rowOfTestCase != null)
            {
                return GetRowData(testData, rowOfTestCase);
            }

            throw new Exception($"Invalid test case {testCase}");
        }
        private Dictionary<string, string> GetRowData(DataTable testdata, DataRow row)
        {
            var rowData = new Dictionary<string, string>();

            var rowItems = row.ItemArray;
            for (int item = 1; item < rowItems.Length; item++)
            {
                rowData.Add(testdata.Columns[item].ColumnName.ToString(), rowItems[item].ToString());
            }
            return rowData;
        }

        private DataRow FindNamedRow(string nameOfFirstRow, DataTable rows)
        {
            for (int row = 0; row < rows.Rows.Count; row++)
            {
                var rowAsArray = rows.Rows[row].ItemArray;
                if (rowAsArray.Length > 0)
                {
                    if (rowAsArray[0].ToString() == nameOfFirstRow)
                    {
                        return rows.Rows[row];
                    }
                }
            }

            return null;
        }
    }
}

