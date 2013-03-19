﻿/*  Generated by CodeGen written by Concord Mfg.
 *  Transform file used: BEGridControl (v0.1.0.0).xslt
 *  Date generated: 3/28/2012 12:46:29 PM
 *  CodeGen version: 0.1.0.0  */

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
using ISWG = ISNet.WebUI.WebGrid;

public partial class FacilityOffering_Controls_FacilityOfferingGrid : System.Web.UI.UserControl
{
	private bool _needsRefresh = false;

	protected void Page_Load(object sender, EventArgs e)
	{
		wgFacilityOffering.InitializePostBack += new ISWG.PostBackEventHandler(wgFacilityOffering_InitializePostBack);
		wgFacilityOffering.Unload += new EventHandler(wgFacilityOffering_Unload);
	}

	void wgFacilityOffering_InitializePostBack(object sender, ISWG.PostbackEventArgs e)
	{
		if (wgFacilityOffering.ActionName == "AddRow")
		{
			_needsRefresh = true;
		}
	}

	void wgFacilityOffering_Unload(object sender, EventArgs e)
	{
		if (_needsRefresh)
		{
			_needsRefresh = false;

			//isdFacilityOffering.DataBind();
			//isdFacilityOffering.DoSelect();
			//isdFacilityOffering.Select();

			//wgFacilityOffering.DataBind();
			//wgFacilityOffering.GetChanges();
			//wgFacilityOffering.RebindDataSource();
			//wgFacilityOffering.Reset();

			// This is the current working solution. Hopefully one of the above will work instead.
			// Comment this line out to debug. The refresh hides error messages.
			this.Response.Redirect("~/FacilityOffering/FacilityOfferingGrid.aspx");
		}
	}

	/// <summary>
	/// Builds to the link button to send the FacilityGuidOfferingGuid link to the FacilityOfferingDetail page in the same folder.
	/// </summary>
	/// <param name="sender">Sender, as object.</param>
	/// <param name="e">Intersoft WebGrid RowEventArgs.</param>
	protected void wgFacilityOffering_InitializeRow(object sender, ISWG.RowEventArgs e)
	{
		if (e.Row.Type == ISWG.RowType.Record &&
			e.Row.Table.Name == "FacilityOfferingCollection")
		{
			string FacilityGuidOfferingGuidHyperlink = "FacilityOfferingDetail.aspx?FacilityGuidOfferingGuid=" +
				e.Row.Cells.GetNamedItem("FacilityGuidOfferingGuid").Value;

			// configure the column as Hyperlink
			wgFacilityOffering.RootTable.Columns.GetNamedItem("FacilityGuid").ColumnType =
				ISWG.ColumnType.HyperLink;

			// configure the HyperlinkFormatString
			wgFacilityOffering.RootTable.Columns.GetNamedItem("FacilityGuid").HyperlinkFormatString =
				FacilityGuidOfferingGuidHyperlink;

			wgFacilityOffering.RootTable.Columns.GetNamedItem("FacilityGuidOfferingGuid").HyperlinkDisplayText =
				e.Row.Cells.GetNamedItem("FacilityGuid").Text;
		}
	}
}