
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/18/2023 17:25:56
-- Generated from EDMX file: H:\FALCON SOFTWARE\FalconReportingweb\FalconReportingweb\dBmODEL.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FalconHouse];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Access_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Access] DROP CONSTRAINT [FK_Access_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Advance_Employees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Advance] DROP CONSTRAINT [FK_Advance_Employees];
GO
IF OBJECT_ID(N'[dbo].[FK_AdvanceReturn_Employees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdvanceReturn] DROP CONSTRAINT [FK_AdvanceReturn_Employees];
GO
IF OBJECT_ID(N'[dbo].[FK_Allottee_House]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Allottee] DROP CONSTRAINT [FK_Allottee_House];
GO
IF OBJECT_ID(N'[dbo].[FK_ComercialAllottment_MarketTb]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ComercialAllottment] DROP CONSTRAINT [FK_ComercialAllottment_MarketTb];
GO
IF OBJECT_ID(N'[dbo].[FK_Documents_Residents]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Documents] DROP CONSTRAINT [FK_Documents_Residents];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeSalary_Employees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeeSalary] DROP CONSTRAINT [FK_EmployeeSalary_Employees];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeesAttendance_EmployeesAttendance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeesAttendance] DROP CONSTRAINT [FK_EmployeesAttendance_EmployeesAttendance];
GO
IF OBJECT_ID(N'[dbo].[FK_HouseBills_Expenses]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HouseBills] DROP CONSTRAINT [FK_HouseBills_Expenses];
GO
IF OBJECT_ID(N'[dbo].[FK_HouseBills_HouseBills]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HouseBills] DROP CONSTRAINT [FK_HouseBills_HouseBills];
GO
IF OBJECT_ID(N'[dbo].[FK_IssueDetailTb_ProjectMeterialIssuTb]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IssueDetailTb] DROP CONSTRAINT [FK_IssueDetailTb_ProjectMeterialIssuTb];
GO
IF OBJECT_ID(N'[dbo].[FK_ItemsDeff_CategoryTb]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ItemsDeff] DROP CONSTRAINT [FK_ItemsDeff_CategoryTb];
GO
IF OBJECT_ID(N'[dbo].[FK_Payment_Payment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Payment] DROP CONSTRAINT [FK_Payment_Payment];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentDetails_PaymentDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentDetails] DROP CONSTRAINT [FK_PaymentDetails_PaymentDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_ProgressTb_ProjectAssignedTb]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProgressTb] DROP CONSTRAINT [FK_ProgressTb_ProjectAssignedTb];
GO
IF OBJECT_ID(N'[dbo].[FK_ProgressTb_YardStick]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProgressTb] DROP CONSTRAINT [FK_ProgressTb_YardStick];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectAssignedTb_ContractorTb]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectAssignedTb] DROP CONSTRAINT [FK_ProjectAssignedTb_ContractorTb];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectAssignedTb_ProjectTbNew]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectAssignedTb] DROP CONSTRAINT [FK_ProjectAssignedTb_ProjectTbNew];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectTbNew_ProjectTypeTb]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectTbNew] DROP CONSTRAINT [FK_ProjectTbNew_ProjectTypeTb];
GO
IF OBJECT_ID(N'[dbo].[FK_PurchaseDetail_PurchaseTb]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchaseDetail] DROP CONSTRAINT [FK_PurchaseDetail_PurchaseTb];
GO
IF OBJECT_ID(N'[dbo].[FK_Purchaser_House]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Purchaser] DROP CONSTRAINT [FK_Purchaser_House];
GO
IF OBJECT_ID(N'[dbo].[FK_RarReceiptTb_RarTb]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RarReceiptTb] DROP CONSTRAINT [FK_RarReceiptTb_RarTb];
GO
IF OBJECT_ID(N'[dbo].[FK_RarTb_ProjectAssignedTb]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RarTb] DROP CONSTRAINT [FK_RarTb_ProjectAssignedTb];
GO
IF OBJECT_ID(N'[dbo].[FK_RenteePaymentTb_ShopCurrentTb]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RenteePaymentTb] DROP CONSTRAINT [FK_RenteePaymentTb_ShopCurrentTb];
GO
IF OBJECT_ID(N'[dbo].[FK_RenteePaymentTb_ShopsTb]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RenteePaymentTb] DROP CONSTRAINT [FK_RenteePaymentTb_ShopsTb];
GO
IF OBJECT_ID(N'[dbo].[FK_Residents_Residents]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Residents] DROP CONSTRAINT [FK_Residents_Residents];
GO
IF OBJECT_ID(N'[dbo].[FK_Residents_Tenant]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Residents] DROP CONSTRAINT [FK_Residents_Tenant];
GO
IF OBJECT_ID(N'[dbo].[FK_ResidentsInfo_Residents]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ResidentsInfo] DROP CONSTRAINT [FK_ResidentsInfo_Residents];
GO
IF OBJECT_ID(N'[dbo].[FK_ResidentTb_House]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ResidentTb] DROP CONSTRAINT [FK_ResidentTb_House];
GO
IF OBJECT_ID(N'[dbo].[FK_Servant_Residents]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Servant] DROP CONSTRAINT [FK_Servant_Residents];
GO
IF OBJECT_ID(N'[dbo].[FK_ShopCurrentTb_ShopsTb]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShopCurrentTb] DROP CONSTRAINT [FK_ShopCurrentTb_ShopsTb];
GO
IF OBJECT_ID(N'[dbo].[FK_ShopsRent_ShopsTb]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShopsRent] DROP CONSTRAINT [FK_ShopsRent_ShopsTb];
GO
IF OBJECT_ID(N'[dbo].[FK_ShopsTb_MarketTb]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShopsTb] DROP CONSTRAINT [FK_ShopsTb_MarketTb];
GO
IF OBJECT_ID(N'[dbo].[FK_Tenant_House]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tenant] DROP CONSTRAINT [FK_Tenant_House];
GO
IF OBJECT_ID(N'[dbo].[FK_Vehicles_Vehicles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehicles] DROP CONSTRAINT [FK_Vehicles_Vehicles];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Access]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Access];
GO
IF OBJECT_ID(N'[dbo].[Advance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Advance];
GO
IF OBJECT_ID(N'[dbo].[AdvanceReturn]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdvanceReturn];
GO
IF OBJECT_ID(N'[dbo].[Alerts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Alerts];
GO
IF OBJECT_ID(N'[dbo].[Allottee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Allottee];
GO
IF OBJECT_ID(N'[dbo].[AltrationTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AltrationTb];
GO
IF OBJECT_ID(N'[dbo].[CareOf]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CareOf];
GO
IF OBJECT_ID(N'[dbo].[CategoryTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoryTb];
GO
IF OBJECT_ID(N'[dbo].[ColorTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ColorTb];
GO
IF OBJECT_ID(N'[dbo].[ComercialAllottment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ComercialAllottment];
GO
IF OBJECT_ID(N'[dbo].[ComplaintTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ComplaintTb];
GO
IF OBJECT_ID(N'[dbo].[Contractor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contractor];
GO
IF OBJECT_ID(N'[dbo].[ContractorTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContractorTb];
GO
IF OBJECT_ID(N'[dbo].[dbFiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[dbFiles];
GO
IF OBJECT_ID(N'[dbo].[Documents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Documents];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[EmployeeSalary]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeSalary];
GO
IF OBJECT_ID(N'[dbo].[EmployeesAttendance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeesAttendance];
GO
IF OBJECT_ID(N'[dbo].[Expenses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Expenses];
GO
IF OBJECT_ID(N'[dbo].[FamilytreeTB]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FamilytreeTB];
GO
IF OBJECT_ID(N'[dbo].[Fine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Fine];
GO
IF OBJECT_ID(N'[dbo].[House]', 'U') IS NOT NULL
    DROP TABLE [dbo].[House];
GO
IF OBJECT_ID(N'[dbo].[HouseBills]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HouseBills];
GO
IF OBJECT_ID(N'[dbo].[ImagesPath]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImagesPath];
GO
IF OBJECT_ID(N'[dbo].[InvTransferTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvTransferTb];
GO
IF OBJECT_ID(N'[dbo].[IssueDetailTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IssueDetailTb];
GO
IF OBJECT_ID(N'[dbo].[ItemsDeff]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ItemsDeff];
GO
IF OBJECT_ID(N'[dbo].[MarketTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MarketTb];
GO
IF OBJECT_ID(N'[dbo].[Payment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Payment];
GO
IF OBJECT_ID(N'[dbo].[PaymentDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentDetails];
GO
IF OBJECT_ID(N'[dbo].[Pets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pets];
GO
IF OBJECT_ID(N'[dbo].[ProgressTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProgressTb];
GO
IF OBJECT_ID(N'[dbo].[ProjectAssignedTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectAssignedTb];
GO
IF OBJECT_ID(N'[dbo].[ProjectMeterialIssuTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectMeterialIssuTb];
GO
IF OBJECT_ID(N'[dbo].[ProjectTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectTb];
GO
IF OBJECT_ID(N'[dbo].[ProjectTbNew]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectTbNew];
GO
IF OBJECT_ID(N'[dbo].[ProjectTypeTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectTypeTb];
GO
IF OBJECT_ID(N'[dbo].[PurchaseDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PurchaseDetail];
GO
IF OBJECT_ID(N'[dbo].[Purchaser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Purchaser];
GO
IF OBJECT_ID(N'[dbo].[PurchaseTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PurchaseTb];
GO
IF OBJECT_ID(N'[dbo].[RAC]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RAC];
GO
IF OBJECT_ID(N'[dbo].[RarReceiptTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RarReceiptTb];
GO
IF OBJECT_ID(N'[dbo].[RarTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RarTb];
GO
IF OBJECT_ID(N'[dbo].[ReceiptApprovedTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReceiptApprovedTb];
GO
IF OBJECT_ID(N'[dbo].[RenteePaymentTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RenteePaymentTb];
GO
IF OBJECT_ID(N'[dbo].[Residents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Residents];
GO
IF OBJECT_ID(N'[dbo].[ResidentsInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ResidentsInfo];
GO
IF OBJECT_ID(N'[dbo].[ResidentTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ResidentTb];
GO
IF OBJECT_ID(N'[dbo].[Servant]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Servant];
GO
IF OBJECT_ID(N'[dbo].[ShopCurrentTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShopCurrentTb];
GO
IF OBJECT_ID(N'[dbo].[ShopsRent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShopsRent];
GO
IF OBJECT_ID(N'[dbo].[ShopsTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShopsTb];
GO
IF OBJECT_ID(N'[dbo].[Supplier]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Supplier];
GO
IF OBJECT_ID(N'[dbo].[Tenant]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tenant];
GO
IF OBJECT_ID(N'[dbo].[UOMTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UOMTb];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[vaccinTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[vaccinTb];
GO
IF OBJECT_ID(N'[dbo].[Vehicles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vehicles];
GO
IF OBJECT_ID(N'[dbo].[VehicleTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VehicleTb];
GO
IF OBJECT_ID(N'[dbo].[VisiterTb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VisiterTb];
GO
IF OBJECT_ID(N'[dbo].[Visitors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Visitors];
GO
IF OBJECT_ID(N'[dbo].[YardStick]', 'U') IS NOT NULL
    DROP TABLE [dbo].[YardStick];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accesses'
CREATE TABLE [dbo].[Accesses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NULL,
    [FormName] nvarchar(max)  NULL
);
GO

-- Creating table 'Advances'
CREATE TABLE [dbo].[Advances] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EmpId] int  NULL,
    [Advance1] float  NULL,
    [Date] datetime  NULL,
    [Reason] varchar(max)  NULL
);
GO

-- Creating table 'AdvanceReturns'
CREATE TABLE [dbo].[AdvanceReturns] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EmpId] int  NULL,
    [AdvanceReturn1] float  NULL,
    [Date] datetime  NULL
);
GO

-- Creating table 'Alerts'
CREATE TABLE [dbo].[Alerts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(max)  NULL,
    [ContentType] varchar(max)  NULL,
    [Data] varbinary(max)  NULL
);
GO

-- Creating table 'Allottees'
CREATE TABLE [dbo].[Allottees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HouseId] int  NULL,
    [Name] nvarchar(max)  NULL,
    [CNIC] nvarchar(max)  NULL,
    [Gender] nvarchar(max)  NULL,
    [ContactNo] nvarchar(max)  NULL,
    [CurrentOwnerShip] nvarchar(max)  NULL,
    [Date] datetime  NULL,
    [Residing] nvarchar(max)  NULL,
    [Remarks] nvarchar(max)  NULL,
    [Sof] varchar(200)  NULL,
    [SO] varchar(100)  NULL,
    [Image] varchar(max)  NULL
);
GO

-- Creating table 'AltrationTbs'
CREATE TABLE [dbo].[AltrationTbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [houseid] int  NULL,
    [Detail] nvarchar(max)  NULL,
    [Date] datetime  NULL,
    [Title] nvarchar(max)  NULL
);
GO

-- Creating table 'CareOfs'
CREATE TABLE [dbo].[CareOfs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SaleId] int  NOT NULL,
    [Name] varchar(max)  NULL,
    [CareOf1] varchar(max)  NULL
);
GO

-- Creating table 'CategoryTbs'
CREATE TABLE [dbo].[CategoryTbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL
);
GO

-- Creating table 'ComercialAllottments'
CREATE TABLE [dbo].[ComercialAllottments] (
    [Id] int  NOT NULL,
    [marketid] int  NULL,
    [shopid] int  NULL,
    [Allottee] nvarchar(300)  NULL,
    [SO] varchar(50)  NULL,
    [SoName] nvarchar(300)  NULL,
    [CNIC] nvarchar(500)  NULL,
    [Gender] varchar(50)  NULL,
    [Contact] varchar(300)  NULL,
    [Remarks] nvarchar(max)  NULL,
    [Status] varchar(200)  NULL,
    [Date] datetime  NULL
);
GO

-- Creating table 'ComplaintTbs'
CREATE TABLE [dbo].[ComplaintTbs] (
    [Id] int  NOT NULL,
    [houseid] int  NULL,
    [complaint] varchar(max)  NULL,
    [Date] datetime  NULL,
    [Status] varchar(50)  NULL,
    [Remarks] varchar(max)  NULL,
    [Title] varchar(300)  NULL,
    [employeeid] int  NOT NULL
);
GO

-- Creating table 'Contractors'
CREATE TABLE [dbo].[Contractors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(100)  NULL,
    [Mobile] varchar(50)  NULL,
    [Teleph] varchar(50)  NULL,
    [Company] varchar(200)  NULL,
    [CNIC] varchar(50)  NULL,
    [Address] varbinary(max)  NULL,
    [NTN] varchar(50)  NULL
);
GO

-- Creating table 'ContractorTbs'
CREATE TABLE [dbo].[ContractorTbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NULL,
    [Contact] varchar(50)  NULL,
    [Company] nvarchar(200)  NULL,
    [CNIC] nvarchar(60)  NULL,
    [Phone] varchar(50)  NULL,
    [Address] nvarchar(max)  NULL,
    [NTN] nvarchar(100)  NULL
);
GO

-- Creating table 'dbFiles'
CREATE TABLE [dbo].[dbFiles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(max)  NULL,
    [ContentType] varchar(max)  NULL,
    [Data] varbinary(max)  NULL
);
GO

-- Creating table 'Documents'
CREATE TABLE [dbo].[Documents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ResId] int  NULL,
    [FileName] nvarchar(max)  NULL,
    [FilePath] nvarchar(max)  NULL,
    [FileType] nvarchar(max)  NULL,
    [FileSize] varbinary(max)  NULL,
    [CreatedAt] datetime  NULL,
    [CreatedBy] int  NULL,
    [UpdatedAt] datetime  NULL,
    [UpdatedBy] int  NULL,
    [type] nvarchar(max)  NULL,
    [memberid] int  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(max)  NULL,
    [Gender] varchar(max)  NULL,
    [DOB] datetime  NULL,
    [Age] int  NULL,
    [ContactNo] varchar(max)  NULL,
    [Designation] varchar(max)  NULL,
    [CNIC] varchar(max)  NULL,
    [BloodGroup] varchar(max)  NULL,
    [Srnumber] varchar(max)  NULL,
    [Cardexp] datetime  NULL,
    [CardIssue] datetime  NULL,
    [Occupation] varchar(200)  NULL,
    [CardStatus] varchar(50)  NULL,
    [CardTrackNote] varchar(max)  NULL,
    [Img] varchar(max)  NULL,
    [Sof] varchar(max)  NULL,
    [Address] varchar(max)  NULL,
    [Selected] int  NULL
);
GO

-- Creating table 'EmployeeSalaries'
CREATE TABLE [dbo].[EmployeeSalaries] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EmpId] int  NULL,
    [Increment] float  NULL,
    [Salary] float  NULL,
    [Date] datetime  NULL
);
GO

-- Creating table 'EmployeesAttendances'
CREATE TABLE [dbo].[EmployeesAttendances] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EmpId] int  NOT NULL,
    [Date] datetime  NULL,
    [TimeDue] varchar(max)  NULL,
    [Arrival] varchar(max)  NULL
);
GO

-- Creating table 'Expenses'
CREATE TABLE [dbo].[Expenses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Head] nvarchar(max)  NULL,
    [Amount] float  NULL,
    [Type] nvarchar(max)  NULL
);
GO

-- Creating table 'FamilytreeTBs'
CREATE TABLE [dbo].[FamilytreeTBs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [type] varchar(50)  NOT NULL,
    [sponsirid] int  NOT NULL,
    [Name] varchar(50)  NULL,
    [CNIC] varchar(100)  NULL,
    [Relation] varchar(100)  NULL,
    [Gender] varchar(50)  NULL,
    [DOB] datetime  NULL,
    [Img] varchar(max)  NULL,
    [Selected] int  NULL,
    [CardTrackNote] varchar(max)  NULL,
    [CardStatus] varchar(50)  NULL,
    [CardIssue] datetime  NULL,
    [Cardexp] datetime  NULL,
    [Srnumber] varchar(300)  NULL,
    [so] varchar(50)  NULL,
    [soname] varchar(200)  NULL
);
GO

-- Creating table 'Fines'
CREATE TABLE [dbo].[Fines] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NULL,
    [HouseId] int  NULL,
    [Fine1] float  NULL,
    [Reason] nvarchar(max)  NULL,
    [Paid] nvarchar(max)  NULL
);
GO

-- Creating table 'Houses'
CREATE TABLE [dbo].[Houses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HouseNo] nvarchar(max)  NULL,
    [Address] nvarchar(max)  NULL,
    [Street] nvarchar(max)  NULL,
    [Type] nvarchar(max)  NULL
);
GO

-- Creating table 'HouseBills'
CREATE TABLE [dbo].[HouseBills] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HouseId] int  NULL,
    [Type] nvarchar(50)  NULL,
    [Date] datetime  NULL,
    [ExpenseId] int  NULL,
    [Due_Date] datetime  NULL,
    [Status] nvarchar(50)  NULL,
    [BillingMonth] nvarchar(50)  NULL,
    [Payable] float  NULL,
    [Paid] float  NULL,
    [Arears] float  NULL,
    [Surcharge] float  NULL
);
GO

-- Creating table 'ImagesPaths'
CREATE TABLE [dbo].[ImagesPaths] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Path] nvarchar(max)  NULL
);
GO

-- Creating table 'InvTransferTbs'
CREATE TABLE [dbo].[InvTransferTbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Projectid] int  NULL,
    [ContractorId] int  NULL,
    [Date] datetime  NULL,
    [Amount] float  NULL,
    [Status] varchar(50)  NULL,
    [Detail] nvarchar(max)  NULL
);
GO

-- Creating table 'IssueDetailTbs'
CREATE TABLE [dbo].[IssueDetailTbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Issueid] int  NULL,
    [Itemid] int  NULL,
    [Qty] float  NULL,
    [price] float  NULL,
    [Total] float  NULL,
    [Detail] varchar(max)  NULL
);
GO

-- Creating table 'ItemsDeffs'
CREATE TABLE [dbo].[ItemsDeffs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NULL,
    [Unit] int  NULL,
    [Cost] float  NULL,
    [Detail] nvarchar(200)  NULL,
    [Catid] int  NULL,
    [ItemCode] varchar(max)  NULL
);
GO

-- Creating table 'MarketTbs'
CREATE TABLE [dbo].[MarketTbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Detail] nvarchar(max)  NULL,
    [Allottee] nvarchar(300)  NULL,
    [CNIC] varchar(50)  NULL,
    [SO] varchar(50)  NULL,
    [SoName] nvarchar(300)  NULL,
    [Gender] varchar(50)  NULL,
    [Contact] varchar(50)  NULL,
    [Date] datetime  NULL,
    [Status] varchar(50)  NULL
);
GO

-- Creating table 'Payments'
CREATE TABLE [dbo].[Payments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HouseId] int  NULL,
    [Date] datetime  NULL,
    [TotalBill] float  NULL
);
GO

-- Creating table 'PaymentDetails'
CREATE TABLE [dbo].[PaymentDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PayId] int  NULL,
    [Paid] float  NULL,
    [BillingMonth] nvarchar(50)  NULL,
    [Remaining] float  NULL,
    [type] varchar(50)  NULL,
    [Arear] float  NULL
);
GO

-- Creating table 'Pets'
CREATE TABLE [dbo].[Pets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ResId] int  NULL,
    [Pet_Kind] nvarchar(max)  NULL,
    [Vaccinated] datetime  NULL,
    [Vaccinated_Due] datetime  NULL,
    [ownby] varchar(50)  NULL,
    [memberid] int  NULL
);
GO

-- Creating table 'ProgressTbs'
CREATE TABLE [dbo].[ProgressTbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NULL,
    [passinid] int  NULL,
    [stickid] int  NULL,
    [GF] float  NULL,
    [FF] float  NULL
);
GO

-- Creating table 'ProjectAssignedTbs'
CREATE TABLE [dbo].[ProjectAssignedTbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Pid] int  NULL,
    [ctorid] int  NULL,
    [datecomm] datetime  NULL,
    [datetcomp] datetime  NULL,
    [extenddate] datetime  NULL,
    [ExtendStatus] varchar(max)  NULL,
    [CAno] varchar(100)  NULL,
    [CaCost] decimal(19,4)  NULL,
    [Extenssion] int  NULL,
    [Advancepercen] float  NULL,
    [Advance] float  NULL
);
GO

-- Creating table 'ProjectMeterialIssuTbs'
CREATE TABLE [dbo].[ProjectMeterialIssuTbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [passignid] int  NULL,
    [date] datetime  NULL,
    [Amount] float  NULL,
    [status] varchar(50)  NULL,
    [rarid] int  NULL
);
GO

-- Creating table 'ProjectTbs'
CREATE TABLE [dbo].[ProjectTbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [contractor] int  NULL,
    [Name] nvarchar(max)  NULL,
    [ContractNumber] nvarchar(200)  NULL,
    [EstimatedCost] float  NULL,
    [CompletionDate] datetime  NULL,
    [AssigningDate] datetime  NULL,
    [PDetail] nvarchar(max)  NULL
);
GO

-- Creating table 'ProjectTbNews'
CREATE TABLE [dbo].[ProjectTbNews] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Pname] varchar(max)  NULL,
    [PHnumber] varchar(50)  NULL,
    [Phtype] varchar(50)  NULL,
    [ptypeid] int  NULL
);
GO

-- Creating table 'ProjectTypeTbs'
CREATE TABLE [dbo].[ProjectTypeTbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(200)  NULL,
    [Detail] varchar(max)  NULL
);
GO

-- Creating table 'PurchaseDetails'
CREATE TABLE [dbo].[PurchaseDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Itemid] int  NULL,
    [Packages] float  NULL,
    [ItemspPackage] float  NULL,
    [Quantity] float  NULL,
    [PricepPckage] float  NULL,
    [TotalAmount] float  NULL,
    [Date] datetime  NULL,
    [pricepItem] float  NULL,
    [puid] int  NULL
);
GO

-- Creating table 'Purchasers'
CREATE TABLE [dbo].[Purchasers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HouseId] int  NULL,
    [Name] nvarchar(max)  NULL,
    [CNIC] nvarchar(max)  NULL,
    [Gender] nvarchar(max)  NULL,
    [ContactNo] nvarchar(max)  NULL,
    [CurrentOwnerShip] nvarchar(max)  NULL,
    [Date] datetime  NULL,
    [Residing] nvarchar(max)  NULL,
    [Remarks] varchar(max)  NULL,
    [Sof] varchar(200)  NULL,
    [SO] varchar(100)  NULL,
    [Image] varchar(max)  NULL
);
GO

-- Creating table 'PurchaseTbs'
CREATE TABLE [dbo].[PurchaseTbs] (
    [Id] int  NOT NULL,
    [Supplierid] int  NULL,
    [Numberitems] int  NULL,
    [Amount] float  NULL,
    [Date] datetime  NULL,
    [Terminal] varchar(520)  NULL,
    [InoviceNumber] varchar(200)  NULL,
    [purchasefor] varchar(200)  NULL
);
GO

-- Creating table 'RACs'
CREATE TABLE [dbo].[RACs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(max)  NULL,
    [Designation] varchar(max)  NULL,
    [PhoneNo] varchar(max)  NULL,
    [Email] varchar(max)  NULL
);
GO

-- Creating table 'RarReceiptTbs'
CREATE TABLE [dbo].[RarReceiptTbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [rarid] int  NULL,
    [valueofwork] float  NULL,
    [workexcuted] float  NULL,
    [yardstickpercentage] float  NULL,
    [provesionalmeasured] float  NULL,
    [dosmeasured] float  NULL,
    [meterialprovided] float  NULL,
    [mobilisationadvance] float  NULL,
    [Retentionmoney] float  NULL,
    [previouserar] float  NULL,
    [storesacclastrar] float  NULL,
    [storesissued] float  NULL,
    [rent] float  NULL,
    [water] float  NULL,
    [transport] float  NULL,
    [loadingunloading] float  NULL,
    [incometax] float  NULL,
    [bank] float  NULL,
    [mailexp] float  NULL,
    [secureadvance] float  NULL,
    [Netpayable] float  NULL,
    [storereturn] float  NULL
);
GO

-- Creating table 'RarTbs'
CREATE TABLE [dbo].[RarTbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [rarnumber] varchar(100)  NULL,
    [date] datetime  NULL,
    [onprogress] float  NULL,
    [Status] varchar(100)  NULL,
    [Remarks] varchar(max)  NULL,
    [pasind] int  NULL,
    [RarDocument] varchar(max)  NULL,
    [SDOapp] bit  NULL,
    [Adapp] bit  NULL,
    [SDOeng] bit  NULL,
    [WOic] bit  NULL,
    [DDH] bit  NULL,
    [Director] bit  NULL,
    [ICCash] bit  NULL
);
GO

-- Creating table 'ReceiptApprovedTbs'
CREATE TABLE [dbo].[ReceiptApprovedTbs] (
    [Id] int  NOT NULL,
    [Rank] varchar(200)  NULL,
    [Name] varchar(200)  NULL,
    [Pakno] varchar(300)  NULL,
    [Sig] varchar(max)  NULL
);
GO

-- Creating table 'RenteePaymentTbs'
CREATE TABLE [dbo].[RenteePaymentTbs] (
    [id] int IDENTITY(1,1) NOT NULL,
    [voucher] varchar(50)  NULL,
    [renteeid] int  NULL,
    [date] datetime  NULL,
    [Amount] float  NULL,
    [Status] varchar(50)  NULL,
    [duedate] datetime  NULL,
    [shopid] int  NULL
);
GO

-- Creating table 'Residents'
CREATE TABLE [dbo].[Residents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HouseId] int  NULL,
    [Floors] nvarchar(50)  NULL,
    [Pets] int  NULL,
    [vehicles] int  NULL,
    [ResidentsNo] int  NULL,
    [StartDate] datetime  NULL,
    [Email] nvarchar(max)  NULL,
    [ContactNo] nvarchar(max)  NULL,
    [servants] int  NULL,
    [profession] nvarchar(max)  NULL,
    [CNIC] nvarchar(max)  NULL,
    [Nationality] nvarchar(max)  NULL,
    [BloodGroup] nvarchar(max)  NULL,
    [ContactPerson] nvarchar(max)  NULL,
    [Gender] nvarchar(max)  NULL,
    [tenantid] int  NULL
);
GO

-- Creating table 'ResidentsInfoes'
CREATE TABLE [dbo].[ResidentsInfoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ResId] int  NULL,
    [Name] nvarchar(max)  NULL,
    [Date_Of_Birth] nvarchar(max)  NULL,
    [Gender] nvarchar(max)  NULL,
    [Blood_Group] nvarchar(max)  NULL,
    [CNIC_NO] nvarchar(max)  NULL,
    [Nationality] nvarchar(max)  NULL,
    [Relation_To_The_ContactPerson] nvarchar(max)  NULL
);
GO

-- Creating table 'ResidentTbs'
CREATE TABLE [dbo].[ResidentTbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [houseid] int  NULL,
    [type] varchar(50)  NULL,
    [memberid] nchar(10)  NULL,
    [Date] datetime  NULL,
    [Floor] varchar(50)  NULL,
    [checkoutDate] datetime  NULL,
    [ownertyp] varchar(50)  NULL,
    [ownerid] int  NULL,
    [Srnumber] varchar(max)  NULL,
    [Cardexp] datetime  NULL,
    [CardIssue] datetime  NULL,
    [Occupation] varchar(200)  NULL,
    [CardStatus] varchar(50)  NULL,
    [CardTrackNote] varchar(max)  NULL,
    [Selected] int  NULL
);
GO

-- Creating table 'Servants'
CREATE TABLE [dbo].[Servants] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ResId] int  NULL,
    [Name] nvarchar(max)  NULL,
    [Gender] nvarchar(max)  NULL,
    [CNIC] nvarchar(max)  NULL,
    [Date_Of_Birth] datetime  NULL,
    [ContactNo] nvarchar(max)  NULL,
    [BloodGroup] nvarchar(max)  NULL,
    [SecurityPass] nvarchar(max)  NULL,
    [Type] nvarchar(max)  NULL,
    [Status] nvarchar(max)  NULL,
    [houseid] int  NULL,
    [Img] nvarchar(max)  NULL,
    [Srnumber] varchar(max)  NULL,
    [ExpiryDate] datetime  NULL,
    [DateIssue] datetime  NULL,
    [CardStatus] varchar(50)  NULL,
    [CardTrackNote] varchar(max)  NULL,
    [residentid] int  NULL,
    [Selected] int  NULL,
    [suposof] varchar(50)  NULL,
    [Suposofname] varchar(300)  NULL,
    [ShopId] int  NOT NULL
   
);
GO

-- Creating table 'ShopCurrentTbs'
CREATE TABLE [dbo].[ShopCurrentTbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [shopid] int  NULL,
    [Name] varchar(300)  NULL,
    [SO] varchar(50)  NULL,
    [SofName] varchar(500)  NULL,
    [CNIC] varchar(20)  NULL,
    [Contact] varchar(50)  NULL,
    [Address] varchar(max)  NULL,
    [Image] varchar(max)  NULL,
    [srnumber] varchar(500)  NULL,
    [cardexp] datetime  NULL,
    [cardissu] datetime  NULL,
    [CardStatus] varchar(50)  NULL,
    [CardTrackNote] varchar(max)  NULL,
    [Selected] int  NULL,
    [TypeStat] varchar(50)  NULL,
    [SecuerityDeposit] float  NULL,
    [AgrementEnd] datetime  NULL,
    [Status] varchar(50)  NULL,
    [Businessname] nvarchar(max)  NULL
);
GO

-- Creating table 'ShopsRents'
CREATE TABLE [dbo].[ShopsRents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [shopid] int  NULL,
    [Rent] float  NULL,
    [date] datetime  NULL,
    [status] varchar(50)  NULL
);
GO

-- Creating table 'ShopsTbs'
CREATE TABLE [dbo].[ShopsTbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ShopeNumber] varchar(50)  NULL,
    [marketid] int  NULL,
    [Detail] nvarchar(max)  NULL
);
GO

-- Creating table 'Suppliers'
CREATE TABLE [dbo].[Suppliers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NULL,
    [Mobile] varchar(50)  NULL,
    [CNIC] varchar(50)  NULL,
    [Company] varchar(200)  NULL,
    [NTN] varchar(50)  NULL,
    [Address] varchar(max)  NULL,
    [Phone] varchar(50)  NULL
);
GO

-- Creating table 'Tenants'
CREATE TABLE [dbo].[Tenants] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HouseId] int  NULL,
    [Name] nvarchar(max)  NULL,
    [CNIC] nvarchar(max)  NULL,
    [Gender] nvarchar(max)  NULL,
    [ContactNo] nvarchar(max)  NULL,
    [CurrentOwnerShip] nvarchar(max)  NULL,
    [Date] datetime  NULL,
    [Residing] nvarchar(max)  NULL,
    [Remarks] nvarchar(max)  NULL,
    [Sof] varchar(200)  NULL,
    [SO] varchar(100)  NULL,
    [Image] varchar(max)  NULL
);
GO

-- Creating table 'UOMTbs'
CREATE TABLE [dbo].[UOMTbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UOM] varchar(50)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NULL,
    [Password] nvarchar(max)  NULL,
    [UserType] varchar(50)  NULL,
    [Image] varchar(max)  NULL
);
GO

-- Creating table 'vaccinTbs'
CREATE TABLE [dbo].[vaccinTbs] (
    [id] int IDENTITY(1,1) NOT NULL,
    [petid] int  NULL,
    [vaccin] varchar(50)  NULL,
    [date] datetime  NULL,
    [nextdate] datetime  NULL
);
GO

-- Creating table 'Vehicles'
CREATE TABLE [dbo].[Vehicles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ResId] int  NULL,
    [RegNo] nvarchar(max)  NULL,
    [Make] nvarchar(max)  NULL,
    [ModelNo] real  NULL,
    [Color] nvarchar(50)  NULL,
    [EtagId] nvarchar(max)  NULL
);
GO

-- Creating table 'VehicleTbs'
CREATE TABLE [dbo].[VehicleTbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ownertype] varchar(50)  NULL,
    [ownerid] int  NULL,
    [RegNo] varchar(80)  NULL,
    [Make] varchar(50)  NULL,
    [ModelNo] varchar(50)  NULL,
    [Color] varchar(50)  NULL,
    [Eteg] varchar(50)  NULL,
    [Typevh] varchar(100)  NULL
);
GO

-- Creating table 'VisiterTbs'
CREATE TABLE [dbo].[VisiterTbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Vhnumber] varchar(100)  NULL,
    [Name] varchar(50)  NULL,
    [PhoneNo] varchar(50)  NULL,
    [CNIC] varchar(60)  NULL,
    [VisitTo] varchar(50)  NULL,
    [Remarks] varchar(max)  NULL,
    [DateTime] datetime  NULL,
    [Ingate] varchar(50)  NULL,
    [Outgate] varchar(50)  NULL,
    [InTime] datetime  NULL,
    [OutTime] datetime  NULL,
    [Img1] varchar(max)  NULL,
    [Img2] varchar(max)  NULL
);
GO

-- Creating table 'Visitors'
CREATE TABLE [dbo].[Visitors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [VehicalNo] nvarchar(max)  NULL,
    [Name] nvarchar(max)  NULL,
    [Phone] nvarchar(max)  NULL,
    [CNIC] nvarchar(max)  NULL,
    [VisitTo] nvarchar(max)  NULL,
    [InGate] nvarchar(max)  NULL,
    [InTime] datetime  NULL,
    [OutGate] nvarchar(max)  NULL,
    [OutTime] datetime  NULL,
    [Remarks] nvarchar(max)  NULL,
    [PIcture1] varchar(max)  NULL,
    [Picture2] varchar(max)  NULL
);
GO

-- Creating table 'YardSticks'
CREATE TABLE [dbo].[YardSticks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(300)  NULL,
    [GF] float  NULL,
    [FF] float  NULL
);
GO

-- Creating table 'ColorTbs'
CREATE TABLE [dbo].[ColorTbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [cardname] varchar(50)  NULL,
    [backcolor] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Accesses'
ALTER TABLE [dbo].[Accesses]
ADD CONSTRAINT [PK_Accesses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Advances'
ALTER TABLE [dbo].[Advances]
ADD CONSTRAINT [PK_Advances]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AdvanceReturns'
ALTER TABLE [dbo].[AdvanceReturns]
ADD CONSTRAINT [PK_AdvanceReturns]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Alerts'
ALTER TABLE [dbo].[Alerts]
ADD CONSTRAINT [PK_Alerts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Allottees'
ALTER TABLE [dbo].[Allottees]
ADD CONSTRAINT [PK_Allottees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AltrationTbs'
ALTER TABLE [dbo].[AltrationTbs]
ADD CONSTRAINT [PK_AltrationTbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CareOfs'
ALTER TABLE [dbo].[CareOfs]
ADD CONSTRAINT [PK_CareOfs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategoryTbs'
ALTER TABLE [dbo].[CategoryTbs]
ADD CONSTRAINT [PK_CategoryTbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ComercialAllottments'
ALTER TABLE [dbo].[ComercialAllottments]
ADD CONSTRAINT [PK_ComercialAllottments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ComplaintTbs'
ALTER TABLE [dbo].[ComplaintTbs]
ADD CONSTRAINT [PK_ComplaintTbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Contractors'
ALTER TABLE [dbo].[Contractors]
ADD CONSTRAINT [PK_Contractors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContractorTbs'
ALTER TABLE [dbo].[ContractorTbs]
ADD CONSTRAINT [PK_ContractorTbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'dbFiles'
ALTER TABLE [dbo].[dbFiles]
ADD CONSTRAINT [PK_dbFiles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Documents'
ALTER TABLE [dbo].[Documents]
ADD CONSTRAINT [PK_Documents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmployeeSalaries'
ALTER TABLE [dbo].[EmployeeSalaries]
ADD CONSTRAINT [PK_EmployeeSalaries]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmployeesAttendances'
ALTER TABLE [dbo].[EmployeesAttendances]
ADD CONSTRAINT [PK_EmployeesAttendances]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Expenses'
ALTER TABLE [dbo].[Expenses]
ADD CONSTRAINT [PK_Expenses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FamilytreeTBs'
ALTER TABLE [dbo].[FamilytreeTBs]
ADD CONSTRAINT [PK_FamilytreeTBs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Fines'
ALTER TABLE [dbo].[Fines]
ADD CONSTRAINT [PK_Fines]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Houses'
ALTER TABLE [dbo].[Houses]
ADD CONSTRAINT [PK_Houses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HouseBills'
ALTER TABLE [dbo].[HouseBills]
ADD CONSTRAINT [PK_HouseBills]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ImagesPaths'
ALTER TABLE [dbo].[ImagesPaths]
ADD CONSTRAINT [PK_ImagesPaths]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InvTransferTbs'
ALTER TABLE [dbo].[InvTransferTbs]
ADD CONSTRAINT [PK_InvTransferTbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IssueDetailTbs'
ALTER TABLE [dbo].[IssueDetailTbs]
ADD CONSTRAINT [PK_IssueDetailTbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ItemsDeffs'
ALTER TABLE [dbo].[ItemsDeffs]
ADD CONSTRAINT [PK_ItemsDeffs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MarketTbs'
ALTER TABLE [dbo].[MarketTbs]
ADD CONSTRAINT [PK_MarketTbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [PK_Payments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PaymentDetails'
ALTER TABLE [dbo].[PaymentDetails]
ADD CONSTRAINT [PK_PaymentDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pets'
ALTER TABLE [dbo].[Pets]
ADD CONSTRAINT [PK_Pets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProgressTbs'
ALTER TABLE [dbo].[ProgressTbs]
ADD CONSTRAINT [PK_ProgressTbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectAssignedTbs'
ALTER TABLE [dbo].[ProjectAssignedTbs]
ADD CONSTRAINT [PK_ProjectAssignedTbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectMeterialIssuTbs'
ALTER TABLE [dbo].[ProjectMeterialIssuTbs]
ADD CONSTRAINT [PK_ProjectMeterialIssuTbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectTbs'
ALTER TABLE [dbo].[ProjectTbs]
ADD CONSTRAINT [PK_ProjectTbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectTbNews'
ALTER TABLE [dbo].[ProjectTbNews]
ADD CONSTRAINT [PK_ProjectTbNews]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectTypeTbs'
ALTER TABLE [dbo].[ProjectTypeTbs]
ADD CONSTRAINT [PK_ProjectTypeTbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PurchaseDetails'
ALTER TABLE [dbo].[PurchaseDetails]
ADD CONSTRAINT [PK_PurchaseDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Purchasers'
ALTER TABLE [dbo].[Purchasers]
ADD CONSTRAINT [PK_Purchasers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PurchaseTbs'
ALTER TABLE [dbo].[PurchaseTbs]
ADD CONSTRAINT [PK_PurchaseTbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RACs'
ALTER TABLE [dbo].[RACs]
ADD CONSTRAINT [PK_RACs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RarReceiptTbs'
ALTER TABLE [dbo].[RarReceiptTbs]
ADD CONSTRAINT [PK_RarReceiptTbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RarTbs'
ALTER TABLE [dbo].[RarTbs]
ADD CONSTRAINT [PK_RarTbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ReceiptApprovedTbs'
ALTER TABLE [dbo].[ReceiptApprovedTbs]
ADD CONSTRAINT [PK_ReceiptApprovedTbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'RenteePaymentTbs'
ALTER TABLE [dbo].[RenteePaymentTbs]
ADD CONSTRAINT [PK_RenteePaymentTbs]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'Residents'
ALTER TABLE [dbo].[Residents]
ADD CONSTRAINT [PK_Residents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ResidentsInfoes'
ALTER TABLE [dbo].[ResidentsInfoes]
ADD CONSTRAINT [PK_ResidentsInfoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ResidentTbs'
ALTER TABLE [dbo].[ResidentTbs]
ADD CONSTRAINT [PK_ResidentTbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Servants'
ALTER TABLE [dbo].[Servants]
ADD CONSTRAINT [PK_Servants]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ShopCurrentTbs'
ALTER TABLE [dbo].[ShopCurrentTbs]
ADD CONSTRAINT [PK_ShopCurrentTbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ShopsRents'
ALTER TABLE [dbo].[ShopsRents]
ADD CONSTRAINT [PK_ShopsRents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ShopsTbs'
ALTER TABLE [dbo].[ShopsTbs]
ADD CONSTRAINT [PK_ShopsTbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Suppliers'
ALTER TABLE [dbo].[Suppliers]
ADD CONSTRAINT [PK_Suppliers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tenants'
ALTER TABLE [dbo].[Tenants]
ADD CONSTRAINT [PK_Tenants]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UOMTbs'
ALTER TABLE [dbo].[UOMTbs]
ADD CONSTRAINT [PK_UOMTbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'vaccinTbs'
ALTER TABLE [dbo].[vaccinTbs]
ADD CONSTRAINT [PK_vaccinTbs]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [PK_Vehicles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VehicleTbs'
ALTER TABLE [dbo].[VehicleTbs]
ADD CONSTRAINT [PK_VehicleTbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VisiterTbs'
ALTER TABLE [dbo].[VisiterTbs]
ADD CONSTRAINT [PK_VisiterTbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Visitors'
ALTER TABLE [dbo].[Visitors]
ADD CONSTRAINT [PK_Visitors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'YardSticks'
ALTER TABLE [dbo].[YardSticks]
ADD CONSTRAINT [PK_YardSticks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ColorTbs'
ALTER TABLE [dbo].[ColorTbs]
ADD CONSTRAINT [PK_ColorTbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'Accesses'
ALTER TABLE [dbo].[Accesses]
ADD CONSTRAINT [FK_Access_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Access_Users'
CREATE INDEX [IX_FK_Access_Users]
ON [dbo].[Accesses]
    ([UserId]);
GO

-- Creating foreign key on [EmpId] in table 'Advances'
ALTER TABLE [dbo].[Advances]
ADD CONSTRAINT [FK_Advance_Employees]
    FOREIGN KEY ([EmpId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Advance_Employees'
CREATE INDEX [IX_FK_Advance_Employees]
ON [dbo].[Advances]
    ([EmpId]);
GO

-- Creating foreign key on [EmpId] in table 'AdvanceReturns'
ALTER TABLE [dbo].[AdvanceReturns]
ADD CONSTRAINT [FK_AdvanceReturn_Employees]
    FOREIGN KEY ([EmpId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdvanceReturn_Employees'
CREATE INDEX [IX_FK_AdvanceReturn_Employees]
ON [dbo].[AdvanceReturns]
    ([EmpId]);
GO

-- Creating foreign key on [HouseId] in table 'Allottees'
ALTER TABLE [dbo].[Allottees]
ADD CONSTRAINT [FK_Allottee_House]
    FOREIGN KEY ([HouseId])
    REFERENCES [dbo].[Houses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Allottee_House'
CREATE INDEX [IX_FK_Allottee_House]
ON [dbo].[Allottees]
    ([HouseId]);
GO

-- Creating foreign key on [Catid] in table 'ItemsDeffs'
ALTER TABLE [dbo].[ItemsDeffs]
ADD CONSTRAINT [FK_ItemsDeff_CategoryTb]
    FOREIGN KEY ([Catid])
    REFERENCES [dbo].[CategoryTbs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemsDeff_CategoryTb'
CREATE INDEX [IX_FK_ItemsDeff_CategoryTb]
ON [dbo].[ItemsDeffs]
    ([Catid]);
GO

-- Creating foreign key on [marketid] in table 'ComercialAllottments'
ALTER TABLE [dbo].[ComercialAllottments]
ADD CONSTRAINT [FK_ComercialAllottment_MarketTb]
    FOREIGN KEY ([marketid])
    REFERENCES [dbo].[MarketTbs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComercialAllottment_MarketTb'
CREATE INDEX [IX_FK_ComercialAllottment_MarketTb]
ON [dbo].[ComercialAllottments]
    ([marketid]);
GO

-- Creating foreign key on [ctorid] in table 'ProjectAssignedTbs'
ALTER TABLE [dbo].[ProjectAssignedTbs]
ADD CONSTRAINT [FK_ProjectAssignedTb_ContractorTb]
    FOREIGN KEY ([ctorid])
    REFERENCES [dbo].[ContractorTbs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectAssignedTb_ContractorTb'
CREATE INDEX [IX_FK_ProjectAssignedTb_ContractorTb]
ON [dbo].[ProjectAssignedTbs]
    ([ctorid]);
GO

-- Creating foreign key on [ResId] in table 'Documents'
ALTER TABLE [dbo].[Documents]
ADD CONSTRAINT [FK_Documents_Residents]
    FOREIGN KEY ([ResId])
    REFERENCES [dbo].[Residents]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Documents_Residents'
CREATE INDEX [IX_FK_Documents_Residents]
ON [dbo].[Documents]
    ([ResId]);
GO

-- Creating foreign key on [EmpId] in table 'EmployeeSalaries'
ALTER TABLE [dbo].[EmployeeSalaries]
ADD CONSTRAINT [FK_EmployeeSalary_Employees]
    FOREIGN KEY ([EmpId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeSalary_Employees'
CREATE INDEX [IX_FK_EmployeeSalary_Employees]
ON [dbo].[EmployeeSalaries]
    ([EmpId]);
GO

-- Creating foreign key on [EmpId] in table 'EmployeesAttendances'
ALTER TABLE [dbo].[EmployeesAttendances]
ADD CONSTRAINT [FK_EmployeesAttendance_EmployeesAttendance]
    FOREIGN KEY ([EmpId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeesAttendance_EmployeesAttendance'
CREATE INDEX [IX_FK_EmployeesAttendance_EmployeesAttendance]
ON [dbo].[EmployeesAttendances]
    ([EmpId]);
GO

-- Creating foreign key on [ExpenseId] in table 'HouseBills'
ALTER TABLE [dbo].[HouseBills]
ADD CONSTRAINT [FK_HouseBills_Expenses]
    FOREIGN KEY ([ExpenseId])
    REFERENCES [dbo].[Expenses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HouseBills_Expenses'
CREATE INDEX [IX_FK_HouseBills_Expenses]
ON [dbo].[HouseBills]
    ([ExpenseId]);
GO

-- Creating foreign key on [HouseId] in table 'HouseBills'
ALTER TABLE [dbo].[HouseBills]
ADD CONSTRAINT [FK_HouseBills_HouseBills]
    FOREIGN KEY ([HouseId])
    REFERENCES [dbo].[Houses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HouseBills_HouseBills'
CREATE INDEX [IX_FK_HouseBills_HouseBills]
ON [dbo].[HouseBills]
    ([HouseId]);
GO

-- Creating foreign key on [HouseId] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [FK_Payment_Payment]
    FOREIGN KEY ([HouseId])
    REFERENCES [dbo].[Houses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Payment_Payment'
CREATE INDEX [IX_FK_Payment_Payment]
ON [dbo].[Payments]
    ([HouseId]);
GO

-- Creating foreign key on [HouseId] in table 'Purchasers'
ALTER TABLE [dbo].[Purchasers]
ADD CONSTRAINT [FK_Purchaser_House]
    FOREIGN KEY ([HouseId])
    REFERENCES [dbo].[Houses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Purchaser_House'
CREATE INDEX [IX_FK_Purchaser_House]
ON [dbo].[Purchasers]
    ([HouseId]);
GO

-- Creating foreign key on [HouseId] in table 'Residents'
ALTER TABLE [dbo].[Residents]
ADD CONSTRAINT [FK_Residents_Residents]
    FOREIGN KEY ([HouseId])
    REFERENCES [dbo].[Houses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Residents_Residents'
CREATE INDEX [IX_FK_Residents_Residents]
ON [dbo].[Residents]
    ([HouseId]);
GO

-- Creating foreign key on [houseid] in table 'ResidentTbs'
ALTER TABLE [dbo].[ResidentTbs]
ADD CONSTRAINT [FK_ResidentTb_House]
    FOREIGN KEY ([houseid])
    REFERENCES [dbo].[Houses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ResidentTb_House'
CREATE INDEX [IX_FK_ResidentTb_House]
ON [dbo].[ResidentTbs]
    ([houseid]);
GO

-- Creating foreign key on [HouseId] in table 'Tenants'
ALTER TABLE [dbo].[Tenants]
ADD CONSTRAINT [FK_Tenant_House]
    FOREIGN KEY ([HouseId])
    REFERENCES [dbo].[Houses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tenant_House'
CREATE INDEX [IX_FK_Tenant_House]
ON [dbo].[Tenants]
    ([HouseId]);
GO

-- Creating foreign key on [Issueid] in table 'IssueDetailTbs'
ALTER TABLE [dbo].[IssueDetailTbs]
ADD CONSTRAINT [FK_IssueDetailTb_ProjectMeterialIssuTb]
    FOREIGN KEY ([Issueid])
    REFERENCES [dbo].[ProjectMeterialIssuTbs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IssueDetailTb_ProjectMeterialIssuTb'
CREATE INDEX [IX_FK_IssueDetailTb_ProjectMeterialIssuTb]
ON [dbo].[IssueDetailTbs]
    ([Issueid]);
GO

-- Creating foreign key on [marketid] in table 'ShopsTbs'
ALTER TABLE [dbo].[ShopsTbs]
ADD CONSTRAINT [FK_ShopsTb_MarketTb]
    FOREIGN KEY ([marketid])
    REFERENCES [dbo].[MarketTbs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShopsTb_MarketTb'
CREATE INDEX [IX_FK_ShopsTb_MarketTb]
ON [dbo].[ShopsTbs]
    ([marketid]);
GO

-- Creating foreign key on [PayId] in table 'PaymentDetails'
ALTER TABLE [dbo].[PaymentDetails]
ADD CONSTRAINT [FK_PaymentDetails_PaymentDetails]
    FOREIGN KEY ([PayId])
    REFERENCES [dbo].[Payments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentDetails_PaymentDetails'
CREATE INDEX [IX_FK_PaymentDetails_PaymentDetails]
ON [dbo].[PaymentDetails]
    ([PayId]);
GO

-- Creating foreign key on [passinid] in table 'ProgressTbs'
ALTER TABLE [dbo].[ProgressTbs]
ADD CONSTRAINT [FK_ProgressTb_ProjectAssignedTb]
    FOREIGN KEY ([passinid])
    REFERENCES [dbo].[ProjectAssignedTbs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProgressTb_ProjectAssignedTb'
CREATE INDEX [IX_FK_ProgressTb_ProjectAssignedTb]
ON [dbo].[ProgressTbs]
    ([passinid]);
GO

-- Creating foreign key on [stickid] in table 'ProgressTbs'
ALTER TABLE [dbo].[ProgressTbs]
ADD CONSTRAINT [FK_ProgressTb_YardStick]
    FOREIGN KEY ([stickid])
    REFERENCES [dbo].[YardSticks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProgressTb_YardStick'
CREATE INDEX [IX_FK_ProgressTb_YardStick]
ON [dbo].[ProgressTbs]
    ([stickid]);
GO

-- Creating foreign key on [Pid] in table 'ProjectAssignedTbs'
ALTER TABLE [dbo].[ProjectAssignedTbs]
ADD CONSTRAINT [FK_ProjectAssignedTb_ProjectTbNew]
    FOREIGN KEY ([Pid])
    REFERENCES [dbo].[ProjectTbNews]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectAssignedTb_ProjectTbNew'
CREATE INDEX [IX_FK_ProjectAssignedTb_ProjectTbNew]
ON [dbo].[ProjectAssignedTbs]
    ([Pid]);
GO

-- Creating foreign key on [pasind] in table 'RarTbs'
ALTER TABLE [dbo].[RarTbs]
ADD CONSTRAINT [FK_RarTb_ProjectAssignedTb]
    FOREIGN KEY ([pasind])
    REFERENCES [dbo].[ProjectAssignedTbs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RarTb_ProjectAssignedTb'
CREATE INDEX [IX_FK_RarTb_ProjectAssignedTb]
ON [dbo].[RarTbs]
    ([pasind]);
GO

-- Creating foreign key on [ptypeid] in table 'ProjectTbNews'
ALTER TABLE [dbo].[ProjectTbNews]
ADD CONSTRAINT [FK_ProjectTbNew_ProjectTypeTb]
    FOREIGN KEY ([ptypeid])
    REFERENCES [dbo].[ProjectTypeTbs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectTbNew_ProjectTypeTb'
CREATE INDEX [IX_FK_ProjectTbNew_ProjectTypeTb]
ON [dbo].[ProjectTbNews]
    ([ptypeid]);
GO

-- Creating foreign key on [puid] in table 'PurchaseDetails'
ALTER TABLE [dbo].[PurchaseDetails]
ADD CONSTRAINT [FK_PurchaseDetail_PurchaseTb]
    FOREIGN KEY ([puid])
    REFERENCES [dbo].[PurchaseTbs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchaseDetail_PurchaseTb'
CREATE INDEX [IX_FK_PurchaseDetail_PurchaseTb]
ON [dbo].[PurchaseDetails]
    ([puid]);
GO

-- Creating foreign key on [rarid] in table 'RarReceiptTbs'
ALTER TABLE [dbo].[RarReceiptTbs]
ADD CONSTRAINT [FK_RarReceiptTb_RarTb]
    FOREIGN KEY ([rarid])
    REFERENCES [dbo].[RarTbs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RarReceiptTb_RarTb'
CREATE INDEX [IX_FK_RarReceiptTb_RarTb]
ON [dbo].[RarReceiptTbs]
    ([rarid]);
GO

-- Creating foreign key on [renteeid] in table 'RenteePaymentTbs'
ALTER TABLE [dbo].[RenteePaymentTbs]
ADD CONSTRAINT [FK_RenteePaymentTb_ShopCurrentTb]
    FOREIGN KEY ([renteeid])
    REFERENCES [dbo].[ShopCurrentTbs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RenteePaymentTb_ShopCurrentTb'
CREATE INDEX [IX_FK_RenteePaymentTb_ShopCurrentTb]
ON [dbo].[RenteePaymentTbs]
    ([renteeid]);
GO

-- Creating foreign key on [shopid] in table 'RenteePaymentTbs'
ALTER TABLE [dbo].[RenteePaymentTbs]
ADD CONSTRAINT [FK_RenteePaymentTb_ShopsTb]
    FOREIGN KEY ([shopid])
    REFERENCES [dbo].[ShopsTbs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RenteePaymentTb_ShopsTb'
CREATE INDEX [IX_FK_RenteePaymentTb_ShopsTb]
ON [dbo].[RenteePaymentTbs]
    ([shopid]);
GO

-- Creating foreign key on [tenantid] in table 'Residents'
ALTER TABLE [dbo].[Residents]
ADD CONSTRAINT [FK_Residents_Tenant]
    FOREIGN KEY ([tenantid])
    REFERENCES [dbo].[Tenants]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Residents_Tenant'
CREATE INDEX [IX_FK_Residents_Tenant]
ON [dbo].[Residents]
    ([tenantid]);
GO

-- Creating foreign key on [ResId] in table 'ResidentsInfoes'
ALTER TABLE [dbo].[ResidentsInfoes]
ADD CONSTRAINT [FK_ResidentsInfo_Residents]
    FOREIGN KEY ([ResId])
    REFERENCES [dbo].[Residents]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ResidentsInfo_Residents'
CREATE INDEX [IX_FK_ResidentsInfo_Residents]
ON [dbo].[ResidentsInfoes]
    ([ResId]);
GO

-- Creating foreign key on [ResId] in table 'Servants'
ALTER TABLE [dbo].[Servants]
ADD CONSTRAINT [FK_Servant_Residents]
    FOREIGN KEY ([ResId])
    REFERENCES [dbo].[Residents]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Servant_Residents'
CREATE INDEX [IX_FK_Servant_Residents]
ON [dbo].[Servants]
    ([ResId]);
GO

-- Creating foreign key on [ResId] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [FK_Vehicles_Vehicles]
    FOREIGN KEY ([ResId])
    REFERENCES [dbo].[Residents]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Vehicles_Vehicles'
CREATE INDEX [IX_FK_Vehicles_Vehicles]
ON [dbo].[Vehicles]
    ([ResId]);
GO

-- Creating foreign key on [shopid] in table 'ShopCurrentTbs'
ALTER TABLE [dbo].[ShopCurrentTbs]
ADD CONSTRAINT [FK_ShopCurrentTb_ShopsTb]
    FOREIGN KEY ([shopid])
    REFERENCES [dbo].[ShopsTbs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShopCurrentTb_ShopsTb'
CREATE INDEX [IX_FK_ShopCurrentTb_ShopsTb]
ON [dbo].[ShopCurrentTbs]
    ([shopid]);
GO

-- Creating foreign key on [shopid] in table 'ShopsRents'
ALTER TABLE [dbo].[ShopsRents]
ADD CONSTRAINT [FK_ShopsRent_ShopsTb]
    FOREIGN KEY ([shopid])
    REFERENCES [dbo].[ShopsTbs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShopsRent_ShopsTb'
CREATE INDEX [IX_FK_ShopsRent_ShopsTb]
ON [dbo].[ShopsRents]
    ([shopid]);
GO

-- Creating foreign key on [ShopsTb_Id] in table 'Servants'
ALTER TABLE [dbo].[Servants]
ADD CONSTRAINT [FK_ServantShopsTb]
    FOREIGN KEY ([ShopsTb_Id])
    REFERENCES [dbo].[ShopsTbs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServantShopsTb'
CREATE INDEX [IX_FK_ServantShopsTb]
ON [dbo].[Servants]
    ([ShopsTb_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------