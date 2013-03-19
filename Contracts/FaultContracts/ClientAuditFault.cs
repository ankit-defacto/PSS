using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts
{

	/// <summary>
	/// Fault Contract Class - ClientAuditFault
	/// </summary>
	[DataContract(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts/2007/01", Name = "ClientAuditFault")]
	public partial class ClientAuditFault
	{
		#region Constructors
		public ClientAuditFault()
		{
		}
		#endregion


		#region Public Properties

		[DataMember(IsRequired = true, Name = "ClientAuditGuid", Order = 0)]
		public Guid ClientAuditGuid
		{
			get { return _clientAuditGuid; }
			set { _clientAuditGuid = value; }
		}
		[DataMember(IsRequired = true, Name = "ErrorMessage", Order = 0)]
		public System.String ErrorMessage
		{
			get { return _errorMessage; }
			set { _errorMessage = value; }
		}
		#endregion


		#region Private Fields

		private Guid _clientAuditGuid;
		private string _errorMessage;
		#endregion
	}
	
}
	