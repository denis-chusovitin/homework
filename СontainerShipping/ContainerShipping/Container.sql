CREATE TABLE [dbo].[Container]
(
	[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY, 
    [Type] NCHAR(50) NULL, 
    [Weight] INT NULL, 
    [Volume] INT NULL
)
