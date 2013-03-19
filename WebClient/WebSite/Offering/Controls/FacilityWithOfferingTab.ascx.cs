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

public partial class Offering_Controls_FacilityWithOfferingTab : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
	}

	/// <summary>
	/// Responds to the AddFacilityToOffering click event to add the selected facility to offerings. 
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The event arguments.</param>
	protected void btnAddFacilityToOffering_Click(object sender, EventArgs e)
	{
		this.AddFacilityToOffering();
	}

	private void AddFacilityToOffering()
	{
		Guid offeringGuid = ConcordMfg.PremierSeniorSolutions.Client.Tools.Common.GetID(this.Page, "OfferingGuid");
		if (!Guid.Equals(offeringGuid, Guid.Empty) && !(0 == this.wcFacilitiesNotForOffering.Value.Length))
		{
			System.Guid facilityGuid = new Guid(wcFacilitiesNotForOffering.Value);
			System.Boolean isChecked = Convert.ToBoolean(wcFacilitiesNotForOffering.Value);

			DataAccess.AddFacilityToOffering(facilityGuid, offeringGuid, isChecked);

			wcFacilitiesNotForOffering.Value = string.Empty;
			txtIsChecked.Text = string.Empty;
		}
	}

	/// <summary>
	/// Responds to DeleteFacilityFromOffering click event to delete the FacilityOffering combination.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The event arguments.</param>
	protected void btnDeleteFacilityFromOffering_Click(object sender, EventArgs e)
	{
		this.RemoveFacilityFromOffering();
	}

	private void RemoveFacilityFromOffering()
	{
		foreach (string keyValue in wgFacilityWithOffering.RootTable.GetCheckedRows())
		{
			System.Guid facilityGuid = new Guid(keyValue);
			System.Guid offeringGuid = ConcordMfg.PremierSeniorSolutions.Client.Tools.Common.GetID(this.Page, "OfferingGuid");
			if (Guid.Empty != offeringGuid)
			{
				DataAccess.DeleteFacilityFromOffering(offeringGuid, facilityGuid);
			}
		}
	}
}