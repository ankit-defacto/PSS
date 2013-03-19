
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

public partial class Facility_Controls_FacilityDetail : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Request.QueryString.Keys.Count == 0)
		{
			this.fvFacility.ChangeMode(FormViewMode.Insert);
		}
		else if (Request.QueryString.Keys.Count == 1)
		{
			this.fvFacility.ChangeMode(FormViewMode.Edit);
		}
		// Performing an insert with url parameters messes everything up. This redirects back to itself without any parameters.
		else if (Request.QueryString.Keys.Count >= 1 && fvFacility.CurrentMode == FormViewMode.Insert)
		{
			this.Response.Redirect("~/Facility/FacilityDetail.aspx", false);
		}
		else
		{
			this.fvFacility.ChangeMode(FormViewMode.Insert);
		}

		fvFacility.ModeChanging += new FormViewModeEventHandler(fvFacility_ModeChanging);
		fvFacility.PreRender += new EventHandler(fvFacility_PreRender);
		fvFacility.ItemInserting += new FormViewInsertEventHandler(fvFacility_ItemInserting);
		fvFacility.ItemUpdating += new FormViewUpdateEventHandler(fvFacility_ItemUpdating);
		fvFacility.ItemDeleted += new FormViewDeletedEventHandler(fvFacility_ItemDeleted);

	}

	void fvFacility_ModeChanging(object sender, FormViewModeEventArgs e)
	{
		if (e.NewMode == FormViewMode.Insert &&
			this.Request.QueryString.Count > 0)
		{
			this.Response.Redirect("~/Facility/FacilityDetail.aspx");
		}
	}

	void fvFacility_PreRender(object sender, EventArgs e)
	{
		// After clicking cancel in Insert mode, this redirects the page back to the grid.
		Label guidFieldLabel = (Label)fvFacility.FindControl("lblFacilityGuid");
		if (null != guidFieldLabel)
		{
			if (guidFieldLabel.Text == Guid.Empty.ToString())
			{
				this.Response.Redirect("~/Facility/FacilityGrid.aspx");
			}
		}

		if (fvFacility.CurrentMode == FormViewMode.Edit)
		{

			ISNet.WebUI.WebCombo.WebCombo cityStateZipWebCombo =
				fvFacility.FindControl("wcCityStateZip") as ISNet.WebUI.WebCombo.WebCombo;
			Label cityStateZipGuidLabel = fvFacility.FindControl("lblCityStateZipGuid") as Label;
			if (cityStateZipWebCombo != null && cityStateZipGuidLabel != null)
				cityStateZipWebCombo.Value = cityStateZipGuidLabel.Text;

			ISNet.WebUI.WebCombo.WebCombo clientWebCombo =
				fvFacility.FindControl("wcClient") as ISNet.WebUI.WebCombo.WebCombo;
			Label clientGuidLabel = fvFacility.FindControl("lblClientGuid") as Label;
			if (clientWebCombo != null && clientGuidLabel != null)
				clientWebCombo.Value = clientGuidLabel.Text;

			ISNet.WebUI.WebCombo.WebCombo listingTypeWebCombo =
				fvFacility.FindControl("wcListingType") as ISNet.WebUI.WebCombo.WebCombo;
			Label listingTypeGuidLabel = fvFacility.FindControl("lblListingTypeGuid") as Label;
			if (listingTypeWebCombo != null && listingTypeGuidLabel != null)
				listingTypeWebCombo.Value = listingTypeGuidLabel.Text;
		}
	}

	void fvFacility_ItemInserting(object sender, FormViewInsertEventArgs e)
	{
		AddInsertParameterValues(e);
	}

	void fvFacility_ItemUpdating(object sender, FormViewUpdateEventArgs e)
	{
		AddUpdateParameterValues(e);
	}

	void fvFacility_ItemDeleted(object sender, FormViewDeletedEventArgs e)
	{
		this.Response.Redirect("~/Facility/FacilityGrid.aspx");
	}

	private void AddInsertParameterValues(FormViewInsertEventArgs e)
	{

		ISNet.WebUI.WebCombo.WebCombo cityStateZipWebCombo =
			fvFacility.FindControl("wcCityStateZip") as ISNet.WebUI.WebCombo.WebCombo;
		e.Values.Add("CityStateZipGuid", cityStateZipWebCombo.SelectedRow.Value);

		ISNet.WebUI.WebCombo.WebCombo clientWebCombo =
			fvFacility.FindControl("wcClient") as ISNet.WebUI.WebCombo.WebCombo;
		e.Values.Add("ClientGuid", clientWebCombo.SelectedRow.Value);

		ISNet.WebUI.WebCombo.WebCombo listingTypeWebCombo =
			fvFacility.FindControl("wcListingType") as ISNet.WebUI.WebCombo.WebCombo;
		e.Values.Add("ListingTypeGuid", listingTypeWebCombo.SelectedRow.Value);
	}

	private void AddUpdateParameterValues(FormViewUpdateEventArgs e)
	{

		ISNet.WebUI.WebCombo.WebCombo cityStateZipWebCombo =
			fvFacility.FindControl("wcCityStateZip") as ISNet.WebUI.WebCombo.WebCombo;
		e.NewValues.Add("CityStateZipGuid", cityStateZipWebCombo.SelectedRow.Value);

		ISNet.WebUI.WebCombo.WebCombo clientWebCombo =
			fvFacility.FindControl("wcClient") as ISNet.WebUI.WebCombo.WebCombo;
		e.NewValues.Add("ClientGuid", clientWebCombo.SelectedRow.Value);

		ISNet.WebUI.WebCombo.WebCombo listingTypeWebCombo =
			fvFacility.FindControl("wcListingType") as ISNet.WebUI.WebCombo.WebCombo;
		e.NewValues.Add("ListingTypeGuid", listingTypeWebCombo.SelectedRow.Value);
	}
}