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

public partial class ListingType_ListingTypeGrid : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		btnAddNewListingType.Click += new EventHandler(btnAddNewListingType_Click);
	}

	protected void btnAddNewListingType_Click(object sender, EventArgs e)
	{
		Response.Redirect("ListingTypeDetail.aspx");
	}
}
	