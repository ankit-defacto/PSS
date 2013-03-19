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
	[ServiceBehavior(Name = "FacilityWithCityStateZip", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01")]
	class FacilityWithCityStateZip : SC.IFacilityWithCityStateZip
	{
		#region IFacilityWithCityStateZip Members

		public List<DC.FacilityWithCityStateZip> GetAllFacilityWithCityStateZip()
		{
			try
			{
				BL.FacilityWithCityStateZipLogic facilityWithCityStateZipLogic = new BL.FacilityWithCityStateZipLogic();
				List<BE.FacilityWithCityStateZip> entities = facilityWithCityStateZipLogic.GetAllFacilityWithCityStateZip();
				List<DC.FacilityWithCityStateZip> response = entities.ToDataContractList();
				return response;
			}
			catch (Exception ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = "Unable to retrieve FacilityWithCityStateZip data.";
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		public List<DC.FacilityWithCityStateZip> GetFacilityWithCityStateZipByFacilityGuid(Guid personGuid)
		{
			try
			{
				BL.FacilityWithCityStateZipLogic facilityWithCityStateZipLogic = new BL.FacilityWithCityStateZipLogic();
				List<BE.FacilityWithCityStateZip> entities = facilityWithCityStateZipLogic.GetFacilityWithCityStateZipByFacilityGuid(personGuid);
				List<DC.FacilityWithCityStateZip> response = entities.ToDataContractList();
				return response;
			}
			catch (Exception ex)
			{
				FC.FacilityLocationCriteriaFault fault = new FC.FacilityLocationCriteriaFault();
				fault.ErrorMessage = "Unable to retrieve FacilityWithCityStateZip data.";
				throw new FaultException<FC.FacilityLocationCriteriaFault>(fault,
					new FaultReason(ex.Message));
			}
		}

		public List<DC.FacilityWithCityStateZip> GetFacilityWithCityStateZipByCityStateZipGuid(Guid taskGuid)
		{
			try
			{
				BL.FacilityWithCityStateZipLogic facilityWithCityStateZipLogic = new BL.FacilityWithCityStateZipLogic();
				List<BE.FacilityWithCityStateZip> entities = facilityWithCityStateZipLogic.GetFacilityWithCityStateZipByCityStateZipGuid(taskGuid);
				List<DC.FacilityWithCityStateZip> response = entities.ToDataContractList();
				return response;
			}
			catch (Exception ex)
			{
				FC.FacilityLocationCriteriaFault fault = new FC.FacilityLocationCriteriaFault();
				fault.ErrorMessage = "Unable to retrieve FacilityWithCityStateZip data.";
				throw new FaultException<FC.FacilityLocationCriteriaFault>(fault,
					new FaultReason(ex.Message));
			}
		}

		public void UpdateFacilityWithCityStateZip(DC.FacilityWithCityStateZip request)
		{
			try
			{
				BL.FacilityWithCityStateZipLogic facilityWithCityStateZipLogic = new BL.FacilityWithCityStateZipLogic();
				BE.FacilityWithCityStateZip entity = request.ToBusinessEntity();
				facilityWithCityStateZipLogic.UpdateFacilityWithCityStateZip(entity);
			}
			catch (BE.FacilityLocationCriteriaNotFoundException ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = String.Format("Unable to update FacilityWithCityStateZip data for person '{0}' and '{1}'.",
					request.FacilityGuid.ToString(), request.CityStateZip_CityStateZipGuid.ToString());
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		#endregion
	}
}