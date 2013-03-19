
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

public partial class CityStateZip_Controls_CityStateZipDetail : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Request.QueryString.Keys.Count == 0)
		{
			this.fvCityStateZip.ChangeMode(FormViewMode.Insert);
		}
		else if (Request.QueryString.Keys.Count == 1)
		{
			this.fvCityStateZip.ChangeMode(FormViewMode.Edit);
		}
		// Performing an insert with url parameters messes everything up. This redirects back to itself without any parameters.
		else if (Request.QueryString.Keys.Count >= 1 && fvCityStateZip.CurrentMode == FormViewMode.Insert)
		{
			this.Response.Redirect("~/CityStateZip/CityStateZipDetail.aspx", false);
		}
		else
		{
			this.fvCityStateZip.ChangeMode(FormViewMode.Insert);
		}

		fvCityStateZip.ModeChanging += new FormViewModeEventHandler(fvCityStateZip_ModeChanging);
		fvCityStateZip.PreRender += new EventHandler(fvCityStateZip_PreRender);
		fvCityStateZip.ItemInserting += new FormViewInsertEventHandler(fvCityStateZip_ItemInserting);
		fvCityStateZip.ItemUpdating += new FormViewUpdateEventHandler(fvCityStateZip_ItemUpdating);
		fvCityStateZip.ItemDeleted += new FormViewDeletedEventHandler(fvCityStateZip_ItemDeleted);

	}

	void fvCityStateZip_ModeChanging(object sender, FormViewModeEventArgs e)
	{
		if (e.NewMode == FormViewMode.Insert &&
			this.Request.QueryString.Count > 0)
		{
			this.Response.Redirect("~/CityStateZip/CityStateZipDetail.aspx");
		}
	}

	void fvCityStateZip_PreRender(object sender, EventArgs e)
	{
		// After clicking cancel in Insert mode, this redirects the page back to the grid.
		Label guidFieldLabel = (Label)fvCityStateZip.FindControl("lblCityStateZipGuid");
		if (null != guidFieldLabel)
		{
			if (guidFieldLabel.Text == Guid.Empty.ToString())
			{
				this.Response.Redirect("~/CityStateZip/CityStateZipGrid.aspx");
			}
		}

		if (fvCityStateZip.CurrentMode == FormViewMode.Edit)
		{
		}
	}

	void fvCityStateZip_ItemInserting(object sender, FormViewInsertEventArgs e)
	{
		AddInsertParameterValues(e);
	}

	void fvCityStateZip_ItemUpdating(object sender, FormViewUpdateEventArgs e)
	{
		AddUpdateParameterValues(e);
	}

	void fvCityStateZip_ItemDeleted(object sender, FormViewDeletedEventArgs e)
	{
		this.Response.Redirect("~/CityStateZip/CityStateZipGrid.aspx");
	}

	private void AddInsertParameterValues(FormViewInsertEventArgs e)
	{
	}

	private void AddUpdateParameterValues(FormViewUpdateEventArgs e)
	{
	}
}