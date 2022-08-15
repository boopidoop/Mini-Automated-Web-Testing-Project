
using AP_TestAutomationFramework.lib.driver_config;
using MiniAutomatedWebTestingFramework.lib.pages;
using OpenQA.Selenium;

namespace MiniAutomatedWebTestingFramework.lib
{
    public class SD_Website<T> where T : IWebDriver, new()
    {
        #region Accessible Page Objects and Selenium Driver
        public IWebDriver SeleniumDriver { get; set; }

        // Properties for the website POMs
        public SD_SignInPage SD_SignInPage { get; set; }
        public SD_ProductsPage SD_ProductsPage { get; set; }
        public SD_YourCartPage SD_YourCartPage { get; set; }
        #endregion

        public SD_Website(int pageLoadInsecs = 10, int implicitWaitInSecs = 10, bool isHeadless = false)
        {
            // Instatiate the driver
            SeleniumDriver = new SeleniumDriverConfig<T>(pageLoadInsecs, implicitWaitInSecs, isHeadless).Driver;

            // Instatiate our POMs with the selenium driver
            SD_SignInPage = new SD_SignInPage(SeleniumDriver);
            SD_ProductsPage = new SD_ProductsPage(SeleniumDriver);
            SD_YourCartPage = new SD_YourCartPage(SeleniumDriver);

        }
    }
}
