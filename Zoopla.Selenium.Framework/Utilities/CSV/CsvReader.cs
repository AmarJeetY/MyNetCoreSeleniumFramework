using System.Data;
using System.IO;

namespace Zoopla.Selenium.Framework.Utilities.CSV
{
    public class CSVReader : Interfaces.IDataReader
    {
        public DataTable ReadData(string strFilePath)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(strFilePath))
            {
                string[] headers = sr.ReadLine().Split('|');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    var nextLine = sr.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nextLine))
                    {
                        string[] rows = nextLine.Split('|');
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i];
                        }
                        dt.Rows.Add(dr);
                    }
                }
            }

            return dt;
        }
    }
}

