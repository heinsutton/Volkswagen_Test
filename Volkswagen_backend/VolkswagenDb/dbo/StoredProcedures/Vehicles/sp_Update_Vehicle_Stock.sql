CREATE PROCEDURE [dbo].[sp_Update_Vehicle_Stock]
	@id int,
	@stockNumber int = 0
AS
	IF (@stockNumber > 0)
	BEGIN 
		UPDATE Vehicles SET StockAmount = @stockNumber WHERE Id = @id
	END
	ELSE
	BEGIN
		DECLARE @newStockNumber AS INT

		SELECT @newStockNumber = StockAmount - 1 FROM Vehicles WHERE Id = @id

		UPDATE Vehicles SET StockAmount = @newStockNumber WHERE Id = @id
	END

	SELECT * FROM Vehicles WHERE Id = @id
RETURN 0
