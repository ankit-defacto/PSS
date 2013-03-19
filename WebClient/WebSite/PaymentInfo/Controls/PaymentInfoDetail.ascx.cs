
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

public partial class PaymentInfo_Controls_PaymentInfoDetail : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Request.QueryString.Keys.Count == 0)
		{
			this.fvPaymentInfo.ChangeMode(FormViewMode.Insert);
		}
		else if (Request.QueryString.Keys.Count == 1)
		{
			this.fvPaymentInfo.ChangeMode(FormViewMode.Edit);
		}
		// Performing an insert with url parameters messes everything up. This redirects back to itself without any parameters.
		else if (Request.QueryString.Keys.Count >= 1 && fvPaymentInfo.CurrentMode == FormViewMode.Insert)
		{
			this.Response.Redirect("~/PaymentInfo/PaymentInfoDetail.aspx", false);
		}
		else
		{
			this.fvPaymentInfo.ChangeMode(FormViewMode.Insert);
		}

		fvPaymentInfo.ModeChanging += new FormViewModeEventHandler(fvPaymentInfo_ModeChanging);
		fvPaymentInfo.PreRender += new EventHandler(fvPaymentInfo_PreRender);
		fvPaymentInfo.ItemInserting += new FormViewInsertEventHandler(fvPaymentInfo_ItemInserting);
		fvPaymentInfo.ItemUpdating += new FormViewUpdateEventHandler(fvPaymentInfo_ItemUpdating);
		fvPaymentInfo.ItemDeleted += new FormViewDeletedEventHandler(fvPaymentInfo_ItemDeleted);

	}

	void fvPaymentInfo_ModeChanging(object sender, FormViewModeEventArgs e)
	{
		if (e.NewMode == FormViewMode.Insert &&
			this.Request.QueryString.Count > 0)
		{
			this.Response.Redirect("~/PaymentInfo/PaymentInfoDetail.aspx");
		}
	}

	void fvPaymentInfo_PreRender(object sender, EventArgs e)
	{
		// After clicking cancel in Insert mode, this redirects the page back to the grid.
		Label guidFieldLabel = (Label)fvPaymentInfo.FindControl("lblPaymentInfoGuid");
		if (null != guidFieldLabel)
		{
			if (guidFieldLabel.Text == Guid.Empty.ToString())
			{
				this.Response.Redirect("~/PaymentInfo/PaymentInfoGrid.aspx");
			}
		}

		if (fvPaymentInfo.CurrentMode == FormViewMode.Edit)
		{
		}
	}

	void fvPaymentInfo_ItemInserting(object sender, FormViewInsertEventArgs e)
	{
		AddInsertParameterValues(e);
	}

	void fvPaymentInfo_ItemUpdating(object sender, FormViewUpdateEventArgs e)
	{
		AddUpdateParameterValues(e);
	}

	void fvPaymentInfo_ItemDeleted(object sender, FormViewDeletedEventArgs e)
	{
		this.Response.Redirect("~/PaymentInfo/PaymentInfoGrid.aspx");
	}

	private void AddInsertParameterValues(FormViewInsertEventArgs e)
	{
	}

	private void AddUpdateParameterValues(FormViewUpdateEventArgs e)
	{
	}
}