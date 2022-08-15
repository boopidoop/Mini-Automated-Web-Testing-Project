using OpenQA.Selenium;

namespace MiniAutomatedWebTestingFramework.lib.pages
{
    public class SD_ProductsPage
    {
        private IWebDriver _seleniumDriver;
        private SD_SignInPage _signinPage;

        private string _productsPageURL = "https://www.saucedemo.com/inventory.html";
        private IWebElement _inventoryItemImage => _seleniumDriver.FindElement(By.ClassName("inventory_item_img"));
        private IWebElement _inventoryItemName => _seleniumDriver.FindElement(By.ClassName("inventory_item_name"));

        // Sort Items dropdown element.
        private IWebElement _sortProductsDropDown => _seleniumDriver.FindElement(By.ClassName("Select_Container"));

        public SD_ProductsPage(IWebDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
            _signinPage = new SD_SignInPage(seleniumDriver); // Gives access to the Signin features
        }

        public void SignIn()
        {
            _signinPage.VisitSignInPage();
            _signinPage.FillUsername("standard_user");
            _signinPage.FillPassword("secret_sauce");
            _signinPage.ClickLogin();

            Thread.Sleep(2000);
        }

        // Not sure how helpful these methods are.
        public string GetProductsPageURL() => _productsPageURL;

        // Use these in the tests methods when testing the Sort options
        public string GetSortAToZ() => "Name (A to Z)";
        public string GetSortZToA() => "Name (Z to A)";
        public string GetSortPriceLowToHigh() => "Price (low to high)";
        public string GetSortPriceHighToLow() => "Price (high to low)";

        public void VisitItemPageFromImage(string itemID)
        {
            IWebElement _itemLinkID = _inventoryItemImage.FindElement(By.Id(itemID));

            _itemLinkID.Click();
        }

        public void VisitItemPageFromName(string itemID)
        {
            IWebElement _itemLinkID = _inventoryItemName.FindElement(By.Id(itemID));

            _itemLinkID.Click();
        }

        public void SortItems(string sortType)
        {
            _sortProductsDropDown.Click();

            IWebElement sortButton = _sortProductsDropDown.FindElement(By.Name(sortType));

            sortButton.Click();
        }

        public void AddItemToCart(string buttonID)
        {
            IWebElement addButton = _seleniumDriver.FindElement(By.Id(buttonID));

            addButton.Click();
        }

        public void RemoveItemFromCart(string buttonID)
        {
            IWebElement removeButton = _seleniumDriver.FindElement(By.Id(buttonID));

            removeButton.Click();
        }
    }
}
