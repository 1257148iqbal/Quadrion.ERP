CREATE TABLE [production].[RejectTypes] (
    [Id]                  UNIQUEIDENTIFIER NOT NULL,
    [ProductionProcessId] UNIQUEIDENTIFIER NOT NULL,
    [Name]                NVARCHAR (150)   NOT NULL,
    [Status]              BIT              NOT NULL,
    [CreatedAt]           DATETIME         NULL,
    [CreatedBy]           UNIQUEIDENTIFIER NULL,
    [UpdatedAt]           DATETIME         NULL,
    [UpdatedBy]           UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_production_RejectTypes_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_production_RejectTypes_ProductionProcess] FOREIGN KEY ([ProductionProcessId]) REFERENCES [production].[ProductionProcess] ([Id])
);

