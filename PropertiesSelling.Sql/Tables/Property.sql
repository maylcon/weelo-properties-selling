CREATE TABLE [dbo].[Property]
(
	[IdProperty] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Address] NVARCHAR(100) NOT NULL, 
    [Price] NUMERIC(12, 2) NULL, 
    [CodeInternal] NVARCHAR(10) NULL, 
    [Year] INT NULL, 
    [IdOwner] UNIQUEIDENTIFIER NOT NULL
    CONSTRAINT [FK_Property_Owner] FOREIGN KEY ([IdOwner]) REFERENCES [Owner]([IdOwner]) 
)

