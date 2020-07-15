Feature: IsTravelTimeSearchSuccessful
	In order to get property alerts for my desired property
	As a Zoopla user
	I want to search Zoopla website based on travel time from specified postcode

@searchPropertyBasedOnTimeToTravel
Scenario: Property Search Based on Travel Time	
	Given I have registered on Zoopla with <myprofile> and logged in
	And I browse to travel search page
	When I try to search property based on travel time described in <testcase>
	Then I am able to save search and register for saved search in form of email alerts with frequency of <alertfrequency>

	# Please refer to SearchParameters.csv file in TestData folder
	# for search query parameters
	Examples: 
	| testcase         | description                                          | myprofile            |alertfrequency |
	| AC01-TravelTime  | All properties within 15 minutes drive of "SE1 2LH"  | I am looking to rent |Weekly         |


