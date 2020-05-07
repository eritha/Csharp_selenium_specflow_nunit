Feature: LoginFinesse
	As a AIA Agent 
	I want to be logged into agent desktop

Background: The user starts out on the login page
        Given I am on "https://hhufinessepub.telecentre.com/desktop/container/landing.jsp?locale=en_US"

@ALL @LoginFinesse
Scenario: TC001 - Login Finesse Desktop
	When The Sign In Landing page is displayed 
	And I enter the valid user name is "uatagent.erit"
	And Clicking the button Next
	Then I enter the valid password is "NTTCreate@9" and extension "34509"
	And Clicking the button Sign In
	Then The finesse desktop should be displayed successfully
