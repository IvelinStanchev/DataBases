SELECT e.FirstName + ' ' + e.LastName AS [Name], a.AddressText AS [Address]
FROM [TelerikAcademy].[dbo].[Employees] e, 
		[TelerikAcademy].[dbo].[Addresses] a
WHERE e.AddressID = a.AddressID