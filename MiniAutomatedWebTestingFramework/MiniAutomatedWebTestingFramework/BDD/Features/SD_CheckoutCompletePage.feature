Feature: SD_CheckoutCompletePage

As a user, I want a page to tell me the order process is complete and my package is on its way

@HappyPath
Scenario: Clicking on "Back Home" button
	Given I am on the Checkout Complete page
	When I click the BackHome button
	Then I am taken back to the Products page
