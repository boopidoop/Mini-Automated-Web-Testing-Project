Feature: SD_SignIn

The user can enter credentials on the sign in page and have them validated

@HappyPath
Scenario: 1.1.1 Empty Fields
	Given I am on the SignIn page
	And I provide an empty "<Username>" and/or "<Password>", with expected "<ErrorMessage>":
	| Username      | Password | ErrorMessage         |
	|               |          |                      |
	| standard_user |          | Password is required |
	|               |          | Username is required |
	When I click the Login button
	Then I get the correct error message

@HappyPath
Scenario: 1.2.1 Valid Credentials
	Given I am on the SignIn page
	And I provide valid credentials
	When I click the Login button
	Then I land on the Products page

@HappyPath
Scenario: 1.3.1 Invalid Credentials
	Given I am on the SignIn page
	And I enter an invalid "<Username>" and/ or "<Password>":
	| Username      | Password     | 
	| standard_user | gg           | 
	| gg            | secret_sauce |
	| gg            | gg           |
	When I click the Login button
	Then I get an error message containing "do not match"
	
