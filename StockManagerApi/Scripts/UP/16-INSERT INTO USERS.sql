INSERT INTO [dbo].[USERS]
           ([UserName]
           ,[Password]
           ,[First_name]
           ,[Last_name]
           ,[DateBorn]
           ,[DateAdmission]
           ,[Email]
           ,[Address]
           ,[PostalCode]
           ,[IdSucursal]
           ,[IdRole])
   SELECT 'admin',
		  '123',
		  'admin',
		  'admin',
		  24/07/2020,
		  24/07/2020,
		  'admin@StockManager.com',
		  'Central',
		  '1426',
		   1,
		   1

