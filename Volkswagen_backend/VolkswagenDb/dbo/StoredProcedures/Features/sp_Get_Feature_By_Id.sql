CREATE PROCEDURE [dbo].[sp_Get_Feature_By_Id]
	@Id int = 0
AS

	SELECT * 
	FROM Features
	WHERE Id = @Id

RETURN 0
