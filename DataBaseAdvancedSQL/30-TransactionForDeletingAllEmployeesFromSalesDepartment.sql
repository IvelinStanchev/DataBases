USE TelerikAcademy

BEGIN TRAN

ALTER TABLE Departments
DROP CONSTRAINT FK_Departments_Employees
 
DELETE FROM Employees
WHERE Employees.DepartmentID = (
        SELECT DepartmentID
        FROM Departments
        WHERE Departments.Name = 'Sales')

ROLLBACK TRAN