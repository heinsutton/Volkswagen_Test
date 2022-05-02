CREATE PROCEDURE [dbo].[sp_Insert]
	@modelName nvarchar(50),
	@rangeName nvarchar(50),
	@price decimal(19,4),
	@stockAmount int,
	@featureName nvarchar(200)
AS
	IF NOT EXISTS (SELECT * FROM Models WHERE [Name] LIKE @modelName)
	BEGIN
		INSERT INTO Models VALUES (@modelName)
	END

	DECLARE @modelId AS INT 
	SELECT @modelId = Id FROM Models WHERE [Name] LIKE @modelName

	IF NOT EXISTS (SELECT * FROM Vehicles WHERE ModelId = @modelId AND RangeName LIKE @rangeName)
	BEGIN
		INSERT INTO Vehicles VALUES (@modelId, @rangeName, @price, @stockAmount)
	END

	DECLARE @vehicleId AS INT
	SELECT @vehicleId = id FROM Vehicles WHERE ModelId = @modelId AND RangeName LIKE @rangeName

	IF NOT EXISTS (SELECT * FROM Features WHERE [Name] LIKE @featureName)
	BEGIN 
		INSERT INTO Features VALUES (@featureName)
	END

	DECLARE @featureId AS INT
	SELECT @featureId = id FROM Features WHERE [Name] LIKE @featureName

	IF NOT EXISTS (SELECT * FROM VehicleFeatures WHERE VehicleId = @vehicleId AND FeatureId = @featureId)
	BEGIN
		INSERT INTO VehicleFeatures VALUES (@vehicleId, @featureId)
	END

RETURN 0
