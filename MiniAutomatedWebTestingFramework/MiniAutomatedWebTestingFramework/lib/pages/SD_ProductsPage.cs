using OpenQA.Selenium;

namespace MiniAutomatedWebTestingFramework.lib.pages
{
    public class SD_ProductsPage
    {
        #region Parameters
        private IWebDriver _seleniumDriver;
        private SD_SignInPage _signinPage;

        private IWebElement _inventoryItemImage => _seleniumDriver.FindElement(By.ClassName("inventory_item_img"));
        private IWebElement _inventoryItemLabel => _seleniumDriver.FindElement(By.ClassName("inventory_item_label"));

        private IWebElement _sortProductsDropDown => _seleniumDriver.FindElement(By.ClassName("select_container"));
        private IWebElement _shoppingCartButton => _seleniumDriver.FindElement(By.Id("shopping_cart_container"));
        private IWebElement _shoppingCartBadge => _seleniumDriver.FindElement(By.ClassName("shopping_cart_badge"));
        #endregion

        #region Methods
        public SD_ProductsPage(IWebDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
            _signinPage = new SD_SignInPage(seleniumDriver);
        }

        public void SignIn()
        {
            _signinPage.VisitSignInPage();
            _signinPage.FillUsername("standard_user");
            _signinPage.FillPassword("secret_sauce");
            _signinPage.ClickLogin();

            Thread.Sleep(2000);
        }

        public string GetProductsPageURL() => AppConfigReader.ProductPageUrl;

        public string GetSortAToZ() => "Name (A to Z)";
        public string GetSortZToA() => "Name (Z to A)";
        public string GetSortPriceLowToHigh() => "Price (low to high)";
        public string GetSortPriceHighToLow() => "Price (high to low)";

        public void VisitYourCart() => _shoppingCartButton.Click();

        public void VisitItemPageFromImage(string itemID)
        {
            IWebElement _itemLinkButton = _inventoryItemImage.FindElement(By.Id(itemID));

            _itemLinkButton.Click();
        }

        public void VisitItemPageFromName(string itemID)
        {
            IWebElement _itemLinkButton = _inventoryItemLabel.FindElement(By.Id(itemID));

            _itemLinkButton.Click();
        }

        public void SortItems(string sortType)
        {
            _sortProductsDropDown.Click();

            IWebElement sortButton = _sortProductsDropDown.FindElement(By.Name(sortType));

            sortButton.Click();
        }

        public bool ProductButtonCheck(string item)
        {
            IWebElement addButton = _seleniumDriver.FindElement(By.Id(item));

            if (addButton != null)
            {
                return true;
            }

            return false;
        }

        public void AddItemToCart(string buttonID)
        {
            IWebElement addButton = _seleniumDriver.FindElement(By.Id(buttonID));

            addButton.Click();

            Thread.Sleep(1000);
        }

        public void RemoveItemFromCart(string buttonID)
        {
            IWebElement removeButton = _seleniumDriver.FindElement(By.Id(buttonID));

            removeButton.Click();
        }

        public string GetCartTotalNumber()
        {
            return _shoppingCartBadge.Text;
        }

        public bool ShoppingCartBadgeCheck()
        {
            if (_shoppingCartBadge != null)
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}
