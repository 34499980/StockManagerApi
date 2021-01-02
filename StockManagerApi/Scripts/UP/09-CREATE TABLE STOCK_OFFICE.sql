CREATE TABLE [STOCK_OFFICE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdOffice] [int] NOT NULL,
	[IdStock] [bigint] NOT NULL,
	[Unity] [int] NOT NULL,
	 CONSTRAINT PK_STOCK_OFFICE PRIMARY KEY (ID),
	 CONSTRAINT FK_STOCK_OFFICE_OFFICE FOREIGN KEY (IdOffice) REFERENCES OFFICE(ID),
	 CONSTRAINT FK_STOCK_OFFICE_STOCK FOREIGN KEY (IdStock) REFERENCES STOCK(ID)
)