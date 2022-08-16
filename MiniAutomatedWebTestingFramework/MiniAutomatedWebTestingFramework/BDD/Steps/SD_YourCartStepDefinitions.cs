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
            SD_Website.SD_SignInPage.ClickLogin();
        }

        [Given(@"I have items\(s\) in the cart")]
        public void GivenIHaveItemsSInTheCart()
        {
            SD_Website.SD_ProductsPage.AddItemToCart("add-to-cart-sauce-labs-backpack");
            SD_Website.SD_ProductsPage.VisitYourCart();

            Assert.That(SD_Website.SD_YourCartPage.GetNumberOfItems(), Is.GreaterThanOrEqualTo(1));
        }

        [When(@"I click the checkout button")]
        public void WhenIClickTheCheckoutButton()
        {
            SD_Website.SD_YourCartPage.ClickCheckout();
        }

        [Then(@"I should not see any items in list")]
        public void ThenIShouldNotSeeAnyItemsInList()
        {
            Assert.That(SD_Website.SD_YourCartPage.GetNumberOfItems(), Is.EqualTo(0));
        }

        [Then(@"I should not be able to checkout")]
        public void ThenIShouldNotBeAbleToCheckout()
        {
            SD_Website.SD_YourCartPage.ClickCheckout();
            Assert.That(SD_Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/cart.html"));
        }

        [Then(@"I should be taken to the Checkout: Your information page")]
        public void ThenIShouldBeTakenToTheCheckoutYourInformationPage()
        {
            Assert.That(SD_Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/checkout-step-one.html"));
        }

        [When(@"I have items\(s\) in the cart")]
        public void WhenIHaveItemsSInTheCart()
        {
            SD_Website.SD_ProductsPage.AddItemToCart("add-to-cart-sauce-labs-backpack");
            SD_Website.SD_ProductsPage.VisitYourCart();

            Assert.That(SD_Website.SD_YourCartPage.GetNumberOfItems(), Is.GreaterThanOrEqualTo(1));
        }


        [When(@"I click the Continue Shopping button")]
        public void WhenIClickTheContinueShoppingButton()
        {
            SD_Website.SD_ProductsPage.VisitYourCart();
            SD_Website.SD_YourCartPage.ClickContinueShopping();
        }

        [Then(@"I should be taken to Products page")]
        public void ThenIShouldBeTakenToProductsPage()
        {
            Assert.That(SD_Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));
        }

        [Given(@"I have no items in the cart")]
        public void GivenIHaveNoItemsInTheCart()
        {
            SD_Website.SD_ProductsPage.VisitYourCart();
            Assert.That(SD_Website.SD_YourCartPage.GetNumberOfItems(), Is.EqualTo(0));
        }


        [AfterScenario]
        public void DisposeWebDriver()
        {
            SD_Website.SeleniumDriver.Dispose();
            SD_Website.SeleniumDriver.Quit();
        }

    }
}
