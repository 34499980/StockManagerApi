
CREATE TABLE USERS(
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](10) NOT NULL,
	[First_name] [nvarchar](200) NOT NULL,
	[Last_name] [nvarchar](200) NOT NULL,
	[DateBorn] [datetime] NOT NULL,
	[DateAdmission] [datetime] NOT NULL,
	[Email] [nvarchar](500) NULL,
	[Address] [nvarchar](500) NOT NULL,
	[PostalCode] [int] NOT NULL,
	[IdOffice] [int] NOT NULL,	
	[IdRole] [int] NOT NULL,
	[Active] [bit] NOT NULL DEFAULT 1,
	 CONSTRAINT PK_USERS PRIMARY KEY (ID),
	 CONSTRAINT FK_USERS_OFFICE FOREIGN KEY (IdOffice) REFERENCES OFFICE(ID),
	 CONSTRAINT FK_USERS_ROLES FOREIGN KEY (IdRole) REFERENCES ROLES(ID)
)

