﻿/*  Generated by CodeGen written by Concord Mfg.
 * Transform file used: BEGateway (v0.2.0.0).xslt
 * Date generated: 3/28/2012 12:46:00 PM
 * CodeGen version: 0.2.0.0  */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using ConcordMfg.PremierSeniorSolutions.WebService.DataAccess.DAEntities;

namespace ConcordMfg.PremierSeniorSolutions.WebService.DataAccess
{
	public class FacilityGateway : GatewayBase, IFacilityGateway
    {
        #region Search
        public IList<Facility> GetAllByDistanceFilter(IEnumerable<Offering> offerings, LatLng location, double radius, bool wideSearch, int page, int pageSize, out int totalCount)
        {
            using (PSS2012DataContext context = this.DataContext)
            {
                var search = this.GetAllFacilityByDistance(context, location, radius);
                return this.TypeOfCareIntersect(context, this.ExcludePausedAccounts(context, search), offerings, wideSearch)
                    .GetPage<Facility>(page, pageSize, out totalCount);
            }
        }

        public IList<Facility> GetAllByDistance(LatLng location, double radius, int page, int pageSize, out int totalCount)
        {
            using (PSS2012DataContext context = this.DataContext)
            {
                var facilitiesAll = this.GetAllFacilityByDistance(context, location, radius);
                return this.ExcludePausedAccounts(context, facilitiesAll).GetPage<Facility>(page, pageSize, out totalCount);
            }
        }

        public IList<Facility> GetAllFilter(CityStateZip csz, IEnumerable<Offering> offerings, bool wideSearch, int page, int pageSize, out int totalCount)
        {
            using (PSS2012DataContext context = this.DataContext)
            {
                var search = context.CityStateZips.Where(c => c.City.StartsWith(csz.City) && c.State.StartsWith(csz.State) &&
                    c.ZipCode.StartsWith(csz.ZipCode))
                    .Join(context.Facilities, oid => oid.CityStateZipGuid, iid => iid.CityStateZipGuid, (oid, iid) => iid)                    
                    .Distinct();
                return this.TypeOfCareIntersect(context, this.ExcludePausedAccounts(context, search), offerings, wideSearch)
                    .GetPage<Facility>(page, pageSize, out totalCount);
            }
        }

        private IQueryable<Facility> TypeOfCareIntersect(PSS2012DataContext context, IQueryable<Facility> query, IEnumerable<Offering> offerings, bool wideSearch)
        {
            if (offerings.Count() > 0)
            {
                if (wideSearch)
                {
                    //wider search - includes any of the input offerings
                    var ofg = context.Offerings.Where(Offering.ContainsOfferings(offerings))
                        .Join(context.FacilityOfferings, oid => oid.OfferingGuid, iid => iid.OfferingGuid, 
                        (oid, iid) => iid)
                        .Join(query, oid => oid.FacilityGuid, iid => iid.FacilityGuid, (oid, iid) => iid);
                    //
                    query = query.Intersect(ofg);
                }
                else
	            {
                    // get offering guid list as queryable to avoid not supported exception
                    var offeringsAsQueryable = context.Offerings.Where(Offering.ContainsOfferings(offerings)).Select(s => s.OfferingGuid);
                    // group by guid and intersect with offerings
                    var facilityOfferings = context.FacilityOfferings
                        .GroupBy(g => g.FacilityGuid)
                        .Select(s => new { Fguid = s.Key, Fos = s.Select(ss => ss.OfferingGuid).Intersect(offeringsAsQueryable) })
                        .Where(w => w.Fos.Count() == offeringsAsQueryable.Count());
                    query = query.Join(facilityOfferings, oid => oid.FacilityGuid, iid => iid.Fguid, (oid, iid) => oid);
	            }
            }

            return query.OrderBy(f => f.FacilityName);
        }

        private IQueryable<Facility> GetAllFacilityByDistance(PSS2012DataContext context, LatLng location, double radius)
        {
            var facilities = context.Facilities.Where(f =>
                    context.ufn_Haversine(location.Latitude, location.Longitude, f.Latitude, f.Longitude) < radius);
            return facilities;
        }

        private IQueryable<Facility> ExcludePausedAccounts(PSS2012DataContext context, IQueryable<Facility> facilities)
        {
            var facilitiesActive = facilities
            .Join(context.Clients, oid => oid.ClientGuid, iid => iid.ClientGuid, (oid, iid) => new { Facility = oid, Exclude = iid.AccountPaused })
                    .Where(fe => !fe.Exclude)
                    .Select(f => f.Facility);
            return facilitiesActive;
        }
        #endregion

