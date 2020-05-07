Feature: Login Dimension Data Workday
		As a Valid User,
		I can login Dimension Data site to manager my profile

Background: The user starts out on the login page
        Given I am on "https://auth.dimensiondata.com/adfs/ls/idpinitiatedSignon.aspx"

@Dimension @smokeTest @regression
Scenario: DD001 - Sign in Dimension Option page should be displayed
	Then The sign in option page should be dispayed
	And browser title is "Sign In"
	And the site status is "You are not signed in."
	And the radio checkbox "Sign in to this site." should be checked as default
	And the radio checkbox "Sign in to one of the following sites:" should not be checked
	And the dropdown Site selections should be hidden & disabled

@Dimension @smokeTest @regression
Scenario: DD002 - Dropdown Site selections should be enabled after checking radio button select other site
	When user click radio checkbox "Sign in to one of the following sites:"
	Then dropdown Site selections should be enabled

@Dimension @smokeTest @regression
Scenario: DD003 - Dropdown Site selections should be enabled after checking radio button select other site
	When user click radio checkbox "Sign in to one of the following sites:"
	And select dropdown Site selections "GIS - Workday"
	Then dropdown Site selections text should be "GIS - Workday"

@Dimension @smokeTest @regression
Scenario: DD004 - My Workday Home page will be displayed
	When user click radio checkbox "Sign in to one of the following sites:"
	And select dropdown Site selections "GIS - Workday"
	And click button Sign in
	And I enter valid account with user name is "erit.ha@dimensiondata.com" and password is "*******" then submit
	Then I should see the text "Welcome, Ha Erit (74853)"
	And the workday home page should be shown with title "Home - Workday"