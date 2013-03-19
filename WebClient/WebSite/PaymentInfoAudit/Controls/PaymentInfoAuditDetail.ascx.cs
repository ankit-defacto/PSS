
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

public partial class PaymentInfoAudit_Controls_PaymentInfoAuditDetail : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Request.QueryString.Keys.Count == 0)
		{
			this.fvPaymentInfoAudit.ChangeMode(FormViewMode.Insert);
		}
		else if (Request.QueryString.Keys.Count == 1)
		{
			this.fvPaymentInfoAudit.ChangeMode(FormViewMode.Edit);
		}
		// Performing an insert with url parameters messes everything up. This redirects back to itself without any parameters.
		else if (Request.QueryString.Keys.Count >= 1 && fvPaymentInfoAudit.CurrentMode == FormViewMode.Insert)
		{
			this.Response.Redirect("~/PaymentInfoAudit/PaymentInfoAuditDetail.aspx", false);
		}
		else
		{
			this.fvPaymentInfoAudit.ChangeMode(FormViewMode.Insert);
		}

		fvPaymentInfoAudit.ModeChanging += new FormViewModeEventHandler(fvPaymentInfoAudit_ModeChanging);
		fvPaymentInfoAudit.PreRender += new EventHandler(fvPaymentInfoAudit_PreRender);
		fvPaymentInfoAudit.ItemInserting += new FormViewInsertEventHandler(fvPaymentInfoAudit_ItemInserting);
		fvPaymentInfoAudit.ItemUpdating += new FormViewUpdateEventHandler(fvPaymentInfoAudit_ItemUpdating);
		fvPaymentInfoAudit.ItemDeleted += new FormViewDeletedEventHandler(fvPaymentInfoAudit_ItemDeleted);

	}

	void fvPaymentInfoAudit_ModeChanging(object sender, FormViewModeEventArgs e)
	{
		if (e.NewMode == FormViewMode.Insert &&
			this.Request.QueryString.Count > 0)
		{
			this.Response.Redirect("~/PaymentInfoAudit/PaymentInfoAuditDetail.aspx");
		}
	}

	void fvPaymentInfoAudit_PreRender(object sender, EventArgs e)
	{
		// After clicking cancel in Insert mode, this redirects the page back to the grid.
		Label guidFieldLabel = (Label)fvPaymentInfoAudit.FindControl("lblPaymentInfoAuditGuid");
		if (null != guidFieldLabel)
		{
			if (guidFieldLabel.Text == Guid.Empty.ToString())
			{
				this.Response.Redirect("~/PaymentInfoAudit/PaymentInfoAuditGrid.aspx");
			}
		}

		if (fvPaymentInfoAudit.CurrentMode == FormViewMode.Edit)
		{

			ISNet.WebUI.WebCombo.WebCombo paymentInfoWebCombo =
				fvPaymentInfoAudit.FindControl("wcPaymentInfo") as ISNet.WebUI.WebCombo.WebCombo;
			Label paymentInfoGuidLabel = fvPaymentInfoAudit.FindControl("lblPaymentInfoGuid") as Label;
			if (paymentInfoWebCombo != null && paymentInfoGuidLabel != null)
				paymentInfoWebCombo.Value = paymentInfoGuidLabel.Text;

			ISNet.WebUI.WebControls.WebInput paymentInfoIDWebInput =
				fvPaymentInfoAudit.FindControl("wiPaymentInfoID") as ISNet.WebUI.WebControls.WebInput;
			Label paymentInfoIDLabel = fvPaymentInfoAudit.FindControl("lblPaymentInfoID") as Label;
			if (paymentInfoIDWebInput != null && paymentInfoIDLabel != null)
				paymentInfoIDWebInput.Text = paymentInfoIDLabel.Text;
		}
	}

	void fvPaymentInfoAudit_ItemInserting(object sender, FormViewInsertEventArgs e)
	{
		AddInsertParameterValues(e);
	}

	void fvPaymentInfoAudit_ItemUpdating(object sender, FormViewUpdateEventArgs e)
	{
		AddUpdateParameterValues(e);
	}

	void fvPaymentInfoAudit_ItemDeleted(object sender, FormViewDeletedEventArgs e)
	{
		this.Response.Redirect("~/PaymentInfoAudit/PaymentInfoAuditGrid.aspx");
	}

	private void AddInsertParameterValues(FormViewInsertEventArgs e)
	{

		ISNet.WebUI.WebCombo.WebCombo paymentInfoWebCombo =
			fvPaymentInfoAudit.FindControl("wcPaymentInfo") as ISNet.WebUI.WebCombo.WebCombo;
		e.Values.Add("PaymentInfoGuid", paymentInfoWebCombo.SelectedRow.Value);

		ISNet.WebUI.WebControls.WebInput paymentInfoIDWebInput =
			fvPaymentInfoAudit.FindControl("wiPaymentInfoID") as ISNet.WebUI.WebControls.WebInput;
		e.Values.Add("PaymentInfoID", paymentInfoIDWebInput.Text);
	}

	private void AddUpdateParameterValues(FormViewUpdateEventArgs e)
	{

		ISNet.WebUI.WebCombo.WebCombo paymentInfoWebCombo =
			fvPaymentInfoAudit.FindControl("wcPaymentInfo") as ISNet.WebUI.WebCombo.WebCombo;
		e.NewValues.Add("PaymentInfoGuid", paymentInfoWebCombo.SelectedRow.Value);

		ISNet.WebUI.WebControls.WebInput paymentInfoIDWebInput =
			fvPaymentInfoAudit.FindControl("wiPaymentInfoID") as ISNet.WebUI.WebControls.WebInput;
		e.NewValues.Add("PaymentInfoID", paymentInfoIDWebInput.Text);
	}
}