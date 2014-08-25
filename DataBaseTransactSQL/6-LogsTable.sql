CREATE TABLE Logs(
	LogID int IDENTITY,
	AccountID int NOT NULL,
	OldBalance int NOT NULL,
	NewBalance int NOT NULL,
	CONSTRAINT PK_Logs PRIMARY KEY(LogID),
	CONSTRAINT FK_Logs_Accounts FOREIGN KEY(AccountID) REFERENCES Accounts(AccountID)
)

GO

CREATE TRIGGER tr_AccountsUpdate ON Accounts FOR UPDATE
AS
	DECLARE @updatedId int
	SET @updatedId = (SELECT AccountID FROM Inserted)
	INSERT INTO Logs(AccountID, OldBalance, NewBalance)
	Values(@updatedId,
		   (SELECT Balance FROM Deleted),
		   (SELECT Balance FROM Inserted))
GO