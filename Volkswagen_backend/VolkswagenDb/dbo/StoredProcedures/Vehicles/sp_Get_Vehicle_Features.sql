CREATE PROCEDURE [dbo].[sp_Get_Vehicle_Features]
	@VehicleId int
AS
	SELECT DISTINCT f.* 
	FROM Vehicles v
		INNER JOIN VehicleFeatures vf
			ON v.Id = vf.VehicleId
		INNER JOIN Features f
			ON vf.FeatureId = f.Id
	WHERE v.Id = @VehicleId
RETURN 0
