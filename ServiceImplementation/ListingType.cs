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
	[ServiceBehavior(Name = "ListingType", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01")]
	public class ListingType : SC.IListingType
	{
		#region IListingType Members
		public List<DC.ListingType> GetAllListingType()
		{
			try
			{
				BL.ListingTypeLogic listingTypeLogic = new BL.ListingTypeLogic();
				List<BE.ListingType> entities = listingTypeLogic.GetAllListingType();
				List<DC.ListingType> response = entities.ToDataContractList();
				return response;
			}
			catch (Exception ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = "Unable to retrieve listingType data.";
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		public List<DC.ListingType> GetAllListingTypeWithUndefined()
		{
			try
			{
				BL.ListingTypeLogic listingTypeLogic = new BL.ListingTypeLogic();
				List<BE.ListingType> entities = listingTypeLogic.GetAllListingTypeWithUndefined();
				List<DC.ListingType> response = entities.ToDataContractList();
				return response;
			}
			catch (Exception ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = "Unable to retrieve listingType data.";
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		public DC.ListingType GetListingTypeByListingTypeGuid(Guid listingTypeGuid)
		{
			try
			{
				BL.ListingTypeLogic listingTypeLogic = new BL.ListingTypeLogic();
				BE.ListingType entity = listingTypeLogic.GetListingTypeByListingTypeGuid(listingTypeGuid);
				DC.ListingType response = entity.ToDataContract();
				return response;
			}
			catch (BE.ListingTypeNotFoundException ex)
			{
				FC.ListingTypeFault fault = new FC.ListingTypeFault();
				fault.ListingTypeGuid = ex.ListingTypeGuid;
				fault.ErrorMessage = "ListingType does not exsist in the database.";
				throw new FaultException<FC.ListingTypeFault>(fault,
					new FaultReason(ex.Message));
			}
			catch (Exception ex)
			{
				FC.ListingTypeFault fault = new FC.ListingTypeFault();
				fault.ErrorMessage = "Could not retrieve a specific ListingType for unknown reasons.";
				throw new FaultException<FC.ListingTypeFault>(fault,
					new FaultReason(ex.Message));
			}
		}

		public void InsertListingType(DC.ListingType request)
		{
			try
			{
				BL.ListingTypeLogic listingTypeLogic = new BL.ListingTypeLogic();
				BE.ListingType entity = request.ToBusinessEntity();
				listingTypeLogic.InsertListingType(entity);
			}
			catch (BE.ListingTypeAlreadyExistsException ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = String.Format(
					"Unable to insert Listing Type data. Data: {0}",
					request.ToBusinessEntity().ToString());
	
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		public void UpdateListingType(DC.ListingType request)
		{
			try
			{
				BL.ListingTypeLogic listingTypeLogic = new BL.ListingTypeLogic();
				BE.ListingType entity = request.ToBusinessEntity();
				listingTypeLogic.UpdateListingType(entity);
			}
			catch (BE.ListingTypeNotFoundException ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = String.Format(
					"Unable to update Listing Type data. Data: {0}",
					request.ToBusinessEntity().ToString());
	
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		public void DeleteListingType(DC.ListingType request)
		{
			try
			{
				BL.ListingTypeLogic listingTypeLogic = new BL.ListingTypeLogic();
				BE.ListingType entity = request.ToBusinessEntity();
				listingTypeLogic.DeleteListingType(entity);
			}
			catch (BE.ListingTypeNotFoundException ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = String.Format(
					"Unable to delete Listing Type data. Data: {0}",
					request.ToBusinessEntity().ToString());
	
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}
		#endregion
	}
}