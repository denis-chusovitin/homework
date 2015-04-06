CREATE TABLE [dbo].[Ship]
(
	[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	[Name] NCHAR(50) NULL, 
    [OutputPort] NCHAR(50) NULL, 
    [InputPort] NCHAR(50) NULL, 
    [OutputTime] DATETIME NULL, 
    [InputTime] DATETIME NULL
)
