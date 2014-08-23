USE TelerikAcademy

SELECT COUNT(DISTINCT e.ManagerID) AS [Managers Count], t.Name
FROM Employees e
        JOIN Employees m
        ON e.ManagerID = m.EmployeeID
        JOIN Addresses a
        ON a.AddressID = m.AddressID
        JOIN Towns t
        ON a.TownID = t.TownID
GROUP BY t.Name