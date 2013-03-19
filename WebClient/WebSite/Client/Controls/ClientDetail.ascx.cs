
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

public partial class Client_Controls_ClientDetail : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Request.QueryString.Keys.Count == 0)
		{
			this.fvClient.ChangeMode(FormViewMode.Insert);
		}
		else if (Request.QueryString.Keys.Count == 1)
		{
			this.fvClient.ChangeMode(FormViewMode.Edit);
		}
		// Performing an insert with url parameters messes everything up. This redirects back to itself without any parameters.
		else if (Request.QueryString.Keys.Count >= 1 && fvClient.CurrentMode == FormViewMode.Insert)
		{
			this.Response.Redirect("~/Client/ClientDetail.aspx", false);
		}
		else
		{
			this.fvClient.ChangeMode(FormViewMode.Insert);
		}

		fvClient.ModeChanging += new FormViewModeEventHandler(fvClient_ModeChanging);
		fvClient.PreRender += new EventHandler(fvClient_PreRender);
		fvClient.ItemInserting += new FormViewInsertEventHandler(fvClient_ItemInserting);
		fvClient.ItemUpdating += new FormViewUpdateEventHandler(fvClient_ItemUpdating);
		fvClient.ItemDeleted += new FormViewDeletedEventHandler(fvClient_ItemDeleted);

	}

	void fvClient_ModeChanging(object sender, FormViewModeEventArgs e)
	{
		if (e.NewMode == FormViewMode.Insert &&
			this.Request.QueryString.Count > 0)
		{
			this.Response.Redirect("~/Client/ClientDetail.aspx");
		}
	}

	void fvClient_PreRender(object sender, EventArgs e)
	{
		// After clicking cancel in Insert mode, this redirects the page back to the grid.
		Label guidFieldLabel = (Label)fvClient.FindControl("lblClientGuid");
		if (null != guidFieldLabel)
		{
			if (guidFieldLabel.Text == Guid.Empty.ToString())
			{
				this.Response.Redirect("~/Client/ClientGrid.aspx");
			}
		}

		if (fvClient.CurrentMode == FormViewMode.Edit)
		{

			ISNet.WebUI.WebCombo.WebCombo cityStateZipWebCombo =
				fvClient.FindControl("wcCityStateZip") as ISNet.WebUI.WebCombo.WebCombo;
			Label cityStateZipGuidLabel = fvClient.FindControl("lblCityStateZipGuid") as Label;
			if (cityStateZipWebCombo != null && cityStateZipGuidLabel != null)
				cityStateZipWebCombo.Value = cityStateZipGuidLabel.Text;

			ISNet.WebUI.WebCombo.WebCombo paymentInfoWebCombo =
				fvClient.FindControl("wcPaymentInfo") as ISNet.WebUI.WebCombo.WebCombo;
			Label paymentInfoGuidLabel = fvClient.FindControl("lblPaymentInfoGuid") as Label;
			if (paymentInfoWebCombo != null && paymentInfoGuidLabel != null)
				paymentInfoWebCombo.Value = paymentInfoGuidLabel.Text;
		}
	}

	void fvClient_ItemInserting(object sender, FormViewInsertEventArgs e)
	{
		AddInsertParameterValues(e);
	}

	void fvClient_ItemUpdating(object sender, FormViewUpdateEventArgs e)
	{
		AddUpdateParameterValues(e);
	}

	void fvClient_ItemDeleted(object sender, FormViewDeletedEventArgs e)
	{
		this.Response.Redirect("~/Client/ClientGrid.aspx");
	}

	private void AddInsertParameterValues(FormViewInsertEventArgs e)
	{

		ISNet.WebUI.WebCombo.WebCombo cityStateZipWebCombo =
			fvClient.FindControl("wcCityStateZip") as ISNet.WebUI.WebCombo.WebCombo;
		e.Values.Add("CityStateZipGuid", cityStateZipWebCombo.SelectedRow.Value);

		ISNet.WebUI.WebCombo.WebCombo paymentInfoWebCombo =
			fvClient.FindControl("wcPaymentInfo") as ISNet.WebUI.WebCombo.WebCombo;
		e.Values.Add("PaymentInfoGuid", paymentInfoWebCombo.SelectedRow.Value);
	}

	private void AddUpdateParameterValues(FormViewUpdateEventArgs e)
	{

		ISNet.WebUI.WebCombo.WebCombo cityStateZipWebCombo =
			fvClient.FindControl("wcCityStateZip") as ISNet.WebUI.WebCombo.WebCombo;
		e.NewValues.Add("CityStateZipGuid", cityStateZipWebCombo.SelectedRow.Value);

		ISNet.WebUI.WebCombo.WebCombo paymentInfoWebCombo =
			fvClient.FindControl("wcPaymentInfo") as ISNet.WebUI.WebCombo.WebCombo;
		e.NewValues.Add("PaymentInfoGuid", paymentInfoWebCombo.SelectedRow.Value);
	}
}