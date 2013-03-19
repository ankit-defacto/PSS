using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts
{

	/// <summary>
	/// Fault Contract Class - ClientFault
	/// </summary>
	[DataContract(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts/2007/01", Name = "ClientFault")]
	public partial class ClientFault
	{
		#region Constructors
		public ClientFault()
		{
		}
		#endregion


		#region Public Properties

		[DataMember(IsRequired = true, Name = "ClientGuid", Order = 0)]
		public Guid ClientGuid
		{
			get { return _clientGuid; }
			set { _clientGuid = value; }
		}
		[DataMember(IsRequired = true, Name = "ErrorMessage", Order = 0)]
		public System.String ErrorMessage
		{
			get { return _errorMessage; }
			set { _errorMessage = value; }
		}
		#endregion


		#region Private Fields

		private Guid _clientGuid;
		private string _errorMessage;
		#endregion
	}
	
}
	