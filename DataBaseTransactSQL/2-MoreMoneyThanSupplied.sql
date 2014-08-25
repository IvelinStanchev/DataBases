USE AccountSystem
GO

CREATE PROC usp_MoreMoneyThanSupplied(@money int)
AS
	SELECT p.FirstName + ' ' + p.LastName AS [Full Name]
	FROM Persons p
		JOIN Accounts a
		ON a.PersonID = p.PersonID
	WHERE a.Balance > @money
GO

EXEC usp_MoreMoneyThanSupplied 240
