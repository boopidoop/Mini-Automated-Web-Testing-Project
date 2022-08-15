Feature: SD_YourCart

User shouldbe able to manage their cart on this page, proceed to checkout and return to shopping

@HappyPath
Scenario: 7.1.1 Quantity is correct
	Given I am on the Your Cart page
	When I have items(s) in the cart
	Then the quantity should be the same

Scenario: 7.2.1 Quantity can be changed
	Given I am on the Your Cart page
	And I have items(s) in the cart
	When I click on the quantity field
	Then I should be able to change the quantity

Scenario: 7.3.1 Name is correct
	Given I am on the Your Cart page
	When I have items(s) in the cart
	Then the item name is correct

Scenario: 7.3.2 Description is correct
	Given I am on the Your Cart page
	When I have item(s) in the cart
	Then the item description is correct

Scenario: 7.4.1 Remove item
	Given I am on the Your Cart page
	And I have items(s) in the cart
	When I click the item's remove button
	Then that item should be removed from cart
	
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

Scenario: 7.7.1 Inspect item
	Given I am on the Your Cart page
	And I have items(s) in the cart
	When I click that item's name
	Then I should be taken to that item's page

Scenario: 7.8.1 Click on cart
	Given I am on the Your Cart page
	When I Click the Cart Button
	Then I should stay on the Your Cart page

Scenario: 7.9.1 Empty cart
	Given I am on the Your Cart page
	And I have no items in the cart
	Then I should not see any items in list
	And I should not be able to chekcout 
