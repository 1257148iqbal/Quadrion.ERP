CREATE TABLE [production].[ProductionProcessGroupProductionProcess] (
    [Id]                       UNIQUEIDENTIFIER NOT NULL,
    [SortOrder]                INT              NOT NULL,
    [ProductionProcessGroupId] UNIQUEIDENTIFIER NOT NULL,
    [ProductionProcessId]      UNIQUEIDENTIFIER NOT NULL,
    [ProductionSubProcessId]   NVARCHAR (50)    NULL,
    CONSTRAINT [PK_production_ProductionProcessGroupProductionProcess_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_production_ProductionProcessGroupProductionProcess_ProductionProcess] FOREIGN KEY ([ProductionProcessId]) REFERENCES [production].[ProductionProcess] ([Id]),
    CONSTRAINT [FK_production_ProductionProcessGroupProductionProcess_ProductionProcessGroups] FOREIGN KEY ([ProductionProcessGroupId]) REFERENCES [production].[ProductionProcessGroups] ([Id])
);

