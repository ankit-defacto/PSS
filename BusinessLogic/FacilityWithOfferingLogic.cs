﻿/*  Generated by CodeGen written by Concord Mfg.
 * Transform file used: JoinLogic (v0.2.0.0).xslt
 * Date generated: 3/28/2012 12:46:05 PM
 * CodeGen version: 0.2.0.0  */

using System;
using System.Collections.Generic;
using System.Linq;
using BE = ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;
using DA = ConcordMfg.PremierSeniorSolutions.WebService.DataAccess;

namespace ConcordMfg.PremierSeniorSolutions.WebService.BusinessLogic
{
	public class FacilityWithOfferingLogic
	{
		#region Public CRUD Methods
		public List<BE.FacilityWithOffering> GetAllFacilityWithOffering()
		{
			DA.FacilityWithOfferingGateway gateway = new DA.FacilityWithOfferingGateway();
			List<BE.FacilityWithOffering> result = new List<BE.FacilityWithOffering>();
			try
			{
				result = gateway.GetAll().ToBusinessEntitiesList();
			}
			catch (Exception ex) { throw ex; }
			return result;
		}

		public List<BE.FacilityWithOffering> GetFacilityWithOfferingByFacilityGuid(Guid facilityGuid)
		{
			DA.FacilityWithOfferingGateway gateway = new DA.FacilityWithOfferingGateway();
			List<BE.FacilityWithOffering> result = new List<BE.FacilityWithOffering>();
			try
			{
				result = gateway.GetByFacilityGuid(facilityGuid).ToBusinessEntity();
			}
			catch (Exception ex) { throw ex; }
			return result;
		}

		public List<BE.FacilityWithOffering> GetFacilityWithOfferingByOfferingGuid(Guid offeringGuid)
		{
			DA.FacilityWithOfferingGateway gateway = new DA.FacilityWithOfferingGateway();
			List<BE.FacilityWithOffering> result = new List<BE.FacilityWithOffering>();
			try
			{
				result = gateway.GetByOfferingGuid(offeringGuid).ToBusinessEntity();
		}
		catch (Exception ex) { throw ex; }
		return result;
		}

		public void UpdateFacilityWithOffering(BE.FacilityWithOffering request)
		{
			DA.FacilityWithOfferingGateway gateway = new DA.FacilityWithOfferingGateway();
			try
			{
				gateway.Update(request);
			}
			catch (Exception ex) { throw ex; }
		}
		#endregion
	}
}