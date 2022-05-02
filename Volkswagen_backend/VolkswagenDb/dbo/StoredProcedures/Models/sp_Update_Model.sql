CREATE PROCEDURE [dbo].[sp_Update_Model]
	@id int,
	@makeId int,
	@name nvarchar(50)
AS
	UPDATE Models SET [Name] = @name WHERE Id = @id
RETURN 0
