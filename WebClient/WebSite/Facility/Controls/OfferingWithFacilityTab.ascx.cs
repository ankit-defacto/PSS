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

public partial class Facility_Controls_OfferingWithFacilityTab : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
	}

	/// <summary>
	/// Responds to the AddOfferingToFacility click event to add the selected offering to facilities. 
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The event arguments.</param>
	protected void btnAddOfferingToFacility_Click(object sender, EventArgs e)
	{
		this.AddOfferingToFacility();
	}

	private void AddOfferingToFacility()
	{
		Guid facilityGuid = ConcordMfg.PremierSeniorSolutions.Client.Tools.Common.GetID(this.Page, "FacilityGuid");
		if (!Guid.Equals(facilityGuid, Guid.Empty) && !(0 == this.wcOfferingsNotForFacility.Value.Length))
		{
			System.Guid offeringGuid = new Guid(wcOfferingsNotForFacility.Value);
			System.Boolean isChecked = Convert.ToBoolean(wcOfferingsNotForFacility.Value);

			DataAccess.AddOfferingToFacility(facilityGuid, offeringGuid, isChecked);

			wcOfferingsNotForFacility.Value = string.Empty;
			txtIsChecked.Text = string.Empty;
		}
	}

	/// <summary>
	/// Responds to DeleteOfferingFromFacility click event to delete the FacilityOffering combination.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The event arguments.</param>
	protected void btnDeleteOfferingFromFacility_Click(object sender, EventArgs e)
	{
		this.RemoveOfferingFromFacility();
	}

	private void RemoveOfferingFromFacility()
	{
		foreach (string keyValue in wgOfferingWithFacility.RootTable.GetCheckedRows())
		{
			System.Guid offeringGuid = new Guid(keyValue);
			System.Guid facilityGuid = ConcordMfg.PremierSeniorSolutions.Client.Tools.Common.GetID(this.Page, "FacilityGuid");
			if (Guid.Empty != facilityGuid)
			{
				DataAccess.DeleteOfferingFromFacility(facilityGuid, offeringGuid);
			}
		}
	}
}