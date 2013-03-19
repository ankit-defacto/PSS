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

public partial class CityStateZip_Controls_FacilityWithCityStateZipTab : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
	}

	/// <summary>
	/// Responds to the AddFacilityToCityStateZip click event to add the selected facility to cityStateZips. 
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The event arguments.</param>
	protected void btnAddFacilityToCityStateZip_Click(object sender, EventArgs e)
	{
		this.AddFacilityToCityStateZip();
	}

	private void AddFacilityToCityStateZip()
	{
		Guid cityStateZipGuid = ConcordMfg.PremierSeniorSolutions.Client.Tools.Common.GetID(this.Page, "CityStateZipGuid");
		if (!Guid.Equals(cityStateZipGuid, Guid.Empty) && !(0 == this.wcFacilitiesNotForCityStateZip.Value.Length))
		{
			System.Guid facilityGuid = new Guid(wcFacilitiesNotForCityStateZip.Value);

			DataAccess.AddFacilityToCityStateZip(facilityGuid, cityStateZipGuid);

			wcFacilitiesNotForCityStateZip.Value = string.Empty;
		}
	}

	/// <summary>
	/// Responds to DeleteFacilityFromCityStateZip click event to delete the FacilityLocationCriteria combination.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The event arguments.</param>
	protected void btnDeleteFacilityFromCityStateZip_Click(object sender, EventArgs e)
	{
		this.RemoveFacilityFromCityStateZip();
	}

	private void RemoveFacilityFromCityStateZip()
	{
		foreach (string keyValue in wgFacilityWithCityStateZip.RootTable.GetCheckedRows())
		{
			System.Guid facilityGuid = new Guid(keyValue);
			System.Guid cityStateZipGuid = ConcordMfg.PremierSeniorSolutions.Client.Tools.Common.GetID(this.Page, "CityStateZipGuid");
			if (Guid.Empty != cityStateZipGuid)
			{
				DataAccess.DeleteFacilityFromCityStateZip(cityStateZipGuid, facilityGuid);
			}
		}
	}
}