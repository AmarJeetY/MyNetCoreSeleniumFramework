Feature: PropertySearch
	In order to get property alerts for my desired property
	As a Zoopla website user
	I want to search property as per my custom criteria

@searchUniqueProperty
Scenario: Search Unique property
	Given I am on Zoopla home page
	When I try to search property described in <testcase>
	Then I am able to see my custom searched property appears first in list
	
	# Please refer to SearchParameters.csv file in TestData folder
	# for search query parameters
	Examples: 
	| testcase        | description												  | 
	| AC01-PropSearch | Custom property search "45 Sheep Street, Northampton NN1" | 	

@searchPropertyWithGarage
Scenario: Search Property with attached garage
	Given I am on Zoopla home page
	When I try to search property described in <testcase>
	Then I can confirm that the properties in search results have specified feature attached to them
	
	# Please refer to SearchParameters.csv file in TestData folder
	# for search query parameters. Here Garage is passed as keyword into search query
	Examples: 
	| testcase        | description								|	
	| AC02-PropSearch | Houses with attached "Garage" in London | 