
CREATE PROCEDURE [dbo].[Get_StockByParameters](
	 @param NVARCHAR(500)
)
AS

DECLARE	@query NVARCHAR(MAX)

SET @query ='SELECT S.ID
					,S.Code
					,S.QR
					,S.Name
					,S.Brand
					,S.Model
					,S.IdSucursal
					,S.IdState
					,S.Description FROM STOCK S WITH(NOLOCK)
					INNER JOIN STOCK_SUCURSAL SS WITH(NOLOCK) ON S.ID = SS.IdStock'+ @param

EXEC(@query)