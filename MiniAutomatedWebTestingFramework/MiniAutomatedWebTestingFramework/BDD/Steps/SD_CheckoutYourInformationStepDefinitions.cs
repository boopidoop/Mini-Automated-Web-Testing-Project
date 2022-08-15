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
            throw new PendingStepException();
        }

        [Given(@"I enter valid ""([^""]*)"", ""([^""]*)"" and ""([^""]*)"" credentials into all fields")]
        public void GivenIEnterValidAndCredentialsIntoAllFields(string firstName, string lastName, string postalCode, Table table)
        {
            _customerDetails = table.CreateInstance<CustomerDetails>();
            _customerDetails.firstName = firstName.Replace(" ", "");
            _customerDetails.lastName = firstName.Replace(" ", "");
            _customerDetails.postalCode = postalCode.Replace(" ", "");
            SD_Website.SD_CheckYourInformation.FillCustomerDetails(_customerDetails);
        }

        [When(@"I click on Continue")]
        public void WhenIClickOnContinue()
        {
            SD_Website.SD_CheckYourInformation.ClickContinue();
        }

        [Then(@"I should land on the Overview page")]
        public void ThenIShouldLandOnTheOverviewPage()
        {
            throw new PendingStepException();
        }
    }
}
