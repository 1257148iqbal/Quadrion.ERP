CREATE TABLE [production].[TimeSlots] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [Name]      NVARCHAR (150)   NOT NULL,
    [FromTime]  TIME (7)         NOT NULL,
    [ToTime]    TIME (7)         NOT NULL,
    [Duration]  INT              NOT NULL,
    [Status]    BIT              NOT NULL,
    [CreatedAt] DATETIME         NULL,
    [CreatedBy] UNIQUEIDENTIFIER NULL,
    [UpdatedAt] DATETIME         NULL,
    [UpdatedBy] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_production_TimeSlots_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

