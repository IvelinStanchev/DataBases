USE TelerikAcademy

DELETE FROM Users
WHERE UserName = 'Test' AND UserID = 1
GO

DELETE FROM Groups
WHERE Name = 'Group2' AND GroupID = 2