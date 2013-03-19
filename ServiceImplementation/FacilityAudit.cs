﻿/*  Generated by CodeGen written by Concord Mfg.
 *  Transform file used: BEServiceImplementation (v0.1.0.0).xslt
 *  Date generated: 3/28/2012 12:46:11 PM
 *  CodeGen version: 0.1.0.0  */

using System;
using System.Collections.Generic;
using System.ServiceModel;
using BE = ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;
using BL = ConcordMfg.PremierSeniorSolutions.WebService.BusinessLogic;
using DC = ConcordMfg.PremierSeniorSolutions.WebService.DataContracts;
using FC = ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts;
using SC = ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts;
using ConcordMfg.PremierSeniorSolutions.WebService.EntityConversions;


namespace ConcordMfg.PremierSeniorSolutions.WebService.ServiceImplementation
{
	[ServiceBehavior(Name = "FacilityAudit", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01")]
	public class FacilityAudit : SC.IFacilityAudit
	{
		#region IFacilityAudit Members
		public List<DC.FacilityAudit> GetAllFacilityAudit()
		{
			try
			{
				BL.FacilityAuditLogic facilityAuditLogic = new BL.FacilityAuditLogic();
				List<BE.FacilityAudit> entities = facilityAuditLogic.GetAllFacilityAudit();
				List<DC.FacilityAudit> response = entities.ToDataContractList();
				return response;
			}
			catch (Exception ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = "Unable to retrieve facilityAudit data.";
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		public List<DC.FacilityAudit> GetAllFacilityAuditWithUndefined()
		{
			try
			{
				BL.FacilityAuditLogic facilityAuditLogic = new BL.FacilityAuditLogic();
				List<BE.FacilityAudit> entities = facilityAuditLogic.GetAllFacilityAuditWithUndefined();
				List<DC.FacilityAudit> response = entities.ToDataContractList();
				return response;
			}
			catch (Exception ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = "Unable to retrieve facilityAudit data.";
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		public DC.FacilityAudit GetFacilityAuditByFacilityAuditGuid(Guid facilityAuditGuid)
		{
			try
			{
				BL.FacilityAuditLogic facilityAuditLogic = new BL.FacilityAuditLogic();
				BE.FacilityAudit entity = facilityAuditLogic.GetFacilityAuditByFacilityAuditGuid(facilityAuditGuid);
				DC.FacilityAudit response = entity.ToDataContract();
				return response;
			}
			catch (BE.FacilityAuditNotFoundException ex)
			{
				FC.FacilityAuditFault fault = new FC.FacilityAuditFault();
				fault.FacilityAuditGuid = ex.FacilityAuditGuid;
				fault.ErrorMessage = "FacilityAudit does not exsist in the database.";
				throw new FaultException<FC.FacilityAuditFault>(fault,
					new FaultReason(ex.Message));
			}
			catch (Exception ex)
			{
				FC.FacilityAuditFault fault = new FC.FacilityAuditFault();
				fault.ErrorMessage = "Could not retrieve a specific FacilityAudit for unknown reasons.";
				throw new FaultException<FC.FacilityAuditFault>(fault,
					new FaultReason(ex.Message));
			}
		}

		public void InsertFacilityAudit(DC.FacilityAudit request)
		{
			try
			{
				BL.FacilityAuditLogic facilityAuditLogic = new BL.FacilityAuditLogic();
				BE.FacilityAudit entity = request.ToBusinessEntity();
				facilityAuditLogic.InsertFacilityAudit(entity);
			}
			catch (BE.FacilityAuditAlreadyExistsException ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = String.Format(
					"Unable to insert Facility Audit data. Data: {0}",
					request.ToBusinessEntity().ToString());
	
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		public void UpdateFacilityAudit(DC.FacilityAudit request)
		{
			try
			{
				BL.FacilityAuditLogic facilityAuditLogic = new BL.FacilityAuditLogic();
				BE.FacilityAudit entity = request.ToBusinessEntity();
				facilityAuditLogic.UpdateFacilityAudit(entity);
			}
			catch (BE.FacilityAuditNotFoundException ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = String.Format(
					"Unable to update Facility Audit data. Data: {0}",
					request.ToBusinessEntity().ToString());
	
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		public void DeleteFacilityAudit(DC.FacilityAudit request)
		{
			try
			{
				BL.FacilityAuditLogic facilityAuditLogic = new BL.FacilityAuditLogic();
				BE.FacilityAudit entity = request.ToBusinessEntity();
				facilityAuditLogic.DeleteFacilityAudit(entity);
			}
			catch (BE.FacilityAuditNotFoundException ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = String.Format(
					"Unable to delete Facility Audit data. Data: {0}",
					request.ToBusinessEntity().ToString());
	
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		public List<DC.FacilityAudit> GetFacilityAuditsForFacilityByFacilityGuid(Guid facilityGuid)
		{
			try
			{
				BL.FacilityAuditLogic facilityAuditLogic = new BL.FacilityAuditLogic();
				List<BE.FacilityAudit> entities = facilityAuditLogic.GetFacilityAuditsForFacilityByFacilityGuid(facilityGuid);
				List<DC.FacilityAudit> response = entities.ToDataContractList();
				return response;
			}
			catch (BE.FacilityAuditException ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = string.Format("Unable to find a FacilityAudit with the given Facility");
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}


		public List<DC.FacilityAudit> GetFacilityAuditsForCityStateZipByCityStateZipGuid(Guid cityStateZipGuid)
		{
			try
			{
				BL.FacilityAuditLogic facilityAuditLogic = new BL.FacilityAuditLogic();
				List<BE.FacilityAudit> entities = facilityAuditLogic.GetFacilityAuditsForCityStateZipByCityStateZipGuid(cityStateZipGuid);
				List<DC.FacilityAudit> response = entities.ToDataContractList();
				return response;
			}
			catch (BE.FacilityAuditException ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = string.Format("Unable to find a FacilityAudit with the given CityStateZip");
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}


		public List<DC.FacilityAudit> GetFacilityAuditsForClientByClientGuid(Guid clientGuid)
		{
			try
			{
				BL.FacilityAuditLogic facilityAuditLogic = new BL.FacilityAuditLogic();
				List<BE.FacilityAudit> entities = facilityAuditLogic.GetFacilityAuditsForClientByClientGuid(clientGuid);
				List<DC.FacilityAudit> response = entities.ToDataContractList();
				return response;
			}
			catch (BE.FacilityAuditException ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = string.Format("Unable to find a FacilityAudit with the given Client");
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}


		public List<DC.FacilityAudit> GetFacilityAuditsForListingTypeByListingTypeGuid(Guid listingTypeGuid)
		{
			try
			{
				BL.FacilityAuditLogic facilityAuditLogic = new BL.FacilityAuditLogic();
				List<BE.FacilityAudit> entities = facilityAuditLogic.GetFacilityAuditsForListingTypeByListingTypeGuid(listingTypeGuid);
				List<DC.FacilityAudit> response = entities.ToDataContractList();
				return response;
			}
			catch (BE.FacilityAuditException ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = string.Format("Unable to find a FacilityAudit with the given ListingType");
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		#endregion
	}
}