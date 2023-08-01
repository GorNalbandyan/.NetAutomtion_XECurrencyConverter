Feature: Unit And Full Amount Mathematical Correctness

The conversion values presented for the amount specified
and the 1 unit values
should be mathematically correct

Scenario: Verify Single Unit And Full amount mathematical precision
	Given XE website is open
		And I am on the Convert screen
	When I convert 100 - US Dollar to Armenian Dram
Then Unit And Full conversion amounts are mathematically correct