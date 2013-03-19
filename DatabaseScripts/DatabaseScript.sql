
USE master
GO

--********************************--
--******* Create Databases *******--
--********************************--


IF EXISTS (SELECT name FROM sys.databases WHERE name = N'PSS2012')
BEGIN
	DROP DATABASE [PSS2012]
END
GO
CREATE DATABASE [PSS2012]
GO


--*****************************--
--******* Create Tables *******--
--*****************************--


USE [PSS2012]
GO
CREATE TABLE [dbo].[CityStateZip](
	[CityStateZipGuid] [uniqueidentifier] ROWGUIDCOL NOT NULL CONSTRAINT [DF_CityStateZip_CityStateZipGuid]  DEFAULT (newid())
	,[City] [varchar](50) NOT NULL
	,[State] [varchar](50) NOT NULL
	,[ZipCode] [char](5) NOT NULL
) ON [PRIMARY]
GO

USE [PSS2012]
GO
CREATE TABLE [dbo].[Click](
	[ClickGuid] [uniqueidentifier] ROWGUIDCOL NOT NULL CONSTRAINT [DF_Click_ClickGuid]  DEFAULT (newid())
	,[FacilityGuid] [uniqueidentifier] NOT NULL
	,[ListingTypeGuid] [uniqueidentifier] NOT NULL
	,[TimeStamp] [datetime] NOT NULL CONSTRAINT [DF_Click_TimeStamp]  DEFAULT (getdate())
) ON [PRIMARY]
GO

USE [PSS2012]
GO
CREATE TABLE [dbo].[Client](
	[ClientGuid] [uniqueidentifier] ROWGUIDCOL NOT NULL CONSTRAINT [DF_Client_ClientGuid]  DEFAULT (newid())
	,[ClientID] [int] IDENTITY(1,1) NOT NULL
	,[ClientName] [varchar](100) NOT NULL
	,[PhoneNumber] [char](10) NOT NULL
	,[Email] [varchar](100) NOT NULL
	,[Address] [varchar](100) NOT NULL
	,[CityStateZipGuid] [uniqueidentifier] NOT NULL
	,[PaymentInfoGuid] [uniqueidentifier] NOT NULL
	,[FederatedID] [varchar](100) NULL
	,[FederatedKey] [varchar](400) NULL
	,[FederatedIDProvider] [varchar](50) NULL
	,[Username] [varchar](50) NULL
	,[HashedPassword] [varchar](200) NULL
) ON [PRIMARY]
GO

USE [PSS2012]
GO
CREATE TABLE [dbo].[ClientAudit](
	[ClientAuditGuid] [uniqueidentifier] ROWGUIDCOL NOT NULL CONSTRAINT [DF_ClientAudit_ClientAuditGuid]  DEFAULT (newid())
	,[ClientGuid] [uniqueidentifier] NOT NULL
	,[ClientID] [int] NOT NULL
	,[ClientName] [varchar](100) NOT NULL
	,[PhoneNumber] [char](10) NOT NULL
	,[Email] [varchar](100) NOT NULL
	,[Address] [varchar](100) NOT NULL
	,[CityStateZipGuid] [uniqueidentifier] NOT NULL
	,[PaymentInfoGuid] [uniqueidentifier] NOT NULL
	,[FederatedID] [varchar](100) NULL
	,[FederatedKey] [varchar](400) NULL
	,[FederatedIDProvider] [varchar](50) NULL
	,[Username] [varchar](50) NULL
	,[HashedPassword] [varchar](200) NULL
	,[DateModified] [datetime] NOT NULL CONSTRAINT [DF_ClientAudit_DateModified]  DEFAULT (getdate())
) ON [PRIMARY]
GO

