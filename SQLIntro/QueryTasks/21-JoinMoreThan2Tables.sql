SELECT e.FirstName + ' ' + e.LastName AS [Name],
		m.FirstName + ' ' + m.LastName AS [Manager],
		a.AddressText AS [Address]
FROM [TelerikAcademy].[dbo].[Employees] e
		INNER JOIN [TelerikAcademy].[dbo].[Employees] m
		ON e.ManagerID = m.EmployeeID
			INNER JOIN [TelerikAcademy].[dbo].[Addresses] a
				ON e.AddressID = a.AddressID