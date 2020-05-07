Feature: FinesseCallInfoTab
	As a AIA Agent 
	I want to be logged into agent desktop
	Then verify call info tab

Background: The user starts out on the login page
        Given I am on "file:///C:/WebContent/test_callinfo.html"

@ALL @Gadget @CallInfoTab
Scenario: TC002 - Verify Call Info Tab - No incomming call
	Then The Call Info tab should be displayed successfully
