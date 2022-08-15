using MiniAutomatedWebTestingFramework.lib;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace MiniAutomatedWebTestingFramework.BDD.Steps
{
    [Binding]
    public class SD_YourCartStepDefinitions
    {
        public SD_Website<ChromeDriver> SD_Website { get; } = new SD_Website<ChromeDriver>();

        [Given(@"I am on the Your Cart page")]
        public void GivenIAmOnTheYourCartPage()
        {
            //Sign in page
            SD_Website.SD_SignInPage.VisitSignInPage();
            SD_Website.SD_SignInPage.FillUsername("standard_user");
            SD_Website.SD_SignInPage.FillPassword("secret_sauce");

            //Products page
            SD_Website.SD_ProductsPage.AddItemToCart("add-to-cart-sauce-labs-backpack");
            SD_Website.SD_ProductsPage.VisitYourCart();
        }

        [Given(@"I have items\(s\) in the cart")]
        public void GivenIHaveItemsSInTheCart()
        {
            Assert.That(SD_Website.SD_YourCartPage.GetNumberOfItems(), Is.GreaterThanOrEqualTo(1));
        }

        [When(@"I click the checkout button")]
        public void WhenIClickTheCheckoutButton()
        {
            SD_Website.SD_YourCartPage.ClickCheckout();
        }

        [Then(@"I should be taken to the Checkout: Your information page")]
        public void ThenIShouldBeTakenToTheCheckoutYourInformationPage()
        {
            Assert.That(SD_Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/checkout-step-one.html"));
        }
    }
}
