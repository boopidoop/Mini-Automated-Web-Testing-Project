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

        [Given(@"I have an ""([^""]*)"" in the cart")]
        public void GivenIHaveAnInTheCart(string item)
        {
            SD_Website.SD_ProductsPage.AddItemToCart(item);
        }

        [When(@"I click on the ""([^""]*)"" image")]
        public void WhenIClickOnTheImage(string itemImageID)
        {
            SD_Website.SD_ProductsPage.VisitItemPageFromImage(itemImageID);
        }

        [When(@"I click on the ""([^""]*)"" name")]
        public void WhenIClickOnTheName(string itemNameID) // This should work but fails saying: Unable to locate element.
        {
            SD_Website.SD_ProductsPage.VisitItemPageFromName(itemNameID);
        }

        [Then(@"I am taken to that Item's ""([^""]*)""")]
        public void ThenIAmTakenToThatItems(string pageID)
        {
            Assert.That(SD_Website.SeleniumDriver.Url, Is.EqualTo($"https://www.saucedemo.com/inventory-item.html?{pageID}"));
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

        [When(@"I have no Items in the cart")]
        public void WhenIHaveNoItemsInTheCart()
        {
            Assert.That(SD_Website.SD_ProductsPage.ShoppingCartBadgeCheck()); // Not sure how to check the cart is empty on the products page, Test will Fail.
        }

        [Then(@"I should not be able to click an ""([^""]*)"" Remove button")]
        public void ThenIShouldNotBeAbleToClickAnRemoveButton(string item)
        {
            Assert.That(!SD_Website.SD_ProductsPage.ProductButtonCheck(item));
        }

        [When(@"I click that ""([^""]*)"" button")]
        public void WhenIClickThatButton(string item)
        {
            SD_Website.SD_ProductsPage.RemoveItemFromCart(item);
        }

        [Then(@"that Item is removed from the cart")]
        public void ThenThatItemIsRemovedFromTheCart()
        {
            Assert.That(SD_Website.SD_ProductsPage.GetCartTotalNumber(), Is.Null);
        }

        [Then(@"that Item is removed from the cart""([^""]*)""")]
        public void ThenThatItemIsRemovedFromTheCart(string item)
        {
            Assert.That(SD_Website.SD_ProductsPage.ProductButtonCheck(item));
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
