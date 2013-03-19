using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts
{

	/// <summary>
	/// Fault Contract Class - PaymentInfoFault
	/// </summary>
	[DataContract(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts/2007/01", Name = "PaymentInfoFault")]
	public partial class PaymentInfoFault
	{
		#region Constructors
		public PaymentInfoFault()
		{
		}
		#endregion


		#region Public Properties

		[DataMember(IsRequired = true, Name = "PaymentInfoGuid", Order = 0)]
		public Guid PaymentInfoGuid
		{
			get { return _paymentInfoGuid; }
			set { _paymentInfoGuid = value; }
		}
		[DataMember(IsRequired = true, Name = "ErrorMessage", Order = 0)]
		public System.String ErrorMessage
		{
			get { return _errorMessage; }
			set { _errorMessage = value; }
		}
		#endregion


		#region Private Fields

		private Guid _paymentInfoGuid;
		private string _errorMessage;
		#endregion
	}
	
}
	