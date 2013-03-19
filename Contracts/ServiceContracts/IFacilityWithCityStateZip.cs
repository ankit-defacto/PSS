using System;
using System.ServiceModel;

namespace ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts
{
	/// <summary>
	/// The service contract for an object of a facility that includes the cityStateZip identifier.
	/// </summary>
	[ServiceContract(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01", 
		Name = "IFacilityWithCityStateZip", SessionMode = SessionMode.Allowed)]
	public interface IFacilityWithCityStateZip
	{
		/// <summary>
		/// When implemented, gets a list of all facilities that includes its associated cityStateZip identifier and related data.
		/// </summary>
		/// <returns>The list of facilities that includes its associated cityStateZip identifier and related data.</returns>
		/// <remarks><para>The implementation of this method returns only those facilities who have associations with one or more cityStateZips.
		/// Those facilities who have no association with a cityStateZip are not returned.</para>
		/// <para>This represents an operations contract.</para></remarks>
		[FaultContract(typeof(ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts.DefaultFaultContract))]
		[OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false,
		   Action = "GetAllFacilityWithCityStateZip")]
		System.Collections.Generic.List<ConcordMfg.PremierSeniorSolutions.WebService.DataContracts.FacilityWithCityStateZip> GetAllFacilityWithCityStateZip();

		/// <summary>
		/// When implemented, gets a list of facilities that includes its associated cityStateZip identifier and related data given a facility identifier.
		/// </summary>
		/// <param name="facilityGuid">Facility Guid</param>
		/// <returns>The list of facilities that includes its associated cityStateZip identifier and related data.</returns>
		/// <remarks>This represents an operations contract.</remarks>
		[FaultContract(typeof(ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts.FacilityLocationCriteriaFault))]
		[OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, 
			Action = "GetFacilityWithCityStateZipByFacilityGuid")]
		System.Collections.Generic.List<ConcordMfg.PremierSeniorSolutions.WebService.DataContracts.FacilityWithCityStateZip> GetFacilityWithCityStateZipByFacilityGuid(Guid facilityGuid);

		/// <summary>
		/// When implemented, gets a list of facilities that includes its associated cityStateZip identifier and related data given a cityStateZip identifier.
		/// </summary>
		/// <param name="cityStateZipGuid">City State Zip Guid</param>
		/// <returns>The list of facilities that includes its associated cityStateZip identifier and related data.</returns>
		/// <remarks>This represents an operations contract.</remarks>
		[FaultContract(typeof(ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts.FacilityLocationCriteriaFault))]
		[OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false,
		   Action = "GetFacilityWithCityStateZipByCityStateZipGuid")]
		System.Collections.Generic.List<ConcordMfg.PremierSeniorSolutions.WebService.DataContracts.FacilityWithCityStateZip> GetFacilityWithCityStateZipByCityStateZipGuid(Guid cityStateZipGuid);


	}
}
	