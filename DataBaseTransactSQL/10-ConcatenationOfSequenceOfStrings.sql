DECLARE @str nvarchar(MAX);
SET @str = '';
SELECT @str = CONCAT(@str, e.FirstName, ', ')
FROM Employees e
SELECT LEFT(@str,LEN(@str)-2);