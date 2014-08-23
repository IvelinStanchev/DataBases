USE TelerikAcademy

ALTER TABLE Users
        ADD GroupID INT
 
ALTER TABLE Users
        ADD CONSTRAINT FK_UsersGroup FOREIGN KEY(GroupID) REFERENCES Groups(GroupID)