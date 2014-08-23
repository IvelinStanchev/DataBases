USE TelerikAcademy

UPDATE Users
SET FullName = 'Kiro3 Kirov', GroupID = '1'
WHERE UserName = 'Kiro2'
GO

UPDATE Groups
SET Name = 'Test2 Group'
WHERE Name = 'Group1'