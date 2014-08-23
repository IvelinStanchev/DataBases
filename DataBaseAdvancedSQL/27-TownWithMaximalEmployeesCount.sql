USE TelerikAcademy

SELECT TOP 1 t.Name, COUNT(e.EmployeeID) AS [Employees Count]
FROM Towns t
	JOIN Addresses a
	ON t.TownID = a.TownID
	JOIN Employees e
	ON e.AddressID = a.AddressID
GROUP BY t.Name
ORDER BY [Employees Count] DESC