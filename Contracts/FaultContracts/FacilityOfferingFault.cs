using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts
{

	/// <summary>
	/// Fault Contract Class - FacilityOfferingFault
	/// </summary>
	[DataContract(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts/2007/01", Name = "FacilityOfferingFault")]
	public partial class FacilityOfferingFault
	{
		#region Constructors
		public FacilityOfferingFault()
		{
		}
		#endregion


		#region Public Properties

		[DataMember(IsRequired = true, Name = "FacilityGuid", Order = 0)]
		public Guid FacilityGuid
		{
			get { return _facilityGuid; }
			set { _facilityGuid = value; }
		}
		[DataMember(IsRequired = true, Name = "OfferingGuid", Order = 0)]
		public Guid OfferingGuid
		{
			get { return _offeringGuid; }
			set { _offeringGuid = value; }
		}
		[DataMember(IsRequired = true, Name = "ErrorMessage", Order = 0)]
		public System.String ErrorMessage
		{
			get { return _errorMessage; }
			set { _errorMessage = value; }
		}
		#endregion


		#region Private Fields

		private Guid _facilityGuid;
		private Guid _offeringGuid;
		private string _errorMessage;
		#endregion
	}
	
}
	