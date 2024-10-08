IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914160755_InitialCreate'
)
BEGIN
    CREATE TABLE [BreakpointAnalysisTables] (
        [ID] int NOT NULL IDENTITY,
        [MaterialCode] nvarchar(max) NOT NULL,
        [LocationCode] nvarchar(max) NOT NULL,
        [FaultCode] nvarchar(max) NOT NULL,
        [BreakpointTime] nvarchar(max) NOT NULL,
        [PQSNumber] nvarchar(max) NOT NULL,
        [VAN] nvarchar(max) NOT NULL,
        [VIN] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_BreakpointAnalysisTables] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914160755_InitialCreate'
)
BEGIN
    CREATE TABLE [DailyQualityIssueChecklists] (
        [ID] int NOT NULL IDENTITY,
        [SerialNumber] nvarchar(max) NOT NULL,
        [ApprovalDate] nvarchar(max) NOT NULL,
        [Model] nvarchar(max) NOT NULL,
        [OldMaterialCode] nvarchar(max) NOT NULL,
        [OldMaterialDescription] nvarchar(max) NOT NULL,
        [SupplierShortCode] nvarchar(max) NOT NULL,
        [ResponsibilitySourceSupplierName] nvarchar(max) NOT NULL,
        [CaseCount] nvarchar(max) NOT NULL,
        [MIS] nvarchar(max) NOT NULL,
        [FaultMode] nvarchar(max) NOT NULL,
        [QE] nvarchar(max) NOT NULL,
        [IncludedInSIL] nvarchar(max) NOT NULL,
        [PQSNumber] nvarchar(max) NOT NULL,
        [BreakpointTime] nvarchar(max) NOT NULL,
        [StartTime] nvarchar(max) NOT NULL,
        [Remarks] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_DailyQualityIssueChecklists] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914160755_InitialCreate'
)
BEGIN
    CREATE TABLE [DailyQualityIssueChecklistV91Queries] (
        [ID] int NOT NULL IDENTITY,
        [ApprovalDate] nvarchar(max) NOT NULL,
        [VehicleModel] nvarchar(max) NOT NULL,
        [OldMaterialCode] nvarchar(max) NOT NULL,
        [OldMaterialDescription] nvarchar(max) NOT NULL,
        [SupplierShortCode] nvarchar(max) NOT NULL,
        [ResponsibilitySourceSupplierName] nvarchar(max) NOT NULL,
        [CaseCount] nvarchar(max) NOT NULL,
        [AccumulatedCaseCount] nvarchar(max) NOT NULL,
        [MIS3] nvarchar(max) NOT NULL,
        [MIS6] nvarchar(max) NOT NULL,
        [MIS12] nvarchar(max) NOT NULL,
        [MIS24] nvarchar(max) NOT NULL,
        [MIS36] nvarchar(max) NOT NULL,
        [SMT] nvarchar(max) NOT NULL,
        [LocationCode] nvarchar(max) NOT NULL,
        [FaultCode] nvarchar(max) NOT NULL,
        [PQSNumber] nvarchar(max) NOT NULL,
        [VAN] nvarchar(max) NOT NULL,
        [VIN] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_DailyQualityIssueChecklistV91Queries] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914160755_InitialCreate'
)
BEGIN
    CREATE TABLE [DailyQualityIssueChecklistV91s] (
        [ID] int NOT NULL IDENTITY,
        [OldMaterialCode] nvarchar(max) NOT NULL,
        [OldMaterialDescription] nvarchar(max) NOT NULL,
        [SupplierShortCode] nvarchar(max) NOT NULL,
        [ResponsibilitySourceSupplierName] nvarchar(max) NOT NULL,
        [MIS3] nvarchar(max) NOT NULL,
        [MIS6] nvarchar(max) NOT NULL,
        [MIS12] nvarchar(max) NOT NULL,
        [MIS24] nvarchar(max) NOT NULL,
        [MIS36] nvarchar(max) NOT NULL,
        [SMT] nvarchar(max) NOT NULL,
        [LocationCode] nvarchar(max) NOT NULL,
        [FaultCode] nvarchar(max) NOT NULL,
        [QE] nvarchar(max) NOT NULL,
        [ServiceFaultIdentificationAccurate] nvarchar(max) NOT NULL,
        [IdentifiedFaultMode] nvarchar(max) NOT NULL,
        [BreakdownCount] nvarchar(max) NOT NULL,
        [IsBreakdownInvalid] nvarchar(max) NOT NULL,
        [IncludedInSIL] nvarchar(max) NOT NULL,
        [PQSNumber] nvarchar(max) NOT NULL,
        [BreakpointTime] nvarchar(max) NOT NULL,
        [StartTime] nvarchar(max) NOT NULL,
        [Remarks] nvarchar(max) NOT NULL,
        [ProjectIdentifier] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_DailyQualityIssueChecklistV91s] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914160755_InitialCreate'
)
BEGIN
    CREATE TABLE [DailyServiceReviewForms] (
        [ID] int NOT NULL IDENTITY,
        [ServiceOrder] nvarchar(max) NOT NULL,
        [ServiceOrderStatus] nvarchar(max) NOT NULL,
        [ServiceOrderTotalPrice] nvarchar(max) NOT NULL,
        [WorkOrderNumber] nvarchar(max) NOT NULL,
        [WorkOrderCreationDate] nvarchar(max) NOT NULL,
        [WorkOrderType] nvarchar(max) NOT NULL,
        [DepartureTime] nvarchar(max) NOT NULL,
        [CarPickupTime] nvarchar(max) NOT NULL,
        [WorkOrderRepairEndTime] nvarchar(max) NOT NULL,
        [WorkOrderRepairAccount] nvarchar(max) NOT NULL,
        [OutboundServiceLocation] nvarchar(max) NOT NULL,
        [OutboundMileage] nvarchar(max) NOT NULL,
        [Province] nvarchar(max) NOT NULL,
        [ServiceStation] nvarchar(max) NOT NULL,
        [ServiceStationName] nvarchar(max) NOT NULL,
        [NoticeVehicleModel] nvarchar(max) NOT NULL,
        [VAN] nvarchar(max) NOT NULL,
        [VIN] nvarchar(max) NOT NULL,
        [WarrantyStartDate] nvarchar(max) NOT NULL,
        [MaterialType] nvarchar(max) NOT NULL,
        [LineNumber] nvarchar(max) NOT NULL,
        [OldMaterialCode] nvarchar(max) NOT NULL,
        [OldMaterialDescription] nvarchar(max) NOT NULL,
        [NewMaterialCode] nvarchar(max) NOT NULL,
        [NewMaterialDescription] nvarchar(max) NOT NULL,
        [RepairMethod] nvarchar(max) NOT NULL,
        [SupplyMethod] nvarchar(max) NOT NULL,
        [Quantity] nvarchar(max) NOT NULL,
        [OldPartReturnStatus] nvarchar(max) NOT NULL,
        [ResponsibilitySourceIdentifier] nvarchar(max) NOT NULL,
        [ResponsibilitySourceSupplier] nvarchar(max) NOT NULL,
        [SupplierShortCode] nvarchar(max) NOT NULL,
        [ResponsibilitySourceSupplierName] nvarchar(max) NOT NULL,
        [LinePrice] nvarchar(max) NOT NULL,
        [ActualAmount] nvarchar(max) NOT NULL,
        [MaterialMarkupCoefficient] nvarchar(max) NOT NULL,
        [LaborRegionCoefficient] nvarchar(max) NOT NULL,
        [LaborColdClimateCoefficient] nvarchar(max) NOT NULL,
        [LaborQualityCoefficient] nvarchar(max) NOT NULL,
        [LocationCode] nvarchar(max) NOT NULL,
        [LocationCodeDescription] nvarchar(max) NOT NULL,
        [FaultCode] nvarchar(max) NOT NULL,
        [FaultCodeDescription] nvarchar(max) NOT NULL,
        [FaultDescription] nvarchar(max) NOT NULL,
        [ServiceCategory] nvarchar(max) NOT NULL,
        [ServiceOrderCreationDate] nvarchar(max) NOT NULL,
        [FDP] nvarchar(max) NOT NULL,
        [SpecialAuthorizationCode] nvarchar(max) NOT NULL,
        [WBS] nvarchar(max) NOT NULL,
        [DrivingMileageKM] nvarchar(max) NOT NULL,
        [OutboundRescueLicensePlate1] nvarchar(max) NOT NULL,
        [OutboundRescueLicensePlate2] nvarchar(max) NOT NULL,
        [ApprovalDate] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_DailyServiceReviewForms] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914160755_InitialCreate'
)
BEGIN
    CREATE TABLE [VehicleBasicInfos] (
        [ID] int NOT NULL IDENTITY,
        [ShortVin] nvarchar(max) NOT NULL,
        [VIN] nvarchar(max) NOT NULL,
        [VAN] nvarchar(max) NOT NULL,
        [FDP] nvarchar(max) NOT NULL,
        [AnnouncementModel] nvarchar(max) NOT NULL,
        [ProductionDate] nvarchar(max) NOT NULL,
        [SalesDate] nvarchar(max) NOT NULL,
        [EngineNumber] nvarchar(max) NOT NULL,
        [ClaimDate] nvarchar(max) NOT NULL,
        [ExportStatus] nvarchar(max) NOT NULL,
        [EngineModel] nvarchar(max) NOT NULL,
        [SsvaOrSva] nvarchar(max) NOT NULL,
        [InternalAnnouncemen] nvarchar(max) NOT NULL,
        [SeriesDescription] nvarchar(max) NOT NULL,
        [ProductionMouth] nvarchar(max) NOT NULL,
        [Series] nvarchar(max) NOT NULL,
        [Emissions] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_VehicleBasicInfos] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914160755_InitialCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240914160755_InitialCreate', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914162652_MakePropertiesNullable'
)
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91Queries]') AND [c].[name] = N'VehicleModel');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91Queries] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ALTER COLUMN [VehicleModel] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914162652_MakePropertiesNullable'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91Queries]') AND [c].[name] = N'VIN');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91Queries] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ALTER COLUMN [VIN] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914162652_MakePropertiesNullable'
)
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91Queries]') AND [c].[name] = N'VAN');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91Queries] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ALTER COLUMN [VAN] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914162652_MakePropertiesNullable'
)
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91Queries]') AND [c].[name] = N'SupplierShortCode');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91Queries] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ALTER COLUMN [SupplierShortCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914162652_MakePropertiesNullable'
)
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91Queries]') AND [c].[name] = N'SMT');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91Queries] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ALTER COLUMN [SMT] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914162652_MakePropertiesNullable'
)
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91Queries]') AND [c].[name] = N'ResponsibilitySourceSupplierName');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91Queries] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ALTER COLUMN [ResponsibilitySourceSupplierName] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914162652_MakePropertiesNullable'
)
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91Queries]') AND [c].[name] = N'PQSNumber');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91Queries] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ALTER COLUMN [PQSNumber] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914162652_MakePropertiesNullable'
)
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91Queries]') AND [c].[name] = N'OldMaterialDescription');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91Queries] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ALTER COLUMN [OldMaterialDescription] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914162652_MakePropertiesNullable'
)
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91Queries]') AND [c].[name] = N'OldMaterialCode');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91Queries] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ALTER COLUMN [OldMaterialCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914162652_MakePropertiesNullable'
)
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91Queries]') AND [c].[name] = N'MIS6');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91Queries] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ALTER COLUMN [MIS6] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914162652_MakePropertiesNullable'
)
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91Queries]') AND [c].[name] = N'MIS36');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91Queries] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ALTER COLUMN [MIS36] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914162652_MakePropertiesNullable'
)
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91Queries]') AND [c].[name] = N'MIS3');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91Queries] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ALTER COLUMN [MIS3] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914162652_MakePropertiesNullable'
)
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91Queries]') AND [c].[name] = N'MIS24');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91Queries] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ALTER COLUMN [MIS24] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914162652_MakePropertiesNullable'
)
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91Queries]') AND [c].[name] = N'MIS12');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91Queries] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ALTER COLUMN [MIS12] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914162652_MakePropertiesNullable'
)
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91Queries]') AND [c].[name] = N'LocationCode');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91Queries] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ALTER COLUMN [LocationCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914162652_MakePropertiesNullable'
)
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91Queries]') AND [c].[name] = N'FaultCode');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91Queries] DROP CONSTRAINT [' + @var15 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ALTER COLUMN [FaultCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914162652_MakePropertiesNullable'
)
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91Queries]') AND [c].[name] = N'CaseCount');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91Queries] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ALTER COLUMN [CaseCount] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914162652_MakePropertiesNullable'
)
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91Queries]') AND [c].[name] = N'ApprovalDate');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91Queries] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ALTER COLUMN [ApprovalDate] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914162652_MakePropertiesNullable'
)
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91Queries]') AND [c].[name] = N'AccumulatedCaseCount');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91Queries] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ALTER COLUMN [AccumulatedCaseCount] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914162652_MakePropertiesNullable'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240914162652_MakePropertiesNullable', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var19 sysname;
    SELECT @var19 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleBasicInfos]') AND [c].[name] = N'VIN');
    IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [VehicleBasicInfos] DROP CONSTRAINT [' + @var19 + '];');
    ALTER TABLE [VehicleBasicInfos] ALTER COLUMN [VIN] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var20 sysname;
    SELECT @var20 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleBasicInfos]') AND [c].[name] = N'VAN');
    IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [VehicleBasicInfos] DROP CONSTRAINT [' + @var20 + '];');
    ALTER TABLE [VehicleBasicInfos] ALTER COLUMN [VAN] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var21 sysname;
    SELECT @var21 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleBasicInfos]') AND [c].[name] = N'SsvaOrSva');
    IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [VehicleBasicInfos] DROP CONSTRAINT [' + @var21 + '];');
    ALTER TABLE [VehicleBasicInfos] ALTER COLUMN [SsvaOrSva] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var22 sysname;
    SELECT @var22 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleBasicInfos]') AND [c].[name] = N'ShortVin');
    IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [VehicleBasicInfos] DROP CONSTRAINT [' + @var22 + '];');
    ALTER TABLE [VehicleBasicInfos] ALTER COLUMN [ShortVin] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var23 sysname;
    SELECT @var23 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleBasicInfos]') AND [c].[name] = N'SeriesDescription');
    IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [VehicleBasicInfos] DROP CONSTRAINT [' + @var23 + '];');
    ALTER TABLE [VehicleBasicInfos] ALTER COLUMN [SeriesDescription] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var24 sysname;
    SELECT @var24 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleBasicInfos]') AND [c].[name] = N'Series');
    IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [VehicleBasicInfos] DROP CONSTRAINT [' + @var24 + '];');
    ALTER TABLE [VehicleBasicInfos] ALTER COLUMN [Series] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var25 sysname;
    SELECT @var25 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleBasicInfos]') AND [c].[name] = N'SalesDate');
    IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [VehicleBasicInfos] DROP CONSTRAINT [' + @var25 + '];');
    ALTER TABLE [VehicleBasicInfos] ALTER COLUMN [SalesDate] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var26 sysname;
    SELECT @var26 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleBasicInfos]') AND [c].[name] = N'ProductionMouth');
    IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [VehicleBasicInfos] DROP CONSTRAINT [' + @var26 + '];');
    ALTER TABLE [VehicleBasicInfos] ALTER COLUMN [ProductionMouth] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var27 sysname;
    SELECT @var27 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleBasicInfos]') AND [c].[name] = N'ProductionDate');
    IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [VehicleBasicInfos] DROP CONSTRAINT [' + @var27 + '];');
    ALTER TABLE [VehicleBasicInfos] ALTER COLUMN [ProductionDate] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var28 sysname;
    SELECT @var28 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleBasicInfos]') AND [c].[name] = N'InternalAnnouncemen');
    IF @var28 IS NOT NULL EXEC(N'ALTER TABLE [VehicleBasicInfos] DROP CONSTRAINT [' + @var28 + '];');
    ALTER TABLE [VehicleBasicInfos] ALTER COLUMN [InternalAnnouncemen] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var29 sysname;
    SELECT @var29 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleBasicInfos]') AND [c].[name] = N'FDP');
    IF @var29 IS NOT NULL EXEC(N'ALTER TABLE [VehicleBasicInfos] DROP CONSTRAINT [' + @var29 + '];');
    ALTER TABLE [VehicleBasicInfos] ALTER COLUMN [FDP] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var30 sysname;
    SELECT @var30 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleBasicInfos]') AND [c].[name] = N'ExportStatus');
    IF @var30 IS NOT NULL EXEC(N'ALTER TABLE [VehicleBasicInfos] DROP CONSTRAINT [' + @var30 + '];');
    ALTER TABLE [VehicleBasicInfos] ALTER COLUMN [ExportStatus] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var31 sysname;
    SELECT @var31 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleBasicInfos]') AND [c].[name] = N'EngineNumber');
    IF @var31 IS NOT NULL EXEC(N'ALTER TABLE [VehicleBasicInfos] DROP CONSTRAINT [' + @var31 + '];');
    ALTER TABLE [VehicleBasicInfos] ALTER COLUMN [EngineNumber] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var32 sysname;
    SELECT @var32 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleBasicInfos]') AND [c].[name] = N'EngineModel');
    IF @var32 IS NOT NULL EXEC(N'ALTER TABLE [VehicleBasicInfos] DROP CONSTRAINT [' + @var32 + '];');
    ALTER TABLE [VehicleBasicInfos] ALTER COLUMN [EngineModel] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var33 sysname;
    SELECT @var33 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleBasicInfos]') AND [c].[name] = N'Emissions');
    IF @var33 IS NOT NULL EXEC(N'ALTER TABLE [VehicleBasicInfos] DROP CONSTRAINT [' + @var33 + '];');
    ALTER TABLE [VehicleBasicInfos] ALTER COLUMN [Emissions] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var34 sysname;
    SELECT @var34 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleBasicInfos]') AND [c].[name] = N'ClaimDate');
    IF @var34 IS NOT NULL EXEC(N'ALTER TABLE [VehicleBasicInfos] DROP CONSTRAINT [' + @var34 + '];');
    ALTER TABLE [VehicleBasicInfos] ALTER COLUMN [ClaimDate] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var35 sysname;
    SELECT @var35 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleBasicInfos]') AND [c].[name] = N'AnnouncementModel');
    IF @var35 IS NOT NULL EXEC(N'ALTER TABLE [VehicleBasicInfos] DROP CONSTRAINT [' + @var35 + '];');
    ALTER TABLE [VehicleBasicInfos] ALTER COLUMN [AnnouncementModel] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var36 sysname;
    SELECT @var36 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'WorkOrderType');
    IF @var36 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var36 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [WorkOrderType] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var37 sysname;
    SELECT @var37 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'WorkOrderRepairEndTime');
    IF @var37 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var37 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [WorkOrderRepairEndTime] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var38 sysname;
    SELECT @var38 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'WorkOrderRepairAccount');
    IF @var38 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var38 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [WorkOrderRepairAccount] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var39 sysname;
    SELECT @var39 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'WorkOrderNumber');
    IF @var39 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var39 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [WorkOrderNumber] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var40 sysname;
    SELECT @var40 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'WorkOrderCreationDate');
    IF @var40 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var40 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [WorkOrderCreationDate] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var41 sysname;
    SELECT @var41 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'WarrantyStartDate');
    IF @var41 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var41 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [WarrantyStartDate] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var42 sysname;
    SELECT @var42 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'WBS');
    IF @var42 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var42 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [WBS] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var43 sysname;
    SELECT @var43 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'VIN');
    IF @var43 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var43 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [VIN] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var44 sysname;
    SELECT @var44 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'VAN');
    IF @var44 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var44 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [VAN] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var45 sysname;
    SELECT @var45 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'SupplyMethod');
    IF @var45 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var45 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [SupplyMethod] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var46 sysname;
    SELECT @var46 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'SupplierShortCode');
    IF @var46 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var46 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [SupplierShortCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var47 sysname;
    SELECT @var47 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'SpecialAuthorizationCode');
    IF @var47 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var47 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [SpecialAuthorizationCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var48 sysname;
    SELECT @var48 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'ServiceStationName');
    IF @var48 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var48 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [ServiceStationName] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var49 sysname;
    SELECT @var49 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'ServiceStation');
    IF @var49 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var49 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [ServiceStation] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var50 sysname;
    SELECT @var50 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'ServiceOrderTotalPrice');
    IF @var50 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var50 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [ServiceOrderTotalPrice] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var51 sysname;
    SELECT @var51 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'ServiceOrderStatus');
    IF @var51 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var51 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [ServiceOrderStatus] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var52 sysname;
    SELECT @var52 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'ServiceOrderCreationDate');
    IF @var52 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var52 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [ServiceOrderCreationDate] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var53 sysname;
    SELECT @var53 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'ServiceOrder');
    IF @var53 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var53 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [ServiceOrder] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var54 sysname;
    SELECT @var54 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'ServiceCategory');
    IF @var54 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var54 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [ServiceCategory] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var55 sysname;
    SELECT @var55 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'ResponsibilitySourceSupplierName');
    IF @var55 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var55 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [ResponsibilitySourceSupplierName] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var56 sysname;
    SELECT @var56 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'ResponsibilitySourceSupplier');
    IF @var56 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var56 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [ResponsibilitySourceSupplier] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var57 sysname;
    SELECT @var57 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'ResponsibilitySourceIdentifier');
    IF @var57 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var57 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [ResponsibilitySourceIdentifier] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var58 sysname;
    SELECT @var58 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'RepairMethod');
    IF @var58 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var58 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [RepairMethod] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var59 sysname;
    SELECT @var59 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'Quantity');
    IF @var59 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var59 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [Quantity] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var60 sysname;
    SELECT @var60 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'Province');
    IF @var60 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var60 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [Province] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var61 sysname;
    SELECT @var61 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'OutboundServiceLocation');
    IF @var61 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var61 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [OutboundServiceLocation] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var62 sysname;
    SELECT @var62 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'OutboundRescueLicensePlate2');
    IF @var62 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var62 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [OutboundRescueLicensePlate2] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var63 sysname;
    SELECT @var63 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'OutboundRescueLicensePlate1');
    IF @var63 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var63 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [OutboundRescueLicensePlate1] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var64 sysname;
    SELECT @var64 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'OutboundMileage');
    IF @var64 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var64 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [OutboundMileage] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var65 sysname;
    SELECT @var65 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'OldPartReturnStatus');
    IF @var65 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var65 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [OldPartReturnStatus] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var66 sysname;
    SELECT @var66 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'OldMaterialDescription');
    IF @var66 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var66 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [OldMaterialDescription] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var67 sysname;
    SELECT @var67 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'OldMaterialCode');
    IF @var67 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var67 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [OldMaterialCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var68 sysname;
    SELECT @var68 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'NoticeVehicleModel');
    IF @var68 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var68 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [NoticeVehicleModel] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var69 sysname;
    SELECT @var69 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'NewMaterialDescription');
    IF @var69 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var69 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [NewMaterialDescription] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var70 sysname;
    SELECT @var70 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'NewMaterialCode');
    IF @var70 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var70 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [NewMaterialCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var71 sysname;
    SELECT @var71 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'MaterialType');
    IF @var71 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var71 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [MaterialType] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var72 sysname;
    SELECT @var72 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'MaterialMarkupCoefficient');
    IF @var72 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var72 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [MaterialMarkupCoefficient] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var73 sysname;
    SELECT @var73 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'LocationCodeDescription');
    IF @var73 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var73 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [LocationCodeDescription] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var74 sysname;
    SELECT @var74 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'LocationCode');
    IF @var74 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var74 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [LocationCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var75 sysname;
    SELECT @var75 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'LinePrice');
    IF @var75 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var75 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [LinePrice] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var76 sysname;
    SELECT @var76 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'LineNumber');
    IF @var76 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var76 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [LineNumber] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var77 sysname;
    SELECT @var77 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'LaborRegionCoefficient');
    IF @var77 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var77 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [LaborRegionCoefficient] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var78 sysname;
    SELECT @var78 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'LaborQualityCoefficient');
    IF @var78 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var78 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [LaborQualityCoefficient] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var79 sysname;
    SELECT @var79 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'LaborColdClimateCoefficient');
    IF @var79 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var79 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [LaborColdClimateCoefficient] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var80 sysname;
    SELECT @var80 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'FaultDescription');
    IF @var80 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var80 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [FaultDescription] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var81 sysname;
    SELECT @var81 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'FaultCodeDescription');
    IF @var81 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var81 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [FaultCodeDescription] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var82 sysname;
    SELECT @var82 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'FaultCode');
    IF @var82 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var82 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [FaultCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var83 sysname;
    SELECT @var83 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'FDP');
    IF @var83 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var83 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [FDP] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var84 sysname;
    SELECT @var84 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'DrivingMileageKM');
    IF @var84 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var84 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [DrivingMileageKM] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var85 sysname;
    SELECT @var85 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'DepartureTime');
    IF @var85 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var85 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [DepartureTime] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var86 sysname;
    SELECT @var86 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'CarPickupTime');
    IF @var86 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var86 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [CarPickupTime] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var87 sysname;
    SELECT @var87 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'ApprovalDate');
    IF @var87 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var87 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [ApprovalDate] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var88 sysname;
    SELECT @var88 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewForms]') AND [c].[name] = N'ActualAmount');
    IF @var88 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewForms] DROP CONSTRAINT [' + @var88 + '];');
    ALTER TABLE [DailyServiceReviewForms] ALTER COLUMN [ActualAmount] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var89 sysname;
    SELECT @var89 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'WorkOrderType');
    IF @var89 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var89 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [WorkOrderType] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var90 sysname;
    SELECT @var90 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'WorkOrderRepairEndTime');
    IF @var90 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var90 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [WorkOrderRepairEndTime] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var91 sysname;
    SELECT @var91 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'WorkOrderRepairAccount');
    IF @var91 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var91 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [WorkOrderRepairAccount] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var92 sysname;
    SELECT @var92 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'WorkOrderNumber');
    IF @var92 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var92 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [WorkOrderNumber] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var93 sysname;
    SELECT @var93 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'WorkOrderCreationDate');
    IF @var93 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var93 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [WorkOrderCreationDate] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var94 sysname;
    SELECT @var94 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'WarrantyStartDate');
    IF @var94 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var94 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [WarrantyStartDate] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var95 sysname;
    SELECT @var95 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'WBS');
    IF @var95 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var95 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [WBS] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var96 sysname;
    SELECT @var96 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'VehicleType');
    IF @var96 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var96 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [VehicleType] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var97 sysname;
    SELECT @var97 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'VehicleModel');
    IF @var97 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var97 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [VehicleModel] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var98 sysname;
    SELECT @var98 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'VIN');
    IF @var98 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var98 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [VIN] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var99 sysname;
    SELECT @var99 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'VAN');
    IF @var99 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var99 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [VAN] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var100 sysname;
    SELECT @var100 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'SupplyMethod');
    IF @var100 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var100 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [SupplyMethod] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var101 sysname;
    SELECT @var101 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'SupplierShortCode');
    IF @var101 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var101 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [SupplierShortCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var102 sysname;
    SELECT @var102 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'SpecialAuthorizationCode');
    IF @var102 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var102 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [SpecialAuthorizationCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var103 sysname;
    SELECT @var103 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'ServiceStationName');
    IF @var103 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var103 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [ServiceStationName] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var104 sysname;
    SELECT @var104 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'ServiceStation');
    IF @var104 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var104 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [ServiceStation] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var105 sysname;
    SELECT @var105 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'ServiceOrderTotalPrice');
    IF @var105 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var105 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [ServiceOrderTotalPrice] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var106 sysname;
    SELECT @var106 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'ServiceOrderStatus');
    IF @var106 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var106 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [ServiceOrderStatus] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var107 sysname;
    SELECT @var107 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'ServiceOrderCreationDate');
    IF @var107 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var107 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [ServiceOrderCreationDate] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var108 sysname;
    SELECT @var108 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'ServiceOrder');
    IF @var108 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var108 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [ServiceOrder] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var109 sysname;
    SELECT @var109 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'ServiceCategory');
    IF @var109 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var109 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [ServiceCategory] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var110 sysname;
    SELECT @var110 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'SalesDate');
    IF @var110 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var110 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [SalesDate] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var111 sysname;
    SELECT @var111 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'ResponsibilitySourceSupplierName');
    IF @var111 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var111 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [ResponsibilitySourceSupplierName] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var112 sysname;
    SELECT @var112 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'ResponsibilitySourceSupplier');
    IF @var112 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var112 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [ResponsibilitySourceSupplier] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var113 sysname;
    SELECT @var113 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'ResponsibilitySourceIdentifier');
    IF @var113 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var113 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [ResponsibilitySourceIdentifier] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var114 sysname;
    SELECT @var114 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'RepairMethod');
    IF @var114 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var114 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [RepairMethod] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var115 sysname;
    SELECT @var115 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'Quantity');
    IF @var115 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var115 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [Quantity] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var116 sysname;
    SELECT @var116 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'Province');
    IF @var116 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var116 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [Province] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var117 sysname;
    SELECT @var117 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'OutboundServiceLocation');
    IF @var117 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var117 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [OutboundServiceLocation] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var118 sysname;
    SELECT @var118 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'OutboundRescueLicensePlate2');
    IF @var118 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var118 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [OutboundRescueLicensePlate2] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var119 sysname;
    SELECT @var119 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'OutboundRescueLicensePlate1');
    IF @var119 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var119 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [OutboundRescueLicensePlate1] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var120 sysname;
    SELECT @var120 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'OutboundMileage');
    IF @var120 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var120 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [OutboundMileage] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var121 sysname;
    SELECT @var121 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'OrderType');
    IF @var121 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var121 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [OrderType] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var122 sysname;
    SELECT @var122 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'OldPartReturnStatus');
    IF @var122 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var122 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [OldPartReturnStatus] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var123 sysname;
    SELECT @var123 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'OldMaterialDescription');
    IF @var123 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var123 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [OldMaterialDescription] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var124 sysname;
    SELECT @var124 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'OldMaterialCode');
    IF @var124 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var124 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [OldMaterialCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var125 sysname;
    SELECT @var125 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'NoticeVehicleModel');
    IF @var125 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var125 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [NoticeVehicleModel] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var126 sysname;
    SELECT @var126 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'NewMaterialDescription');
    IF @var126 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var126 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [NewMaterialDescription] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var127 sysname;
    SELECT @var127 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'NewMaterialCode');
    IF @var127 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var127 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [NewMaterialCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var128 sysname;
    SELECT @var128 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'MaterialType');
    IF @var128 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var128 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [MaterialType] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var129 sysname;
    SELECT @var129 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'MaterialMarkupCoefficient');
    IF @var129 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var129 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [MaterialMarkupCoefficient] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var130 sysname;
    SELECT @var130 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'ManufacturingMonth');
    IF @var130 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var130 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [ManufacturingMonth] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var131 sysname;
    SELECT @var131 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'MISInterval');
    IF @var131 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var131 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [MISInterval] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var132 sysname;
    SELECT @var132 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'MIS');
    IF @var132 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var132 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [MIS] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var133 sysname;
    SELECT @var133 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'LocationCodeDescription');
    IF @var133 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var133 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [LocationCodeDescription] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var134 sysname;
    SELECT @var134 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'LocationCode');
    IF @var134 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var134 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [LocationCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var135 sysname;
    SELECT @var135 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'LinePrice');
    IF @var135 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var135 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [LinePrice] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var136 sysname;
    SELECT @var136 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'LineNumber');
    IF @var136 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var136 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [LineNumber] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var137 sysname;
    SELECT @var137 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'LaborRegionCoefficient');
    IF @var137 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var137 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [LaborRegionCoefficient] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var138 sysname;
    SELECT @var138 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'LaborQualityCoefficient');
    IF @var138 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var138 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [LaborQualityCoefficient] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var139 sysname;
    SELECT @var139 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'LaborColdClimateCoefficient');
    IF @var139 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var139 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [LaborColdClimateCoefficient] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var140 sysname;
    SELECT @var140 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'InternalModelCode');
    IF @var140 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var140 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [InternalModelCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var141 sysname;
    SELECT @var141 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'Fuel');
    IF @var141 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var141 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [Fuel] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var142 sysname;
    SELECT @var142 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'FilteredVehicleModel');
    IF @var142 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var142 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [FilteredVehicleModel] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var143 sysname;
    SELECT @var143 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'FaultDescription');
    IF @var143 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var143 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [FaultDescription] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var144 sysname;
    SELECT @var144 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'FaultCodeDescription');
    IF @var144 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var144 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [FaultCodeDescription] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var145 sysname;
    SELECT @var145 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'FaultCode');
    IF @var145 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var145 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [FaultCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var146 sysname;
    SELECT @var146 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'FDP');
    IF @var146 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var146 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [FDP] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var147 sysname;
    SELECT @var147 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'Emission');
    IF @var147 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var147 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [Emission] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var148 sysname;
    SELECT @var148 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'DrivingMileageKM');
    IF @var148 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var148 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [DrivingMileageKM] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var149 sysname;
    SELECT @var149 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'DepartureTime');
    IF @var149 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var149 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [DepartureTime] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var150 sysname;
    SELECT @var150 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'CarPickupTime');
    IF @var150 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var150 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [CarPickupTime] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var151 sysname;
    SELECT @var151 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'ApprovalDate');
    IF @var151 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var151 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [ApprovalDate] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var152 sysname;
    SELECT @var152 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyServiceReviewFormQueries]') AND [c].[name] = N'ActualAmount');
    IF @var152 IS NOT NULL EXEC(N'ALTER TABLE [DailyServiceReviewFormQueries] DROP CONSTRAINT [' + @var152 + '];');
    ALTER TABLE [DailyServiceReviewFormQueries] ALTER COLUMN [ActualAmount] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var153 sysname;
    SELECT @var153 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BreakpointAnalysisTables]') AND [c].[name] = N'VIN');
    IF @var153 IS NOT NULL EXEC(N'ALTER TABLE [BreakpointAnalysisTables] DROP CONSTRAINT [' + @var153 + '];');
    ALTER TABLE [BreakpointAnalysisTables] ALTER COLUMN [VIN] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var154 sysname;
    SELECT @var154 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BreakpointAnalysisTables]') AND [c].[name] = N'VAN');
    IF @var154 IS NOT NULL EXEC(N'ALTER TABLE [BreakpointAnalysisTables] DROP CONSTRAINT [' + @var154 + '];');
    ALTER TABLE [BreakpointAnalysisTables] ALTER COLUMN [VAN] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var155 sysname;
    SELECT @var155 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BreakpointAnalysisTables]') AND [c].[name] = N'PQSNumber');
    IF @var155 IS NOT NULL EXEC(N'ALTER TABLE [BreakpointAnalysisTables] DROP CONSTRAINT [' + @var155 + '];');
    ALTER TABLE [BreakpointAnalysisTables] ALTER COLUMN [PQSNumber] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var156 sysname;
    SELECT @var156 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BreakpointAnalysisTables]') AND [c].[name] = N'MaterialCode');
    IF @var156 IS NOT NULL EXEC(N'ALTER TABLE [BreakpointAnalysisTables] DROP CONSTRAINT [' + @var156 + '];');
    ALTER TABLE [BreakpointAnalysisTables] ALTER COLUMN [MaterialCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var157 sysname;
    SELECT @var157 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BreakpointAnalysisTables]') AND [c].[name] = N'LocationCode');
    IF @var157 IS NOT NULL EXEC(N'ALTER TABLE [BreakpointAnalysisTables] DROP CONSTRAINT [' + @var157 + '];');
    ALTER TABLE [BreakpointAnalysisTables] ALTER COLUMN [LocationCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var158 sysname;
    SELECT @var158 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BreakpointAnalysisTables]') AND [c].[name] = N'FaultCode');
    IF @var158 IS NOT NULL EXEC(N'ALTER TABLE [BreakpointAnalysisTables] DROP CONSTRAINT [' + @var158 + '];');
    ALTER TABLE [BreakpointAnalysisTables] ALTER COLUMN [FaultCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    DECLARE @var159 sysname;
    SELECT @var159 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BreakpointAnalysisTables]') AND [c].[name] = N'BreakpointTime');
    IF @var159 IS NOT NULL EXEC(N'ALTER TABLE [BreakpointAnalysisTables] DROP CONSTRAINT [' + @var159 + '];');
    ALTER TABLE [BreakpointAnalysisTables] ALTER COLUMN [BreakpointTime] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240914163421_NULLABLE'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240914163421_NULLABLE', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240919072606_MigrationSILSimulationTables'
)
BEGIN
    CREATE TABLE [ SILSimulationTables] (
        [ID] int NOT NULL IDENTITY,
        [LocationCode] nvarchar(max) NULL,
        [OldMaterialCode] nvarchar(max) NULL,
        [FaultCode] nvarchar(max) NULL,
        [Title] nvarchar(max) NULL,
        [Province] nvarchar(max) NULL,
        [City] nvarchar(max) NULL,
        [FailurePartCount] int NULL,
        [FaultLevel] nvarchar(max) NULL,
        [FaultDescription] nvarchar(max) NULL,
        [Reporter] nvarchar(max) NULL,
        [ReporterPhone] nvarchar(max) NULL,
        [InitialFaultAnalysis] nvarchar(max) NULL,
        [RepairProcessAndEffect] nvarchar(max) NULL,
        [Inspector] nvarchar(max) NULL,
        [InspectorPhone] nvarchar(max) NULL,
        [RepairTime] nvarchar(max) NULL,
        [VAN] nvarchar(max) NULL,
        [ChassisNumber] nvarchar(max) NULL,
        [VehicleModel] nvarchar(max) NULL,
        [PurchaseTime] nvarchar(max) NULL,
        [FaultTime] nvarchar(max) NULL,
        [VehicleStatus] nvarchar(max) NULL,
        [PreventiveMeasures] nvarchar(max) NULL,
        [ProjectType] nvarchar(max) NULL,
        [ResponsiblePerson] nvarchar(max) NULL,
        [NotificationNumber] nvarchar(max) NULL,
        [PSQNumber] nvarchar(max) NULL,
        [Status] nvarchar(max) NULL,
        [StageStatus] nvarchar(max) NULL,
        [ResponsibleDepartment] nvarchar(max) NULL,
        [Manager] nvarchar(max) NULL,
        [Creator] nvarchar(max) NULL,
        [StartTime] nvarchar(max) NULL,
        [TTF] nvarchar(max) NULL,
        [PendingPerson] nvarchar(max) NULL,
        CONSTRAINT [PK_ SILSimulationTables] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240919072606_MigrationSILSimulationTables'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240919072606_MigrationSILSimulationTables', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240919110355_MigrationName919'
)
BEGIN
    DECLARE @var160 sysname;
    SELECT @var160 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ SILSimulationTables]') AND [c].[name] = N'FailurePartCount');
    IF @var160 IS NOT NULL EXEC(N'ALTER TABLE [ SILSimulationTables] DROP CONSTRAINT [' + @var160 + '];');
    ALTER TABLE [ SILSimulationTables] ALTER COLUMN [FailurePartCount] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240919110355_MigrationName919'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240919110355_MigrationName919', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240919162359_AddPartAndFaultDescriptions'
)
BEGIN
    ALTER TABLE [ SILSimulationTables] ADD [FaultCodeDescription] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240919162359_AddPartAndFaultDescriptions'
)
BEGIN
    ALTER TABLE [ SILSimulationTables] ADD [LocationCodeDescription] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240919162359_AddPartAndFaultDescriptions'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240919162359_AddPartAndFaultDescriptions', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240919163106_AddPartAndFaultDescriptions1.1'
)
BEGIN
    ALTER TABLE [ SILSimulationTables] ADD [OldMaterialCodeDescription] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240919163106_AddPartAndFaultDescriptions1.1'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240919163106_AddPartAndFaultDescriptions1.1', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240920153500_InitialCreateUSER'
)
BEGIN
    CREATE TABLE [userAuthentications] (
        [ID] int NOT NULL IDENTITY,
        [Username] nvarchar(max) NULL,
        [Password] nvarchar(max) NULL,
        [Role] nvarchar(max) NULL,
        [Group] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        CONSTRAINT [PK_userAuthentications] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240920153500_InitialCreateUSER'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240920153500_InitialCreateUSER', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241003103734_AddRowVersion'
)
BEGIN
    ALTER TABLE [DailyQualityIssueChecklistV91s] ADD [RowVersion] rowversion NOT NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241003103734_AddRowVersion'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241003103734_AddRowVersion', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241007143726_AddDescriptionToYourEntity'
)
BEGIN
    CREATE TABLE [dailyQualityIssueChecklistV91QueryTemps] (
        [ID] int NOT NULL IDENTITY,
        [ApprovalDate] nvarchar(max) NULL,
        [VehicleModel] nvarchar(max) NULL,
        [OldMaterialCode] nvarchar(max) NULL,
        [OldMaterialDescription] nvarchar(max) NULL,
        [SupplierShortCode] nvarchar(max) NULL,
        [ResponsibilitySourceSupplierName] nvarchar(max) NULL,
        [CaseCount] nvarchar(max) NULL,
        [AccumulatedCaseCount] nvarchar(max) NULL,
        [MIS3] nvarchar(max) NULL,
        [MIS6] nvarchar(max) NULL,
        [MIS12] nvarchar(max) NULL,
        [MIS24] nvarchar(max) NULL,
        [MIS36] nvarchar(max) NULL,
        [SMT] nvarchar(max) NULL,
        [LocationCode] nvarchar(max) NULL,
        [FaultCode] nvarchar(max) NULL,
        [PQSNumber] nvarchar(max) NULL,
        [VAN] nvarchar(max) NULL,
        [VIN] nvarchar(max) NULL,
        CONSTRAINT [PK_dailyQualityIssueChecklistV91QueryTemps] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241007143726_AddDescriptionToYourEntity'
)
BEGIN
    CREATE TABLE [dailyQualityIssueChecklistV91Temps] (
        [ID] int NOT NULL IDENTITY,
        [OldMaterialCode] nvarchar(max) NOT NULL,
        [OldMaterialDescription] nvarchar(max) NOT NULL,
        [SupplierShortCode] nvarchar(max) NOT NULL,
        [ResponsibilitySourceSupplierName] nvarchar(max) NOT NULL,
        [MIS3] nvarchar(max) NOT NULL,
        [MIS6] nvarchar(max) NOT NULL,
        [MIS12] nvarchar(max) NOT NULL,
        [MIS24] nvarchar(max) NOT NULL,
        [MIS36] nvarchar(max) NOT NULL,
        [SMT] nvarchar(max) NOT NULL,
        [LocationCode] nvarchar(max) NOT NULL,
        [FaultCode] nvarchar(max) NOT NULL,
        [QE] nvarchar(max) NOT NULL,
        [ServiceFaultIdentificationAccurate] nvarchar(max) NOT NULL,
        [IdentifiedFaultMode] nvarchar(max) NOT NULL,
        [BreakdownCount] nvarchar(max) NOT NULL,
        [IsBreakdownInvalid] nvarchar(max) NOT NULL,
        [IncludedInSIL] nvarchar(max) NOT NULL,
        [PQSNumber] nvarchar(max) NOT NULL,
        [BreakpointTime] nvarchar(max) NOT NULL,
        [StartTime] nvarchar(max) NOT NULL,
        [Remarks] nvarchar(max) NOT NULL,
        [ProjectIdentifier] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_dailyQualityIssueChecklistV91Temps] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241007143726_AddDescriptionToYourEntity'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241007143726_AddDescriptionToYourEntity', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008094642_settheunll'
)
BEGIN
    DECLARE @var161 sysname;
    SELECT @var161 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91s]') AND [c].[name] = N'SupplierShortCode');
    IF @var161 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91s] DROP CONSTRAINT [' + @var161 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91s] ALTER COLUMN [SupplierShortCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008094642_settheunll'
)
BEGIN
    DECLARE @var162 sysname;
    SELECT @var162 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91s]') AND [c].[name] = N'StartTime');
    IF @var162 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91s] DROP CONSTRAINT [' + @var162 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91s] ALTER COLUMN [StartTime] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008094642_settheunll'
)
BEGIN
    DECLARE @var163 sysname;
    SELECT @var163 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91s]') AND [c].[name] = N'ServiceFaultIdentificationAccurate');
    IF @var163 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91s] DROP CONSTRAINT [' + @var163 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91s] ALTER COLUMN [ServiceFaultIdentificationAccurate] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008094642_settheunll'
)
BEGIN
    DECLARE @var164 sysname;
    SELECT @var164 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91s]') AND [c].[name] = N'SMT');
    IF @var164 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91s] DROP CONSTRAINT [' + @var164 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91s] ALTER COLUMN [SMT] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008094642_settheunll'
)
BEGIN
    DECLARE @var165 sysname;
    SELECT @var165 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91s]') AND [c].[name] = N'ResponsibilitySourceSupplierName');
    IF @var165 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91s] DROP CONSTRAINT [' + @var165 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91s] ALTER COLUMN [ResponsibilitySourceSupplierName] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008094642_settheunll'
)
BEGIN
    DECLARE @var166 sysname;
    SELECT @var166 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91s]') AND [c].[name] = N'Remarks');
    IF @var166 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91s] DROP CONSTRAINT [' + @var166 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91s] ALTER COLUMN [Remarks] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008094642_settheunll'
)
BEGIN
    DECLARE @var167 sysname;
    SELECT @var167 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91s]') AND [c].[name] = N'QE');
    IF @var167 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91s] DROP CONSTRAINT [' + @var167 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91s] ALTER COLUMN [QE] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008094642_settheunll'
)
BEGIN
    DECLARE @var168 sysname;
    SELECT @var168 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91s]') AND [c].[name] = N'ProjectIdentifier');
    IF @var168 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91s] DROP CONSTRAINT [' + @var168 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91s] ALTER COLUMN [ProjectIdentifier] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008094642_settheunll'
)
BEGIN
    DECLARE @var169 sysname;
    SELECT @var169 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91s]') AND [c].[name] = N'PQSNumber');
    IF @var169 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91s] DROP CONSTRAINT [' + @var169 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91s] ALTER COLUMN [PQSNumber] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008094642_settheunll'
)
BEGIN
    DECLARE @var170 sysname;
    SELECT @var170 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91s]') AND [c].[name] = N'OldMaterialDescription');
    IF @var170 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91s] DROP CONSTRAINT [' + @var170 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91s] ALTER COLUMN [OldMaterialDescription] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008094642_settheunll'
)
BEGIN
    DECLARE @var171 sysname;
    SELECT @var171 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91s]') AND [c].[name] = N'MIS6');
    IF @var171 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91s] DROP CONSTRAINT [' + @var171 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91s] ALTER COLUMN [MIS6] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008094642_settheunll'
)
BEGIN
    DECLARE @var172 sysname;
    SELECT @var172 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91s]') AND [c].[name] = N'MIS36');
    IF @var172 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91s] DROP CONSTRAINT [' + @var172 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91s] ALTER COLUMN [MIS36] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008094642_settheunll'
)
BEGIN
    DECLARE @var173 sysname;
    SELECT @var173 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91s]') AND [c].[name] = N'MIS3');
    IF @var173 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91s] DROP CONSTRAINT [' + @var173 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91s] ALTER COLUMN [MIS3] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008094642_settheunll'
)
BEGIN
    DECLARE @var174 sysname;
    SELECT @var174 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91s]') AND [c].[name] = N'MIS24');
    IF @var174 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91s] DROP CONSTRAINT [' + @var174 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91s] ALTER COLUMN [MIS24] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008094642_settheunll'
)
BEGIN
    DECLARE @var175 sysname;
    SELECT @var175 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91s]') AND [c].[name] = N'MIS12');
    IF @var175 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91s] DROP CONSTRAINT [' + @var175 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91s] ALTER COLUMN [MIS12] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008094642_settheunll'
)
BEGIN
    DECLARE @var176 sysname;
    SELECT @var176 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91s]') AND [c].[name] = N'LocationCode');
    IF @var176 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91s] DROP CONSTRAINT [' + @var176 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91s] ALTER COLUMN [LocationCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008094642_settheunll'
)
BEGIN
    DECLARE @var177 sysname;
    SELECT @var177 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91s]') AND [c].[name] = N'IsBreakdownInvalid');
    IF @var177 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91s] DROP CONSTRAINT [' + @var177 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91s] ALTER COLUMN [IsBreakdownInvalid] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008094642_settheunll'
)
BEGIN
    DECLARE @var178 sysname;
    SELECT @var178 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91s]') AND [c].[name] = N'IncludedInSIL');
    IF @var178 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91s] DROP CONSTRAINT [' + @var178 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91s] ALTER COLUMN [IncludedInSIL] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008094642_settheunll'
)
BEGIN
    DECLARE @var179 sysname;
    SELECT @var179 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91s]') AND [c].[name] = N'IdentifiedFaultMode');
    IF @var179 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91s] DROP CONSTRAINT [' + @var179 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91s] ALTER COLUMN [IdentifiedFaultMode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008094642_settheunll'
)
BEGIN
    DECLARE @var180 sysname;
    SELECT @var180 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91s]') AND [c].[name] = N'FaultCode');
    IF @var180 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91s] DROP CONSTRAINT [' + @var180 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91s] ALTER COLUMN [FaultCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008094642_settheunll'
)
BEGIN
    DECLARE @var181 sysname;
    SELECT @var181 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91s]') AND [c].[name] = N'BreakpointTime');
    IF @var181 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91s] DROP CONSTRAINT [' + @var181 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91s] ALTER COLUMN [BreakpointTime] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008094642_settheunll'
)
BEGIN
    DECLARE @var182 sysname;
    SELECT @var182 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DailyQualityIssueChecklistV91s]') AND [c].[name] = N'BreakdownCount');
    IF @var182 IS NOT NULL EXEC(N'ALTER TABLE [DailyQualityIssueChecklistV91s] DROP CONSTRAINT [' + @var182 + '];');
    ALTER TABLE [DailyQualityIssueChecklistV91s] ALTER COLUMN [BreakdownCount] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008094642_settheunll'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241008094642_settheunll', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008095606_AddTheCaseCount'
)
BEGIN
    ALTER TABLE [DailyQualityIssueChecklistV91s] ADD [CaseCount] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008095606_AddTheCaseCount'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241008095606_AddTheCaseCount', N'8.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008104151_ADDTEMPCASE'
)
BEGIN
    DECLARE @var183 sysname;
    SELECT @var183 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dailyQualityIssueChecklistV91Temps]') AND [c].[name] = N'SupplierShortCode');
    IF @var183 IS NOT NULL EXEC(N'ALTER TABLE [dailyQualityIssueChecklistV91Temps] DROP CONSTRAINT [' + @var183 + '];');
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ALTER COLUMN [SupplierShortCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008104151_ADDTEMPCASE'
)
BEGIN
    DECLARE @var184 sysname;
    SELECT @var184 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dailyQualityIssueChecklistV91Temps]') AND [c].[name] = N'StartTime');
    IF @var184 IS NOT NULL EXEC(N'ALTER TABLE [dailyQualityIssueChecklistV91Temps] DROP CONSTRAINT [' + @var184 + '];');
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ALTER COLUMN [StartTime] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008104151_ADDTEMPCASE'
)
BEGIN
    DECLARE @var185 sysname;
    SELECT @var185 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dailyQualityIssueChecklistV91Temps]') AND [c].[name] = N'ServiceFaultIdentificationAccurate');
    IF @var185 IS NOT NULL EXEC(N'ALTER TABLE [dailyQualityIssueChecklistV91Temps] DROP CONSTRAINT [' + @var185 + '];');
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ALTER COLUMN [ServiceFaultIdentificationAccurate] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008104151_ADDTEMPCASE'
)
BEGIN
    DECLARE @var186 sysname;
    SELECT @var186 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dailyQualityIssueChecklistV91Temps]') AND [c].[name] = N'SMT');
    IF @var186 IS NOT NULL EXEC(N'ALTER TABLE [dailyQualityIssueChecklistV91Temps] DROP CONSTRAINT [' + @var186 + '];');
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ALTER COLUMN [SMT] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008104151_ADDTEMPCASE'
)
BEGIN
    DECLARE @var187 sysname;
    SELECT @var187 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dailyQualityIssueChecklistV91Temps]') AND [c].[name] = N'ResponsibilitySourceSupplierName');
    IF @var187 IS NOT NULL EXEC(N'ALTER TABLE [dailyQualityIssueChecklistV91Temps] DROP CONSTRAINT [' + @var187 + '];');
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ALTER COLUMN [ResponsibilitySourceSupplierName] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008104151_ADDTEMPCASE'
)
BEGIN
    DECLARE @var188 sysname;
    SELECT @var188 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dailyQualityIssueChecklistV91Temps]') AND [c].[name] = N'Remarks');
    IF @var188 IS NOT NULL EXEC(N'ALTER TABLE [dailyQualityIssueChecklistV91Temps] DROP CONSTRAINT [' + @var188 + '];');
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ALTER COLUMN [Remarks] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008104151_ADDTEMPCASE'
)
BEGIN
    DECLARE @var189 sysname;
    SELECT @var189 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dailyQualityIssueChecklistV91Temps]') AND [c].[name] = N'QE');
    IF @var189 IS NOT NULL EXEC(N'ALTER TABLE [dailyQualityIssueChecklistV91Temps] DROP CONSTRAINT [' + @var189 + '];');
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ALTER COLUMN [QE] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008104151_ADDTEMPCASE'
)
BEGIN
    DECLARE @var190 sysname;
    SELECT @var190 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dailyQualityIssueChecklistV91Temps]') AND [c].[name] = N'ProjectIdentifier');
    IF @var190 IS NOT NULL EXEC(N'ALTER TABLE [dailyQualityIssueChecklistV91Temps] DROP CONSTRAINT [' + @var190 + '];');
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ALTER COLUMN [ProjectIdentifier] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008104151_ADDTEMPCASE'
)
BEGIN
    DECLARE @var191 sysname;
    SELECT @var191 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dailyQualityIssueChecklistV91Temps]') AND [c].[name] = N'PQSNumber');
    IF @var191 IS NOT NULL EXEC(N'ALTER TABLE [dailyQualityIssueChecklistV91Temps] DROP CONSTRAINT [' + @var191 + '];');
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ALTER COLUMN [PQSNumber] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008104151_ADDTEMPCASE'
)
BEGIN
    DECLARE @var192 sysname;
    SELECT @var192 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dailyQualityIssueChecklistV91Temps]') AND [c].[name] = N'OldMaterialDescription');
    IF @var192 IS NOT NULL EXEC(N'ALTER TABLE [dailyQualityIssueChecklistV91Temps] DROP CONSTRAINT [' + @var192 + '];');
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ALTER COLUMN [OldMaterialDescription] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008104151_ADDTEMPCASE'
)
BEGIN
    DECLARE @var193 sysname;
    SELECT @var193 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dailyQualityIssueChecklistV91Temps]') AND [c].[name] = N'MIS6');
    IF @var193 IS NOT NULL EXEC(N'ALTER TABLE [dailyQualityIssueChecklistV91Temps] DROP CONSTRAINT [' + @var193 + '];');
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ALTER COLUMN [MIS6] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008104151_ADDTEMPCASE'
)
BEGIN
    DECLARE @var194 sysname;
    SELECT @var194 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dailyQualityIssueChecklistV91Temps]') AND [c].[name] = N'MIS36');
    IF @var194 IS NOT NULL EXEC(N'ALTER TABLE [dailyQualityIssueChecklistV91Temps] DROP CONSTRAINT [' + @var194 + '];');
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ALTER COLUMN [MIS36] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008104151_ADDTEMPCASE'
)
BEGIN
    DECLARE @var195 sysname;
    SELECT @var195 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dailyQualityIssueChecklistV91Temps]') AND [c].[name] = N'MIS3');
    IF @var195 IS NOT NULL EXEC(N'ALTER TABLE [dailyQualityIssueChecklistV91Temps] DROP CONSTRAINT [' + @var195 + '];');
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ALTER COLUMN [MIS3] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008104151_ADDTEMPCASE'
)
BEGIN
    DECLARE @var196 sysname;
    SELECT @var196 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dailyQualityIssueChecklistV91Temps]') AND [c].[name] = N'MIS24');
    IF @var196 IS NOT NULL EXEC(N'ALTER TABLE [dailyQualityIssueChecklistV91Temps] DROP CONSTRAINT [' + @var196 + '];');
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ALTER COLUMN [MIS24] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008104151_ADDTEMPCASE'
)
BEGIN
    DECLARE @var197 sysname;
    SELECT @var197 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dailyQualityIssueChecklistV91Temps]') AND [c].[name] = N'MIS12');
    IF @var197 IS NOT NULL EXEC(N'ALTER TABLE [dailyQualityIssueChecklistV91Temps] DROP CONSTRAINT [' + @var197 + '];');
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ALTER COLUMN [MIS12] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008104151_ADDTEMPCASE'
)
BEGIN
    DECLARE @var198 sysname;
    SELECT @var198 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dailyQualityIssueChecklistV91Temps]') AND [c].[name] = N'LocationCode');
    IF @var198 IS NOT NULL EXEC(N'ALTER TABLE [dailyQualityIssueChecklistV91Temps] DROP CONSTRAINT [' + @var198 + '];');
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ALTER COLUMN [LocationCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008104151_ADDTEMPCASE'
)
BEGIN
    DECLARE @var199 sysname;
    SELECT @var199 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dailyQualityIssueChecklistV91Temps]') AND [c].[name] = N'IsBreakdownInvalid');
    IF @var199 IS NOT NULL EXEC(N'ALTER TABLE [dailyQualityIssueChecklistV91Temps] DROP CONSTRAINT [' + @var199 + '];');
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ALTER COLUMN [IsBreakdownInvalid] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008104151_ADDTEMPCASE'
)
BEGIN
    DECLARE @var200 sysname;
    SELECT @var200 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dailyQualityIssueChecklistV91Temps]') AND [c].[name] = N'IncludedInSIL');
    IF @var200 IS NOT NULL EXEC(N'ALTER TABLE [dailyQualityIssueChecklistV91Temps] DROP CONSTRAINT [' + @var200 + '];');
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ALTER COLUMN [IncludedInSIL] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008104151_ADDTEMPCASE'
)
BEGIN
    DECLARE @var201 sysname;
    SELECT @var201 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dailyQualityIssueChecklistV91Temps]') AND [c].[name] = N'IdentifiedFaultMode');
    IF @var201 IS NOT NULL EXEC(N'ALTER TABLE [dailyQualityIssueChecklistV91Temps] DROP CONSTRAINT [' + @var201 + '];');
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ALTER COLUMN [IdentifiedFaultMode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008104151_ADDTEMPCASE'
)
BEGIN
    DECLARE @var202 sysname;
    SELECT @var202 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dailyQualityIssueChecklistV91Temps]') AND [c].[name] = N'FaultCode');
    IF @var202 IS NOT NULL EXEC(N'ALTER TABLE [dailyQualityIssueChecklistV91Temps] DROP CONSTRAINT [' + @var202 + '];');
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ALTER COLUMN [FaultCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008104151_ADDTEMPCASE'
)
BEGIN
    DECLARE @var203 sysname;
    SELECT @var203 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dailyQualityIssueChecklistV91Temps]') AND [c].[name] = N'BreakpointTime');
    IF @var203 IS NOT NULL EXEC(N'ALTER TABLE [dailyQualityIssueChecklistV91Temps] DROP CONSTRAINT [' + @var203 + '];');
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ALTER COLUMN [BreakpointTime] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008104151_ADDTEMPCASE'
)
BEGIN
    DECLARE @var204 sysname;
    SELECT @var204 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dailyQualityIssueChecklistV91Temps]') AND [c].[name] = N'BreakdownCount');
    IF @var204 IS NOT NULL EXEC(N'ALTER TABLE [dailyQualityIssueChecklistV91Temps] DROP CONSTRAINT [' + @var204 + '];');
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ALTER COLUMN [BreakdownCount] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008104151_ADDTEMPCASE'
)
BEGIN
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ADD [CaseCount] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241008104151_ADDTEMPCASE'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241008104151_ADDTEMPCASE', N'8.0.8');
END;
GO

COMMIT;
GO

