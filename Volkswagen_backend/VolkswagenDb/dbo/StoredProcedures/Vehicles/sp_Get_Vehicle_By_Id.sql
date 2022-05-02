CREATE PROCEDURE [dbo].[sp_Get_Vehicle_By_Id]
	@Id int
AS

	SELECT * FROM Vehicles WHERE Id = @Id

RETURN 0
