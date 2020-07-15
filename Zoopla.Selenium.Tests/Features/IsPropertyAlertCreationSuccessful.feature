Feature: EmailAlerts
	In order to get property alerts for my desired property
	As a Zoopla user
	I want to regsister myself to Zoopla website and get property alerts


@registerAndUpdatePropertyAlert
Scenario: Create and Update email alert
	Given I have registered on Zoopla with <myprofile> and logged in		
	When I try to search property described in <testcase>
	Then I am able to save search and register for saved search in form of email alerts with frequency of <alertfrequency>
	And I am able to update to new email frequency of <changetoalertfrequency>
	And I am able to retrieve results in saved search

	# Please refer to SearchParameters.csv file in TestData folder
	# for search query parameters
	Examples: 
	| testcase         | description                                        | alertfrequency | changetoalertfrequency |myprofile            |
	| AC01-EmailAlerts | Rented property priced £800 to £1000 pcm in London | Weekly         | None                   |I am looking to rent |
