
CREATE TABLE [SALE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DateProces] [datetime] NOT NULL,
	[IdUser] [int] NOT NULL,
	[Amount] [float] NOT NULL,
	[Refer] [nvarchar](max) NOT NULL,
	[IdOffice] [int] NOT NULL,
	[IdState] [int] NOT NULL,
	 CONSTRAINT PK_SALE PRIMARY KEY (ID),
	 CONSTRAINT FK_SALE_USERS FOREIGN KEY (IdUser) REFERENCES USERS(ID),
	 CONSTRAINT FK_SALE_OFFICE FOREIGN KEY (IdOffice) REFERENCES OFFICE(ID),
	 CONSTRAINT FK_SALE_SALE_STATE FOREIGN KEY (IdOffice) REFERENCES SALE_STATE(ID)
 
 )
