USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName AS [Full Name], e.EmployeeID
FROM Employees e
WHERE (
        SELECT COUNT(*)
        FROM Employees
        WHERE ManagerID = e.EmployeeID
		) = 5
                