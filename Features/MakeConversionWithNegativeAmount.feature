Feature: MakeConversionWithNegativeAmount

When specifying negative numeric values:
- an error message should be displayed 
- but conversion happens anyway.

Scenario: Make Conversion with negative amount and 0
	Given XE website is open
		And I am on the Convert screen
	When I convert <amount> - US Dollar to Armenian Dram
	Then Negative value validation message shoud appear
		And Full conversion amount in Armenian Dram is displayed
	Examples:
		| amount |
		| -100   |
		| 0      |

	#These test cases are failing as when inserting negative value or 0 Convert btn is not active 
	#It becomes active after doing conversion with one positive value
	#So this function doesn't meet acceptance criteria