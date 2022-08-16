Feature: SD_CheckoutOverview

To list and check items in the shopping cart before payment

@HappyPath
Scenario: 9.7.1 Finish Button
	Given I am on the Checkout Overview page
	When I click the Finish button
	Then I am taken to the Order Complete page
