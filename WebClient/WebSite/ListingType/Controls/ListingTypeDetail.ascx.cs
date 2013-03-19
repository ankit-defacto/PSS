
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

public partial class ListingType_Controls_ListingTypeDetail : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Request.QueryString.Keys.Count == 0)
		{
			this.fvListingType.ChangeMode(FormViewMode.Insert);
		}
		else if (Request.QueryString.Keys.Count == 1)
		{
			this.fvListingType.ChangeMode(FormViewMode.Edit);
		}
		// Performing an insert with url parameters messes everything up. This redirects back to itself without any parameters.
		else if (Request.QueryString.Keys.Count >= 1 && fvListingType.CurrentMode == FormViewMode.Insert)
		{
			this.Response.Redirect("~/ListingType/ListingTypeDetail.aspx", false);
		}
		else
		{
			this.fvListingType.ChangeMode(FormViewMode.Insert);
		}

		fvListingType.ModeChanging += new FormViewModeEventHandler(fvListingType_ModeChanging);
		fvListingType.PreRender += new EventHandler(fvListingType_PreRender);
		fvListingType.ItemInserting += new FormViewInsertEventHandler(fvListingType_ItemInserting);
		fvListingType.ItemUpdating += new FormViewUpdateEventHandler(fvListingType_ItemUpdating);
		fvListingType.ItemDeleted += new FormViewDeletedEventHandler(fvListingType_ItemDeleted);

	}

	void fvListingType_ModeChanging(object sender, FormViewModeEventArgs e)
	{
		if (e.NewMode == FormViewMode.Insert &&
			this.Request.QueryString.Count > 0)
		{
			this.Response.Redirect("~/ListingType/ListingTypeDetail.aspx");
		}
	}

	void fvListingType_PreRender(object sender, EventArgs e)
	{
		// After clicking cancel in Insert mode, this redirects the page back to the grid.
		Label guidFieldLabel = (Label)fvListingType.FindControl("lblListingTypeGuid");
		if (null != guidFieldLabel)
		{
			if (guidFieldLabel.Text == Guid.Empty.ToString())
			{
				this.Response.Redirect("~/ListingType/ListingTypeGrid.aspx");
			}
		}

		if (fvListingType.CurrentMode == FormViewMode.Edit)
		{
		}
	}

	void fvListingType_ItemInserting(object sender, FormViewInsertEventArgs e)
	{
		AddInsertParameterValues(e);
	}

	void fvListingType_ItemUpdating(object sender, FormViewUpdateEventArgs e)
	{
		AddUpdateParameterValues(e);
	}

	void fvListingType_ItemDeleted(object sender, FormViewDeletedEventArgs e)
	{
		this.Response.Redirect("~/ListingType/ListingTypeGrid.aspx");
	}

	private void AddInsertParameterValues(FormViewInsertEventArgs e)
	{
	}

	private void AddUpdateParameterValues(FormViewUpdateEventArgs e)
	{
	}
}