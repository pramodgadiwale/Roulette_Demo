# Roulette_Demo
Demo using Web API / Sqlite / Dapper

Assesment 1 – Stored Procedure
1. Open SQL server and implement script NorthwindDB/NorthwindDBScript.sql
2. Open script to create store proc named NorthwindDB/pr_GetOrderSummary - This SP will return a summary of orders from the data in the Northwind database
The results should be able to be filtered by specifying parameters:
•	Date of the Order (@StartDate and @EndDate)
•	Nullable Parameter to filter for a specific Employee (@EmployeeID)
•	Nullable Parameter to filter for a specific Customer (@CustomerID)

 The columns to be returned are:
•	EmployeeFullName (TitleOfCourtesy + FirstName + LastName)
•	Shipper CompanyName
•	Customer CompanyName
•	NumberOfOders
•	Date
•	TotalFreightCost
•	NumberOfDifferentProducts
•	TotalOrderValue

The results should be grouped by:
•	Order Day (i.e. grouped by day)
•	Employee 
•	Customer
•	Shipper


Some helpful tests:
exec pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=NULL , @CustomerID=NULL

exec pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=5 , @CustomerID=NULL

exec pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=NULL , @CustomerID='VINET'

exec pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=5 , @CustomerID='VINET'

Assesment 2 – Web API
1.	Create a C# REST API based around the game of roulette. Simple functions will need to be created, for example:
-	PlaceBet
-	Spin
-	Payout
-	ShowPreviousSpins
2.	Save the PlaceBet data to a SQLite DB.
