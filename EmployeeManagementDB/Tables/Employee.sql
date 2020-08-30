CREATE TABLE [dbo].[Employee]
(
	[EmployeeID] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(10) NULL, 
    [Surname] NCHAR(10) NULL, 
    [Address] NCHAR(10) NULL, 
    [Qualification] NCHAR(10) NULL, 
    [ContactNumber] NCHAR(10) NULL, 
    [DepartmentID] INT NOT NULL
)
