CREATE TABLE [dbo].[PropertyTrace]
(
	[IdPropertyTrace] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [DateSale] DATE NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Value] NUMERIC(18, 5) NOT NULL, 
    [Tax] NUMERIC(18, 5) NOT NULL, 
    [IdProperty] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_PropertyTrace_Property] FOREIGN KEY ([IdProperty]) REFERENCES [Property]([IdProperty])
)
