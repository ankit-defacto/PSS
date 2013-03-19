
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

public partial class FacilityPhoto_Controls_FacilityPhotoDetail : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Request.QueryString.Keys.Count == 0)
		{
			this.fvFacilityPhoto.ChangeMode(FormViewMode.Insert);
		}
		else if (Request.QueryString.Keys.Count == 1)
		{
			this.fvFacilityPhoto.ChangeMode(FormViewMode.Edit);
		}
		// Performing an insert with url parameters messes everything up. This redirects back to itself without any parameters.
		else if (Request.QueryString.Keys.Count >= 1 && fvFacilityPhoto.CurrentMode == FormViewMode.Insert)
		{
			this.Response.Redirect("~/FacilityPhoto/FacilityPhotoDetail.aspx", false);
		}
		else
		{
			this.fvFacilityPhoto.ChangeMode(FormViewMode.Insert);
		}

		fvFacilityPhoto.ModeChanging += new FormViewModeEventHandler(fvFacilityPhoto_ModeChanging);
		fvFacilityPhoto.PreRender += new EventHandler(fvFacilityPhoto_PreRender);
		fvFacilityPhoto.ItemInserting += new FormViewInsertEventHandler(fvFacilityPhoto_ItemInserting);
		fvFacilityPhoto.ItemUpdating += new FormViewUpdateEventHandler(fvFacilityPhoto_ItemUpdating);
		fvFacilityPhoto.ItemDeleted += new FormViewDeletedEventHandler(fvFacilityPhoto_ItemDeleted);

	}

	void fvFacilityPhoto_ModeChanging(object sender, FormViewModeEventArgs e)
	{
		if (e.NewMode == FormViewMode.Insert &&
			this.Request.QueryString.Count > 0)
		{
			this.Response.Redirect("~/FacilityPhoto/FacilityPhotoDetail.aspx");
		}
	}

	void fvFacilityPhoto_PreRender(object sender, EventArgs e)
	{
		// After clicking cancel in Insert mode, this redirects the page back to the grid.
		Label guidFieldLabel = (Label)fvFacilityPhoto.FindControl("lblFacilityPhotoGuid");
		if (null != guidFieldLabel)
		{
			if (guidFieldLabel.Text == Guid.Empty.ToString())
			{
				this.Response.Redirect("~/FacilityPhoto/FacilityPhotoGrid.aspx");
			}
		}

		if (fvFacilityPhoto.CurrentMode == FormViewMode.Edit)
		{

			ISNet.WebUI.WebCombo.WebCombo facilityWebCombo =
				fvFacilityPhoto.FindControl("wcFacility") as ISNet.WebUI.WebCombo.WebCombo;
			Label facilityGuidLabel = fvFacilityPhoto.FindControl("lblFacilityGuid") as Label;
			if (facilityWebCombo != null && facilityGuidLabel != null)
				facilityWebCombo.Value = facilityGuidLabel.Text;
		}
	}

	void fvFacilityPhoto_ItemInserting(object sender, FormViewInsertEventArgs e)
	{
		AddInsertParameterValues(e);
	}

	void fvFacilityPhoto_ItemUpdating(object sender, FormViewUpdateEventArgs e)
	{
		AddUpdateParameterValues(e);
	}

	void fvFacilityPhoto_ItemDeleted(object sender, FormViewDeletedEventArgs e)
	{
		this.Response.Redirect("~/FacilityPhoto/FacilityPhotoGrid.aspx");
	}

	private void AddInsertParameterValues(FormViewInsertEventArgs e)
	{

		ISNet.WebUI.WebCombo.WebCombo facilityWebCombo =
			fvFacilityPhoto.FindControl("wcFacility") as ISNet.WebUI.WebCombo.WebCombo;
		e.Values.Add("FacilityGuid", facilityWebCombo.SelectedRow.Value);
	}

	private void AddUpdateParameterValues(FormViewUpdateEventArgs e)
	{

		ISNet.WebUI.WebCombo.WebCombo facilityWebCombo =
			fvFacilityPhoto.FindControl("wcFacility") as ISNet.WebUI.WebCombo.WebCombo;
		e.NewValues.Add("FacilityGuid", facilityWebCombo.SelectedRow.Value);
	}
}