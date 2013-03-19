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

public partial class Offering_Controls_OfferingGrid : System.Web.UI.UserControl
{
	private bool _needsRefresh = false;

	protected void Page_Load(object sender, EventArgs e)
	{
		wgOffering.InitializePostBack += new ISWG.PostBackEventHandler(wgOffering_InitializePostBack);
		wgOffering.Unload += new EventHandler(wgOffering_Unload);
	}

	void wgOffering_InitializePostBack(object sender, ISWG.PostbackEventArgs e)
	{
		if (wgOffering.ActionName == "AddRow")
		{
			_needsRefresh = true;
		}
	}

	void wgOffering_Unload(object sender, EventArgs e)
	{
		if (_needsRefresh)
		{
			_needsRefresh = false;

			//isdOffering.DataBind();
			//isdOffering.DoSelect();
			//isdOffering.Select();

			//wgOffering.DataBind();
			//wgOffering.GetChanges();
			//wgOffering.RebindDataSource();
			//wgOffering.Reset();

			// This is the current working solution. Hopefully one of the above will work instead.
			// Comment this line out to debug. The refresh hides error messages.
			this.Response.Redirect("~/Offering/OfferingGrid.aspx");
		}
	}

	/// <summary>
	/// Builds to the link button to send the OfferingGuid link to the OfferingDetail page in the same folder.
	/// </summary>
	/// <param name="sender">Sender, as object.</param>
	/// <param name="e">Intersoft WebGrid RowEventArgs.</param>
	protected void wgOffering_InitializeRow(object sender, ISWG.RowEventArgs e)
	{
		if (e.Row.Type == ISWG.RowType.Record &&
			e.Row.Table.Name == "OfferingCollection")
		{
			string OfferingGuidHyperlink = "OfferingDetail.aspx?OfferingGuid=" +
				e.Row.Cells.GetNamedItem("OfferingGuid").Value;

			// configure the column as Hyperlink
			wgOffering.RootTable.Columns.GetNamedItem("OfferingName").ColumnType =
				ISWG.ColumnType.HyperLink;

			// configure the HyperlinkFormatString
			wgOffering.RootTable.Columns.GetNamedItem("OfferingName").HyperlinkFormatString =
				OfferingGuidHyperlink;

			wgOffering.RootTable.Columns.GetNamedItem("OfferingGuid").HyperlinkDisplayText =
				e.Row.Cells.GetNamedItem("OfferingName").Text;
		}
	}
}