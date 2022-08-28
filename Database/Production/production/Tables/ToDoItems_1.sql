CREATE TABLE [production].[ToDoItems] (
    [Id]    UNIQUEIDENTIFIER NOT NULL,
    [Title] VARCHAR (100)    NOT NULL,
    CONSTRAINT [PK_production_ToDoItems_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

