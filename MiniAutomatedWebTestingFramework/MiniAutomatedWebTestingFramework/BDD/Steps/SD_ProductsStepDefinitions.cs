using MiniAutomatedWebTestingFramework.lib;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace MiniAutomatedWebTestingFramework.BDD.Steps
{
    [Binding]
    public class SD_ProductsStepDefinitions
    {
        public SD_Website<ChromeDriver> SD_Website { get; } = new SD_Website<ChromeDriver>();

        [Given(@"I am on the Products Page")]
        public void GivenIAmOnTheProductsPage()
        {
            SD_Website.SD_ProductsPage.SignIn();
        }

        [When(@"I click on the Item's image")]
        public void WhenICkickOnTheItemsImage()
        {
            string productsImageLink = "item_4_img_link";

            SD_Website.SD_ProductsPage.VisitItemPageFromImage(productsImageLink);
        }

        [Then(@"I am taken to that Item's page")]
        public void ThenIAmTakenToThatItemsPage()
        {
            string productsURLID = "id=4";

            Assert.That(SD_Website.SeleniumDriver.Url, Is.EqualTo($"https://www.saucedemo.com/inventory-item.html?{productsURLID}"));
        }

        [When(@"I click an ""([^""]*)"" Add to cart button")]
        public void WhenIClickAnAddToCartButton(string itemName)
        {
            SD_Website.SD_ProductsPage.AddItemToCart(itemName);
        }


        [Then(@"that Item is added to the cart")]
        public void ThenThatItemIsAddedToTheCart()
        {
            Assert.That(SD_Website.SD_ProductsPage.GetCartTotalNumber, Is.EqualTo("1"));
        }

        [When(@"I Click the Cart Button")]
        public void WhenIClickTheCartButton()
        {
            SD_Website.SD_ProductsPage.VisitYourCart();
        }

        [Then(@"I am taken to the Your Cart Page")]
        public void ThenIAmTakenToTheYourCartPage()
        {
            Assert.That(SD_Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/cart.html"));
        }


        [AfterScenario]
        public void DisposeWebDriver()
        {
            SD_Website.SeleniumDriver.Quit();
        }
    }
}
