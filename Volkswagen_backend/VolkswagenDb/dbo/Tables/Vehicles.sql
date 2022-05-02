CREATE TABLE [dbo].[Vehicles]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY, 
    [ModelId] INT NOT NULL,
    [RangeName] NVARCHAR(50) NOT NULL, 
    [Price] DECIMAL(19, 4) NOT NULL, 
    [StockAmount] INT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Vehicles_Models] FOREIGN KEY ([ModelId]) REFERENCES [Models]([Id])
)
