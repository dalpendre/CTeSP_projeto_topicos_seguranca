CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Username] NCHAR(10) NOT NULL, 
    [SaltedPasswordHash] BINARY(64) NOT NULL, 
    [Salt] BINARY(8) NOT NULL
);
