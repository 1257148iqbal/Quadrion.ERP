CREATE TABLE [production].[ProductionProcessGroupProductionProcess] (
    [ProductionProcessGroupId] UNIQUEIDENTIFIER NOT NULL,
    [ProductionProcessId]      UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_production_ProductionProcessGroupProductionProcess_Id] PRIMARY KEY CLUSTERED ([ProductionProcessGroupId] ASC, [ProductionProcessId] ASC),
    CONSTRAINT [FK_production_ProductionProcessGroupProductionProcess_ProductionProcess] FOREIGN KEY ([ProductionProcessId]) REFERENCES [production].[ProductionProcess] ([Id]),
    CONSTRAINT [FK_production_ProductionProcessGroupProductionProcess_ProductionProcessGroups] FOREIGN KEY ([ProductionProcessGroupId]) REFERENCES [production].[ProductionProcessGroups] ([Id])
);

