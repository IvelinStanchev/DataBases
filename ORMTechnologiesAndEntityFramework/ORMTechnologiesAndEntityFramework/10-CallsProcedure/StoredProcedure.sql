CREATE PROC usp_GetTotalIncomes(@supplierName nvarchar(50), @startDate date, @endDate date)
AS
	SELECT SUM(p.UnitPrice) FROM Products p
		JOIN Suppliers s ON p.SupplierID = s.SupplierID
		JOIN [Order Details] od ON od.ProductID = p.ProductID
		JOIN Orders o ON o.OrderID = od.OrderID
	WHERE (o.ShippedDate BETWEEN @startDate AND @endDate) AND s.CompanyName = @supplierName
GO
