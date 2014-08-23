SELECT e.FirstName + ' ' + e.LastName AS [Full Name]
FROM [TelerikAcademy].[dbo].[Departments] d, [TelerikAcademy].[dbo].[Employees] e
	WHERE e.DepartmentID = d.DepartmentID 
		AND (d.Name = 'Sales' OR d.Name = 'Finance') 
		AND e.HireDate BETWEEN '1995-01-01 00:00:00' AND '2005-01-01 00:00:00'