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

public partial class PaymentInfo_PaymentInfoGrid : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		btnAddNewPaymentInfo.Click += new EventHandler(btnAddNewPaymentInfo_Click);
	}

	protected void btnAddNewPaymentInfo_Click(object sender, EventArgs e)
	{
		Response.Redirect("PaymentInfoDetail.aspx");
	}
}
	