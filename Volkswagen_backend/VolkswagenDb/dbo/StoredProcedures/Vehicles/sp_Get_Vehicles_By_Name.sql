CREATE PROCEDURE [dbo].[sp_Get_Vehicles_By_Name]
	@modelId int,
	@name nvarchar(50)
AS
	SELECT	* 
	FROM	Vehicles
	WHERE	RangeName LIKE '%' + @name + '%'
RETURN 0