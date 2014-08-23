USE TelerikAcademy

CREATE TABLE Users (
	UserID int PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	UserName nvarchar(50) NOT NULL,
	UserPassword nvarchar(50) CHECK(LEN(UserPassword) > 5) NOT NULL,
	FullName nvarchar(50) NOT NULL,	
	LastLoginTime datetime DEFAULT GETDATE()
)
GO

INSERT INTO Users (UserName, UserPassword, FullName)
VALUES ('Test', 12345, 'Test Tester', 4)
GO

INSERT INTO Users (UserName, UserPassword, FullName, GroupID)
VALUES ('Pesho', 12345, 'Pesho Peshov', 1)
GO

INSERT INTO Users (UserName, UserPassword, FullName, GroupID)
VALUES ('Kiro', 12345, 'Kiro Kirov', 2)
GO

INSERT INTO Users (UserName, UserPassword, FullName, GroupID)
VALUES ('Gosho', 12345, 'Gosho Goshov', 5)
GO

INSERT INTO Users (UserName, UserPassword, FullName, GroupID)
VALUES ('Gosho', 12345, 'Gosho Goshov', 3)
GO

INSERT INTO Users (UserName, UserPassword, FullName, GroupID)
VALUES ('Kiro2', 12345, 'Kiro2 Kirov', 1)
GO