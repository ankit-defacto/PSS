using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts
{

	/// <summary>
	/// Fault Contract Class - PaymentInfoAuditFault
	/// </summary>
	[DataContract(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts/2007/01", Name = "PaymentInfoAuditFault")]
	public partial class PaymentInfoAuditFault
	{
		#region Constructors
		public PaymentInfoAuditFault()
		{
		}
		#endregion


		#region Public Properties

		[DataMember(IsRequired = true, Name = "PaymentInfoAuditGuid", Order = 0)]
		public Guid PaymentInfoAuditGuid
		{
			get { return _paymentInfoAuditGuid; }
			set { _paymentInfoAuditGuid = value; }
		}
		[DataMember(IsRequired = true, Name = "ErrorMessage", Order = 0)]
		public System.String ErrorMessage
		{
			get { return _errorMessage; }
			set { _errorMessage = value; }
		}
		#endregion


		#region Private Fields

		private Guid _paymentInfoAuditGuid;
		private string _errorMessage;
		#endregion
	}
	
}
	