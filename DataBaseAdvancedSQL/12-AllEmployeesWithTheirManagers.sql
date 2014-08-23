USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName AS [Name], 
		ISNULL( m.FirstName + ' ' + m.LastName, 'no manager') AS [Manager]
FROM Employees e
		LEFT JOIN Employees m
		ON e.ManagerID = m.EmployeeID