CREATE PROC usp_GiveInterestToPerson(@accountId int, @interestRate float)
AS
	SELECT p.FirstName + ' ' + p.LastName AS [Full Name], 
			a.Balance as Balance, 
			dbo.ufn_CalculateSumByInterestRate(a.Balance, @interestRate, 1) as [Balance With Interest]
	FROM Persons p
		JOIN Accounts a 
		ON a.PersonId = p.PersonID
	WHERE a.AccountID = @accountId
GO

EXEC usp_GiveInterestToPerson 2, 150