CREATE TABLE [production].[Markers] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [CutPlanId] UNIQUEIDENTIFIER NOT NULL,
    [CutPlanNo] NVARCHAR (100)   NOT NULL,
    [Length]    DECIMAL (20, 2)  NOT NULL,
    [Width]     DECIMAL (20, 2)  NOT NULL,
    [TotalQty]  DECIMAL (20, 2)  NOT NULL,
    CONSTRAINT [PK_production_Markers_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_production_Markers_CutPlans] FOREIGN KEY ([CutPlanId]) REFERENCES [production].[CutPlans] ([Id])
);

