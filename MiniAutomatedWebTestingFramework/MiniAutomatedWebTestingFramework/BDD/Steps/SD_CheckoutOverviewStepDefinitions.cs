using MiniAutomatedWebTestingFramework.lib;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace MiniAutomatedWebTestingFramework.BDD.Steps
{
    [Binding]
    public class SD_CheckoutOverviewStepDefinitions
    {
        public SD_Website<ChromeDriver> SD_Website { get; } = new SD_Website<ChromeDriver>();

        [Given(@"I am on the Checkout Overview page")]
        public void GivenIAmOnTheCheckoutOverviewPage()
        {
            // Sign In Page
            SD_Website.SD_SignInPage.VisitSignInPage();
            SD_Website.SD_SignInPage.FillUsername("standard_user");
            SD_Website.SD_SignInPage.FillPassword("secret_sauce");
            SD_Website.SD_SignInPage.ClickLogin();

            // Products Page
            SD_Website.SD_ProductsPage.AddItemToCart("add-to-cart-sauce-labs-backpack");
            SD_Website.SD_ProductsPage.VisitYourCart();

            // Your Cart Page
            SD_Website.SD_YourCartPage.ClickCheckout();

            // Checkout Your Information
            SD_Website.SD_CheckoutYourInformation.FillFirstName("Jim");
            SD_Website.SD_CheckoutYourInformation.FillLastName("Smith");
            SD_Website.SD_CheckoutYourInformation.FillPostalCode("SW1A 1AA");
            SD_Website.SD_CheckoutYourInformation.ClickContinue();
        }

        [When(@"I click the Finish button")]
        public void WhenIClickTheFinishButton()
        {
            SD_Website.SD_CheckoutOverviewPage.ClickFinish();
        }

        [Then(@"I am taken to the Order Complete page")]
        public void ThenIAmTakenToTheOrderCompletePage()
        {
            Assert.That(SD_Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/checkout-complete.html"));
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            SD_Website.SeleniumDriver.Quit();
        }
    }
}
