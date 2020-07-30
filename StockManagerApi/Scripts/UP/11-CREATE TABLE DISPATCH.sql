CREATE TABLE [DISPATCH](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DateCreate] [datetime] NOT NULL,
	[IdUser] [int] NOT NULL,
	[Origin] [int] NOT NULL,
	[Destiny] [int] NOT NULL,
	[IdState] [int] NOT NULL,
	[DateDispatched] [int] NOT NULL,
	[DateRecived] [int] NOT NULL,
	[Unity] [int] NOT NULL,
	 CONSTRAINT PK_DISPATCH PRIMARY KEY (ID),
	 CONSTRAINT FK_DISPATCH_USERS FOREIGN KEY (IdUser) REFERENCES USERS(ID),
	 CONSTRAINT FK_DISPATCH_DISPATCH_STATE FOREIGN KEY (IdState) REFERENCES DISPATCH_STATE(ID)
	
)