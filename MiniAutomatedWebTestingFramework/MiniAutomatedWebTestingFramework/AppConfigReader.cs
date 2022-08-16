using System.Configuration;

namespace MiniAutomatedWebTestingFramework
{
    public static class AppConfigReader
    {
        public static readonly string BaseUrl = ConfigurationManager.AppSettings["base_url"];
        public static readonly string SignInPageUrl = ConfigurationManager.AppSettings["signinpage_url"];
        public static readonly string ProductPageUrl = ConfigurationManager.AppSettings["productpage_url"];
        public static readonly string CheckoutYourInfo = ConfigurationManager.AppSettings["checkout_yourinfo_url"];
        public static readonly string CheckoutOverview = ConfigurationManager.AppSettings["checkout_overview_url"];
        public static readonly string CheckoutComplete = ConfigurationManager.AppSettings["checkout_complete_url"];
        public static readonly string YourCartURL = ConfigurationManager.AppSettings["your_cart_url"];
    }
}
