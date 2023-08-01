Feature: NonNumericAmountErrorValidation

If users specify non numeric values, the system should give an error

Scenario: Verify non numeric amount validation
	Given XE website is open
		And I am on the Convert screen
	When I convert <amount> - US Dollar to Armenian Dram
	Then Non numeric amount validation message shoud appear
	Examples:
		| amount  |
		| USD     |
		| **$#    |
		| 100,-   | #For this case it failed as validation message doesn't appear when I insert Number + any char
		| 200 USD | #For this case it failed as validation message doesn't appear when I insert Number + any char
