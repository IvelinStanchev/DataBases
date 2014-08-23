SELECT FirstName + ' ' +  MiddleName + ' ' + LastName AS [Full Name]
FROM [TelerikAcademy].[dbo].[Employees]
WHERE MiddleName IS NOT NULL