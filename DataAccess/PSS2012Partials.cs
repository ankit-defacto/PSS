using System;

namespace ConcordMfg.PremierSeniorSolutions.WebService.DataAccess
{
	public partial class CityStateZip
	{
		public override string ToString()
		{
			return this.City;
		}
	}

	public partial class Click
	{
		public override string ToString()
		{
			return this.ClickGuid.ToString();
		}
	}

	public partial class Client
	{
		public override string ToString()
		{
			return this.ClientName;
		}
	}

	public partial class ClientAudit
	{
		public override string ToString()
		{
			return this.ClientName;
		}
	}

	public partial class Facility
	{
		public override string ToString()
		{
			return this.FacilityName;
		}
	}

	public partial class FacilityAudit
	{
		public override string ToString()
		{
			return this.FacilityName;
		}
	}

	public partial class FacilityLocationCriteria
	{
		public override string ToString()
		{
			return this.FacilityGuid.ToString();
		}
	}

	public partial class FacilityOffering
	{
		public override string ToString()
		{
			return this.FacilityGuid.ToString();
		}
	}

	public partial class ListingType
	{
		public override string ToString()
		{
			return this.ListingTypeName;
		}
	}

	public partial class Offering
	{
		public override string ToString()
		{
			return this.OfferingName;
		}
	}

	public partial class PaymentInfo
	{
		public override string ToString()
		{
			return this.AmazonToken;
		}
	}

	public partial class PaymentInfoAudit
	{
		public override string ToString()
		{
			return this.AmazonToken;
		}
	}

	public partial class FacilityPhoto
	{
		public override string ToString()
		{
			return this.PhotoUri;
		}
	}
}