CREATE FUNCTION ufn_CalculateSumByInterestRate(@sum int, @yearlyInterestRate float, @numberOfMonths int)
RETURNS INT
AS 
BEGIN
	RETURN @sum * POWER(1 + @yearlyInterestRate/100, @numberOfMonths / 12.0)
END

GO
SELECT dbo.ufn_CalculateSumByInterestRate (1000, 1.25, 1) FROM Accounts WHERE AccountID= 2;