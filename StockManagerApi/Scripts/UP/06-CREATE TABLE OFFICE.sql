
CREATE TABLE OFFICE(
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Address] [nvarchar](500) NULL,
	[PostalCode] [int] NULL,
	[IdCountry] INT NOT NULL,
	[Active] [bit] NOT NULL
	 CONSTRAINT PK_OFFICE PRIMARY KEY (ID),
	 CONSTRAINT FK_OFFICE_COUNTRY FOREIGN KEY (IdCountry) REFERENCES COUNTRY(ID)
)


