using MiniAutomatedWebTestingFramework.lib;
using MiniAutomatedWebTestingFramework.utils;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MiniAutomatedWebTestingFramework.BDD.Steps
{
    [Binding]
    public class SD_SignInStepDefinitions
    {
        public SD_Website<ChromeDriver> SD_Website { get; } = new SD_Website<ChromeDriver>();
        private Credentials _credentials;

        [Given(@"I am on the SignIn page")]
        public void GivenIAmOnTheSignInPage()
        {
            SD_Website.SD_SignInPage.VisitSignInPage();
        }

        [Given(@"I provide valid credentials")]
        public void GivenIProvideValidCredentials()
        {
            SD_Website.SD_SignInPage.FillUsername("standard_user");
            SD_Website.SD_SignInPage.FillPassword("secret_sauce");
        }



        [Then(@"I get the correct error message")]
        public void ThenIGetTheCorrectErrorMessage()
        {
            Assert.That(SD_Website.SD_SignInPage.GetErrorMessage(), Does.Contain(_credentials.ErrorMessage));
        }

        [Given(@"I provide an empty ""([^""]*)"" and/or ""([^""]*)"", with expected ""([^""]*)"":")]
        public void GivenIProvideAnEmptyAndOrWithExpected(string username, string password, string errorMessage, Table table)
        {
            _credentials = table.CreateInstance<Credentials>();
            _credentials.Username = username.Replace(" ", "");
            _credentials.Password = password.Replace(" ", "");
            _credentials.ErrorMessage = errorMessage;
            SD_Website.SD_SignInPage.InputCredentials(_credentials);
        }

        [Given(@"I enter an invalid ""([^""]*)"" and/ or ""([^""]*)"":")]
        public void GivenIEnterAnInvalidAndOr(string username, string password, Table table)
        {
            _credentials = table.CreateInstance<Credentials>();
            _credentials.Username = username;
            _credentials.Password = password;
            SD_Website.SD_SignInPage.InputCredentials(_credentials);
        }


        [Then(@"I get the correct ""([^""]*)""")]
        public void ThenIGetTheCorrect(string errorMessage, Table table)
        {
            _credentials = table.CreateInstance<Credentials>();
            _credentials.ErrorMessage = errorMessage;
            Assert.That(SD_Website.SD_SignInPage.GetErrorMessage(), Does.Contain(errorMessage));
        }


 

        [Given(@"Some or all credentials I provide are invalid:")]
        public void GivenSomeOrAllCredentialsIProvideAreInvalid(Table table)
        {
            _credentials = table.CreateInstance<Credentials>();
            SD_Website.SD_SignInPage.InputCredentials(_credentials);
        }

        [When(@"I click the Login button")]
        public void WhenIClickTheLoginButton()
        {
            SD_Website.SD_SignInPage.ClickLogin();
        }

        [Then(@"I get an error message containing ""([^""]*)""")]
        public void ThenIGetAnErrorMessageContaining(string expected)
        {
            Assert.That(SD_Website.SD_SignInPage.GetErrorMessage(), Does.Contain(expected));
        }

        [Then(@"I land on the Products page")]
        public void ThenILandOnTheProductsPage()
        {
            Assert.That(SD_Website.SeleniumDriver.Url, Does.Contain("https://www.saucedemo.com/inventory.html"));
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            SD_Website.SeleniumDriver.Quit();
        }
    }
}
