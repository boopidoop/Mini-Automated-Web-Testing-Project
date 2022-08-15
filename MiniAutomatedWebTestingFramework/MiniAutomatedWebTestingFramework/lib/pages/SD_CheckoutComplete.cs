using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAutomatedWebTestingFramework.lib.pages
{
    public class SD_CheckoutComplete
    {
        #region Parameters
        private IWebDriver _seleniumDriver;
        private string _CheckoutCompletedPageUrl = AppConfigReader.CheckoutComplete;

        private IWebElement _completionText => _seleniumDriver.FindElement(By.ClassName("complete-text"));
        private IWebElement _completionImage => _seleniumDriver.FindElement(By.ClassName("pony_express"));
        private IWebElement _backHomeButton => _seleniumDriver.FindElement(By.Id("back-to-products"));
        #endregion

        #region Methods
        public string GetCompletionText() => _completionText.Text;
        public void ClickBackHomeButton() => _backHomeButton.Click();
        #endregion
    }
}
