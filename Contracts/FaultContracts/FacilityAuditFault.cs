using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts
{

	/// <summary>
	/// Fault Contract Class - FacilityAuditFault
	/// </summary>
	[DataContract(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts/2007/01", Name = "FacilityAuditFault")]
	public partial class FacilityAuditFault
	{
		#region Constructors
		public FacilityAuditFault()
		{
		}
		#endregion


		#region Public Properties

		[DataMember(IsRequired = true, Name = "FacilityAuditGuid", Order = 0)]
		public Guid FacilityAuditGuid
		{
			get { return _facilityAuditGuid; }
			set { _facilityAuditGuid = value; }
		}
		[DataMember(IsRequired = true, Name = "ErrorMessage", Order = 0)]
		public System.String ErrorMessage
		{
			get { return _errorMessage; }
			set { _errorMessage = value; }
		}
		#endregion


		#region Private Fields

		private Guid _facilityAuditGuid;
		private string _errorMessage;
		#endregion
	}
	
}
	