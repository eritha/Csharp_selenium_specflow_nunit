Feature: FinesseWrapUpTab
	As a AIA Agent 
	I want to be logged into agent desktop
	Then verify the Wrap Up tab

Background: The user starts out on the login page
        Given I am on "file:///C:/WebContent/test_wrapup.html"

@ALL @Gadget @WrapUpTab
Scenario: TC004 - Verify Wrap Up - No incomming call
	Then The Wrap Up tab should be displayed successfully

