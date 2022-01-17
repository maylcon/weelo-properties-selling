CREATE TABLE [dbo].[PropertyImage]
(
	[IdPropertyImage] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [IdProperty] UNIQUEIDENTIFIER NOT NULL, 
    [File] VARBINARY(MAX) NOT NULL, 
    [Enable] BIT NOT NULL, 
    CONSTRAINT [FK_PropertyImage_Property] FOREIGN KEY ([IdProperty]) REFERENCES [Property]([IdProperty])
)
