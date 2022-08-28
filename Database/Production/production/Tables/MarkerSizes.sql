CREATE TABLE [production].[MarkerSizes] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [CutPlanNo] NVARCHAR (100)   NOT NULL,
    [CutPlanId] UNIQUEIDENTIFIER NOT NULL,
    [MarkerId]  UNIQUEIDENTIFIER NOT NULL,
    [SizeId]    UNIQUEIDENTIFIER NOT NULL,
    [SizeName]  NVARCHAR (20)    NOT NULL,
    [Ratio]     DECIMAL (20, 2)  NOT NULL,
    [Quantity]  DECIMAL (20, 2)  NOT NULL,
    CONSTRAINT [PK_production_MarkerSizes_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_production_MarkerSizes_Markers] FOREIGN KEY ([MarkerId]) REFERENCES [production].[Markers] ([Id])
);

