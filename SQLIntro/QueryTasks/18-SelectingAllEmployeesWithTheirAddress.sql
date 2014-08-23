SELECT e.FirstName AS [Name], a.AddressText AS [Address]
FROM [TelerikAcademy].[dbo].[Employees] e
		INNER JOIN  [TelerikAcademy].[dbo].[Addresses] a
			ON e.AddressID = a.AddressID
		