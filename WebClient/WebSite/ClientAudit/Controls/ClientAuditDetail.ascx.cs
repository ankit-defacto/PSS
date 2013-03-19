
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

public partial class ClientAudit_Controls_ClientAuditDetail : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Request.QueryString.Keys.Count == 0)
		{
			this.fvClientAudit.ChangeMode(FormViewMode.Insert);
		}
		else if (Request.QueryString.Keys.Count == 1)
		{
			this.fvClientAudit.ChangeMode(FormViewMode.Edit);
		}
		// Performing an insert with url parameters messes everything up. This redirects back to itself without any parameters.
		else if (Request.QueryString.Keys.Count >= 1 && fvClientAudit.CurrentMode == FormViewMode.Insert)
		{
			this.Response.Redirect("~/ClientAudit/ClientAuditDetail.aspx", false);
		}
		else
		{
			this.fvClientAudit.ChangeMode(FormViewMode.Insert);
		}

		fvClientAudit.ModeChanging += new FormViewModeEventHandler(fvClientAudit_ModeChanging);
		fvClientAudit.PreRender += new EventHandler(fvClientAudit_PreRender);
		fvClientAudit.ItemInserting += new FormViewInsertEventHandler(fvClientAudit_ItemInserting);
		fvClientAudit.ItemUpdating += new FormViewUpdateEventHandler(fvClientAudit_ItemUpdating);
		fvClientAudit.ItemDeleted += new FormViewDeletedEventHandler(fvClientAudit_ItemDeleted);

	}

	void fvClientAudit_ModeChanging(object sender, FormViewModeEventArgs e)
	{
		if (e.NewMode == FormViewMode.Insert &&
			this.Request.QueryString.Count > 0)
		{
			this.Response.Redirect("~/ClientAudit/ClientAuditDetail.aspx");
		}
	}

	void fvClientAudit_PreRender(object sender, EventArgs e)
	{
		// After clicking cancel in Insert mode, this redirects the page back to the grid.
		Label guidFieldLabel = (Label)fvClientAudit.FindControl("lblClientAuditGuid");
		if (null != guidFieldLabel)
		{
			if (guidFieldLabel.Text == Guid.Empty.ToString())
			{
				this.Response.Redirect("~/ClientAudit/ClientAuditGrid.aspx");
			}
		}

		if (fvClientAudit.CurrentMode == FormViewMode.Edit)
		{

			ISNet.WebUI.WebCombo.WebCombo clientWebCombo =
				fvClientAudit.FindControl("wcClient") as ISNet.WebUI.WebCombo.WebCombo;
			Label clientGuidLabel = fvClientAudit.FindControl("lblClientGuid") as Label;
			if (clientWebCombo != null && clientGuidLabel != null)
				clientWebCombo.Value = clientGuidLabel.Text;

			ISNet.WebUI.WebCombo.WebCombo cityStateZipWebCombo =
				fvClientAudit.FindControl("wcCityStateZip") as ISNet.WebUI.WebCombo.WebCombo;
			Label cityStateZipGuidLabel = fvClientAudit.FindControl("lblCityStateZipGuid") as Label;
			if (cityStateZipWebCombo != null && cityStateZipGuidLabel != null)
				cityStateZipWebCombo.Value = cityStateZipGuidLabel.Text;

			ISNet.WebUI.WebCombo.WebCombo paymentInfoWebCombo =
				fvClientAudit.FindControl("wcPaymentInfo") as ISNet.WebUI.WebCombo.WebCombo;
			Label paymentInfoGuidLabel = fvClientAudit.FindControl("lblPaymentInfoGuid") as Label;
			if (paymentInfoWebCombo != null && paymentInfoGuidLabel != null)
				paymentInfoWebCombo.Value = paymentInfoGuidLabel.Text;

			ISNet.WebUI.WebControls.WebInput clientIDWebInput =
				fvClientAudit.FindControl("wiClientID") as ISNet.WebUI.WebControls.WebInput;
			Label clientIDLabel = fvClientAudit.FindControl("lblClientID") as Label;
			if (clientIDWebInput != null && clientIDLabel != null)
				clientIDWebInput.Text = clientIDLabel.Text;
		}
	}

	void fvClientAudit_ItemInserting(object sender, FormViewInsertEventArgs e)
	{
		AddInsertParameterValues(e);
	}

	void fvClientAudit_ItemUpdating(object sender, FormViewUpdateEventArgs e)
	{
		AddUpdateParameterValues(e);
	}

	void fvClientAudit_ItemDeleted(object sender, FormViewDeletedEventArgs e)
	{
		this.Response.Redirect("~/ClientAudit/ClientAuditGrid.aspx");
	}

	private void AddInsertParameterValues(FormViewInsertEventArgs e)
	{

		ISNet.WebUI.WebCombo.WebCombo clientWebCombo =
			fvClientAudit.FindControl("wcClient") as ISNet.WebUI.WebCombo.WebCombo;
		e.Values.Add("ClientGuid", clientWebCombo.SelectedRow.Value);

		ISNet.WebUI.WebCombo.WebCombo cityStateZipWebCombo =
			fvClientAudit.FindControl("wcCityStateZip") as ISNet.WebUI.WebCombo.WebCombo;
		e.Values.Add("CityStateZipGuid", cityStateZipWebCombo.SelectedRow.Value);

		ISNet.WebUI.WebCombo.WebCombo paymentInfoWebCombo =
			fvClientAudit.FindControl("wcPaymentInfo") as ISNet.WebUI.WebCombo.WebCombo;
		e.Values.Add("PaymentInfoGuid", paymentInfoWebCombo.SelectedRow.Value);

		ISNet.WebUI.WebControls.WebInput clientIDWebInput =
			fvClientAudit.FindControl("wiClientID") as ISNet.WebUI.WebControls.WebInput;
		e.Values.Add("ClientID", clientIDWebInput.Text);
	}

	private void AddUpdateParameterValues(FormViewUpdateEventArgs e)
	{

		ISNet.WebUI.WebCombo.WebCombo clientWebCombo =
			fvClientAudit.FindControl("wcClient") as ISNet.WebUI.WebCombo.WebCombo;
		e.NewValues.Add("ClientGuid", clientWebCombo.SelectedRow.Value);

		ISNet.WebUI.WebCombo.WebCombo cityStateZipWebCombo =
			fvClientAudit.FindControl("wcCityStateZip") as ISNet.WebUI.WebCombo.WebCombo;
		e.NewValues.Add("CityStateZipGuid", cityStateZipWebCombo.SelectedRow.Value);

		ISNet.WebUI.WebCombo.WebCombo paymentInfoWebCombo =
			fvClientAudit.FindControl("wcPaymentInfo") as ISNet.WebUI.WebCombo.WebCombo;
		e.NewValues.Add("PaymentInfoGuid", paymentInfoWebCombo.SelectedRow.Value);

		ISNet.WebUI.WebControls.WebInput clientIDWebInput =
			fvClientAudit.FindControl("wiClientID") as ISNet.WebUI.WebControls.WebInput;
		e.NewValues.Add("ClientID", clientIDWebInput.Text);
	}
}