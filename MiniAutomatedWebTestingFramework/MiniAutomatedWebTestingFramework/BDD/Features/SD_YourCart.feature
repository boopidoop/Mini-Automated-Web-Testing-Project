Feature: SD_YourCart

User shouldbe able to manage their cart on this page, proceed to checkout and return to shopping
	
@HappyPath
Scenario: 7.5.1 Continue shopping
	Given I am on the Your Cart page
	When I click the Continue Shopping button
	Then I should be taken to Products page

@HappyPath
Scenario: 7.6.1 Checkout
	Given I am on the Your Cart page
	And I have items(s) in the cart
	When I click the checkout button
	Then I should be taken to the Checkout: Your information page

@SadPath
Scenario: 7.9.1 Empty cart
	Given I am on the Your Cart page
	And I have no items in the cart
	Then I should not see any items in list
	And I should not be able to checkout 
