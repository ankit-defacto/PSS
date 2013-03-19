﻿/*  Generated by CodeGen written by Concord Mfg.
 * Transform file used: BELogic (v0.2.0.0).xslt
 * Date generated: 3/28/2012 12:46:04 PM
 * CodeGen version: 0.2.0.0  */

using System;
using System.Collections.Generic;
using System.Linq;
using BE = ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;
using DA = ConcordMfg.PremierSeniorSolutions.WebService.DataAccess;
using ConcordMfg.PremierSeniorSolutions.WebService.EntityConversions;

namespace ConcordMfg.PremierSeniorSolutions.WebService.BusinessLogic
{
	public class FacilityOfferingLogic
	{
		#region Public CRUD Methods

		public List<BE.FacilityOffering> GetAllFacilityOffering()
		{
            DA.FacilityOfferingGateway gateway = new DA.FacilityOfferingGateway();
			List<BE.FacilityOffering> result = new List<BE.FacilityOffering>();
			result = gateway.GetAll().ToBusinessEntitiesList();
			return result;
		}

		public BE.FacilityOffering GetFacilityOfferingByFacilityGuidOfferingGuid(Guid facilityGuid, Guid offeringGuid)
		{
			DA.FacilityOfferingGateway gateway = new DA.FacilityOfferingGateway();
			BE.FacilityOffering result = new BE.FacilityOffering();
            // plamen: data access method throws exception if entity not found. This behavior breaks the upper logic
            try
            {
                result = gateway.GetByPK(facilityGuid, offeringGuid).ToBusinessEntity();
            }
            catch (DataAccess.DataAccessException)
            {
                return null;                
            }
			
			return result;
		}

		public BE.FacilityOffering InsertFacilityOffering(BE.FacilityOffering entity)
		{
			//@@NEW - remove try/catch. insert returns DA entity (with new data). this method now returns an entity.
			DA.FacilityOfferingGateway gateway = new DA.FacilityOfferingGateway();
			DA.FacilityOffering result = gateway.Insert(entity.ToDataEntity());
			return result.ToBusinessEntity();
		}

		public void UpdateFacilityOffering(BE.FacilityOffering entity)
		{
			DA.FacilityOfferingGateway gateway = new DA.FacilityOfferingGateway();
			gateway.Update(entity.ToDataEntity());
		}

		public void DeleteFacilityOffering(BE.FacilityOffering entity)
		{
			DA.FacilityOfferingGateway gateway = new DA.FacilityOfferingGateway();
			gateway.Delete(entity.FacilityGuid, entity.OfferingGuid);
		}

		#endregion

		#region Public Many-To-One Methods

		#endregion
		
		#region Public Many-To-Many Methods

		#endregion
	}
}