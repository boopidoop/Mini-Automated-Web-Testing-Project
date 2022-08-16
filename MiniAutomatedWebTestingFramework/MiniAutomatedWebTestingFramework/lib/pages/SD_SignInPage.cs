using MiniAutomatedWebTestingFramework.utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAutomatedWebTestingFramework.lib.pages
{
    public class SD_SignInPage
    {
        private IWebDriver _seleniumDriver;
        private string _SignInPageUrl = AppConfigReader.BaseUrl;
        private IWebElement _usernameField => _seleniumDriver.FindElement(By.Id("user-name"));
        private IWebElement _passwordField => _seleniumDriver.FindElement(By.Id("password"));
        private IWebElement _loginButton => _seleniumDriver.FindElement(By.Id("login-button"));
        private IWebElement _errorMessage => _seleniumDriver.FindElement(By.ClassName("error-message-container"));


        public SD_SignInPage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        public void VisitSignInPage() => _seleniumDriver.Navigate().GoToUrl(_SignInPageUrl);
        public void FillUsername(string username) => _usernameField.SendKeys(username);
        public void FillPassword(string password) => _passwordField.SendKeys(password);
        public void InputCredentials(Credentials credentials)
        {
            FillUsername(credentials.Username);
            FillPassword(credentials.Password);
        }
        public void ClickLogin() => _loginButton.Click();
        public string GetErrorMessage() => _errorMessage.Text;
    }
}
