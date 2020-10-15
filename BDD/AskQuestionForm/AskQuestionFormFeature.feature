Feature: QuestionForm
	In order to ask question about Covid-19 
	As a visitor of BBC
	I want to be able write my question by filling out the required form

Background: Navigation to Question page
	Given i navigate to BBC home page
	And i go to News page
	And i go to Question page

@Negative
Scenario: An error message with an empty question field is correct 
	When i fill form without Question
	And  click Submit button
	Then error text of question is correct

@Negative
Scenario: An error message with an empty name field is correct  
	When i fill form without Name
	And  click Submit button
	Then error text of name is correct

@Negative
Scenario: An error message with an empty email field is correct  
	When i fill form without Email
	And  click Submit button
	Then error text of email is correct

@Negative
Scenario: An error message with an empty telephone number field is correct  
	When i fill form without Telephone Number
	And  click Submit button
	Then error text of telephone number is correct

@Negative
Scenario: An error message with toggle off age checkbox is correct  
	When i fill form without Age Checkbox
	And  click Submit button
	Then error text of toggle off age checkbox is correct

@Negative
Scenario: An error message with toggle off terms checkbox is correct   
	When i fill form without Terms Checkbox
	And  click Submit button
	Then error text of toggle off terms checkbox is correct


