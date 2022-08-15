Feature: SD_CheckoutYourInformation

Enter First Name, Last Name and Postal/Zip Code for an order

@HappyPath
Scenario: 8.1.1 Enter credentials in all fields (Valid)
	Given I am on the CheckoutYourInformation page
	And I enter valid "<firstName>", "<lastName>" and "<postalCode>" credentials into all fields
	| firstName     | lastName | postalCode |
	|               |          |                      |
	| James         | Clark    | SW1A 1AA |
	| Jane          | Doe      | 37188    |
	When I click on Continue
	Then I should land on the Overview page