USE [PSS2012]
GO
CREATE TABLE [dbo].[Facility](
	[FacilityGuid] [uniqueidentifier] ROWGUIDCOL NOT NULL CONSTRAINT [DF_Facility_FacilityGuid]  DEFAULT (newid())
	,[FacilityID] [int] IDENTITY(1,1) NOT NULL
	,[FacilityName] [varchar](50) NOT NULL
	,[Exerpt] [varchar](200) NOT NULL
	,[Description] [varchar](500) NOT NULL
	,[Address] [varchar](100) NOT NULL
	,[CityStateZipGuid] [uniqueidentifier] NOT NULL
	,[PhoneNumber] [char](10) NOT NULL
	,[Email] [varchar](100) NOT NULL
	,[Website] [varchar](100) NOT NULL
	,[ClientGuid] [uniqueidentifier] NOT NULL
	,[ListingTypeGuid] [uniqueidentifier] NOT NULL
	,[PublicPhotoFileUri] [varchar](100) NOT NULL
) ON [PRIMARY]
GO

USE [PSS2012]
GO
CREATE TABLE [dbo].[FacilityAudit](
	[FacilityAuditGuid] [uniqueidentifier] ROWGUIDCOL NOT NULL CONSTRAINT [DF_FacilityAudit_FacilityAuditGuid]  DEFAULT (newid())
	,[FacilityGuid] [uniqueidentifier] NOT NULL
	,[FacilityID] [int] NOT NULL
	,[FacilityName] [varchar](50) NOT NULL
	,[Exerpt] [varchar](200) NOT NULL
	,[Description] [varchar](500) NOT NULL
	,[Address] [varchar](100) NOT NULL
	,[CityStateZipGuid] [uniqueidentifier] NOT NULL
	,[PhoneNumber] [char](10) NOT NULL
	,[Email] [varchar](100) NOT NULL
	,[Website] [varchar](100) NOT NULL
	,[ClientGuid] [uniqueidentifier] NOT NULL
	,[ListingTypeGuid] [uniqueidentifier] NOT NULL
	,[PublicPhotoFileUri] [varchar](100) NOT NULL
	,[DateModified] [datetime] NOT NULL CONSTRAINT [DF_FacilityAudit_DateModified]  DEFAULT (getdate())
) ON [PRIMARY]
GO

