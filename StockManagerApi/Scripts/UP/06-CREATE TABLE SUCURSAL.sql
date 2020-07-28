
CREATE TABLE SUCURSAL(
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Address] [nvarchar](500) NULL,
	[PostalCode] [int] NULL,
	 CONSTRAINT PK_SUCURSAL PRIMARY KEY (ID)
)


