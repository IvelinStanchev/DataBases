USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName AS [Full Name], Salary, d.Name AS [Department Name]
FROM Employees e
     JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
		WHERE Salary = (SELECT MIN(Salary) FROM Employees WHERE DepartmentID = e.DepartmentID)
		ORDER BY d.DepartmentID