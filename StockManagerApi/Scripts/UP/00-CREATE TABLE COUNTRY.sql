CREATE TABLE COUNTRY(
 ID INT IDENTITY(1,1),
 Description NVARCHAR(100) NOT NULL,
 Language NVARCHAR(100) NOT NULL,
 CONSTRAINT PK_COUNTRY PRIMARY KEY (ID)
)