USE TelerikAcademy

CREATE TABLE Tasks (
        TaskID INT IDENTITY(1,1) PRIMARY KEY,
        NAME nvarchar(50) NOT NULL
)
 
CREATE TABLE WorkHours (
        WorkHoursID INT IDENTITY(1,1) PRIMARY KEY,
        EmployeeID INT FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID) NOT NULL,
        [DATE] datetime NOT NULL,
        TaskID INT FOREIGN KEY(TaskID) REFERENCES Tasks(TaskID) NOT NULL,
        [Hours] INT NULL,
        Comments nvarchar(250) NULL,
)
 
INSERT INTO WorkHours
        VALUES(5, '2013-07-12', 4, NULL, NULL)
 
CREATE TABLE WorkHoursLog (
        LogID INT IDENTITY(1,1) PRIMARY KEY,
        ExecutedCommand nvarchar(20) NULL,
        WorkHoursID INT NULL,
        OldEmployeeID INT FOREIGN KEY(OldEmployeeID) REFERENCES Employees(EmployeeID) NULL,
        [OldDate] datetime NULL,
        OldTaskID INT FOREIGN KEY(OldTaskID) REFERENCES Tasks(TaskID) NULL,
        [OldHours] INT NULL,
        OldComments nvarchar(250) NULL,
        NewEmployeeID INT FOREIGN KEY(NewEmployeeID) REFERENCES Employees(EmployeeID) NULL,
        [NewDate] datetime NULL,
        NewTaskID INT FOREIGN KEY(NewTaskID) REFERENCES Tasks(TaskID) NULL,
        [NewHours] INT NULL,
        NewComments nvarchar(250) NULL
)
 
ALTER TRIGGER TR_WorkHoursDelete
ON WorkHours
FOR DELETE
AS
    INSERT INTO WorkHoursLog
    SELECT 'DELETE', *, NULL, NULL, NULL, NULL, NULL
        FROM deleted
 
GO
 
ALTER TRIGGER TR_WorkHoursInsert
ON WorkHours
FOR INSERT
AS
    INSERT INTO WorkHoursLog
    SELECT 'INSERT', WorkHoursID,NULL, NULL, NULL, NULL, NULL,
                EmployeeID, [DATE], TaskID, [Hours], Comments
        FROM inserted
 
GO
 
ALTER TRIGGER TR_WorkHoursUpdate
ON WorkHours
FOR UPDATE
AS
        INSERT INTO WorkHoursLog
        SELECT 'UPDATE', d.WorkHoursID, d.EmployeeID, d.[DATE], d.TaskID, d.[Hours], d.Comments,
        i.EmployeeID, i.[DATE], i.TaskID, i.[Hours], i.Comments  
        FROM inserted i, deleted d
GO
 
 
/*Triggers Testing*/
DELETE FROM WorkHours WHERE WorkHoursID = 3
 
INSERT INTO WorkHours
        VALUES(5, '2013-07-12', 4, NULL, NULL)
 
UPDATE WorkHours
SET Hours = 123
FROM WorkHours
WHERE WorkHoursID = 8;