Feature: SwapSourceAndTargetCurrencies
User should be able to 
- swap target and source currencies
- obtain conversion amount immediately

Scenario: Swap currencies and get result
	Given XE website is open
		And I am on the Convert screen
	When I convert <amount> - <sourceCurrency> to <targetCurrency>
		And I swap currencies
	Then The curreincies are swapped
		And Full conversion amount in <sourceCurrency> is displayed
	Examples: 
		| amount   | sourceCurrency | targetCurrency   |
		| 100      | US Dollar      | Armenian Dram    |