using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConcordMfg.PremierSeniorSolutions.WebService.BusinessLogic;
using ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;

namespace PSSWebPages.Sketches
{
	public partial class CreateListing : System.Web.UI.Page
	{
		//private Guid ClientGuid { get; set; }

		protected void Page_Load(object sender, EventArgs e)
		{
			this.ParseQueryString();
		}

		protected void submitButton_click(object sender, EventArgs e)
		{
			this.InsertData();
		}

		private void ParseQueryString()
		{
			string query = this.ClientQueryString;
			if (string.IsNullOrEmpty(query))
				return;

			string clientGuidStr = query.Split(new char[] { '?', '&' })[0].Split(new char[] { '=' })[1];
			clientGuidTxt.Text = clientGuidStr;
		}

		private void InsertData()
		{
			CityStateZip csz = new CityStateZip();
			csz.City = facCity.Text;
			csz.State = facState.Text;
			csz.ZipCode = facZipCode.Text;
			CityStateZipLogic cszLogic = new CityStateZipLogic();
			csz = cszLogic.InsertCityStateZip(csz);

			ListingType listingType = new ListingType();
			listingType.ListingTypeName = facListingType.Text;
			ListingTypeLogic ltLogic = new ListingTypeLogic();
			listingType = ltLogic.InsertListingType(listingType);

			Facility facility = new Facility();
			facility.ClientGuid = Guid.Parse(clientGuidTxt.Text);
			facility.FacilityName = facFacilityName.Text;
			facility.Exerpt = facExcerpt.Text;
			facility.Description = facDescription.Text;
			facility.PhoneNumber = facPhoneNumber.Text;
			facility.Address = facAddress.Text;
			facility.CityStateZipGuid = csz.CityStateZipGuid;
			facility.Email = facEmail.Text;
			facility.Website = facWebsite.Text;
			facility.ListingTypeGuid = listingType.ListingTypeGuid;
			facility.PublicPhotoFileUri = facPhotoUri.Text;
			FacilityLogic facilityLogic = new FacilityLogic();
			facilityLogic.InsertFacility(facility);
		}
	}
}