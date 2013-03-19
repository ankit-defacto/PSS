using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ISNet.WebUI.WebGrid;
using ConcordMfg.PremierSeniorSolutions.Client.ViewModels;

public partial class Facility_Controls_CityStateZipWithFacilityTab : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
	}

	/// <summary>
	/// Responds to the AddCityStateZipToFacility click event to add the selected cityStateZip to facilities. 
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The event arguments.</param>
	protected void btnAddCityStateZipToFacility_Click(object sender, EventArgs e)
	{
		this.AddCityStateZipToFacility();
	}

	private void AddCityStateZipToFacility()
	{
		Guid facilityGuid = ConcordMfg.PremierSeniorSolutions.Client.Tools.Common.GetID(this.Page, "FacilityGuid");
		if (!Guid.Equals(facilityGuid, Guid.Empty) && !(0 == this.wcCityStateZipsNotForFacility.Value.Length))
		{
			System.Guid cityStateZipGuid = new Guid(wcCityStateZipsNotForFacility.Value);

			DataAccess.AddCityStateZipToFacility(facilityGuid, cityStateZipGuid);

			wcCityStateZipsNotForFacility.Value = string.Empty;
		}
	}

	/// <summary>
	/// Responds to DeleteCityStateZipFromFacility click event to delete the FacilityLocationCriteria combination.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The event arguments.</param>
	protected void btnDeleteCityStateZipFromFacility_Click(object sender, EventArgs e)
	{
		this.RemoveCityStateZipFromFacility();
	}

	private void RemoveCityStateZipFromFacility()
	{
		foreach (string keyValue in wgCityStateZipWithFacility.RootTable.GetCheckedRows())
		{
			System.Guid cityStateZipGuid = new Guid(keyValue);
			System.Guid facilityGuid = ConcordMfg.PremierSeniorSolutions.Client.Tools.Common.GetID(this.Page, "FacilityGuid");
			if (Guid.Empty != facilityGuid)
			{
				DataAccess.DeleteCityStateZipFromFacility(facilityGuid, cityStateZipGuid);
			}
		}
	}
}