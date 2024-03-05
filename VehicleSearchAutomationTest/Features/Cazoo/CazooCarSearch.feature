Feature: Car Search
	As a car seller,
	I want be able to search for cars that are within a certain age range


Background: 
Given I navigate to the Cazoo home page with url "https://www.cazoo.co.uk/value-my-car/"


#@DataSource:.\ExcelReader\DataFiles\car_input_v1.csv
Scenario: Verify that cars are within the specifies age range
	And I accept the cookie
	When I input a car with the "<REGISTRATION>" in the serach field
	#And I enter the milage of "10000"
	And I serach for the details
	Then I will see a car with the following details "<REGISTRATION>", "<MAKE>" and "<MODEL>"
Examples: 
		| REGISTRATION | MAKE       | MODEL                                                             |
		| SG18 HTN     | Volkswagen | Golf                                                              |
		| AD58VNF      | BMW        | 1 Series 2.0 120d M Sport Coupe 2dr Diesel Manual Euro 4 (177 ps) |
		| BW57BOF      | Toyota     | aris 1.0 VVT-i T2 Hatchback 3dr Petrol Manual (127 g/km, 67 bhp)  |
		| KT17DLX      | SKODA      | Superb Diesel Estate - 2.0 TDI CR 190 Sport Line 5dr DSG          |
