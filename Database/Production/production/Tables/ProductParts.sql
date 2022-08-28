CREATE TABLE [production].[ProductParts] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [Name]      NVARCHAR (150)   NOT NULL,
    [ShortCode] NVARCHAR (10)    NULL,
    [Status]    BIT              NOT NULL,
    [CreatedAt] DATETIME         NULL,
    [CreatedBy] UNIQUEIDENTIFIER NULL,
    [UpdatedAt] DATETIME         NULL,
    [UpdatedBy] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_production_ProductParts_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

