USE TelerikAcademy

SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary <=
	(SELECT MIN(Salary) FROM Employees) * 1.1
	ORDER BY Salary ASC