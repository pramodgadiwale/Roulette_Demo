-- =============================================
-- Author:      Pramod Gadiwale
-- Create date: 4/9/2023
-- Description: Get Order Summary between two dates for particular customer or Employee
--
-- Parameters:
--   @StartDate - from date for orders.
--   @EndDate - to date for orders
--   @EmployeeID - Nullable Parameter to filter for a specific Employee 
--   @CustomerID - Nullable Parameter to filter for a specific Customer 


-- Change History:
--   4/9/2023 Pramod Gadiwale: Changed Added new parameter CustomerID

-- =============================================

CREATE PROC pr_GetOrderSummary
 @StartDate Date,
 @EndDate Date,
 @EmployeeID int ,
 @CustomerID nchar(5) 
AS
print @startDate
select 	TitleOfCourtesy + FirstName + LastName 'EmployeeFullName',
	Shippers.CompanyName	'Shipper CompanyName',
	Customers.CompanyName 'Customer CompanyName'
	,count(orederDetails.OrderID) NumberOfOders
	,Orders.OrderDate Date
	,sum(Orders.Freight) TotalFreightCost
	,count(distinct orederDetails.ProductID) NumberOfDifferentProducts
	,sum(orederDetails.Quantity) TotalOrderValue ,Orders.EmployeeID,Orders.CustomerID
	FROM  [Order Details] orederDetails
	INNER JOIN Orders ON Orders.OrderID=orederDetails.OrderID
	INNER JOIN Customers ON Customers.CustomerID=Orders.CustomerID
	INNER JOIN Employees ON Employees.EmployeeID=Orders.EmployeeID
	INNER JOIN Shippers ON Shippers.ShipperID=Orders.ShipVia
	WHERE OrderDate between @StartDate and @EndDate
		and (Orders.EmployeeID=@EmployeeID OR @EmployeeID is null)
		and (Orders.CustomerID=@CustomerID OR @CustomerID is null)
	group by 
		OrderDate,	TitleOfCourtesy + FirstName + LastName ,	Customers.CompanyName,	
		Shippers.CompanyName,Orders.EmployeeID,Orders.CustomerID

		

--exec pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=NULL , @CustomerID=NULL

--exec pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=5 , @CustomerID=NULL

--exec pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=NULL , @CustomerID='VINET'

--exec pr_GetOrderSummary @StartDate='1 Jan 1996', @EndDate='31 Aug 1996', @EmployeeID=5 , @CustomerID='VINET'
