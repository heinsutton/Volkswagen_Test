CREATE PROCEDURE [dbo].[sp_Delete_Vehicle]
	@id int
AS
	IF EXISTS (SELECT * FROM VehicleFeatures WHERE VehicleId = @id)
	BEGIN
		DELETE FROM VehicleFeatures WHERE VehicleId = @id
	END

	DELETE FROM Vehicles WHERE Id = @id

RETURN 0
