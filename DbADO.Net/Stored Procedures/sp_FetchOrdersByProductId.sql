CREATE PROCEDURE [dbo].[sp_FetchOrdersByProductId]
	@ProductId int

AS
Begin
	SELECT Id, CreatedDate, UpdatedDate, ProductId, StatusId from [dbo].[Order]
	where ProductId = @ProductId
End