USE [PSS2012]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FacilityAudit_Facility]') AND parent_object_id = OBJECT_ID(N'[dbo].[FacilityAudit]'))
ALTER TABLE [dbo].[FacilityAudit] DROP CONSTRAINT [FK_FacilityAudit_Facility]
GO


