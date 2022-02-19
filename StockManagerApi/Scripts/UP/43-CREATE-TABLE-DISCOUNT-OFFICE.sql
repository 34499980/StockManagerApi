CREATE TABLE DISCOUNT_OFFICE(
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdOffice] [int] NOT NULL,	
	[IdDiscount] [BigInt] NOT NULL

	 CONSTRAINT PK_DISCOUNT_OFFICE PRIMARY KEY (ID),
	 CONSTRAINT FK_DISCOUNT_OFFICE_OFFICE FOREIGN KEY (IdOffice) REFERENCES OFFICE(ID),
	 CONSTRAINT FK_DISCOUNT_OFFICE_DISCOUNT FOREIGN KEY (IdDiscount) REFERENCES DISCOUNT(ID)
	 
)