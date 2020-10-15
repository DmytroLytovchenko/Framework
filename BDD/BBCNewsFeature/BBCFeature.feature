Feature: BBCNews
	In order to find out about the latest happening
	As a visitor of BBC
	I want to be able to read the News

@positive
Scenario: Text of main news is correct
	Given i navigate to BBC
	When i navigate to news page
	Then the text of main news is correct

@positive
Scenario: Text of secondary news is correct
	Given i navigate to BBC
	When i navigate to news page
	Then the text of secondary news is correct

@positive
Scenario: Search result text is correct
	Given i navigate to BBC
	When i navigate to news page
	And input text of main news category on search field
	And click search button
	Then first search result text is correct 