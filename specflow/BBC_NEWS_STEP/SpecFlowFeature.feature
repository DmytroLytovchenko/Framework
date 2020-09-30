Feature: SpecFlowFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Text of main news is present
	Given user on home page
	When user navigate to news page
	Then the text of main news is correct

@mytag
Scenario: Text of second news is present
	Given user on home page
	When user navigate to news page
	Then the text of second news is correct

@mytag
Scenario: Search result text is correct
	Given user on home page
	When user navigate to news page
	And input text of main news category on search field
	Then the text of result is correct