        #region IFacilityGateway Members

        public IOrderedQueryable<Facility> GetAll()
		{
			try
			{
				using (PSS2012DataContext context = this.DataContext)
				{
					return context.Facilities.OrderBy(facility => facility.FacilityName);
				}
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				throw this.HandleSqlException(ex);
			}
		}

		public List<Facility> GetAllWithUndefined()
		{
			Facility undefinedFacility = new Facility()
			{
				FacilityGuid = Guid.Empty,
				FacilityID = 0,
				FacilityName = "Undefined",
				Exerpt = null,
				Description = null,
				Address = null,
				CityStateZipGuid = Guid.Empty,
				PhoneNumber = null,
				Email = null,
				Website = null,
				ClientGuid = Guid.Empty,
				ListingTypeGuid = Guid.Empty,
				PublicPhotoFileUri = null,
			};

			List<Facility> response = this.GetAll().ToList();
			response.Add(undefinedFacility);

			return response;
		}

        public Facility GetByPK(Guid facilityGuid)
        {
            if (Guid.Empty == facilityGuid)
            { return new Facility(); }

            try
            {
                Facility daFacility = new Facility();
                using (PSS2012DataContext context = this.DataContext)
                {
                    daFacility = (
                        from items in context.Facilities
                        where items.FacilityGuid == facilityGuid
                        select items).SingleOrDefault();
                }

                if (null == daFacility)
                {
                    throw new DataAccessException("Facility no longer exists.");
                }

                return daFacility;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw this.HandleSqlException(ex);
            }
        }

        public List<Facility> GetByClientAndListingTypeGuid(Guid clientGuid, Guid listingTypeGuid)
        {
            if (Guid.Empty == clientGuid)
            { return null; }

            if (Guid.Empty == listingTypeGuid)
            { return null; }

            try
            {
                List<Facility> daFacility = new List<Facility>();
                using (PSS2012DataContext context = this.DataContext)
                {
                    daFacility = (
                        from items in context.Facilities
                        where items.ClientGuid == clientGuid && items.ListingTypeGuid == listingTypeGuid
                        select items).ToList();
                }

                return daFacility;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return null;
            }
        }

