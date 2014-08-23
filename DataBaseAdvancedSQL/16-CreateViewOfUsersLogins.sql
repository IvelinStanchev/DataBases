USE TelerikAcademy

CREATE VIEW RecentUsers
AS
        SELECT Username, DAY(GETDATE() - LastLoginTime) AS DayDifference
        FROM Users
        WHERE DAY(GETDATE() - LastLoginTime) = 1