Feature: SD_Products

User Story 2: Products - Inspect Item

@HappyPath
Scenario: 2.1.1 Click on image takes you to its page
	Given I am on the Products Page
	When I click on the "<Item's>" image
	Then I am taken to that Item's "<page>"
	Examples: 
	| Item's          | page |
	| item_4_img_link | id=4 |

@HappyPath
Scenario: 2.2.1 Click on text takes you to its page
	Given I am on the Products Page
	When  I click on the "<Items's>" name
	Then I am taken to that Item's "<page>"
	Examples: 
	| Item's            | page |
	| item_4_title_link | id=4 |

@HappyPath
Scenario: 4.1.1 Add item to empty cart
	Given I am on the Products Page
	When I click an "<Item's>" Add to cart button
	Then that Item is added to the cart
	Examples: 
	| Item's                          |
	| add-to-cart-sauce-labs-backpack |

@HappyPath
Scenario: 5.1.1 Remove from empty cart
	Given I am on the Products Page
	When I have no Items in the cart
	Then  I should not be able to click an "<Item's>" Remove button
	Examples: 
	| Item's                     |
	| remove-sauce-labs-backpack |

@HappyPath
Scenario: 5.2.1 Remove item from cart with 1 item
	Given I am on the Products Page
	And I have an "<Item>" in the cart
	When I click that "<Item's Remove>" button
	Then that Item is removed from the cart"<Item>"
	Examples: 
	| Item                            | Item's Remove              |
	| add-to-cart-sauce-labs-backpack | remove-sauce-labs-backpack |

@HappyPath
Scenario: Visit Your Cart Page
	Given I am on the Products Page
	When I Click the Cart Button
	Then I am taken to the Your Cart Page

