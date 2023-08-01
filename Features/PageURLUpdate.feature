Feature: PageURLUpdate

Whenever user performs a conversion (or reverses it):
- the page URI should be updated to reflect the amount, source 
and target currency for the conversion.

Background: Convert an amount of money
	Given XE website is open
		And I am on the Convert screen
	When I convert 100 - Armenian Dram to Swiss Franc

Scenario: Verify Page URL Is Updated after conversion
	Then Page URL is updated according to conversion currencies
		
Scenario: Verify Conversion URL Is Updated after currency swap	
	When I swap currencies
	Then Page URL is updated according to swapped currencies