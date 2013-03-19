﻿/*  Generated by CodeGen written by Concord Mfg.
 * Transform file used: JoinGateway (v0.2.0.0).xslt
 * Date generated: 3/28/2012 12:46:01 PM
 * CodeGen version: 0.2.0.0  */

using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace ConcordMfg.PremierSeniorSolutions.WebService.DataAccess
{
	public class OfferingWithFacilityGateway : GatewayBase, IOfferingWithFacilityGateway
	{
		#region IOfferingWithFacilityGateway Members

		public IQueryable<OfferingWithFacility> GetAll()
		{
			try
			{
				using (PSS2012DataContext context = this.DataContext)
				{
					return
						from mt in context.Offerings
						join jt in context.FacilityOfferings on mt.OfferingGuid equals jt.FacilityGuid
						select new OfferingWithFacility()
						{
							OfferingGuid = mt.OfferingGuid,
							OfferingID = mt.OfferingID,
							OfferingName = mt.OfferingName,
							Facility_FacilityGuid = jt.FacilityGuid,
							FacilityOffering_IsChecked = jt.IsChecked,
						};
				}
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				throw this.HandleSqlException(ex);
			}
		}

		public IQueryable<OfferingWithFacility> GetByOfferingGuid(Guid offeringGuid)
		{
			try
			{
				using (PSS2012DataContext context = this.DataContext)
				{
					return
						from mt in context.Offerings
						join jt in context.FacilityOfferings on mt.OfferingGuid equals jt.FacilityGuid
						where mt.OfferingGuid == offeringGuid
						select new OfferingWithFacility()
						{
							OfferingGuid = mt.OfferingGuid,
							OfferingID = mt.OfferingID,
							OfferingName = mt.OfferingName,
							Facility_FacilityGuid = jt.FacilityGuid,
							FacilityOffering_IsChecked = jt.IsChecked,
						};
				}
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				throw this.HandleSqlException(ex);
			}
		}

		public IQueryable<OfferingWithFacility> GetByFacilityGuid(Guid facilityGuid)
		{
			try
			{
				using (PSS2012DataContext context = this.DataContext)
				{
					return 
						from mt in context.Offerings
						join jt in context.FacilityOfferings on mt.OfferingGuid equals jt.FacilityGuid
						where jt.FacilityGuid == facilityGuid
						select new OfferingWithFacility()
						{
							OfferingGuid = mt.OfferingGuid,
							OfferingID = mt.OfferingID,
							OfferingName = mt.OfferingName,
							Facility_FacilityGuid = jt.FacilityGuid,
							FacilityOffering_IsChecked = jt.IsChecked,
						 };
				}
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				throw this.HandleSqlException(ex);
			}
		}

		public void Update(OfferingWithFacility entity)
		{
			try
			{
				using (PSS2012DataContext context = this.DataContext)
				{
					// Get the Offering to update.
					Offering offeringToUpdate = (
						from mt in context.Offerings
						where mt.OfferingGuid == entity.OfferingGuid
						select mt).Single();

					// Update the offering data that is not auto assigned.
					offeringToUpdate.OfferingName = entity.OfferingName;

					// Get the join table.
					FacilityOffering facilityOfferingToUpdate = (
						from jt in context.FacilityOfferings
						where jt.OfferingGuid == entity.OfferingGuid &&
							jt.FacilityGuid == entity.Facility_FacilityGuid
						select jt).Single();

					// Update the join table data that is not auto assigned.
					facilityOfferingToUpdate.IsChecked = entity.FacilityOffering_IsChecked;

					// Perform the update.
					context.SubmitChanges();
				}
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				throw this.HandleSqlException(ex);
			}
		}

		#endregion


		#region Private Handle Exception Methods
		private Exception HandleSqlException(System.Data.SqlClient.SqlException ex)
		{
			if (ex.Message.Contains("An error has occurred while establishing a connection to the server.  When connecting to SQL Server 2005, this failure may be caused by the fact that under the default settings SQL Server does not allow remote connections."))
			{
				return new Exception("Could not establish a connection to SQL Server. See inner exception for more details. Perhaps Windows Firewall has blocked the connection to SQL Server. Check online resources to find out how to allow port exceptions.", ex);
			}
			else if (ex.Message.Contains("Invalid object name 'dbo.Offering'"))
			{
				return new TableDoesNotExistException("PSS2012", "Offering", ex);
			}
			else if (ex.Message.Contains("Invalid object name 'dbo.FacilityOffering'"))
			{
				return new TableDoesNotExistException("PSS2012", "FacilityOffering", ex);
			}
			else if (ex.Message.Contains("Invalid column name"))
			{
				return new ColumnDoesNotExistException("PSS2012", "Offering", ex);
			}
			else if (ex.Message.Contains("String or binary data would be truncated"))
			{
				return new DataAccessException("String or number is too long or too big for the database.", ex);
			}
			else
			{
				return ex;
			}
		}
		#endregion
	}
}