		/// <summary>
		/// Inserts facility business entity into the data store.
		/// </summary>
		/// <param name="entity">The facility business entity to insert.</param>
		/// <returns>The facility identifier.</returns>
		public Facility Insert(Facility entity)
		{
			//@@NEW - changed return type to entity type.
			try
			{
				using (PSS2012DataContext context = this.DataContext)
				{
					entity.FacilityGuid = Guid.NewGuid();

					context.Facilities.InsertOnSubmit(entity);
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

		public void Update(Facility entity)
		{
			if (Guid.Empty == entity.FacilityGuid)
				throw new PrimaryKeyMissingException("Facility", entity, "update");

			try
			{
				using (PSS2012DataContext context = this.DataContext)
				{
					// Get the entity to update.
					Facility facilityToUpdate = GetByPK(entity.FacilityGuid);
                    context.Facilities.Attach(facilityToUpdate);

					// Set the new values.
					//facilityToUpdate.FacilityID = entity.FacilityID;
					facilityToUpdate.FacilityName = entity.FacilityName;
					facilityToUpdate.Exerpt = entity.Exerpt;
					facilityToUpdate.Description = entity.Description;
					facilityToUpdate.Address = entity.Address;
					facilityToUpdate.CityStateZipGuid = entity.CityStateZipGuid;
					facilityToUpdate.PhoneNumber = entity.PhoneNumber;
					facilityToUpdate.Email = entity.Email;
					facilityToUpdate.Website = entity.Website;
					facilityToUpdate.ClientGuid = entity.ClientGuid;
					facilityToUpdate.ListingTypeGuid = entity.ListingTypeGuid;
					facilityToUpdate.PublicPhotoFileUri = entity.PublicPhotoFileUri;
                    facilityToUpdate.Latitude = entity.Latitude;
                    facilityToUpdate.Longitude = entity.Longitude;
                    facilityToUpdate.Price = entity.Price;

					// Perform the update.
					context.SubmitChanges();
				}
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				throw this.HandleSqlException(ex);
			}
		}

        // the deletion is not possible - FK in FacilityAudit prevents from deletion
		public void Delete(Guid facilityGuid)
		{
			if (Guid.Empty == facilityGuid)
				throw new PrimaryKeyMissingException("Facility", facilityGuid, "delete");


			try
			{
				using (PSS2012DataContext context = this.DataContext)
				{
					// Get the entity to delete.
					Facility facilityToDelete = GetByPK(facilityGuid);
                    context.Facilities.Attach(facilityToDelete);

					// Peform the delete.
					context.Facilities.DeleteOnSubmit(facilityToDelete);
					context.SubmitChanges();
				}
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				throw this.HandleSqlException(ex);
			}
		}

		public IOrderedQueryable<Facility> GetForCityStateZipByCityStateZipGuid(Guid cityStateZipGuid)
		{
			try
			{
				using (PSS2012DataContext context = this.DataContext)
				{
					// Get the entity to delete.
					return
						(from items in context.Facilities
						 where items.CityStateZipGuid == cityStateZipGuid
						 select items).OrderBy(facility => facility.FacilityName);
				}
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				throw this.HandleSqlException(ex);
			}
		}

		public List<Facility> GetForClientByClientGuid(Guid clientGuid)
		{
			try
			{
				using (PSS2012DataContext context = this.DataContext)
				{
					var facilities =
						(from items in context.Facilities
						 where items.ClientGuid == clientGuid
						 select items).OrderBy(facility => facility.FacilityName).ToList();
					return facilities;
				}
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				throw this.HandleSqlException(ex);
			}
		}

		public IOrderedQueryable<Facility> GetForListingTypeByListingTypeGuid(Guid listingTypeGuid)
		{
			try
			{
				using (PSS2012DataContext context = this.DataContext)
				{
					// Get the entity to delete.
					return
						(from items in context.Facilities
						 where items.ListingTypeGuid == listingTypeGuid
						 select items).OrderBy(facility => facility.FacilityName);
				}
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				throw this.HandleSqlException(ex);
			}
		}

		public IOrderedQueryable<Facility> GetAllForCityStateZip(Guid cityStateZipGuid)
		{
			try
			{
				using (PSS2012DataContext context = this.DataContext)
				{
					var facilityQuery =
						from items in context.Facilities
						join jt in context.FacilityLocationCriterias on items.FacilityGuid equals jt.FacilityGuid
						where jt.FacilityGuid == cityStateZipGuid
						select items;
					return facilityQuery.OrderBy(facility => facility.FacilityName);
				}
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				throw this.HandleSqlException(ex);
			}
		}

		public IOrderedQueryable<Facility> GetAllNotForCityStateZip(Guid cityStateZipGuid)
		{
			try
			{
				using (PSS2012DataContext context = this.DataContext)
				{
					var query1 =
						from tIn in context.Facilities
						join jtIn in context.FacilityLocationCriterias on tIn.FacilityGuid equals jtIn.FacilityGuid into temp
						from newT in temp.DefaultIfEmpty()
						where newT.FacilityGuid == cityStateZipGuid
						select newT.FacilityGuid;

					var query2 =
						from t in context.Facilities
						where !query1.Contains(t.FacilityGuid)
						select t;

					return query2.OrderBy(facility => facility.FacilityName);
				}
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				throw this.HandleSqlException(ex);
			}
		}

		public IOrderedQueryable<Facility> GetAllForOffering(Guid offeringGuid)
		{
			try
			{
				using (PSS2012DataContext context = this.DataContext)
				{
					var facilityQuery =
						from items in context.Facilities
						join jt in context.FacilityOfferings on items.FacilityGuid equals jt.FacilityGuid
						where jt.FacilityGuid == offeringGuid
						select items;
					return facilityQuery.OrderBy(facility => facility.FacilityName);
				}
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				throw this.HandleSqlException(ex);
			}
		}

		public IOrderedQueryable<Facility> GetAllNotForOffering(Guid offeringGuid)
		{
			try
			{
				using (PSS2012DataContext context = this.DataContext)
				{
					var query1 =
						from tIn in context.Facilities
						join jtIn in context.FacilityOfferings on tIn.FacilityGuid equals jtIn.FacilityGuid into temp
						from newT in temp.DefaultIfEmpty()
						where newT.FacilityGuid == offeringGuid
						select newT.FacilityGuid;

					var query2 =
						from t in context.Facilities
						where !query1.Contains(t.FacilityGuid)
						select t;

					return query2.OrderBy(facility => facility.FacilityName);
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
			else if (ex.Message.Contains("Invalid object name 'dbo.Facility'"))
			{
				return new TableDoesNotExistException("PSS2012", "Facility", ex);
			}
			else if (ex.Message.Contains("Invalid column name"))
			{
				return new ColumnDoesNotExistException("PSS2012", "Facility", ex);
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
					return new RowReferencedElsewhereException(errorMatch.Groups["db"].Value, "Facility", errorMatch.Groups["jtn"].Value, ex);
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