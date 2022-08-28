CREATE TABLE [production].[Floors] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [Name]      NVARCHAR (150)   NOT NULL,
    [Details]   NVARCHAR (500)   NULL,
    [Status]    BIT              NOT NULL,
    [CreatedAt] DATETIME         NULL,
    [CreatedBy] UNIQUEIDENTIFIER NULL,
    [UpdatedAt] DATETIME         NULL,
    [UpdatedBy] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_production_Floors_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

