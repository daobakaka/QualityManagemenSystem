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
    WHERE [MigrationId] = N'20241106080911_INS'
)
BEGIN
    CREATE TABLE [ SILSimulationTables] (
        [ID] int NOT NULL IDENTITY,
        [LocationCode] nvarchar(max) NULL,
        [LocationCodeDescription] nvarchar(max) NULL,
        [OldMaterialCode] nvarchar(max) NULL,
        [OldMaterialCodeDescription] nvarchar(max) NULL,
        [FaultCode] nvarchar(max) NULL,
        [FaultCodeDescription] nvarchar(max) NULL,
        [Title] nvarchar(max) NULL,
        [Province] nvarchar(max) NULL,
        [City] nvarchar(max) NULL,
        [FailurePartCount] nvarchar(max) NULL,
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
    WHERE [MigrationId] = N'20241106080911_INS'
)
BEGIN
    CREATE TABLE [BreakpointAnalysisTables] (
        [ID] int NOT NULL IDENTITY,
        [MaterialCode] nvarchar(max) NULL,
        [LocationCode] nvarchar(max) NULL,
        [FaultCode] nvarchar(max) NULL,
        [BreakpointTime] nvarchar(max) NULL,
        [PQSNumber] nvarchar(max) NULL,
        [VAN] nvarchar(max) NULL,
        [VIN] nvarchar(max) NULL,
        CONSTRAINT [PK_BreakpointAnalysisTables] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241106080911_INS'
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
    WHERE [MigrationId] = N'20241106080911_INS'
)
BEGIN
    CREATE TABLE [DailyQualityIssueChecklistV91Queries] (
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
        CONSTRAINT [PK_DailyQualityIssueChecklistV91Queries] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241106080911_INS'
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
    WHERE [MigrationId] = N'20241106080911_INS'
)
BEGIN
    CREATE TABLE [DailyQualityIssueChecklistV91s] (
        [ID] int NOT NULL IDENTITY,
        [OldMaterialCode] nvarchar(max) NOT NULL,
        [OldMaterialDescription] nvarchar(max) NULL,
        [SupplierShortCode] nvarchar(max) NULL,
        [ResponsibilitySourceSupplierName] nvarchar(max) NULL,
        [CaseCount] nvarchar(max) NULL,
        [MIS3] nvarchar(max) NULL,
        [MIS6] nvarchar(max) NULL,
        [MIS12] nvarchar(max) NULL,
        [MIS24] nvarchar(max) NULL,
        [MIS36] nvarchar(max) NULL,
        [SMT] nvarchar(max) NULL,
        [LocationCode] nvarchar(max) NULL,
        [FaultCode] nvarchar(max) NULL,
        [QE] nvarchar(max) NULL,
        [ServiceFaultIdentificationAccurate] nvarchar(max) NULL,
        [IdentifiedFaultMode] nvarchar(max) NULL,
        [BreakdownCount] nvarchar(max) NULL,
        [IsBreakdownInvalid] nvarchar(max) NULL,
        [IncludedInSIL] nvarchar(max) NULL,
        [PQSNumber] nvarchar(max) NULL,
        [BreakpointTime] nvarchar(max) NULL,
        [StartTime] nvarchar(max) NULL,
        [Remarks] nvarchar(max) NULL,
        [ProjectIdentifier] nvarchar(max) NULL,
        [RowVersion] rowversion NOT NULL,
        CONSTRAINT [PK_DailyQualityIssueChecklistV91s] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241106080911_INS'
)
BEGIN
    CREATE TABLE [dailyQualityIssueChecklistV91Temps] (
        [ID] int NOT NULL IDENTITY,
        [OldMaterialCode] nvarchar(max) NOT NULL,
        [OldMaterialDescription] nvarchar(max) NULL,
        [SupplierShortCode] nvarchar(max) NULL,
        [ResponsibilitySourceSupplierName] nvarchar(max) NULL,
        [CaseCount] nvarchar(max) NULL,
        [MIS3] nvarchar(max) NULL,
        [MIS6] nvarchar(max) NULL,
        [MIS12] nvarchar(max) NULL,
        [MIS24] nvarchar(max) NULL,
        [MIS36] nvarchar(max) NULL,
        [SMT] nvarchar(max) NULL,
        [LocationCode] nvarchar(max) NULL,
        [FaultCode] nvarchar(max) NULL,
        [QE] nvarchar(max) NULL,
        [ServiceFaultIdentificationAccurate] nvarchar(max) NULL,
        [IdentifiedFaultMode] nvarchar(max) NULL,
        [BreakdownCount] nvarchar(max) NULL,
        [IsBreakdownInvalid] nvarchar(max) NULL,
        [IncludedInSIL] nvarchar(max) NULL,
        [PQSNumber] nvarchar(max) NULL,
        [BreakpointTime] nvarchar(max) NULL,
        [StartTime] nvarchar(max) NULL,
        [Remarks] nvarchar(max) NULL,
        [ProjectIdentifier] nvarchar(max) NULL,
        CONSTRAINT [PK_dailyQualityIssueChecklistV91Temps] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241106080911_INS'
)
BEGIN
    CREATE TABLE [DailyServiceReviewFormQueries] (
        [ID] int NOT NULL IDENTITY,
        [ServiceOrder] nvarchar(max) NULL,
        [ServiceOrderStatus] nvarchar(max) NULL,
        [ServiceOrderTotalPrice] nvarchar(max) NULL,
        [WorkOrderNumber] nvarchar(max) NULL,
        [WorkOrderCreationDate] nvarchar(max) NULL,
        [WorkOrderType] nvarchar(max) NULL,
        [DepartureTime] nvarchar(max) NULL,
        [CarPickupTime] nvarchar(max) NULL,
        [WorkOrderRepairEndTime] nvarchar(max) NULL,
        [WorkOrderRepairAccount] nvarchar(max) NULL,
        [OutboundServiceLocation] nvarchar(max) NULL,
        [OutboundMileage] nvarchar(max) NULL,
        [Province] nvarchar(max) NULL,
        [ServiceStation] nvarchar(max) NULL,
        [ServiceStationName] nvarchar(max) NULL,
        [NoticeVehicleModel] nvarchar(max) NULL,
        [VAN] nvarchar(max) NULL,
        [VIN] nvarchar(max) NULL,
        [WarrantyStartDate] nvarchar(max) NULL,
        [MaterialType] nvarchar(max) NULL,
        [LineNumber] nvarchar(max) NULL,
        [OldMaterialCode] nvarchar(max) NULL,
        [OldMaterialDescription] nvarchar(max) NULL,
        [NewMaterialCode] nvarchar(max) NULL,
        [NewMaterialDescription] nvarchar(max) NULL,
        [RepairMethod] nvarchar(max) NULL,
        [SupplyMethod] nvarchar(max) NULL,
        [Quantity] nvarchar(max) NULL,
        [OldPartReturnStatus] nvarchar(max) NULL,
        [ResponsibilitySourceIdentifier] nvarchar(max) NULL,
        [ResponsibilitySourceSupplier] nvarchar(max) NULL,
        [SupplierShortCode] nvarchar(max) NULL,
        [ResponsibilitySourceSupplierName] nvarchar(max) NULL,
        [LinePrice] nvarchar(max) NULL,
        [ActualAmount] nvarchar(max) NULL,
        [MaterialMarkupCoefficient] nvarchar(max) NULL,
        [LaborRegionCoefficient] nvarchar(max) NULL,
        [LaborColdClimateCoefficient] nvarchar(max) NULL,
        [LaborQualityCoefficient] nvarchar(max) NULL,
        [LocationCode] nvarchar(max) NULL,
        [LocationCodeDescription] nvarchar(max) NULL,
        [FaultCode] nvarchar(max) NULL,
        [FaultCodeDescription] nvarchar(max) NULL,
        [FaultDescription] nvarchar(max) NULL,
        [ServiceCategory] nvarchar(max) NULL,
        [ServiceOrderCreationDate] nvarchar(max) NULL,
        [FDP] nvarchar(max) NULL,
        [SpecialAuthorizationCode] nvarchar(max) NULL,
        [WBS] nvarchar(max) NULL,
        [DrivingMileageKM] nvarchar(max) NULL,
        [OutboundRescueLicensePlate1] nvarchar(max) NULL,
        [OutboundRescueLicensePlate2] nvarchar(max) NULL,
        [ApprovalDate] nvarchar(max) NULL,
        [ManufacturingMonth] nvarchar(max) NULL,
        [SalesDate] nvarchar(max) NULL,
        [MIS] nvarchar(max) NULL,
        [VehicleModel] nvarchar(max) NULL,
        [Emission] nvarchar(max) NULL,
        [OrderType] nvarchar(max) NULL,
        [InternalModelCode] nvarchar(max) NULL,
        [VehicleType] nvarchar(max) NULL,
        [Fuel] nvarchar(max) NULL,
        [MISInterval] nvarchar(max) NULL,
        [FilteredVehicleModel] nvarchar(max) NULL,
        CONSTRAINT [PK_DailyServiceReviewFormQueries] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241106080911_INS'
)
BEGIN
    CREATE TABLE [DailyServiceReviewForms] (
        [ID] int NOT NULL IDENTITY,
        [ServiceOrder] nvarchar(max) NULL,
        [ServiceOrderStatus] nvarchar(max) NULL,
        [ServiceOrderTotalPrice] nvarchar(max) NULL,
        [WorkOrderNumber] nvarchar(max) NULL,
        [WorkOrderCreationDate] nvarchar(max) NULL,
        [WorkOrderType] nvarchar(max) NULL,
        [DepartureTime] nvarchar(max) NULL,
        [CarPickupTime] nvarchar(max) NULL,
        [WorkOrderRepairEndTime] nvarchar(max) NULL,
        [WorkOrderRepairAccount] nvarchar(max) NULL,
        [OutboundServiceLocation] nvarchar(max) NULL,
        [OutboundMileage] nvarchar(max) NULL,
        [Province] nvarchar(max) NULL,
        [ServiceStation] nvarchar(max) NULL,
        [ServiceStationName] nvarchar(max) NULL,
        [NoticeVehicleModel] nvarchar(max) NULL,
        [VAN] nvarchar(max) NULL,
        [VIN] nvarchar(max) NULL,
        [WarrantyStartDate] nvarchar(max) NULL,
        [MaterialType] nvarchar(max) NULL,
        [LineNumber] nvarchar(max) NULL,
        [OldMaterialCode] nvarchar(max) NULL,
        [OldMaterialDescription] nvarchar(max) NULL,
        [NewMaterialCode] nvarchar(max) NULL,
        [NewMaterialDescription] nvarchar(max) NULL,
        [RepairMethod] nvarchar(max) NULL,
        [SupplyMethod] nvarchar(max) NULL,
        [Quantity] nvarchar(max) NULL,
        [OldPartReturnStatus] nvarchar(max) NULL,
        [ResponsibilitySourceIdentifier] nvarchar(max) NULL,
        [ResponsibilitySourceSupplier] nvarchar(max) NULL,
        [SupplierShortCode] nvarchar(max) NULL,
        [ResponsibilitySourceSupplierName] nvarchar(max) NULL,
        [LinePrice] nvarchar(max) NULL,
        [ActualAmount] nvarchar(max) NULL,
        [MaterialMarkupCoefficient] nvarchar(max) NULL,
        [LaborRegionCoefficient] nvarchar(max) NULL,
        [LaborColdClimateCoefficient] nvarchar(max) NULL,
        [LaborQualityCoefficient] nvarchar(max) NULL,
        [LocationCode] nvarchar(max) NULL,
        [LocationCodeDescription] nvarchar(max) NULL,
        [FaultCode] nvarchar(max) NULL,
        [FaultCodeDescription] nvarchar(max) NULL,
        [FaultDescription] nvarchar(max) NULL,
        [ServiceCategory] nvarchar(max) NULL,
        [ServiceOrderCreationDate] nvarchar(max) NULL,
        [FDP] nvarchar(max) NULL,
        [SpecialAuthorizationCode] nvarchar(max) NULL,
        [WBS] nvarchar(max) NULL,
        [DrivingMileageKM] nvarchar(max) NULL,
        [OutboundRescueLicensePlate1] nvarchar(max) NULL,
        [OutboundRescueLicensePlate2] nvarchar(max) NULL,
        [ApprovalDate] nvarchar(max) NULL,
        CONSTRAINT [PK_DailyServiceReviewForms] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241106080911_INS'
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
    WHERE [MigrationId] = N'20241106080911_INS'
)
BEGIN
    CREATE TABLE [VehicleBasicInfos] (
        [ID] int NOT NULL IDENTITY,
        [ShortVin] nvarchar(max) NULL,
        [VIN] nvarchar(max) NULL,
        [VAN] nvarchar(max) NULL,
        [FDP] nvarchar(max) NULL,
        [AnnouncementModel] nvarchar(max) NULL,
        [ProductionDate] nvarchar(max) NULL,
        [SalesDate] nvarchar(max) NULL,
        [EngineNumber] nvarchar(max) NULL,
        [ClaimDate] nvarchar(max) NULL,
        [ExportStatus] nvarchar(max) NULL,
        [EngineModel] nvarchar(max) NULL,
        [SsvaOrSva] nvarchar(max) NULL,
        [InternalAnnouncemen] nvarchar(max) NULL,
        [SeriesDescription] nvarchar(max) NULL,
        [ProductionMouth] nvarchar(max) NULL,
        [Series] nvarchar(max) NULL,
        [Emissions] nvarchar(max) NULL,
        CONSTRAINT [PK_VehicleBasicInfos] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241106080911_INS'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241106080911_INS', N'8.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241107061624_ChangeSQL'
)
BEGIN
    EXEC sp_rename N'[dailyQualityIssueChecklistV91Temps].[MIS36]', N'MIS48', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241107061624_ChangeSQL'
)
BEGIN
    EXEC sp_rename N'[DailyQualityIssueChecklistV91s].[MIS36]', N'MIS48', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241107061624_ChangeSQL'
)
BEGIN
    EXEC sp_rename N'[dailyQualityIssueChecklistV91QueryTemps].[MIS36]', N'MIS48', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241107061624_ChangeSQL'
)
BEGIN
    EXEC sp_rename N'[DailyQualityIssueChecklistV91Queries].[MIS36]', N'MIS48', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241107061624_ChangeSQL'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241107061624_ChangeSQL', N'8.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241108050502_UpdateBreakPointTable'
)
BEGIN
    ALTER TABLE [BreakpointAnalysisTables] ADD [FilteredVehicleModel] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241108050502_UpdateBreakPointTable'
)
BEGIN
    ALTER TABLE [BreakpointAnalysisTables] ADD [SupplierShortCode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241108050502_UpdateBreakPointTable'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241108050502_UpdateBreakPointTable', N'8.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241108051026_UpdateBKP'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241108051026_UpdateBKP', N'8.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241109053853_UpdateTemp91'
)
BEGIN
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ADD [FilteredVehicleModel] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241109053853_UpdateTemp91'
)
BEGIN
    ALTER TABLE [DailyQualityIssueChecklistV91s] ADD [FilteredVehicleModel] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241109053853_UpdateTemp91'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241109053853_UpdateTemp91', N'8.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241109162441_UpdateQueryTable'
)
BEGIN
    EXEC sp_rename N'[dailyQualityIssueChecklistV91QueryTemps].[AccumulatedCaseCount]', N'BreakPointNum', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241109162441_UpdateQueryTable'
)
BEGIN
    EXEC sp_rename N'[DailyQualityIssueChecklistV91Queries].[AccumulatedCaseCount]', N'BreakPointNum', N'COLUMN';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241109162441_UpdateQueryTable'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241109162441_UpdateQueryTable', N'8.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111081453_AddSMSTable'
)
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleBasicInfos]') AND [c].[name] = N'Emissions');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [VehicleBasicInfos] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [VehicleBasicInfos] DROP COLUMN [Emissions];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111081453_AddSMSTable'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleBasicInfos]') AND [c].[name] = N'InternalAnnouncemen');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [VehicleBasicInfos] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [VehicleBasicInfos] DROP COLUMN [InternalAnnouncemen];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111081453_AddSMSTable'
)
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleBasicInfos]') AND [c].[name] = N'ProductionMouth');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [VehicleBasicInfos] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [VehicleBasicInfos] DROP COLUMN [ProductionMouth];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111081453_AddSMSTable'
)
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleBasicInfos]') AND [c].[name] = N'Series');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [VehicleBasicInfos] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [VehicleBasicInfos] DROP COLUMN [Series];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111081453_AddSMSTable'
)
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleBasicInfos]') AND [c].[name] = N'SeriesDescription');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [VehicleBasicInfos] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [VehicleBasicInfos] DROP COLUMN [SeriesDescription];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111081453_AddSMSTable'
)
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleBasicInfos]') AND [c].[name] = N'ShortVin');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [VehicleBasicInfos] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [VehicleBasicInfos] DROP COLUMN [ShortVin];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111081453_AddSMSTable'
)
BEGIN
    CREATE TABLE [dailyServiceReviewFormQueryTemps] (
        [ID] int NOT NULL IDENTITY,
        [ServiceOrder] nvarchar(max) NULL,
        [ServiceOrderStatus] nvarchar(max) NULL,
        [ServiceOrderTotalPrice] nvarchar(max) NULL,
        [WorkOrderNumber] nvarchar(max) NULL,
        [WorkOrderCreationDate] nvarchar(max) NULL,
        [WorkOrderType] nvarchar(max) NULL,
        [DepartureTime] nvarchar(max) NULL,
        [CarPickupTime] nvarchar(max) NULL,
        [WorkOrderRepairEndTime] nvarchar(max) NULL,
        [WorkOrderRepairAccount] nvarchar(max) NULL,
        [OutboundServiceLocation] nvarchar(max) NULL,
        [OutboundMileage] nvarchar(max) NULL,
        [Province] nvarchar(max) NULL,
        [ServiceStation] nvarchar(max) NULL,
        [ServiceStationName] nvarchar(max) NULL,
        [NoticeVehicleModel] nvarchar(max) NULL,
        [VAN] nvarchar(max) NULL,
        [VIN] nvarchar(max) NULL,
        [WarrantyStartDate] nvarchar(max) NULL,
        [MaterialType] nvarchar(max) NULL,
        [LineNumber] nvarchar(max) NULL,
        [OldMaterialCode] nvarchar(max) NULL,
        [OldMaterialDescription] nvarchar(max) NULL,
        [NewMaterialCode] nvarchar(max) NULL,
        [NewMaterialDescription] nvarchar(max) NULL,
        [RepairMethod] nvarchar(max) NULL,
        [SupplyMethod] nvarchar(max) NULL,
        [Quantity] nvarchar(max) NULL,
        [OldPartReturnStatus] nvarchar(max) NULL,
        [ResponsibilitySourceIdentifier] nvarchar(max) NULL,
        [ResponsibilitySourceSupplier] nvarchar(max) NULL,
        [SupplierShortCode] nvarchar(max) NULL,
        [ResponsibilitySourceSupplierName] nvarchar(max) NULL,
        [LinePrice] nvarchar(max) NULL,
        [ActualAmount] nvarchar(max) NULL,
        [MaterialMarkupCoefficient] nvarchar(max) NULL,
        [LaborRegionCoefficient] nvarchar(max) NULL,
        [LaborColdClimateCoefficient] nvarchar(max) NULL,
        [LaborQualityCoefficient] nvarchar(max) NULL,
        [LocationCode] nvarchar(max) NULL,
        [LocationCodeDescription] nvarchar(max) NULL,
        [FaultCode] nvarchar(max) NULL,
        [FaultCodeDescription] nvarchar(max) NULL,
        [FaultDescription] nvarchar(max) NULL,
        [ServiceCategory] nvarchar(max) NULL,
        [ServiceOrderCreationDate] nvarchar(max) NULL,
        [FDP] nvarchar(max) NULL,
        [SpecialAuthorizationCode] nvarchar(max) NULL,
        [WBS] nvarchar(max) NULL,
        [DrivingMileageKM] nvarchar(max) NULL,
        [OutboundRescueLicensePlate1] nvarchar(max) NULL,
        [OutboundRescueLicensePlate2] nvarchar(max) NULL,
        [ApprovalDate] nvarchar(max) NULL,
        [ManufacturingMonth] nvarchar(max) NULL,
        [SalesDate] nvarchar(max) NULL,
        [MIS] nvarchar(max) NULL,
        [VehicleModel] nvarchar(max) NULL,
        [Emission] nvarchar(max) NULL,
        [OrderType] nvarchar(max) NULL,
        [InternalModelCode] nvarchar(max) NULL,
        [VehicleType] nvarchar(max) NULL,
        [Fuel] nvarchar(max) NULL,
        [MISInterval] nvarchar(max) NULL,
        [FilteredVehicleModel] nvarchar(max) NULL,
        CONSTRAINT [PK_dailyServiceReviewFormQueryTemps] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111081453_AddSMSTable'
)
BEGIN
    CREATE TABLE [seriesDescriptionTables] (
        [ID] int NOT NULL IDENTITY,
        [VIN] nvarchar(max) NULL,
        [VAN] nvarchar(max) NULL,
        [InternalAnnouncemen] nvarchar(max) NULL,
        [SeriesDescription] nvarchar(max) NULL,
        CONSTRAINT [PK_seriesDescriptionTables] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241111081453_AddSMSTable'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241111081453_AddSMSTable', N'8.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241113081422_Addedit'
)
BEGIN
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ADD [ApprovalDate] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241113081422_Addedit'
)
BEGIN
    ALTER TABLE [DailyQualityIssueChecklistV91s] ADD [ApprovalDate] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241113081422_Addedit'
)
BEGIN
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ADD [EditedBody] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241113081422_Addedit'
)
BEGIN
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ADD [EditedDate] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241113081422_Addedit'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241113081422_Addedit', N'8.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241114014007_ChangeSQL1.1'
)
BEGIN
    ALTER TABLE [dailyQualityIssueChecklistV91Temps] ADD [IssueAttributes] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241114014007_ChangeSQL1.1'
)
BEGIN
    ALTER TABLE [DailyQualityIssueChecklistV91s] ADD [IssueAttributes] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241114014007_ChangeSQL1.1'
)
BEGIN
    ALTER TABLE [dailyQualityIssueChecklistV91QueryTemps] ADD [EditedBody] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241114014007_ChangeSQL1.1'
)
BEGIN
    ALTER TABLE [dailyQualityIssueChecklistV91QueryTemps] ADD [EditedDate] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241114014007_ChangeSQL1.1'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241114014007_ChangeSQL1.1', N'8.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241114033212_Version1.2'
)
BEGIN
    ALTER TABLE [dailyQualityIssueChecklistV91QueryTemps] ADD [BreakPointTime] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241114033212_Version1.2'
)
BEGIN
    ALTER TABLE [dailyQualityIssueChecklistV91QueryTemps] ADD [IsBreakdownInvalid] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241114033212_Version1.2'
)
BEGIN
    ALTER TABLE [dailyQualityIssueChecklistV91QueryTemps] ADD [IssueAttributes] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241114033212_Version1.2'
)
BEGIN
    ALTER TABLE [dailyQualityIssueChecklistV91QueryTemps] ADD [Remarks] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241114033212_Version1.2'
)
BEGIN
    ALTER TABLE [dailyQualityIssueChecklistV91QueryTemps] ADD [StartTime] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241114033212_Version1.2'
)
BEGIN
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ADD [BreakPointTime] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241114033212_Version1.2'
)
BEGIN
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ADD [IsBreakdownInvalid] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241114033212_Version1.2'
)
BEGIN
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ADD [IssueAttributes] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241114033212_Version1.2'
)
BEGIN
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ADD [Remarks] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241114033212_Version1.2'
)
BEGIN
    ALTER TABLE [DailyQualityIssueChecklistV91Queries] ADD [StartTime] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241114033212_Version1.2'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241114033212_Version1.2', N'8.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241127073408_QEI'
)
BEGIN
    CREATE TABLE [QEIdentifies] (
        [ID] int NOT NULL IDENTITY,
        [LocationCode] nvarchar(max) NULL,
        [QEName] nvarchar(max) NULL,
        CONSTRAINT [PK_QEIdentifies] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241127073408_QEI'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241127073408_QEI', N'8.0.10');
END;
GO

COMMIT;
GO

