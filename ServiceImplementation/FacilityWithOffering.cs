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
	[ServiceBehavior(Name = "FacilityWithOffering", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01")]
	class FacilityWithOffering : SC.IFacilityWithOffering
	{
		#region IFacilityWithOffering Members

		public List<DC.FacilityWithOffering> GetAllFacilityWithOffering()
		{
			try
			{
				BL.FacilityWithOfferingLogic facilityWithOfferingLogic = new BL.FacilityWithOfferingLogic();
				List<BE.FacilityWithOffering> entities = facilityWithOfferingLogic.GetAllFacilityWithOffering();
				List<DC.FacilityWithOffering> response = entities.ToDataContractList();
				return response;
			}
			catch (Exception ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = "Unable to retrieve FacilityWithOffering data.";
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		public List<DC.FacilityWithOffering> GetFacilityWithOfferingByFacilityGuid(Guid personGuid)
		{
			try
			{
				BL.FacilityWithOfferingLogic facilityWithOfferingLogic = new BL.FacilityWithOfferingLogic();
				List<BE.FacilityWithOffering> entities = facilityWithOfferingLogic.GetFacilityWithOfferingByFacilityGuid(personGuid);
				List<DC.FacilityWithOffering> response = entities.ToDataContractList();
				return response;
			}
			catch (Exception ex)
			{
				FC.FacilityOfferingFault fault = new FC.FacilityOfferingFault();
				fault.ErrorMessage = "Unable to retrieve FacilityWithOffering data.";
				throw new FaultException<FC.FacilityOfferingFault>(fault,
					new FaultReason(ex.Message));
			}
		}

		public List<DC.FacilityWithOffering> GetFacilityWithOfferingByOfferingGuid(Guid taskGuid)
		{
			try
			{
				BL.FacilityWithOfferingLogic facilityWithOfferingLogic = new BL.FacilityWithOfferingLogic();
				List<BE.FacilityWithOffering> entities = facilityWithOfferingLogic.GetFacilityWithOfferingByOfferingGuid(taskGuid);
				List<DC.FacilityWithOffering> response = entities.ToDataContractList();
				return response;
			}
			catch (Exception ex)
			{
				FC.FacilityOfferingFault fault = new FC.FacilityOfferingFault();
				fault.ErrorMessage = "Unable to retrieve FacilityWithOffering data.";
				throw new FaultException<FC.FacilityOfferingFault>(fault,
					new FaultReason(ex.Message));
			}
		}

		public void UpdateFacilityWithOffering(DC.FacilityWithOffering request)
		{
			try
			{
				BL.FacilityWithOfferingLogic facilityWithOfferingLogic = new BL.FacilityWithOfferingLogic();
				BE.FacilityWithOffering entity = request.ToBusinessEntity();
				facilityWithOfferingLogic.UpdateFacilityWithOffering(entity);
			}
			catch (BE.FacilityOfferingNotFoundException ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = String.Format("Unable to update FacilityWithOffering data for person '{0}' and '{1}'.",
					request.FacilityGuid.ToString(), request.Offering_OfferingGuid.ToString());
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		#endregion
	}
}