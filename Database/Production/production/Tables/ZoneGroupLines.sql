CREATE TABLE [production].[ZoneGroupLines] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [ZoneGroupId] UNIQUEIDENTIFIER NOT NULL,
    [LineId]      UNIQUEIDENTIFIER NOT NULL,
    [LineName]    NVARCHAR (150)   NOT NULL,
    [Status]      BIT              NOT NULL,
    CONSTRAINT [PK_production_ZoneGroupLines_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_production_ZoneGroupLines_ZoneGroups] FOREIGN KEY ([ZoneGroupId]) REFERENCES [production].[ZoneGroups] ([Id]),
    CONSTRAINT [FK_production_ZoneGroups_Lines] FOREIGN KEY ([LineId]) REFERENCES [production].[Lines] ([Id])
);

