/*
   Wednesday, November 28, 20121:42:06 PM
   User: 
   Server: WIN-3JJECQ0GANK\SQLEXPRESS
   Database: PSS2012
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Facility ADD
	Latitude float(53) NOT NULL CONSTRAINT DF_Facility_Latitude DEFAULT 0,
	Longitude float(53) NOT NULL CONSTRAINT DF_Facility_Longitude DEFAULT 0
GO
ALTER TABLE dbo.Facility SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE dbo.FacilityAudit ADD
	Latitude float(53) NOT NULL CONSTRAINT DF_FacilityAudit_Latitude DEFAULT 0,
	Longitude float(53) NOT NULL CONSTRAINT DF_FacilityAudit_Longitude DEFAULT 0
GO
ALTER TABLE dbo.FacilityAudit SET (LOCK_ESCALATION = TABLE)
GO

COMMIT
