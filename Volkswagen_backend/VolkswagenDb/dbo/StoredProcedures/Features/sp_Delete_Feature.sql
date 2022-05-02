CREATE PROCEDURE [dbo].[sp_Delete_Feature]
	@featureId int
AS
	DELETE FROM Features WHERE Id = @featureId
RETURN 0
