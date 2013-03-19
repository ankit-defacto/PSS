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

public partial class PaymentInfoAudit_PaymentInfoAuditGrid : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		btnAddNewPaymentInfoAudit.Click += new EventHandler(btnAddNewPaymentInfoAudit_Click);
	}

	protected void btnAddNewPaymentInfoAudit_Click(object sender, EventArgs e)
	{
		Response.Redirect("PaymentInfoAuditDetail.aspx");
	}
}
	