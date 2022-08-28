CREATE TABLE [production].[ToDoItemList] (
    [Id]     UNIQUEIDENTIFIER NOT NULL,
    [ItemId] UNIQUEIDENTIFIER NOT NULL,
    [Title]  VARCHAR (100)    NOT NULL,
    [Note]   VARCHAR (254)    NOT NULL,
    CONSTRAINT [PK_production_ToDoItemList_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_production_ToDoItemList_ToDoItems] FOREIGN KEY ([ItemId]) REFERENCES [production].[ToDoItems] ([Id])
);

