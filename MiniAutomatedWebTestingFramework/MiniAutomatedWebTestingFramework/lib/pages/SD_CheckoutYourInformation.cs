using OpenQA.Selenium;

namespace MiniAutomatedWebTestingFramework.lib.pages
{
    public class SD_CheckoutYourInformation
    {
        private IWebDriver _seleniumDriver;

        private string _CheckoutStepOnePageUrl = AppConfigReader.CheckoutYourInfo;
        private IWebElement _firstNameField => _seleniumDriver.FindElement(By.Id("first-name"));
        private IWebElement _lastNameField => _seleniumDriver.FindElement(By.Id("last-name"));
        private IWebElement _postalCodeField => _seleniumDriver.FindElement(By.Id("postal-code"));
        private IWebElement _continueButton => _seleniumDriver.FindElement(By.Id("continue"));
        private IWebElement _cancelButton => _seleniumDriver.FindElement(By.Id("cancel"));
        private IWebElement _errorMessageContainer => _seleniumDriver.FindElement(By.ClassName("error-message-container error"));

        private IWebElement _shoppingCartLink => _seleniumDriver.FindElement(By.ClassName("shopping_cart_link"));
        private IWebElement _shoppingCartBadge => _seleniumDriver.FindElement(By.ClassName("shopping_cart_badge"));
        
        
        private IWebElement _burgerMenuButton => _seleniumDriver.FindElement(By.Id("react-burger-menu-btn"));
        private IWebElement _burgerAllItemsLink => _seleniumDriver.FindElement(By.Id("inventory_sidebar_link"));
        private IWebElement _burgerAboutLink => _seleniumDriver.FindElement(By.Id("about_sidebar_link"));
        private IWebElement _burgerLogoutLink => _seleniumDriver.FindElement(By.Id("logout_sidebar_link"));
        private IWebElement _burgerResetAppStateLink => _seleniumDriver.FindElement(By.Id("reset_sidebar_link"));

        private IWebElement _twitterLink => _seleniumDriver.FindElement(By.ClassName("social_twitter"));
        private IWebElement _facebookLink => _seleniumDriver.FindElement(By.ClassName("social_facebook"));
        private IWebElement _linkedinLink => _seleniumDriver.FindElement(By.ClassName("social_linkedin"));

        public SD_CheckoutYourInformation(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;

        // Main page elements
        public void VisitSignInPage() => _seleniumDriver.Navigate().GoToUrl(_CheckoutStepOnePageUrl);
        public void FillFirstName(string firstName) => _firstNameField.SendKeys(firstName);
        public void FillLastName(string lastName) => _lastNameField.SendKeys(lastName);
        public void FillPostalCode(string postalCode) => _postalCodeField.SendKeys(postalCode);
        public void ClickContinue() => _continueButton.Click();
        public void ClickCancel() => _cancelButton.Click();
        public string GetErrorMessage() => _errorMessageContainer.Text;

        // Banner Shopping Cart elements
        public void ClickOnShoppingCart() => _shoppingCartLink.Click();
        public string GetShoppingCartText() => _shoppingCartBadge.Text;

        // Burger Elements
        public void ClickOnBurger() => _burgerMenuButton.Click();
        public void ClickOnBurgerInventory() => _burgerAllItemsLink.Click();
        public void ClickOnBurgerAbout() => _burgerAboutLink.Click();
        public void ClickOnBurgerLogout() => _burgerLogoutLink.Click();
        public void ClickOnBurgerResetApp() => _burgerResetAppStateLink.Click();

        // Socials Elements
        public void ClickOnTwitter() => _twitterLink.Click();
        public void ClickOnFacebook() => _facebookLink.Click();
        public void ClickOnLinkedIn() => _linkedinLink.Click();
    }
}
