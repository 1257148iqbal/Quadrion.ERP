﻿CREATE TABLE [production].[CutPlans] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [CutPlanNo]       NVARCHAR (100)   NOT NULL,
    [StartDate]       DATETIME         NOT NULL,
    [StyleId]         UNIQUEIDENTIFIER NOT NULL,
    [StyleNo]         NVARCHAR (100)   NOT NULL,
    [BuyerId]         UNIQUEIDENTIFIER NOT NULL,
    [BuyerName]       NVARCHAR (100)   NOT NULL,
    [StyleCategoryId] UNIQUEIDENTIFIER NOT NULL,
    [StyleCategory]   NVARCHAR (100)   NOT NULL,
    [SizeGroupId]     UNIQUEIDENTIFIER NOT NULL,
    [SizeGroupName]   NVARCHAR (100)   NOT NULL,
    [LayPerCut]       DECIMAL (20, 2)  NULL,
    [TotalLay]        DECIMAL (20, 2)  NULL,
    [TotalQuantity]   DECIMAL (20, 2)  NULL,
    [IsRunningCut]    BIT              NOT NULL,
    [IsColorGroup]    BIT              NOT NULL,
    [Status]          BIT              NOT NULL,
    [CreatedAt]       DATETIME         NULL,
    [CreatedBy]       UNIQUEIDENTIFIER NULL,
    [UpdatedAt]       DATETIME         NULL,
    [UpdatedBy]       UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_production_CutPlans_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);

