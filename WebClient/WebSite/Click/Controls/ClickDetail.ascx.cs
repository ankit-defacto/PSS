
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

public partial class Click_Controls_ClickDetail : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Request.QueryString.Keys.Count == 0)
		{
			this.fvClick.ChangeMode(FormViewMode.Insert);
		}
		else if (Request.QueryString.Keys.Count == 1)
		{
			this.fvClick.ChangeMode(FormViewMode.Edit);
		}
		// Performing an insert with url parameters messes everything up. This redirects back to itself without any parameters.
		else if (Request.QueryString.Keys.Count >= 1 && fvClick.CurrentMode == FormViewMode.Insert)
		{
			this.Response.Redirect("~/Click/ClickDetail.aspx", false);
		}
		else
		{
			this.fvClick.ChangeMode(FormViewMode.Insert);
		}

		fvClick.ModeChanging += new FormViewModeEventHandler(fvClick_ModeChanging);
		fvClick.PreRender += new EventHandler(fvClick_PreRender);
		fvClick.ItemInserting += new FormViewInsertEventHandler(fvClick_ItemInserting);
		fvClick.ItemUpdating += new FormViewUpdateEventHandler(fvClick_ItemUpdating);
		fvClick.ItemDeleted += new FormViewDeletedEventHandler(fvClick_ItemDeleted);

	}

	void fvClick_ModeChanging(object sender, FormViewModeEventArgs e)
	{
		if (e.NewMode == FormViewMode.Insert &&
			this.Request.QueryString.Count > 0)
		{
			this.Response.Redirect("~/Click/ClickDetail.aspx");
		}
	}

	void fvClick_PreRender(object sender, EventArgs e)
	{
		// After clicking cancel in Insert mode, this redirects the page back to the grid.
		Label guidFieldLabel = (Label)fvClick.FindControl("lblClickGuid");
		if (null != guidFieldLabel)
		{
			if (guidFieldLabel.Text == Guid.Empty.ToString())
			{
				this.Response.Redirect("~/Click/ClickGrid.aspx");
			}
		}

		if (fvClick.CurrentMode == FormViewMode.Edit)
		{

			ISNet.WebUI.WebCombo.WebCombo facilityWebCombo =
				fvClick.FindControl("wcFacility") as ISNet.WebUI.WebCombo.WebCombo;
			Label facilityGuidLabel = fvClick.FindControl("lblFacilityGuid") as Label;
			if (facilityWebCombo != null && facilityGuidLabel != null)
				facilityWebCombo.Value = facilityGuidLabel.Text;

			ISNet.WebUI.WebCombo.WebCombo listingTypeWebCombo =
				fvClick.FindControl("wcListingType") as ISNet.WebUI.WebCombo.WebCombo;
			Label listingTypeGuidLabel = fvClick.FindControl("lblListingTypeGuid") as Label;
			if (listingTypeWebCombo != null && listingTypeGuidLabel != null)
				listingTypeWebCombo.Value = listingTypeGuidLabel.Text;
		}
	}

	void fvClick_ItemInserting(object sender, FormViewInsertEventArgs e)
	{
		AddInsertParameterValues(e);
	}

	void fvClick_ItemUpdating(object sender, FormViewUpdateEventArgs e)
	{
		AddUpdateParameterValues(e);
	}

	void fvClick_ItemDeleted(object sender, FormViewDeletedEventArgs e)
	{
		this.Response.Redirect("~/Click/ClickGrid.aspx");
	}

	private void AddInsertParameterValues(FormViewInsertEventArgs e)
	{

		ISNet.WebUI.WebCombo.WebCombo facilityWebCombo =
			fvClick.FindControl("wcFacility") as ISNet.WebUI.WebCombo.WebCombo;
		e.Values.Add("FacilityGuid", facilityWebCombo.SelectedRow.Value);

		ISNet.WebUI.WebCombo.WebCombo listingTypeWebCombo =
			fvClick.FindControl("wcListingType") as ISNet.WebUI.WebCombo.WebCombo;
		e.Values.Add("ListingTypeGuid", listingTypeWebCombo.SelectedRow.Value);
	}

	private void AddUpdateParameterValues(FormViewUpdateEventArgs e)
	{

		ISNet.WebUI.WebCombo.WebCombo facilityWebCombo =
			fvClick.FindControl("wcFacility") as ISNet.WebUI.WebCombo.WebCombo;
		e.NewValues.Add("FacilityGuid", facilityWebCombo.SelectedRow.Value);

		ISNet.WebUI.WebCombo.WebCombo listingTypeWebCombo =
			fvClick.FindControl("wcListingType") as ISNet.WebUI.WebCombo.WebCombo;
		e.NewValues.Add("ListingTypeGuid", listingTypeWebCombo.SelectedRow.Value);
	}
}