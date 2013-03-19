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
	[ServiceBehavior(Name = "CityStateZipWithFacility", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01")]
	class CityStateZipWithFacility : SC.ICityStateZipWithFacility
	{
		#region ICityStateZipWithFacility Members

		public List<DC.CityStateZipWithFacility> GetAllCityStateZipWithFacility()
		{
			try
			{
				BL.CityStateZipWithFacilityLogic cityStateZipWithFacilityLogic = new BL.CityStateZipWithFacilityLogic();
				List<BE.CityStateZipWithFacility> entities = cityStateZipWithFacilityLogic.GetAllCityStateZipWithFacility();
				List<DC.CityStateZipWithFacility> response = entities.ToDataContractList();
				return response;
			}
			catch (Exception ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = "Unable to retrieve CityStateZipWithFacility data.";
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		public List<DC.CityStateZipWithFacility> GetCityStateZipWithFacilityByCityStateZipGuid(Guid personGuid)
		{
			try
			{
				BL.CityStateZipWithFacilityLogic cityStateZipWithFacilityLogic = new BL.CityStateZipWithFacilityLogic();
				List<BE.CityStateZipWithFacility> entities = cityStateZipWithFacilityLogic.GetCityStateZipWithFacilityByCityStateZipGuid(personGuid);
				List<DC.CityStateZipWithFacility> response = entities.ToDataContractList();
				return response;
			}
			catch (Exception ex)
			{
				FC.FacilityLocationCriteriaFault fault = new FC.FacilityLocationCriteriaFault();
				fault.ErrorMessage = "Unable to retrieve CityStateZipWithFacility data.";
				throw new FaultException<FC.FacilityLocationCriteriaFault>(fault,
					new FaultReason(ex.Message));
			}
		}

		public List<DC.CityStateZipWithFacility> GetCityStateZipWithFacilityByFacilityGuid(Guid taskGuid)
		{
			try
			{
				BL.CityStateZipWithFacilityLogic cityStateZipWithFacilityLogic = new BL.CityStateZipWithFacilityLogic();
				List<BE.CityStateZipWithFacility> entities = cityStateZipWithFacilityLogic.GetCityStateZipWithFacilityByFacilityGuid(taskGuid);
				List<DC.CityStateZipWithFacility> response = entities.ToDataContractList();
				return response;
			}
			catch (Exception ex)
			{
				FC.FacilityLocationCriteriaFault fault = new FC.FacilityLocationCriteriaFault();
				fault.ErrorMessage = "Unable to retrieve CityStateZipWithFacility data.";
				throw new FaultException<FC.FacilityLocationCriteriaFault>(fault,
					new FaultReason(ex.Message));
			}
		}

		public void UpdateCityStateZipWithFacility(DC.CityStateZipWithFacility request)
		{
			try
			{
				BL.CityStateZipWithFacilityLogic cityStateZipWithFacilityLogic = new BL.CityStateZipWithFacilityLogic();
				BE.CityStateZipWithFacility entity = request.ToBusinessEntity();
				cityStateZipWithFacilityLogic.UpdateCityStateZipWithFacility(entity);
			}
			catch (BE.FacilityLocationCriteriaNotFoundException ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = String.Format("Unable to update CityStateZipWithFacility data for person '{0}' and '{1}'.",
					request.CityStateZipGuid.ToString(), request.Facility_FacilityGuid.ToString());
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		#endregion
	}
}