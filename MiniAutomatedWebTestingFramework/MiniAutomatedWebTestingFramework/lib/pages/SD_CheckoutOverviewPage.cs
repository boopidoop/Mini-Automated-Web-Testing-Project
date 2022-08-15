using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAutomatedWebTestingFramework.lib.pages;

public class SD_CheckoutOverviewPage
{
    #region Parameters
    private IWebDriver _seleniumDriver;
    private string _CheckoutOverviewPageUrl = AppConfigReader.CheckoutOverview;
    private List<IWebElement> _cartItem => _seleniumDriver.FindElements(By.ClassName("cart_item")).ToList();
    private List<IWebElement> _cartItemName => _cartItem.Select(x => x.FindElement(By.ClassName("inventory_item_name"))).ToList();
    private List<IWebElement> _cartItemDescription => _cartItem.Select(x => x.FindElement(By.ClassName("inventory_item_desc"))).ToList();
    private List<IWebElement> _cartItemQuantity => _cartItem.Select(x => x.FindElement(By.ClassName("inventory_item_price"))).ToList();
    private IWebElement _subTotal => _seleniumDriver.FindElement(By.ClassName("summary_subtotal_label"));
    private IWebElement _taxTotal => _seleniumDriver.FindElement(By.ClassName("summary_tax_label"));
    private IWebElement _total => _seleniumDriver.FindElement(By.ClassName("summary_total_label"));
    private IWebElement _cancelButton => _seleniumDriver.FindElement(By.Id("cancel"));
    private IWebElement _finishButton => _seleniumDriver.FindElement(By.Id("finish"));
    #endregion

    #region Methods
    public SD_CheckoutOverviewPage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;
    public IWebElement GetItem(int i) => _cartItem[i];
    public string GetItemName(int i) => _cartItemName[i].Text;
    public string GetItemDescription(int i) => _cartItemDescription[i].Text;
    public int GetItemQuantity(int i) => Int32.Parse(_cartItemQuantity[i].Text);
    public int GetSubtotal() => Int32.Parse(_subTotal.Text.Replace("Item total: $",""));
    public int GetTaxTotal() => Int32.Parse(_taxTotal.Text.Replace("Tax: $",""));
    public int GetTotal() => Int32.Parse(_total.Text.Replace("Total: $",""));
    public void ClickCancel() => _cancelButton.Click();
    public void ClickFinish() => _finishButton.Click();
    public string GetURL() => _CheckoutOverviewPageUrl;
    #endregion
}
