using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAutomatedWebTestingFramework.lib.pages
{
    public class SD_YourCartPage
    {
        #region Parameters
        private IWebDriver _seleniumDriver;
        private string _YourCartPageUrl = AppConfigReader.YourCart;
        private List<IWebElement> _cartItem => _seleniumDriver.FindElements(By.ClassName("cart_item")).ToList();
        private List<IWebElement> _cartItemName => _cartItem.Select(x => x.FindElement(By.ClassName("inventory_item_name"))).ToList();
        private List<IWebElement> _cartItemDescription => _cartItem.Select(x => x.FindElement(By.ClassName("inventory_item_desc"))).ToList();
        private List<IWebElement> _cartItemQuantity => _cartItem.Select(x => x.FindElement(By.ClassName("inventory_item_price"))).ToList();
        private IWebElement _checkoutButton => _seleniumDriver.FindElement(By.Id("checkout"));
        private IWebElement _continueShoppingButon => _seleniumDriver.FindElement(By.Id("continue-shopping"));
        #endregion

        #region Methods
        public SD_YourCartPage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;
        public IWebElement GetItem(int i) => _cartItem[i];
        public string GetItemName(int i) => _cartItemName[i].Text;
        public string GetItemDescription(int i) => _cartItemDescription[i].Text;
        public int GetItemQuantity(int i) => Int32.Parse(_cartItemQuantity[i].Text);
        public void RemoveItem(string id) => _seleniumDriver.FindElements(By.ClassName("btn")).Where(x => x.Text == "Remove").Select(x => x.FindElement(By.Id(id))).ToArray()[0].Click();
        public void ClickCheckout() => _checkoutButton.Click();
        public void ClickContinueShopping() => _continueShoppingButon.Click();
        public string GetURL() => _YourCartPageUrl;
        #endregion
    }
}
