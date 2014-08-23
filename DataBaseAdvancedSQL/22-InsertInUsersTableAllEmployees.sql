USE TelerikAcademy

/*there are duplicates if we get the first letter from the FirstName
so I will get the first 3 letters*/
INSERT INTO Users(UserName, [UserPassword], Fullname, GroupID)
SELECT LOWER(LEFT(FirstName, 3) + LastName),
               LOWER(LEFT(FirstName, 3) + LastName),
                FirstName + ' ' + LastName, 1
FROM Employees