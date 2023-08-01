Feature: ConversionViaQueryParameters
Users should be able to:
 - access a conversion page directly by specifying the right query string parameters
 - make conversion via query parameters

Scenario: Access Conversion via query paremeters
#Both of these test cases are failing as after navigating to URL with query parameters conversion is not done
#it requires at least one conversion to correctly apply this action
	Given XE website is open
	When I use <amount> - <sourceCurrency> to <targetCurrency> query params to apply conversion
	Then Full conversion amount in <targetCurrency> is displayed
	Examples: 
		| amount   | sourceCurrency | targetCurrency |
		| 100      | US Dollar      | Armenian Dram  |
		| 555.5555 | British Pound  | Indian Rupee   |

Scenario: Make Conversion via query paremeters
	Given XE website is open
		And Any conversion is done
	When I use <amount> - <sourceCurrency> to <targetCurrency> query params to apply conversion
	Then Full conversion amount in <targetCurrency> is displayed
	Examples: 
		| amount   | sourceCurrency | targetCurrency |
		| 1000000  | US Dollar      | Armenian Dram  |
		| 555.5555 | British Pound  | Indian Rupee   |
