USE TelerikAcademy

CREATE TABLE #LocalTempTable(
        EmployeeID INT NOT NULL,
        ProjectID INT NOT NULL,
        CONSTRAINT PK_EmployeeesProjects PRIMARY KEY (EmployeeID, ProjectID),
)
 
INSERT INTO #LocalTempTable
SELECT * FROM EmployeesProjects
 
DROP TABLE EmployeesProjects
 
CREATE TABLE EmployeesProjects(
        EmployeeID INT NOT NULL,
        ProjectID INT NOT NULL,
        CONSTRAINT PK_EmployeeesProjects PRIMARY KEY (EmployeeID, ProjectID),
        CONSTRAINT FK_EmployeesProjects_Employees FOREIGN KEY (EmployeeID)
                REFERENCES Employees(EmployeeId),
        CONSTRAINT FK_EmployeesProjects_Projects FOREIGN KEY (ProjectID)
                REFERENCES Projects(ProjectId)
)
 
INSERT INTO EmployeesProjects
SELECT * FROM #LocalTempTable