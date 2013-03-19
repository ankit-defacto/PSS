using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts
{

	/// <summary>
	/// Fault Contract Class - CityStateZipFault
	/// </summary>
	[DataContract(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts/2007/01", Name = "CityStateZipFault")]
	public partial class CityStateZipFault
	{
		#region Constructors
		public CityStateZipFault()
		{
		}
		#endregion


		#region Public Properties

		[DataMember(IsRequired = true, Name = "CityStateZipGuid", Order = 0)]
		public Guid CityStateZipGuid
		{
			get { return _cityStateZipGuid; }
			set { _cityStateZipGuid = value; }
		}
		[DataMember(IsRequired = true, Name = "ErrorMessage", Order = 0)]
		public System.String ErrorMessage
		{
			get { return _errorMessage; }
			set { _errorMessage = value; }
		}
		#endregion


		#region Private Fields

		private Guid _cityStateZipGuid;
		private string _errorMessage;
		#endregion
	}
	
}
	