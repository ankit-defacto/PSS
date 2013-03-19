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

public partial class Click_ClickDetail : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
	}

	public void Page_Error(object sender, EventArgs e)
	{
		Exception objErr = Server.GetLastError();
		Exception objErrBase = objErr.GetBaseException();
		string errorHtml =
			"<b>PWO v0.0.7.0 Error</b><hr>" +
			"<br><b>Page: </b>" + Request.Url.ToString() +
			"<br><b>Date and Time: </b>" + DateTime.Now.ToString() +
			"<br><b>Error Message: </b>" + objErr.Message.ToString() +
			"<br><b>Base Error Message: </b>" + objErrBase.Message.ToString();

		if (null != objErr.InnerException)
			errorHtml += "<br><b>Inner Error Message: </b>" + objErr.InnerException.Message.ToString();

		errorHtml +=
			"<br><b>Stack Trace:</b><br>" + objErr.StackTrace.ToString() +
			"<br><b>User: </b>" + Environment.UserDomainName + "\\" + Environment.UserName +
			"<br><b>Operating System: </b>" + Environment.OSVersion.VersionString;
		Response.Write(errorHtml.ToString());
		Server.ClearError();
	}
}
	