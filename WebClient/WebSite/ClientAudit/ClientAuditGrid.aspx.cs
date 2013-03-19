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

public partial class ClientAudit_ClientAuditGrid : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		btnAddNewClientAudit.Click += new EventHandler(btnAddNewClientAudit_Click);
	}

	protected void btnAddNewClientAudit_Click(object sender, EventArgs e)
	{
		Response.Redirect("ClientAuditDetail.aspx");
	}
}
	