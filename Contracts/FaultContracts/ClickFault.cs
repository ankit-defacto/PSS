using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts
{

	/// <summary>
	/// Fault Contract Class - ClickFault
	/// </summary>
	[DataContract(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts/2007/01", Name = "ClickFault")]
	public partial class ClickFault
	{
		#region Constructors
		public ClickFault()
		{
		}
		#endregion


		#region Public Properties

		[DataMember(IsRequired = true, Name = "ClickGuid", Order = 0)]
		public Guid ClickGuid
		{
			get { return _clickGuid; }
			set { _clickGuid = value; }
		}
		[DataMember(IsRequired = true, Name = "ErrorMessage", Order = 0)]
		public System.String ErrorMessage
		{
			get { return _errorMessage; }
			set { _errorMessage = value; }
		}
		#endregion


		#region Private Fields

		private Guid _clickGuid;
		private string _errorMessage;
		#endregion
	}
	
}
	