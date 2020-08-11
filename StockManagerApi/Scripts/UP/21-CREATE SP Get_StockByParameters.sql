
CREATE PROCEDURE [dbo].[Get_StockByParameters](
	 @param NVARCHAR(500)
)
AS

DECLARE	@query NVARCHAR(MAX)

SET @query ='SELECT * FROM STOCK '+ @param

EXEC(@query)