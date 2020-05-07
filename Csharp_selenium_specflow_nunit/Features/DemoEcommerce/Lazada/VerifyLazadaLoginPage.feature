Feature: Verify Lazada Login Page
	In order to avoid Lazada Home Page not working
	As a valid/invalid Users
	I want to be logged into Lazada page
 
@LZD002 @lzsmokeTest
Scenario: LZD002 Login LAZADA Page should be displayed after clicking link Login
	Given I navigated to Lazada Home Page
	And I click the link Login
	Then The login page title should be "AAAALazada.vn: Online Shopping Vietnam - Mobiles, Tablets, Home Appliances, TV, Audio &amp; More"