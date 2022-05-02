CREATE PROCEDURE [dbo].[sp_Update_Vehicle]
	@id int,
	@modelId int,
	@rangeName nvarchar(50),
	@price decimal(19,4),
	@stockAmount int
AS
	UPDATE	Vehicles 
	SET		ModelId = @modelId,
			RangeName = @rangeName,
			Price = @price,
			StockAmount = @stockAmount
	WHERE	Id = @id


RETURN 0
