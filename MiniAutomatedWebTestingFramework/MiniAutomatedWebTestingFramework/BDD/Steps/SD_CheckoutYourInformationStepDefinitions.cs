using MiniAutomatedWebTestingFramework.lib;
using MiniAutomatedWebTestingFramework.utils;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MiniAutomatedWebTestingFramework.BDD.Steps
{
    [Binding]
    public class SD_CheckoutYourInformationStepDefinitions
    {
        public SD_Website<ChromeDriver> SD_Website { get; } = new SD_Website<ChromeDriver>();
        private CustomerDetails _customerDetails;

        [Given(@"I am on the CheckoutYourInformation page")]
        public void GivenIAmOnTheCheckoutYourInformationPage()
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
        }

        [Given(@"I enter valid ""([^""]*)"", ""([^""]*)"" and ""([^""]*)"" credentials into all fields")]
        public void GivenIEnterValidAndCredentialsIntoAllFields(string firstName, string lastName, string postalCode, Table table)
        {
            _customerDetails = table.CreateInstance<CustomerDetails>();
            _customerDetails.firstName = firstName.Replace(" ", "");
            _customerDetails.lastName = lastName.Replace(" ", "");
            _customerDetails.postalCode = postalCode.Replace(" ", "");
            SD_Website.SD_CheckoutYourInformation.FillCustomerDetails(_customerDetails);
        }

        [Given(@"I enter an invalid ""([^""]*)""")]
        public void GivenIEnterAnInvalidPostalOrZipCode(string postalCode, Table table)
        {
            SD_Website.SD_CheckoutYourInformation.FillFirstName("Jane");
            SD_Website.SD_CheckoutYourInformation.FillLastName("Doe");
            SD_Website.SD_CheckoutYourInformation.FillPostalCode(postalCode);
        }

        [When(@"I click on Continue")]
        public void WhenIClickOnContinue()
        {
            SD_Website.SD_CheckoutYourInformation.ClickContinue();
        }

        [Then(@"I should be shown an error")]
        public void ThenIShouldBeShownAnError()
        {
            Assert.That(SD_Website.SD_CheckoutYourInformation.GetErrorMessage(), Is.Not.Null);
        }

        [Then(@"should stay on the Checkout - Your Information page")]
        public void ThenShouldStayOnThePage()
        {
            Assert.That(SD_Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/checkout-step-one.html"));
        }

        [Then(@"I should land on the Overview page")]
        public void ThenIShouldLandOnTheOverviewPage()
        {
            Assert.That(SD_Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/checkout-step-two.html"));
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            SD_Website.SeleniumDriver.Quit();
        }
    }
}
