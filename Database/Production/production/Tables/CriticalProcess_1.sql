CREATE TABLE [production].[CriticalProcess] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (150)   NOT NULL,
    [ProcessType] NVARCHAR (30)    NULL,
    [Status]      BIT              NOT NULL,
    [CreatedAt]   DATETIME         NULL,
    [CreatedBy]   UNIQUEIDENTIFIER NULL,
    [UpdatedAt]   DATETIME         NULL,
    [UpdatedBy]   UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_production_CriticalProcess_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

