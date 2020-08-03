CREATE TABLE DISPATCH_STOCK(
	IdDispatch INT NOT NULL,
	IdStock BIGINT NOT NULL,
	Unity INT NOT NULL
	 CONSTRAINT FK_DISPATCH_STOCK_DISPATCH FOREIGN KEY (IdDispatch) REFERENCES DISPATCH(ID),
	 CONSTRAINT FK_DISPATCH_STOCK_STOCK FOREIGN KEY (IdStock) REFERENCES STOCK(ID)
)
