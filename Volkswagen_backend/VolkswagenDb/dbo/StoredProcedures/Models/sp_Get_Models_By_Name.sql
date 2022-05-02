CREATE PROCEDURE [dbo].[sp_Get_Models_By_Name]
	@name nvarchar(50)
AS
	SELECT * FROM Models WHERE [Name] LIKE '%' + @name + '%'
RETURN 0
