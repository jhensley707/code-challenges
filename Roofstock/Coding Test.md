# Roofstock Coding Exercise

#### Create an ASPNET (or Core) Web Project (MVC) to display fields

Data source from API:

> http://dev1-sample.azurewebsites.net/properties.json

#### Display the records in a table/grid with following fields

* Address

* Year Built

* List Price $ (formatted to two decimal places - e.g. $1234.00)

* Monthly Rent $

* Gross Yield % ('Monthly Rent' * 12 / 'List Price')

#### Save record from above into database table Properties

1. Create a SQL Server database with a table named Properties to store all the fields displayed above

2. Update the above to support record saving

	* Add a Save button to each row
	* When the Save Button is clicked, the record should be inserted into the new table Properties