using MiniAutomatedWebTestingFramework.lib;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace MiniAutomatedWebTestingFramework.BDD.Steps
{
    [Binding]
    public class SD_SignInStepDefinitions
    {
        public SD_Website<ChromeDriver> SD_Website { get; } = new SD_Website<ChromeDriver>();

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

        [When(@"I click the Login button")]
        public void WhenIClickTheLoginButton()
        {
            SD_Website.SD_SignInPage.ClickLogin();
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
