using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts
{

	/// <summary>
	/// Fault Contract Class - FacilityFault
	/// </summary>
	[DataContract(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts/2007/01", Name = "FacilityFault")]
	public partial class FacilityFault
	{
		#region Constructors
		public FacilityFault()
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
		[DataMember(IsRequired = true, Name = "ErrorMessage", Order = 0)]
		public System.String ErrorMessage
		{
			get { return _errorMessage; }
			set { _errorMessage = value; }
		}
		#endregion


		#region Private Fields

		private Guid _facilityGuid;
		private string _errorMessage;
		#endregion
	}
	
}
	