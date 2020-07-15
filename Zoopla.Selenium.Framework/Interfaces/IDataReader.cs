using System.Data;

namespace Zoopla.Selenium.Framework.Interfaces
{
    public interface IDataReader
    {
        DataTable ReadData(string fileName);
    }
}
