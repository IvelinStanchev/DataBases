USE TelerikAcademy

SELECT e.FirstName [Employee Name], 
		e.JobTitle AS [Job Title], 
		d.Name AS [Department], 
		MIN(Salary) AS [Minimal Salary]
FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle, e.FirstName