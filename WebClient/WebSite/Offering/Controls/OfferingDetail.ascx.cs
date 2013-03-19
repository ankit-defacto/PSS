
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

public partial class Offering_Controls_OfferingDetail : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Request.QueryString.Keys.Count == 0)
		{
			this.fvOffering.ChangeMode(FormViewMode.Insert);
		}
		else if (Request.QueryString.Keys.Count == 1)
		{
			this.fvOffering.ChangeMode(FormViewMode.Edit);
		}
		// Performing an insert with url parameters messes everything up. This redirects back to itself without any parameters.
		else if (Request.QueryString.Keys.Count >= 1 && fvOffering.CurrentMode == FormViewMode.Insert)
		{
			this.Response.Redirect("~/Offering/OfferingDetail.aspx", false);
		}
		else
		{
			this.fvOffering.ChangeMode(FormViewMode.Insert);
		}

		fvOffering.ModeChanging += new FormViewModeEventHandler(fvOffering_ModeChanging);
		fvOffering.PreRender += new EventHandler(fvOffering_PreRender);
		fvOffering.ItemInserting += new FormViewInsertEventHandler(fvOffering_ItemInserting);
		fvOffering.ItemUpdating += new FormViewUpdateEventHandler(fvOffering_ItemUpdating);
		fvOffering.ItemDeleted += new FormViewDeletedEventHandler(fvOffering_ItemDeleted);

	}

	void fvOffering_ModeChanging(object sender, FormViewModeEventArgs e)
	{
		if (e.NewMode == FormViewMode.Insert &&
			this.Request.QueryString.Count > 0)
		{
			this.Response.Redirect("~/Offering/OfferingDetail.aspx");
		}
	}

	void fvOffering_PreRender(object sender, EventArgs e)
	{
		// After clicking cancel in Insert mode, this redirects the page back to the grid.
		Label guidFieldLabel = (Label)fvOffering.FindControl("lblOfferingGuid");
		if (null != guidFieldLabel)
		{
			if (guidFieldLabel.Text == Guid.Empty.ToString())
			{
				this.Response.Redirect("~/Offering/OfferingGrid.aspx");
			}
		}

		if (fvOffering.CurrentMode == FormViewMode.Edit)
		{
		}
	}

	void fvOffering_ItemInserting(object sender, FormViewInsertEventArgs e)
	{
		AddInsertParameterValues(e);
	}

	void fvOffering_ItemUpdating(object sender, FormViewUpdateEventArgs e)
	{
		AddUpdateParameterValues(e);
	}

	void fvOffering_ItemDeleted(object sender, FormViewDeletedEventArgs e)
	{
		this.Response.Redirect("~/Offering/OfferingGrid.aspx");
	}

	private void AddInsertParameterValues(FormViewInsertEventArgs e)
	{
	}

	private void AddUpdateParameterValues(FormViewUpdateEventArgs e)
	{
	}
}