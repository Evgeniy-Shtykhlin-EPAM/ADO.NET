CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [Name] NVARCHAR(20) NOT NULL, 
    [Weight] FLOAT NOT NULL, 
    [Height] FLOAT NOT NULL, 
    [Width] FLOAT NOT NULL, 
    [Length] FLOAT NOT NULL, 
    [Description] NVARCHAR(100) NOT NULL
)
