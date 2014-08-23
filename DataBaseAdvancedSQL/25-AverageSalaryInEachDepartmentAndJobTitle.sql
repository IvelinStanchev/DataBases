USE TelerikAcademy

SELECT e.JobTitle AS [Job Title], d.Name AS [Department], AVG(Salary) AS [Average Salary]
FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle