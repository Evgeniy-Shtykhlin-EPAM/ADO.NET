CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [CreatedDate] DATETIME NOT NULL, 
    [UpdatedDate] DATETIME NULL, 
    [ProductId] INT NOT NULL, 
    [StatusId] INT NOT NULL, 
    CONSTRAINT [FK_Order_ToStatus] FOREIGN KEY ([StatusId]) REFERENCES [Status]([Id]), 
    CONSTRAINT [FK_Order_ToProduct] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
)
