
CREATE TABLE [HISTORY](
	[ID] [BIGINT] IDENTITY(1,1) NOT NULL,
	[DateProces] [datetime] NOT NULL,
	[IdUser] [int] NOT NULL,
	[Action] [nvarchar](200) NOT NULL,
	[ActionDetail] [nvarchar](200) NOT NULL,
	[Refer] [nvarchar](max) NOT NULL,
	 CONSTRAINT PK_HISTORY PRIMARY KEY (ID),
	 CONSTRAINT FK_HISTORY_USERS FOREIGN KEY (IdUser) REFERENCES USERS(ID)
	
 
 )
