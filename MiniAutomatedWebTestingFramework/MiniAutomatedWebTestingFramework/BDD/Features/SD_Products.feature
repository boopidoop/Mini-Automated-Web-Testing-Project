Feature: SD_Products

User Story 2: Products - Inspect Item

@HappyPath
Scenario: 2.1.1 Click on image takes you to its page
	Given I am on the Products Page
	When I click on the Item's image
	Then I am taken to that Item's page

@HappyPath
Scenario: 4.1.1 Add item to empty cart
	Given I am on the Products Page
	When I click an "<Item's>" Add to cart button
	Then that Item is added to the cart
	Examples: 
	| Item's                          |
	| add-to-cart-sauce-labs-backpack |

@HappyPath
Scenario: Visit Your Cart Page
	Given I am on the Products Page
	When I Click the Cart Button
	Then I am taken to the Your Cart Page

