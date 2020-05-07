Feature: Verify Lazada Home Page
	In order to avoid Lazada Home Page not working
	As a valid/invalid Users
	I want to be logged into Lazada page
 
@LZD001 @lzsmokeTest
Scenario: LZD001 Home Page is LAZADA Page
	Given I navigated to "https://www.lazada.vn"
	Then browser title is "Shopping online - Buy online on Lazada.vn"