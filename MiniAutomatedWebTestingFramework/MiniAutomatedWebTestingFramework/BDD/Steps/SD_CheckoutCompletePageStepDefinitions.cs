using MiniAutomatedWebTestingFramework.lib;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace MiniAutomatedWebTestingFramework.BDD.Steps
{
    [Binding]
    public class SD_CheckoutCompletePageStepDefinitions
    {
        private SD_Website<ChromeDriver> SD_Website = new SD_Website<ChromeDriver>();

        [Given(@"I am on the Checkout Complete page")]
        public void GivenIAmOnTheCheckoutCompletePage()
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

            // Click Finish
            SD_Website.SD_CheckoutOverviewPage.ClickFinish();
        }

        [When(@"I click the BackHome button")]
        public void WhenIClickTheBackHomeButton()
        {
            SD_Website.SD_CheckoutCompletePage.ClickBackHomeButton();
        }

        [Then(@"I am taken back to the Products page")]
        public void ThenIAmTakenBackToTheProductsPage()
        {
            Assert.That(SD_Website.SeleniumDriver.Url, Is.EqualTo(AppConfigReader.ProductPageUrl));
        }
    }
}
