CREATE PROCEDURE [dbo].[sp_Create_Vehicle]
	@modelId int,
	@rangeName nvarchar(50),
	@price decimal(19,4),
	@stockAmount int
AS

	INSERT INTO Vehicles VALUES (@modelId, @rangeName, @price, @stockAmount)

RETURN 0
