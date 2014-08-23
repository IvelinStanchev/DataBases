USE TelerikAcademy

SELECT COUNT(*) AS [Count]
FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'