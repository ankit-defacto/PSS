using System;
using System.ServiceModel;

namespace ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts
{
	/// <summary>
	/// The service contract for an object of a offering that includes the facility identifier.
	/// </summary>
	[ServiceContract(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01", 
		Name = "IOfferingWithFacility", SessionMode = SessionMode.Allowed)]
	public interface IOfferingWithFacility
	{
		/// <summary>
		/// When implemented, gets a list of all offerings that includes its associated facility identifier and related data.
		/// </summary>
		/// <returns>The list of offerings that includes its associated facility identifier and related data.</returns>
		/// <remarks><para>The implementation of this method returns only those offerings who have associations with one or more facilities.
		/// Those offerings who have no association with a facility are not returned.</para>
		/// <para>This represents an operations contract.</para></remarks>
		[FaultContract(typeof(ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts.DefaultFaultContract))]
		[OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false,
		   Action = "GetAllOfferingWithFacility")]
		System.Collections.Generic.List<ConcordMfg.PremierSeniorSolutions.WebService.DataContracts.OfferingWithFacility> GetAllOfferingWithFacility();

		/// <summary>
		/// When implemented, gets a list of offerings that includes its associated facility identifier and related data given a offering identifier.
		/// </summary>
		/// <param name="offeringGuid">Offering Guid</param>
		/// <returns>The list of offerings that includes its associated facility identifier and related data.</returns>
		/// <remarks>This represents an operations contract.</remarks>
		[FaultContract(typeof(ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts.FacilityOfferingFault))]
		[OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, 
			Action = "GetOfferingWithFacilityByOfferingGuid")]
		System.Collections.Generic.List<ConcordMfg.PremierSeniorSolutions.WebService.DataContracts.OfferingWithFacility> GetOfferingWithFacilityByOfferingGuid(Guid offeringGuid);

		/// <summary>
		/// When implemented, gets a list of offerings that includes its associated facility identifier and related data given a facility identifier.
		/// </summary>
		/// <param name="facilityGuid">Facility Guid</param>
		/// <returns>The list of offerings that includes its associated facility identifier and related data.</returns>
		/// <remarks>This represents an operations contract.</remarks>
		[FaultContract(typeof(ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts.FacilityOfferingFault))]
		[OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false,
		   Action = "GetOfferingWithFacilityByFacilityGuid")]
		System.Collections.Generic.List<ConcordMfg.PremierSeniorSolutions.WebService.DataContracts.OfferingWithFacility> GetOfferingWithFacilityByFacilityGuid(Guid facilityGuid);


		/// <summary>
		/// When implement, updates the values associated with the facilityOffering.
		/// </summary>
		/// <param name="offeringWithFacility">The OfferingWithFacility to update.</param>
		[FaultContract(typeof(ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts.DefaultFaultContract))]
		[OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, 
			Action = "UpdateOfferingWithFacility")]
		void UpdateOfferingWithFacility(ConcordMfg.PremierSeniorSolutions.WebService.DataContracts.OfferingWithFacility offeringWithFacility);

	}
}
	