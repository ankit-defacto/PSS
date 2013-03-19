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
	[ServiceBehavior(Name = "OfferingWithFacility", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01")]
	class OfferingWithFacility : SC.IOfferingWithFacility
	{
		#region IOfferingWithFacility Members

		public List<DC.OfferingWithFacility> GetAllOfferingWithFacility()
		{
			try
			{
				BL.OfferingWithFacilityLogic offeringWithFacilityLogic = new BL.OfferingWithFacilityLogic();
				List<BE.OfferingWithFacility> entities = offeringWithFacilityLogic.GetAllOfferingWithFacility();
				List<DC.OfferingWithFacility> response = entities.ToDataContractList();
				return response;
			}
			catch (Exception ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = "Unable to retrieve OfferingWithFacility data.";
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		public List<DC.OfferingWithFacility> GetOfferingWithFacilityByOfferingGuid(Guid personGuid)
		{
			try
			{
				BL.OfferingWithFacilityLogic offeringWithFacilityLogic = new BL.OfferingWithFacilityLogic();
				List<BE.OfferingWithFacility> entities = offeringWithFacilityLogic.GetOfferingWithFacilityByOfferingGuid(personGuid);
				List<DC.OfferingWithFacility> response = entities.ToDataContractList();
				return response;
			}
			catch (Exception ex)
			{
				FC.FacilityOfferingFault fault = new FC.FacilityOfferingFault();
				fault.ErrorMessage = "Unable to retrieve OfferingWithFacility data.";
				throw new FaultException<FC.FacilityOfferingFault>(fault,
					new FaultReason(ex.Message));
			}
		}

		public List<DC.OfferingWithFacility> GetOfferingWithFacilityByFacilityGuid(Guid taskGuid)
		{
			try
			{
				BL.OfferingWithFacilityLogic offeringWithFacilityLogic = new BL.OfferingWithFacilityLogic();
				List<BE.OfferingWithFacility> entities = offeringWithFacilityLogic.GetOfferingWithFacilityByFacilityGuid(taskGuid);
				List<DC.OfferingWithFacility> response = entities.ToDataContractList();
				return response;
			}
			catch (Exception ex)
			{
				FC.FacilityOfferingFault fault = new FC.FacilityOfferingFault();
				fault.ErrorMessage = "Unable to retrieve OfferingWithFacility data.";
				throw new FaultException<FC.FacilityOfferingFault>(fault,
					new FaultReason(ex.Message));
			}
		}

		public void UpdateOfferingWithFacility(DC.OfferingWithFacility request)
		{
			try
			{
				BL.OfferingWithFacilityLogic offeringWithFacilityLogic = new BL.OfferingWithFacilityLogic();
				BE.OfferingWithFacility entity = request.ToBusinessEntity();
				offeringWithFacilityLogic.UpdateOfferingWithFacility(entity);
			}
			catch (BE.FacilityOfferingNotFoundException ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = String.Format("Unable to update OfferingWithFacility data for person '{0}' and '{1}'.",
					request.OfferingGuid.ToString(), request.Facility_FacilityGuid.ToString());
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		#endregion
	}
}