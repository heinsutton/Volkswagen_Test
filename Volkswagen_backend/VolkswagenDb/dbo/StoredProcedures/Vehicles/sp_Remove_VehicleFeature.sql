CREATE PROCEDURE [dbo].[sp_Remove_VehicleFeature]
	@vehiclieId int,
	@featureId int
AS
	IF EXISTS (SELECT * FROM VehicleFeatures WHERE VehicleId = @vehiclieId AND FeatureId = @featureId)
	BEGIN
		DELETE FROM VehicleFeatures WHERE VehicleId = @vehiclieId AND FeatureId = @featureId
	END

RETURN 0