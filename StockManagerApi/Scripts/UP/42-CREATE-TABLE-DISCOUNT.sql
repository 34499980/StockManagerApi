CREATE TABLE DISCOUNT(
	[ID] [BigInt] IDENTITY(1,1) NOT NULL,
	[IdUser] [int] NOT NULL,
	[Percent][int] NOT NULL,

	[IdStock] [BigInt] NULL,
	[DateFrom] [Datetime] NOT NULL,
	[DateTo] [Datetime] NOT NULL

	 CONSTRAINT PK_DISCOUNT PRIMARY KEY (ID),
	 CONSTRAINT FK_DISCOUNT_USER FOREIGN KEY (IdUser) REFERENCES USERS(ID),
	 CONSTRAINT FK_DISCOUNT_STOCK FOREIGN KEY (IdStock) REFERENCES STOCK(ID)
)