Feature: SD_YourCart

User shouldbe able to manage their cart on this page, proceed to checkout and return to shopping

@HappyPath
Scenario: Quantity is correct

@HappyPath
Scenario: 7.6.1 Checkout
	Given I am on the Your Cart page
	And I have items(s) in the cart
	When I click the checkout button
	Then I should be taken to the Checkout: Your information page
