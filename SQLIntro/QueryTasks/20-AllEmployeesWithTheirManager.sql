SELECT e.FirstName + ' ' + e.LastName AS [Name], m.FirstName + ' ' + m.LastName AS [Manager]
FROM [TelerikAcademy].[dbo].[Employees] e
		INNER JOIN [TelerikAcademy].[dbo].[Employees] m
		ON e.ManagerID = m.EmployeeID