CREATE PROCEDURE [dbo].[sp_Create_Feature]
	@name nvarchar(200),
	@vehicleId int = NULL
AS

	INSERT INTO	Features VALUES (@name);
	
	DECLARE @featureId AS INT = SCOPE_IDENTITY()

	IF (@vehicleId IS NOT NULL AND @vehicleId > 0)
	BEGIN
		INSERT INTO VehicleFeatures VALUES (@vehicleId, @featureId)
	END

RETURN 0