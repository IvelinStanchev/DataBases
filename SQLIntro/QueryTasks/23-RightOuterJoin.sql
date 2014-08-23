SELECT e.FirstName, e.LastName,  m.FirstName + ' ' + m.LastName AS [Manager]
FROM [TelerikAcademy].[dbo].[Employees] m
        RIGHT OUTER JOIN [TelerikAcademy].[dbo].[Employees] e
			ON e.ManagerID = m.EmployeeID