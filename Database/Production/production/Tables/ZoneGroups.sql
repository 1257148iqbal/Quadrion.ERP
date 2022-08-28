CREATE TABLE [production].[ZoneGroups] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [ZoneId]       UNIQUEIDENTIFIER NOT NULL,
    [ZoneName]     NVARCHAR (150)   NOT NULL,
    [OwnerEmpCode] NVARCHAR (150)   NULL,
    [OwnerName]    NVARCHAR (150)   NULL,
    [Status]       BIT              NOT NULL,
    [CreatedAt]    DATETIME         NULL,
    [CreatedBy]    UNIQUEIDENTIFIER NULL,
    [UpdatedAt]    DATETIME         NULL,
    [UpdatedBy]    UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_production_ZoneGroups_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_production_ZoneGroups_Zones] FOREIGN KEY ([ZoneId]) REFERENCES [production].[Zones] ([Id])
);

