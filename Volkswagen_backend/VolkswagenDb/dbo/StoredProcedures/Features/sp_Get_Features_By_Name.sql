CREATE PROCEDURE [dbo].[sp_Get_Features_By_Name]
	@name nvarchar(200)
AS

	SELECT	*	
	FROM	Features
	WHERE	[Name] LIKE '%' + @name + '%'

RETURN 0
