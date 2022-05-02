CREATE PROCEDURE [dbo].[sp_Get_Model_By_Id]
	@id int
AS

	SELECT * FROM Models WHERE Id = @id

RETURN 0
