CREATE PROCEDURE [dbo].[sp_Update_Feature]
	@id int,
	@name nvarchar(200)
AS

	UPDATE	Features SET [Name] = @name WHERE Id = @id

RETURN 0
