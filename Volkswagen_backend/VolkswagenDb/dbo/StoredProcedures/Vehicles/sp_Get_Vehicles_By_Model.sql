CREATE PROCEDURE [dbo].[sp_Get_Vehicles_By_Model]
	@modelId int
AS
	SELECT * FROM Vehicles WHERE ModelId = @modelId
RETURN 0
