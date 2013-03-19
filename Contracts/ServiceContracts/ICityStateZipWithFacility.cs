using System;
using System.ServiceModel;

namespace ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts
{
	/// <summary>
	/// The service contract for an object of a cityStateZip that includes the facility identifier.
	/// </summary>
	[ServiceContract(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01", 
		Name = "ICityStateZipWithFacility", SessionMode = SessionMode.Allowed)]
	public interface ICityStateZipWithFacility
	{
		/// <summary>
		/// When implemented, gets a list of all cityStateZips that includes its associated facility identifier and related data.
		/// </summary>
		/// <returns>The list of cityStateZips that includes its associated facility identifier and related data.</returns>
		/// <remarks><para>The implementation of this method returns only those cityStateZips who have associations with one or more facilities.
		/// Those cityStateZips who have no association with a facility are not returned.</para>
		/// <para>This represents an operations contract.</para></remarks>
		[FaultContract(typeof(ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts.DefaultFaultContract))]
		[OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false,
		   Action = "GetAllCityStateZipWithFacility")]
		System.Collections.Generic.List<ConcordMfg.PremierSeniorSolutions.WebService.DataContracts.CityStateZipWithFacility> GetAllCityStateZipWithFacility();

		/// <summary>
		/// When implemented, gets a list of cityStateZips that includes its associated facility identifier and related data given a cityStateZip identifier.
		/// </summary>
		/// <param name="cityStateZipGuid">City State Zip Guid</param>
		/// <returns>The list of cityStateZips that includes its associated facility identifier and related data.</returns>
		/// <remarks>This represents an operations contract.</remarks>
		[FaultContract(typeof(ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts.FacilityLocationCriteriaFault))]
		[OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, 
			Action = "GetCityStateZipWithFacilityByCityStateZipGuid")]
		System.Collections.Generic.List<ConcordMfg.PremierSeniorSolutions.WebService.DataContracts.CityStateZipWithFacility> GetCityStateZipWithFacilityByCityStateZipGuid(Guid cityStateZipGuid);

		/// <summary>
		/// When implemented, gets a list of cityStateZips that includes its associated facility identifier and related data given a facility identifier.
		/// </summary>
		/// <param name="facilityGuid">Facility Guid</param>
		/// <returns>The list of cityStateZips that includes its associated facility identifier and related data.</returns>
		/// <remarks>This represents an operations contract.</remarks>
		[FaultContract(typeof(ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts.FacilityLocationCriteriaFault))]
		[OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false,
		   Action = "GetCityStateZipWithFacilityByFacilityGuid")]
		System.Collections.Generic.List<ConcordMfg.PremierSeniorSolutions.WebService.DataContracts.CityStateZipWithFacility> GetCityStateZipWithFacilityByFacilityGuid(Guid facilityGuid);


	}
}
	