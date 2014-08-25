CREATE FUNCTION dbo.ufn_NameContainingLetters(@name NVARCHAR(50), @letters NVARCHAR(50))
    RETURNS bit
AS
BEGIN
    DECLARE @contains bit
    SET @contains = 1
    DECLARE @counter INT
    SET @counter = 1
 
    WHILE(@counter <= LEN(@name))
        BEGIN
        IF (CHARINDEX(SUBSTRING(@name, @Counter, 1), @letters) = 0)
            SET @contains = 0
        SET @counter = @counter + 1
        END
    RETURN @contains
END

GO

CREATE PROC dbo.usp_FindFirstNames(@lettersToSearch NVARCHAR(50))
AS
    DECLARE @valid bit
    SET @valid = 0                     
        SELECT e.FirstName AS [First Name]
        FROM Employees e
        WHERE 1 = 
			(SELECT dbo.ufn_NameContainingLetters(e.FirstName, @lettersToSearch))
GO

CREATE PROC dbo.usp_FindMiddleNames(@lettersToSearch NVARCHAR(50))
AS
    DECLARE @valid bit
    SET @valid = 0        
		SELECT e.FirstName AS [Middle Name]
		FROM Employees e
		WHERE 1 = 
			(SELECT dbo.ufn_NameContainingLetters(e.FirstName, @lettersToSearch))
GO

CREATE PROC dbo.usp_FindLastNames(@lettersToSearch NVARCHAR(50))
AS
    DECLARE @valid bit
    SET @valid = 0     
		SELECT e.FirstName AS [Last Name]
		FROM Employees e
		WHERE 1 = 
		(SELECT dbo.ufn_NameContainingLetters(e.FirstName, @lettersToSearch))
GO

CREATE PROC dbo.usp_FindTowns(@lettersToSearch NVARCHAR(50))
AS
    DECLARE @valid bit
    SET @valid = 0    
		SELECT t.Name AS [Town Name]
		FROM Towns t
		WHERE 1 = 
			(SELECT dbo.ufn_NameContainingLetters(t.Name, @lettersToSearch))
GO

EXEC dbo.usp_FindFirstNames 'oistmiahf'
EXEC dbo.usp_FindMiddleNames 'oistmiahf'
EXEC dbo.usp_FindLastNames 'oistmiahf'
EXEC dbo.usp_FindTowns 'oistmiahf'