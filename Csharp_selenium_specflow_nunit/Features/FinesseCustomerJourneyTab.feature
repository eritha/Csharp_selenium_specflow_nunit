Feature: FinesseCustomerJourneyTab
	As a AIA Agent 
	I want to be logged into agent desktop
	Then verify the Customer Journey tab

Background: The user starts out on the login page
        Given I am on "file:///C:/WebContent/test_cust_journey.html"

@ALL @Gadget @CustomerJourneyTab
Scenario: TC003 - Verify Customer Journey Tab - No incomming call
	Then The Customer Journey tab should be displayed successfully
