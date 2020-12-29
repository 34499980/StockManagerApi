
CREATE TABLE [STOCK](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[QR] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Brand] [nvarchar](200) NOT NULL,
	[Model] [nvarchar](100) NOT NULL,
	[IdOffice] [int] NOT NULL,
	[IdState] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	 CONSTRAINT PK_STOCK PRIMARY KEY (ID),
	 CONSTRAINT FK_STOCK_OFFICE FOREIGN KEY (IdOffice) REFERENCES OFFICE(ID),
	 CONSTRAINT FK_STOCK_STOCK_STATE FOREIGN KEY (IdState) REFERENCES STOCK_STATE(ID)
)

