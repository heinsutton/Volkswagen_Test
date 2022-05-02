CREATE PROCEDURE [dbo].[sp_Create_Model]
	@name nvarchar(50)
AS
	INSERT INTO Models VALUES (@name)

RETURN 0
