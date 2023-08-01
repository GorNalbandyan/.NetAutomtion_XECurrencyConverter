Feature: ConversionFullAndSingleUnitValues

Whenever system provides conversion results,
it should display: 
- the full conversion amount for the value specified 
- conversion rate of a single unit for both currencies.

Scenario: Get Full and Single Unit conversion amount
	Given XE website is open
		And I am on the Convert screen
	When I convert <amount> - <sourceCurrency> to <targetCurrency>
	Then Full conversion amount in <targetCurrency> is displayed
		And Single Unit conversion amount from <sourceCurrency> to <targetCurrency> and vice versa is displayed
	Examples: 
		| amount | sourceCurrency | targetCurrency |
		| 100    | British Pound  | Indian Rupee   |