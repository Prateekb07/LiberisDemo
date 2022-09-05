Feature: Liberis Demo

@TC1
Scenario: Verify user landed on partner selection page
	Given User opens the URL "https://www.liberis.com/"
	When User clicks on 'Get a Demo' button
	Then Verify user is landed on partner page with all types of partners displayed