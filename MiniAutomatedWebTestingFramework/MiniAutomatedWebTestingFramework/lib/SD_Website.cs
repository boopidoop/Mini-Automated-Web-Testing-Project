﻿
using AP_TestAutomationFramework.lib.driver_config;
using OpenQA.Selenium;

namespace MiniAutomatedWebTestingFramework.lib
{
    public class SD_Website<T> where T : IWebDriver, new()
    {
        #region Accessible Page Objects and Selenium Driver
        public IWebDriver SeleniumDriver { get; set; }

        // Properties for the website POMs
        #endregion
        public SD_Website(int pageLoadInsecs = 10, int implicitWaitInSecs = 10, bool isHeadless = false)
        {
            // Instatiate the driver
            SeleniumDriver = new SeleniumDriverConfig<T>(pageLoadInsecs, implicitWaitInSecs, isHeadless).Driver;
            
            // Instatiate our POMs with the selenium driver
        }
    }
}
