CREATE PROCEDURE [dbo].[sp_Delete_VehicleModel]
	@Id int
AS

	DELETE FROM Models WHERE Id = @Id

RETURN 0
