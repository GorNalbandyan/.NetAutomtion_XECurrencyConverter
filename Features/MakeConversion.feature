Feature: MakeConversion

User should be able to 
- specify numeric amount, source and target currency
- obtain conversion amount
- specify whole integers
- specify decimal numeric amounts

Scenario: Make Conversion and Get Full conversion amount
	Given XE website is open
		And I am on the Convert screen
	When I convert <amount> - <sourceCurrency> to <targetCurrency>
	Then Full conversion amount in <targetCurrency> is displayed
	Examples: 
		| amount   | sourceCurrency | targetCurrency   |
		| 100      | US Dollar      | Armenian Dram    |
		| 555.5555 | Japanese Yen   | Singapore Dollar |