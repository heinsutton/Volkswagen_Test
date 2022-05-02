CREATE PROCEDURE [dbo].[sp_Add_Vehicle_Feature]
	@vehicleId int,
	@featureId int
AS

	IF NOT EXISTS (SELECT * FROM VehicleFeatures WHERE VehicleId = @vehicleId AND FeatureId = @featureId)
	BEGIN
		INSERT INTO VehicleFeatures (VehicleId, FeatureId)
		VALUES (@vehicleId, @featureId)
	END

RETURN 0


