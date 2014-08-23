SELECT e.FirstName, e.LastName,  m.FirstName + ' ' + m.LastName AS [Manager]
FROM [TelerikAcademy].[dbo].[Employees] e
        LEFT OUTER JOIN [TelerikAcademy].[dbo].[Employees] m
			ON e.ManagerID = m.EmployeeID