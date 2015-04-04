CREATE TABLE [dbo].[DownloadContainer]
(
	[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY, 
    [Weight] INT NULL, 
    [IdContainer] INT NOT NULL, 
	[IdBooking] INT NOT NULL,
    [IdShip] INT NOT NULL,
	CONSTRAINT [FK_DownloadContainer_Container] FOREIGN KEY ([IdContainer]) REFERENCES [Container]([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_DownloadContainer_Booking] FOREIGN KEY ([IdBooking]) REFERENCES [Booking]([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_DownloadContainer_Ship] FOREIGN KEY ([IdShip]) REFERENCES [Ship]([Id])
)
