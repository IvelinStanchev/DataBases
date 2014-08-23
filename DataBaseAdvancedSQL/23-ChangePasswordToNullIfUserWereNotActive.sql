USE TelerikAcademy

UPDATE Users
SET [UserPassword] = NULL
FROM Users
WHERE LastLoginTime < CONVERT(datetime, '10-03-2010')
        AND [UserPassword] IS NOT NULL