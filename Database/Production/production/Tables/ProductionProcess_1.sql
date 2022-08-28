CREATE TABLE [production].[ProductionProcess] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (150)   NOT NULL,
    [ShortCode]   NVARCHAR (10)    NULL,
    [ProcessType] NVARCHAR (30)    NULL,
    [Details]     NVARCHAR (300)   NULL,
    [Status]      BIT              NOT NULL,
    [CreatedAt]   DATETIME         NULL,
    [CreatedBy]   UNIQUEIDENTIFIER NULL,
    [UpdatedAt]   DATETIME         NULL,
    [UpdatedBy]   UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_production_ProductionProcess_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

