﻿/*  Generated by CodeGen written by Concord Mfg.
 * Transform file used: BEGateway (v0.2.0.0).xslt
 * Date generated: 3/28/2012 12:46:00 PM
 * CodeGen version: 0.2.0.0  */

using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConcordMfg.PremierSeniorSolutions.WebService.DataAccess
{
	public class OfferingGateway : GatewayBase, IOfferingGateway
	{
		#region IOfferingGateway Members

		public IList<Offering> GetAll()
		{
			try
			{
				using (PSS2012DataContext context = this.DataContext)
				{
					return context.Offerings.OrderBy(offering => offering.OfferingName).ToList();
				}
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				throw this.HandleSqlException(ex);
			}
		}

		public List<Offering> GetAllWithUndefined()
		{
			Offering undefinedOffering = new Offering()
			{
				OfferingGuid = Guid.Empty,
				OfferingID = 0,
				OfferingName = "Undefined",
			};

			List<Offering> response = this.GetAll().ToList();
			response.Add(undefinedOffering);

			return response;
		}

		public Offering GetByPK(Guid offeringGuid)
		{
			if (Guid.Empty == offeringGuid)
			{ return new Offering(); }

			try
			{
				Offering daOffering = new Offering();
				using (PSS2012DataContext context = this.DataContext)
				{
					daOffering = (
						from items in context.Offerings
						where items.OfferingGuid == offeringGuid
						select items).SingleOrDefault();
				}

				if (null == daOffering)
				{
					throw new DataAccessException("Offering no longer exists.");
				}

				return daOffering;
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				throw this.HandleSqlException(ex);
			}
		}

		/// <summary>
		/// Inserts offering business entity into the data store.
		/// </summary>
		/// <param name="entity">The offering business entity to insert.</param>
		/// <returns>The offering identifier.</returns>
		public Offering Insert(Offering entity)
		{
			//@@NEW - changed return type to entity type.
			try
			{
				using (PSS2012DataContext context = DataContext)
				{
					entity.OfferingGuid = Guid.NewGuid();

					context.Offerings.InsertOnSubmit(entity);
					context.SubmitChanges();
				}

				//@@NEW - returning full entity.
				return entity;
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				throw this.HandleSqlException(ex);
			}
		}

		public void Update(Offering entity)
		{
			if (Guid.Empty == entity.OfferingGuid)
				throw new PrimaryKeyMissingException("Offering", entity, "update");

			try
			{
				using (PSS2012DataContext context = DataContext)
				{
					// Get the entity to update.
					Offering offeringToUpdate = GetByPK(entity.OfferingGuid);

					// Set the new values.
					offeringToUpdate.OfferingID = entity.OfferingID;
					offeringToUpdate.OfferingName = entity.OfferingName;

					// Perform the update.
					context.SubmitChanges();
				}
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				throw this.HandleSqlException(ex);
			}
		}

		public void Delete(Guid offeringGuid)
		{
			if (Guid.Empty == offeringGuid)
				throw new PrimaryKeyMissingException("Offering", offeringGuid, "delete");

			try
			{
				using (PSS2012DataContext context = DataContext)
				{
					// Get the entity to delete.
					Offering offeringToDelete = GetByPK(offeringGuid);

					// Peform the delete.
					context.Offerings.DeleteOnSubmit(offeringToDelete);
					context.SubmitChanges();
				}
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				throw this.HandleSqlException(ex);
			}
		}

		public IEnumerable<Offering> GetAllForFacility(Guid facilityGuid)
		{
			try
			{
				using (PSS2012DataContext context = this.DataContext)
				{
					var offeringQuery =
						from items in context.Offerings
						join jt in context.FacilityOfferings on items.OfferingGuid equals jt.OfferingGuid
						where jt.FacilityGuid == facilityGuid
						select items;
					return offeringQuery.OrderBy(offering => offering.OfferingName).ToList();
				}
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				throw this.HandleSqlException(ex);
			}
		}

		public IOrderedQueryable<Offering> GetAllNotForFacility(Guid facilityGuid)
		{
			try
			{
				using (PSS2012DataContext context = this.DataContext)
				{
					var query1 =
						from tIn in context.Offerings
						join jtIn in context.FacilityOfferings on tIn.OfferingGuid equals jtIn.OfferingGuid into temp
						from newT in temp.DefaultIfEmpty()
						where newT.OfferingGuid == facilityGuid
						select newT.OfferingGuid;

					var query2 =
						from t in context.Offerings
						where !query1.Contains(t.OfferingGuid)
						select t;

					return query2.OrderBy(offering => offering.OfferingName);
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
			else if (ex.Message.Contains("Invalid column name"))
			{
				return new ColumnDoesNotExistException("PSS2012", "Offering", ex);
			}
			else if (ex.Message.Contains("String or binary data would be truncated"))
			{
				return new DataAccessException("String or number is too long or too big for the database.", ex);
			}
			else if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
			{
				Regex errorRx = new Regex("The DELETE statement conflicted with the REFERENCE constraint \"(?<constraint>[\\x20-\\x7E-[\"]]{1,})\". The conflict occurred in database \"(?<db>[\\x20-\\x7E-[\"]]{1,50})\", table \"dbo.(?<jtn>[\\x20-\\x7E-[\"]]{1,50})\"");
				Match errorMatch = errorRx.Match(ex.Message);
				if (errorMatch.Success)
				{
					return new RowReferencedElsewhereException(errorMatch.Groups["db"].Value, "Offering", errorMatch.Groups["jtn"].Value, ex);
				}
				else
				{ return ex; }
			}
			else
			{
				return ex;
			}
		}
		#endregion
	}
}