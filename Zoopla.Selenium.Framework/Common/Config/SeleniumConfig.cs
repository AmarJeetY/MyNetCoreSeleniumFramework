using Zoopla.Selenium.Framework.Interfaces;

namespace Zoopla.Selenium.Framework.Common.Config
{
    public class SeleniumConfig : ISeleniumConfig
    {
        public string RegisterUserUrl { get; set; }
        public string Browser { get; set; }
        public string MyAccountUrl { get; set; }
        public string ToRentUrl { get; set; }
        public string ForSaleUrl { get; set; }
        public string HousePricesUrl { get; set; }
        public string HomePage { get; set; }

        public string TravelTimeUrl { get; set; }

        public string DataFile { get; set; }
    }
}
