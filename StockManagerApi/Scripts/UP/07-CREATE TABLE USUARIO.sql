
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
	[IdSucursal] [int] NOT NULL,
	[IdRule] [int] NOT NULL,
	 CONSTRAINT PK_USUARIO PRIMARY KEY (ID),
	 CONSTRAINT FK_USUARIO_SUCURSAL FOREIGN KEY (IdSucursal) REFERENCES SUCURSAL(ID),
	 CONSTRAINT FK_USUARIO_RULES FOREIGN KEY (IdRule) REFERENCES RULES(ID)
)

