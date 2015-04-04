CREATE TABLE [dbo].[Booking]
(
	[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY, 
    [Date] SMALLDATETIME NULL, 
    [Name] NCHAR(50) NULL, 
    [Weight] INT NULL, 
    [Volume] INT NULL, 
    [Cost] INT NULL, 
    [IdClient] INT NOT NULL, 
	CONSTRAINT [FK_Booking_Client] FOREIGN KEY ([IdClient]) REFERENCES [Client]([Id])
)
