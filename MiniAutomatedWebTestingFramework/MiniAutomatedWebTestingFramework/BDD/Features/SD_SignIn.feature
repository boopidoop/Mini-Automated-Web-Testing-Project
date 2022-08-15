Feature: SD_SignIn

The user can enter credentials on the sign in page and have them validated

@HappyPath
Scenario: 1.2.1 Valid Credentials
	Given I am on the SignIn page
	And I provide valid credentials
	When I click the Login button
	Then I land on the Products page