USE [PSS2012]
GO
CREATE TABLE [dbo].[FacilityLocationCriteria](
	[FacilityGuid] [uniqueidentifier] NOT NULL
	,[CityStateZipGuid] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO

USE [PSS2012]
GO
CREATE TABLE [dbo].[FacilityOffering](
	[FacilityGuid] [uniqueidentifier] NOT NULL
	,[OfferingGuid] [uniqueidentifier] NOT NULL
	,[IsChecked] [bit] NOT NULL
) ON [PRIMARY]
GO

USE [PSS2012]
GO
CREATE TABLE [dbo].[ListingType](
	[ListingTypeGuid] [uniqueidentifier] ROWGUIDCOL NOT NULL CONSTRAINT [DF_ListingType_ListingTypeGuid]  DEFAULT (newid())
	,[ListingTypeName] [varchar](50) NOT NULL
) ON [PRIMARY]
GO

USE [PSS2012]
GO
CREATE TABLE [dbo].[Offering](
	[OfferingGuid] [uniqueidentifier] ROWGUIDCOL NOT NULL CONSTRAINT [DF_Offering_OfferingGuid]  DEFAULT (newid())
	,[OfferingID] [int] IDENTITY(1,1) NOT NULL
	,[OfferingName] [varchar](50) NOT NULL
) ON [PRIMARY]
GO

USE [PSS2012]
GO
CREATE TABLE [dbo].[PaymentInfo](
	[PaymentInfoGuid] [uniqueidentifier] ROWGUIDCOL NOT NULL CONSTRAINT [DF_PaymentInfo_PaymentInfoGuid]  DEFAULT (newid())
	,[PaymentInfoID] [int] IDENTITY(1,1) NOT NULL
	,[AmazonToken] [varchar](100) NOT NULL
) ON [PRIMARY]
GO

USE [PSS2012]
GO
CREATE TABLE [dbo].[PaymentInfoAudit](
	[PaymentInfoAuditGuid] [uniqueidentifier] ROWGUIDCOL NOT NULL CONSTRAINT [DF_PaymentInfoAudit_PaymentInfoAuditGuid]  DEFAULT (newid())
	,[PaymentInfoGuid] [uniqueidentifier] NOT NULL
	,[PaymentInfoID] [int] NOT NULL
	,[AmazonToken] [varchar](100) NOT NULL
	,[DateModified] [datetime] NOT NULL
) ON [PRIMARY]
GO

USE [PSS2012]
GO
CREATE TABLE [dbo].[FacilityPhoto](
	[FacilityPhotoGuid] [uniqueidentifier] ROWGUIDCOL NOT NULL CONSTRAINT [DF_FacilityPhoto_FacilityPhotoGuid]  DEFAULT (newid())
	,[PhotoUri] [varchar](200) NOT NULL
	,[FacilityGuid] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO



--*******************************************--
--******* Add Primary Key constraints *******--
--*******************************************--


ALTER TABLE [dbo].[CityStateZip] WITH NOCHECK ADD
	CONSTRAINT [PK_CityStateZip] PRIMARY KEY CLUSTERED
	(
		[CityStateZipGuid] ASC
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Click] WITH NOCHECK ADD
	CONSTRAINT [PK_Click] PRIMARY KEY CLUSTERED
	(
		[ClickGuid] ASC
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Client] WITH NOCHECK ADD
	CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED
	(
		[ClientGuid] ASC
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ClientAudit] WITH NOCHECK ADD
	CONSTRAINT [PK_ClientAudit] PRIMARY KEY CLUSTERED
	(
		[ClientAuditGuid] ASC
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Facility] WITH NOCHECK ADD
	CONSTRAINT [PK_Facility] PRIMARY KEY CLUSTERED
	(
		[FacilityGuid] ASC
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FacilityAudit] WITH NOCHECK ADD
	CONSTRAINT [PK_FacilityAudit] PRIMARY KEY CLUSTERED
	(
		[FacilityAuditGuid] ASC
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FacilityLocationCriteria] WITH NOCHECK ADD
	CONSTRAINT [PK_FacilityLocationCriteria] PRIMARY KEY CLUSTERED
	(
		[FacilityGuid] ASC
		,[CityStateZipGuid] ASC
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FacilityOffering] WITH NOCHECK ADD
	CONSTRAINT [PK_FacilityOffering] PRIMARY KEY CLUSTERED
	(
		[FacilityGuid] ASC
		,[OfferingGuid] ASC
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ListingType] WITH NOCHECK ADD
	CONSTRAINT [PK_ListingType] PRIMARY KEY CLUSTERED
	(
		[ListingTypeGuid] ASC
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Offering] WITH NOCHECK ADD
	CONSTRAINT [PK_Offering] PRIMARY KEY CLUSTERED
	(
		[OfferingGuid] ASC
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PaymentInfo] WITH NOCHECK ADD
	CONSTRAINT [PK_PaymentInfo] PRIMARY KEY CLUSTERED
	(
		[PaymentInfoGuid] ASC
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PaymentInfoAudit] WITH NOCHECK ADD
	CONSTRAINT [PK_PaymentInfoAudit] PRIMARY KEY CLUSTERED
	(
		[PaymentInfoAuditGuid] ASC
	) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FacilityPhoto] WITH NOCHECK ADD
	CONSTRAINT [PK_FacilityPhoto] PRIMARY KEY CLUSTERED
	(
		[FacilityPhotoGuid] ASC
	) ON [PRIMARY]
GO


--************************************--
--******* Add join constraints *******--
--************************************--

BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT


-- ManyToOne join from Click to Facility --
USE [PSS2012]
BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[Click] ADD CONSTRAINT [FK_Click_Facility]
	FOREIGN KEY ( [FacilityGuid] )
	REFERENCES [dbo].[Facility] ( [FacilityGuid] )
	ON UPDATE  NO ACTION
	ON DELETE  NO ACTION
GO
COMMIT

-- ManyToOne join from Click to ListingType --
USE [PSS2012]
BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[Click] ADD CONSTRAINT [FK_Click_ListingType]
	FOREIGN KEY ( [ListingTypeGuid] )
	REFERENCES [dbo].[ListingType] ( [ListingTypeGuid] )
	ON UPDATE  NO ACTION
	ON DELETE  NO ACTION
GO
COMMIT

-- ManyToOne join from Client to CityStateZip --
USE [PSS2012]
BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[Client] ADD CONSTRAINT [FK_Client_CityStateZip]
	FOREIGN KEY ( [CityStateZipGuid] )
	REFERENCES [dbo].[CityStateZip] ( [CityStateZipGuid] )
	ON UPDATE  NO ACTION
	ON DELETE  NO ACTION
GO
COMMIT

-- ManyToOne join from Client to PaymentInfo --
USE [PSS2012]
BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[Client] ADD CONSTRAINT [FK_Client_PaymentInfo]
	FOREIGN KEY ( [PaymentInfoGuid] )
	REFERENCES [dbo].[PaymentInfo] ( [PaymentInfoGuid] )
	ON UPDATE  NO ACTION
	ON DELETE  NO ACTION
GO
COMMIT

-- ManyToOne join from ClientAudit to Client --
USE [PSS2012]
BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[ClientAudit] ADD CONSTRAINT [FK_ClientAudit_Client]
	FOREIGN KEY ( [ClientGuid] )
	REFERENCES [dbo].[Client] ( [ClientGuid] )
	ON UPDATE  NO ACTION
	ON DELETE  NO ACTION
GO
COMMIT

-- ManyToOne join from ClientAudit to CityStateZip --
USE [PSS2012]
BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[ClientAudit] ADD CONSTRAINT [FK_ClientAudit_CityStateZip]
	FOREIGN KEY ( [CityStateZipGuid] )
	REFERENCES [dbo].[CityStateZip] ( [CityStateZipGuid] )
	ON UPDATE  NO ACTION
	ON DELETE  NO ACTION
GO
COMMIT

-- ManyToOne join from ClientAudit to PaymentInfo --
USE [PSS2012]
BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[ClientAudit] ADD CONSTRAINT [FK_ClientAudit_PaymentInfo]
	FOREIGN KEY ( [PaymentInfoGuid] )
	REFERENCES [dbo].[PaymentInfo] ( [PaymentInfoGuid] )
	ON UPDATE  NO ACTION
	ON DELETE  NO ACTION
GO
COMMIT

-- ManyToOne join from Facility to CityStateZip --
USE [PSS2012]
BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[Facility] ADD CONSTRAINT [FK_Facility_CityStateZip]
	FOREIGN KEY ( [CityStateZipGuid] )
	REFERENCES [dbo].[CityStateZip] ( [CityStateZipGuid] )
	ON UPDATE  NO ACTION
	ON DELETE  NO ACTION
GO
COMMIT

-- ManyToOne join from Facility to Client --
USE [PSS2012]
BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[Facility] ADD CONSTRAINT [FK_Facility_Client]
	FOREIGN KEY ( [ClientGuid] )
	REFERENCES [dbo].[Client] ( [ClientGuid] )
	ON UPDATE  NO ACTION
	ON DELETE  NO ACTION
GO
COMMIT

-- ManyToOne join from Facility to ListingType --
USE [PSS2012]
BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[Facility] ADD CONSTRAINT [FK_Facility_ListingType]
	FOREIGN KEY ( [ListingTypeGuid] )
	REFERENCES [dbo].[ListingType] ( [ListingTypeGuid] )
	ON UPDATE  NO ACTION
	ON DELETE  NO ACTION
GO
COMMIT

-- ManyToOne join from FacilityAudit to Facility --
USE [PSS2012]
BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[FacilityAudit] ADD CONSTRAINT [FK_FacilityAudit_Facility]
	FOREIGN KEY ( [FacilityGuid] )
	REFERENCES [dbo].[Facility] ( [FacilityGuid] )
	ON UPDATE  NO ACTION
	ON DELETE  NO ACTION
GO
COMMIT

-- ManyToOne join from FacilityAudit to CityStateZip --
USE [PSS2012]
BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[FacilityAudit] ADD CONSTRAINT [FK_FacilityAudit_CityStateZip]
	FOREIGN KEY ( [CityStateZipGuid] )
	REFERENCES [dbo].[CityStateZip] ( [CityStateZipGuid] )
	ON UPDATE  NO ACTION
	ON DELETE  NO ACTION
GO
COMMIT

-- ManyToOne join from FacilityAudit to Client --
USE [PSS2012]
BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[FacilityAudit] ADD CONSTRAINT [FK_FacilityAudit_Client]
	FOREIGN KEY ( [ClientGuid] )
	REFERENCES [dbo].[Client] ( [ClientGuid] )
	ON UPDATE  NO ACTION
	ON DELETE  NO ACTION
GO
COMMIT

-- ManyToOne join from FacilityAudit to ListingType --
USE [PSS2012]
BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[FacilityAudit] ADD CONSTRAINT [FK_FacilityAudit_ListingType]
	FOREIGN KEY ( [ListingTypeGuid] )
	REFERENCES [dbo].[ListingType] ( [ListingTypeGuid] )
	ON UPDATE  NO ACTION
	ON DELETE  NO ACTION
GO
COMMIT

-- ManyToOne join from PaymentInfoAudit to PaymentInfo --
USE [PSS2012]
BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[PaymentInfoAudit] ADD CONSTRAINT [FK_PaymentInfoAudit_PaymentInfo]
	FOREIGN KEY ( [PaymentInfoGuid] )
	REFERENCES [dbo].[PaymentInfo] ( [PaymentInfoGuid] )
	ON UPDATE  NO ACTION
	ON DELETE  NO ACTION
GO
COMMIT

-- ManyToOne join from FacilityPhoto to Facility --
USE [PSS2012]
BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[FacilityPhoto] ADD CONSTRAINT [FK_FacilityPhoto_Facility]
	FOREIGN KEY ( [FacilityGuid] )
	REFERENCES [dbo].[Facility] ( [FacilityGuid] )
	ON UPDATE  NO ACTION
	ON DELETE  NO ACTION
GO
COMMIT

-- ManyToMany join from CityStateZip to Facility --
USE [PSS2012]
BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[FacilityLocationCriteria] ADD CONSTRAINT [FK_FacilityLocationCriteria_CityStateZip]
	FOREIGN KEY ( [CityStateZipGuid] )
	REFERENCES [dbo].[CityStateZip] ( [CityStateZipGuid] )
	ON UPDATE  NO ACTION
	ON DELETE  NO ACTION
GO

ALTER TABLE [dbo].[FacilityLocationCriteria] ADD CONSTRAINT [FK_FacilityLocationCriteria_Facility]
	FOREIGN KEY ( [FacilityGuid] )
	REFERENCES [dbo].[Facility] ( [FacilityGuid] )
	ON UPDATE  NO ACTION
	ON DELETE  NO ACTION
GO
COMMIT

-- ManyToMany join from Facility to Offering --
USE [PSS2012]
BEGIN TRANSACTION
GO
ALTER TABLE [dbo].[FacilityOffering] ADD CONSTRAINT [FK_FacilityOffering_Facility]
	FOREIGN KEY ( [FacilityGuid] )
	REFERENCES [dbo].[Facility] ( [FacilityGuid] )
	ON UPDATE  NO ACTION
	ON DELETE  NO ACTION
GO

ALTER TABLE [dbo].[FacilityOffering] ADD CONSTRAINT [FK_FacilityOffering_Offering]
	FOREIGN KEY ( [OfferingGuid] )
	REFERENCES [dbo].[Offering] ( [OfferingGuid] )
	ON UPDATE  NO ACTION
	ON DELETE  NO ACTION
GO
COMMIT