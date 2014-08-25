DECLARE empCursor CURSOR READ_ONLY FOR
    SELECT e1.FirstName, e1.LastName, t.Name, e2.FirstName, e2.LastName
    FROM Employees e1
        INNER JOIN Addresses a
                ON a.AddressID = e1.AddressID
        INNER JOIN Towns t
                ON t.TownID = a.TownID,
    Employees e2
        INNER JOIN Addresses a1
                ON a1.AddressID = e2.AddressID
        INNER JOIN Towns t1
                ON t1.TownID = a1.TownID
    OPEN empCursor
    DECLARE @e1fname NVARCHAR(50)
    DECLARE @e1lname NVARCHAR(50)
    DECLARE @e2fname NVARCHAR(50)
    DECLARE @e2lname NVARCHAR(50)
    DECLARE @town NVARCHAR(50)
	
    FETCH NEXT FROM empCursor
        INTO @e1fname, @e1lname, @e2fname, @e2lname, @town
    WHILE @@FETCH_STATUS = 0
        BEGIN
            PRINT @town + ': ' + @e1fname + ' ' + @e1lname + ' ' + @e2fname + ' ' + @e2lname
            FETCH NEXT FROM empCursor
                INTO @e1fname, @e1lname, @e2fname, @e2lname, @town
        END
CLOSE empCursor
DEALLOCATE empCursor