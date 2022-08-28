CREATE TABLE [production].[Cuttings] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [CutNo]     NVARCHAR (30)    NOT NULL,
    [CutDate]   DATETIME         NULL,
    [TableNo]   NVARCHAR (20)    NULL,
    [ComboQty]  DECIMAL (10, 2)  NULL,
    [LayPerCut] DECIMAL (10, 2)  NOT NULL,
    [StyleId]   UNIQUEIDENTIFIER NOT NULL,
    [CutPlanId] UNIQUEIDENTIFIER NOT NULL,
    [CutPlanNo] NVARCHAR (100)   NOT NULL,
    [MarkerId]  UNIQUEIDENTIFIER NOT NULL,
    [Status]    NVARCHAR (20)    NULL,
    [CreatedAt] DATETIME         NULL,
    [CreatedBy] UNIQUEIDENTIFIER NULL,
    [UpdatedAt] DATETIME         NULL,
    [UpdatedBy] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_production_Cuttings_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_production_Cuttings_CutPlans] FOREIGN KEY ([CutPlanId]) REFERENCES [production].[CutPlans] ([Id])
);

