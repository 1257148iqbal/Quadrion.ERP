CREATE TABLE [production].[Lines] (
    [Id]                  UNIQUEIDENTIFIER NOT NULL,
    [Name]                NVARCHAR (150)   NOT NULL,
    [Details]             NVARCHAR (500)   NULL,
    [FloorId]             UNIQUEIDENTIFIER NULL,
    [ProductionProcessId] UNIQUEIDENTIFIER NULL,
    [Status]              BIT              NOT NULL,
    [CreatedAt]           DATETIME         NULL,
    [CreatedBy]           UNIQUEIDENTIFIER NULL,
    [UpdatedAt]           DATETIME         NULL,
    [UpdatedBy]           UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_production_Lines_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_production_Lines_Floors] FOREIGN KEY ([FloorId]) REFERENCES [production].[Floors] ([Id]),
    CONSTRAINT [FK_production_Lines_ProductionProcess] FOREIGN KEY ([ProductionProcessId]) REFERENCES [production].[ProductionProcess] ([Id])
);

