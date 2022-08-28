CREATE TABLE [production].[ProductionProcessGroups] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [GroupName] NVARCHAR (150)   NOT NULL,
    [Status]    BIT              NOT NULL,
    [CreatedAt] DATETIME         NULL,
    [CreatedBy] UNIQUEIDENTIFIER NULL,
    [UpdatedAt] DATETIME         NULL,
    [UpdatedBy] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_production_ProductionProcessGroups_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

