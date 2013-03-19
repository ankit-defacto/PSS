using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts
{

	/// <summary>
	/// Fault Contract Class - ListingTypeFault
	/// </summary>
	[DataContract(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts/2007/01", Name = "ListingTypeFault")]
	public partial class ListingTypeFault
	{
		#region Constructors
		public ListingTypeFault()
		{
		}
		#endregion


		#region Public Properties

		[DataMember(IsRequired = true, Name = "ListingTypeGuid", Order = 0)]
		public Guid ListingTypeGuid
		{
			get { return _listingTypeGuid; }
			set { _listingTypeGuid = value; }
		}
		[DataMember(IsRequired = true, Name = "ErrorMessage", Order = 0)]
		public System.String ErrorMessage
		{
			get { return _errorMessage; }
			set { _errorMessage = value; }
		}
		#endregion


		#region Private Fields

		private Guid _listingTypeGuid;
		private string _errorMessage;
		#endregion
	}
	
}
	