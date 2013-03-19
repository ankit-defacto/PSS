using System;
using System.ServiceModel;

namespace ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts
{
	/// <summary>
	/// The service contract for an object of a facility that includes the offering identifier.
	/// </summary>
	[ServiceContract(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01", 
		Name = "IFacilityWithOffering", SessionMode = SessionMode.Allowed)]
	public interface IFacilityWithOffering
	{
		/// <summary>
		/// When implemented, gets a list of all facilities that includes its associated offering identifier and related data.
		/// </summary>
		/// <returns>The list of facilities that includes its associated offering identifier and related data.</returns>
		/// <remarks><para>The implementation of this method returns only those facilities who have associations with one or more offerings.
		/// Those facilities who have no association with a offering are not returned.</para>
		/// <para>This represents an operations contract.</para></remarks>
		[FaultContract(typeof(ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts.DefaultFaultContract))]
		[OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false,
		   Action = "GetAllFacilityWithOffering")]
		System.Collections.Generic.List<ConcordMfg.PremierSeniorSolutions.WebService.DataContracts.FacilityWithOffering> GetAllFacilityWithOffering();

		/// <summary>
		/// When implemented, gets a list of facilities that includes its associated offering identifier and related data given a facility identifier.
		/// </summary>
		/// <param name="facilityGuid">Facility Guid</param>
		/// <returns>The list of facilities that includes its associated offering identifier and related data.</returns>
		/// <remarks>This represents an operations contract.</remarks>
		[FaultContract(typeof(ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts.FacilityOfferingFault))]
		[OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, 
			Action = "GetFacilityWithOfferingByFacilityGuid")]
		System.Collections.Generic.List<ConcordMfg.PremierSeniorSolutions.WebService.DataContracts.FacilityWithOffering> GetFacilityWithOfferingByFacilityGuid(Guid facilityGuid);

		/// <summary>
		/// When implemented, gets a list of facilities that includes its associated offering identifier and related data given a offering identifier.
		/// </summary>
		/// <param name="offeringGuid">Offering Guid</param>
		/// <returns>The list of facilities that includes its associated offering identifier and related data.</returns>
		/// <remarks>This represents an operations contract.</remarks>
		[FaultContract(typeof(ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts.FacilityOfferingFault))]
		[OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false,
		   Action = "GetFacilityWithOfferingByOfferingGuid")]
		System.Collections.Generic.List<ConcordMfg.PremierSeniorSolutions.WebService.DataContracts.FacilityWithOffering> GetFacilityWithOfferingByOfferingGuid(Guid offeringGuid);


		/// <summary>
		/// When implement, updates the values associated with the facilityOffering.
		/// </summary>
		/// <param name="facilityWithOffering">The FacilityWithOffering to update.</param>
		[FaultContract(typeof(ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts.DefaultFaultContract))]
		[OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, 
			Action = "UpdateFacilityWithOffering")]
		void UpdateFacilityWithOffering(ConcordMfg.PremierSeniorSolutions.WebService.DataContracts.FacilityWithOffering facilityWithOffering);

	}
}
	