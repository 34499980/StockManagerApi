CREATE TABLE DISPATCH_STOCK(
	[ID] [int] IDENTITY(1,1) NOT NULL,
	IdDispatch INT NOT NULL,
	IdStock BIGINT NOT NULL,
	Unity INT NOT NULL	
	 CONSTRAINT PK_DISPATCH_STOCK PRIMARY KEY (ID),
	 CONSTRAINT FK_DISPATCH_STOCK_DISPATCH FOREIGN KEY (IdDispatch) REFERENCES DISPATCH(ID),
	 CONSTRAINT FK_DISPATCH_STOCK_STOCK FOREIGN KEY (IdStock) REFERENCES STOCK(ID)
)

