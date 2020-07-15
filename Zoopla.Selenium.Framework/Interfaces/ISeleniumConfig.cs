namespace Zoopla.Selenium.Framework.Interfaces
{
    public interface ISeleniumConfig
    {
        string HomePage { get; set; }
        string RegisterUserUrl { get; set; }
        string Browser { get; set; }
        string MyAccountUrl { get; set; }
        string ToRentUrl { get; set; }
        string ForSaleUrl { get; set; }
        string HousePricesUrl { get; set; }
        string DataFile { get; set; }
        string TravelTimeUrl { get; set; }


    }
}
