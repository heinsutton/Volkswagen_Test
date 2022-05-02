CREATE TABLE [dbo].[VehicleFeatures]
(
	[VehicleId] INT NOT NULL, 
    [FeatureId] INT NOT NULL, 
    CONSTRAINT [FK_VehicleFeatures_Vehicles] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicles]([Id]),
    CONSTRAINT [FK_VehicleFeatures_Features] FOREIGN KEY ([FeatureId]) REFERENCES [Features]([Id]) 
)
