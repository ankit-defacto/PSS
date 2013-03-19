
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

public partial class FacilityAudit_Controls_FacilityAuditDetail : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Request.QueryString.Keys.Count == 0)
		{
			this.fvFacilityAudit.ChangeMode(FormViewMode.Insert);
		}
		else if (Request.QueryString.Keys.Count == 1)
		{
			this.fvFacilityAudit.ChangeMode(FormViewMode.Edit);
		}
		// Performing an insert with url parameters messes everything up. This redirects back to itself without any parameters.
		else if (Request.QueryString.Keys.Count >= 1 && fvFacilityAudit.CurrentMode == FormViewMode.Insert)
		{
			this.Response.Redirect("~/FacilityAudit/FacilityAuditDetail.aspx", false);
		}
		else
		{
			this.fvFacilityAudit.ChangeMode(FormViewMode.Insert);
		}

		fvFacilityAudit.ModeChanging += new FormViewModeEventHandler(fvFacilityAudit_ModeChanging);
		fvFacilityAudit.PreRender += new EventHandler(fvFacilityAudit_PreRender);
		fvFacilityAudit.ItemInserting += new FormViewInsertEventHandler(fvFacilityAudit_ItemInserting);
		fvFacilityAudit.ItemUpdating += new FormViewUpdateEventHandler(fvFacilityAudit_ItemUpdating);
		fvFacilityAudit.ItemDeleted += new FormViewDeletedEventHandler(fvFacilityAudit_ItemDeleted);

	}

	void fvFacilityAudit_ModeChanging(object sender, FormViewModeEventArgs e)
	{
		if (e.NewMode == FormViewMode.Insert &&
			this.Request.QueryString.Count > 0)
		{
			this.Response.Redirect("~/FacilityAudit/FacilityAuditDetail.aspx");
		}
	}

	void fvFacilityAudit_PreRender(object sender, EventArgs e)
	{
		// After clicking cancel in Insert mode, this redirects the page back to the grid.
		Label guidFieldLabel = (Label)fvFacilityAudit.FindControl("lblFacilityAuditGuid");
		if (null != guidFieldLabel)
		{
			if (guidFieldLabel.Text == Guid.Empty.ToString())
			{
				this.Response.Redirect("~/FacilityAudit/FacilityAuditGrid.aspx");
			}
		}

		if (fvFacilityAudit.CurrentMode == FormViewMode.Edit)
		{

			ISNet.WebUI.WebCombo.WebCombo facilityWebCombo =
				fvFacilityAudit.FindControl("wcFacility") as ISNet.WebUI.WebCombo.WebCombo;
			Label facilityGuidLabel = fvFacilityAudit.FindControl("lblFacilityGuid") as Label;
			if (facilityWebCombo != null && facilityGuidLabel != null)
				facilityWebCombo.Value = facilityGuidLabel.Text;

			ISNet.WebUI.WebCombo.WebCombo cityStateZipWebCombo =
				fvFacilityAudit.FindControl("wcCityStateZip") as ISNet.WebUI.WebCombo.WebCombo;
			Label cityStateZipGuidLabel = fvFacilityAudit.FindControl("lblCityStateZipGuid") as Label;
			if (cityStateZipWebCombo != null && cityStateZipGuidLabel != null)
				cityStateZipWebCombo.Value = cityStateZipGuidLabel.Text;

			ISNet.WebUI.WebCombo.WebCombo clientWebCombo =
				fvFacilityAudit.FindControl("wcClient") as ISNet.WebUI.WebCombo.WebCombo;
			Label clientGuidLabel = fvFacilityAudit.FindControl("lblClientGuid") as Label;
			if (clientWebCombo != null && clientGuidLabel != null)
				clientWebCombo.Value = clientGuidLabel.Text;

			ISNet.WebUI.WebCombo.WebCombo listingTypeWebCombo =
				fvFacilityAudit.FindControl("wcListingType") as ISNet.WebUI.WebCombo.WebCombo;
			Label listingTypeGuidLabel = fvFacilityAudit.FindControl("lblListingTypeGuid") as Label;
			if (listingTypeWebCombo != null && listingTypeGuidLabel != null)
				listingTypeWebCombo.Value = listingTypeGuidLabel.Text;

			ISNet.WebUI.WebControls.WebInput facilityIDWebInput =
				fvFacilityAudit.FindControl("wiFacilityID") as ISNet.WebUI.WebControls.WebInput;
			Label facilityIDLabel = fvFacilityAudit.FindControl("lblFacilityID") as Label;
			if (facilityIDWebInput != null && facilityIDLabel != null)
				facilityIDWebInput.Text = facilityIDLabel.Text;
		}
	}

	void fvFacilityAudit_ItemInserting(object sender, FormViewInsertEventArgs e)
	{
		AddInsertParameterValues(e);
	}

	void fvFacilityAudit_ItemUpdating(object sender, FormViewUpdateEventArgs e)
	{
		AddUpdateParameterValues(e);
	}

	void fvFacilityAudit_ItemDeleted(object sender, FormViewDeletedEventArgs e)
	{
		this.Response.Redirect("~/FacilityAudit/FacilityAuditGrid.aspx");
	}

	private void AddInsertParameterValues(FormViewInsertEventArgs e)
	{

		ISNet.WebUI.WebCombo.WebCombo facilityWebCombo =
			fvFacilityAudit.FindControl("wcFacility") as ISNet.WebUI.WebCombo.WebCombo;
		e.Values.Add("FacilityGuid", facilityWebCombo.SelectedRow.Value);

		ISNet.WebUI.WebCombo.WebCombo cityStateZipWebCombo =
			fvFacilityAudit.FindControl("wcCityStateZip") as ISNet.WebUI.WebCombo.WebCombo;
		e.Values.Add("CityStateZipGuid", cityStateZipWebCombo.SelectedRow.Value);

		ISNet.WebUI.WebCombo.WebCombo clientWebCombo =
			fvFacilityAudit.FindControl("wcClient") as ISNet.WebUI.WebCombo.WebCombo;
		e.Values.Add("ClientGuid", clientWebCombo.SelectedRow.Value);

		ISNet.WebUI.WebCombo.WebCombo listingTypeWebCombo =
			fvFacilityAudit.FindControl("wcListingType") as ISNet.WebUI.WebCombo.WebCombo;
		e.Values.Add("ListingTypeGuid", listingTypeWebCombo.SelectedRow.Value);

		ISNet.WebUI.WebControls.WebInput facilityIDWebInput =
			fvFacilityAudit.FindControl("wiFacilityID") as ISNet.WebUI.WebControls.WebInput;
		e.Values.Add("FacilityID", facilityIDWebInput.Text);
	}

	private void AddUpdateParameterValues(FormViewUpdateEventArgs e)
	{

		ISNet.WebUI.WebCombo.WebCombo facilityWebCombo =
			fvFacilityAudit.FindControl("wcFacility") as ISNet.WebUI.WebCombo.WebCombo;
		e.NewValues.Add("FacilityGuid", facilityWebCombo.SelectedRow.Value);

		ISNet.WebUI.WebCombo.WebCombo cityStateZipWebCombo =
			fvFacilityAudit.FindControl("wcCityStateZip") as ISNet.WebUI.WebCombo.WebCombo;
		e.NewValues.Add("CityStateZipGuid", cityStateZipWebCombo.SelectedRow.Value);

		ISNet.WebUI.WebCombo.WebCombo clientWebCombo =
			fvFacilityAudit.FindControl("wcClient") as ISNet.WebUI.WebCombo.WebCombo;
		e.NewValues.Add("ClientGuid", clientWebCombo.SelectedRow.Value);

		ISNet.WebUI.WebCombo.WebCombo listingTypeWebCombo =
			fvFacilityAudit.FindControl("wcListingType") as ISNet.WebUI.WebCombo.WebCombo;
		e.NewValues.Add("ListingTypeGuid", listingTypeWebCombo.SelectedRow.Value);

		ISNet.WebUI.WebControls.WebInput facilityIDWebInput =
			fvFacilityAudit.FindControl("wiFacilityID") as ISNet.WebUI.WebControls.WebInput;
		e.NewValues.Add("FacilityID", facilityIDWebInput.Text);
	}
}