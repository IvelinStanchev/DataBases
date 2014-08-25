GO
CREATE PROC usp_WithdrawMoney(@accountID int, @moneyAmount int)
AS
DECLARE @currentBalance int;
BEGIN
	BEGIN TRAN
	UPDATE Accounts
	SET @currentBalance = Balance - @moneyAmount,
	Balance = Balance - @moneyAmount
	WHERE AccountID = @accountID

	IF(@currentBalance < 0)
		ROLLBACK TRAN
	ELSE
		COMMIT TRAN
END

GO

EXEC usp_WithdrawMoney 1, 100

GO

CREATE PROC usp_DepositMoney(@accountID int, @moneyAmount int)
AS
BEGIN
	BEGIN TRANSACTION
	UPDATE Accounts
	SET Balance = Balance + @moneyAmount
	WHERE AccountID = @accountID

	IF(@moneyAmount < 0)
		ROLLBACK TRANSACTION
	ELSE
		COMMIT TRAN
END

GO

EXEC usp_DepositMoney 1, 150