USE TelerikAcademy

CREATE TABLE Groups (
        GroupID INT PRIMARY KEY IDENTITY(1,1),
        Name nvarchar(20) UNIQUE
)
Go

INSERT INTO Groups (Name)
VALUES ('Group1')
GO

INSERT INTO Groups (Name)
VALUES ('Group2')
GO

INSERT INTO Groups (Name)
VALUES ('Group3')
GO

INSERT INTO Groups (Name)
VALUES ('Group4')
GO

INSERT INTO Groups (Name)
VALUES ('Group5')
GO

