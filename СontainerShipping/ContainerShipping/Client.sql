CREATE TABLE [dbo].[Client]
(
	[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY, 
    [Name] NCHAR(50) NULL, 
    [Company] NCHAR(50) NULL, 
    [Address] NCHAR(50) NULL, 
    [Phone] NCHAR(50) NULL, 
    [Fax] NCHAR(50) NULL, 
    [Email] NCHAR(50) NULL 
)
