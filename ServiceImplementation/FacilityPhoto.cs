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
	[ServiceBehavior(Name = "FacilityPhoto", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01")]
	public class FacilityPhoto : SC.IFacilityPhoto
	{
		#region IFacilityPhoto Members
		public List<DC.FacilityPhoto> GetAllFacilityPhoto()
		{
			try
			{
				BL.FacilityPhotoLogic facilityPhotoLogic = new BL.FacilityPhotoLogic();
				List<BE.FacilityPhoto> entities = facilityPhotoLogic.GetAllFacilityPhoto();
				List<DC.FacilityPhoto> response = entities.ToDataContractList();
				return response;
			}
			catch (Exception ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = "Unable to retrieve facilityPhoto data.";
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		public List<DC.FacilityPhoto> GetAllFacilityPhotoWithUndefined()
		{
			try
			{
				BL.FacilityPhotoLogic facilityPhotoLogic = new BL.FacilityPhotoLogic();
				List<BE.FacilityPhoto> entities = facilityPhotoLogic.GetAllFacilityPhotoWithUndefined();
				List<DC.FacilityPhoto> response = entities.ToDataContractList();
				return response;
			}
			catch (Exception ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = "Unable to retrieve facilityPhoto data.";
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		public DC.FacilityPhoto GetFacilityPhotoByFacilityPhotoGuid(Guid facilityPhotoGuid)
		{
			try
			{
				BL.FacilityPhotoLogic facilityPhotoLogic = new BL.FacilityPhotoLogic();
				BE.FacilityPhoto entity = facilityPhotoLogic.GetFacilityPhotoByFacilityPhotoGuid(facilityPhotoGuid);
				DC.FacilityPhoto response = entity.ToDataContract();
				return response;
			}
			catch (BE.FacilityPhotoNotFoundException ex)
			{
				FC.FacilityPhotoFault fault = new FC.FacilityPhotoFault();
				fault.FacilityPhotoGuid = ex.FacilityPhotoGuid;
				fault.ErrorMessage = "FacilityPhoto does not exsist in the database.";
				throw new FaultException<FC.FacilityPhotoFault>(fault,
					new FaultReason(ex.Message));
			}
			catch (Exception ex)
			{
				FC.FacilityPhotoFault fault = new FC.FacilityPhotoFault();
				fault.ErrorMessage = "Could not retrieve a specific FacilityPhoto for unknown reasons.";
				throw new FaultException<FC.FacilityPhotoFault>(fault,
					new FaultReason(ex.Message));
			}
		}

		public void InsertFacilityPhoto(DC.FacilityPhoto request)
		{
			try
			{
				BL.FacilityPhotoLogic facilityPhotoLogic = new BL.FacilityPhotoLogic();
				BE.FacilityPhoto entity = request.ToBusinessEntity();
				facilityPhotoLogic.InsertFacilityPhoto(entity);
			}
			catch (BE.FacilityPhotoAlreadyExistsException ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = String.Format(
					"Unable to insert FacilityPhoto data. Data: {0}",
					request.ToBusinessEntity().ToString());
	
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		public void UpdateFacilityPhoto(DC.FacilityPhoto request)
		{
			try
			{
				BL.FacilityPhotoLogic facilityPhotoLogic = new BL.FacilityPhotoLogic();
				BE.FacilityPhoto entity = request.ToBusinessEntity();
				facilityPhotoLogic.UpdateFacilityPhoto(entity);
			}
			catch (BE.FacilityPhotoNotFoundException ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = String.Format(
					"Unable to update FacilityPhoto data. Data: {0}",
					request.ToBusinessEntity().ToString());
	
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		public void DeleteFacilityPhoto(DC.FacilityPhoto request)
		{
			try
			{
				BL.FacilityPhotoLogic facilityPhotoLogic = new BL.FacilityPhotoLogic();
				BE.FacilityPhoto entity = request.ToBusinessEntity();
				facilityPhotoLogic.DeleteFacilityPhoto(entity);
			}
			catch (BE.FacilityPhotoNotFoundException ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = String.Format(
					"Unable to delete FacilityPhoto data. Data: {0}",
					request.ToBusinessEntity().ToString());
	
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		public List<DC.FacilityPhoto> GetFacilityPhotosForFacilityByFacilityGuid(Guid facilityGuid)
		{
			try
			{
				BL.FacilityPhotoLogic facilityPhotoLogic = new BL.FacilityPhotoLogic();
				List<BE.FacilityPhoto> entities = facilityPhotoLogic.GetFacilityPhotosForFacilityByFacilityGuid(facilityGuid);
				List<DC.FacilityPhoto> response = entities.ToDataContractList();
				return response;
			}
			catch (BE.FacilityPhotoException ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = string.Format("Unable to find a FacilityPhoto with the given Facility");
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		#endregion
	}
}