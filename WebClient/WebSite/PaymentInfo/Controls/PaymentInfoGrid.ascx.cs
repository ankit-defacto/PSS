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

public partial class PaymentInfo_Controls_PaymentInfoGrid : System.Web.UI.UserControl
{
	private bool _needsRefresh = false;

	protected void Page_Load(object sender, EventArgs e)
	{
		wgPaymentInfo.InitializePostBack += new ISWG.PostBackEventHandler(wgPaymentInfo_InitializePostBack);
		wgPaymentInfo.Unload += new EventHandler(wgPaymentInfo_Unload);
	}

	void wgPaymentInfo_InitializePostBack(object sender, ISWG.PostbackEventArgs e)
	{
		if (wgPaymentInfo.ActionName == "AddRow")
		{
			_needsRefresh = true;
		}
	}

	void wgPaymentInfo_Unload(object sender, EventArgs e)
	{
		if (_needsRefresh)
		{
			_needsRefresh = false;

			//isdPaymentInfo.DataBind();
			//isdPaymentInfo.DoSelect();
			//isdPaymentInfo.Select();

			//wgPaymentInfo.DataBind();
			//wgPaymentInfo.GetChanges();
			//wgPaymentInfo.RebindDataSource();
			//wgPaymentInfo.Reset();

			// This is the current working solution. Hopefully one of the above will work instead.
			// Comment this line out to debug. The refresh hides error messages.
			this.Response.Redirect("~/PaymentInfo/PaymentInfoGrid.aspx");
		}
	}

	/// <summary>
	/// Builds to the link button to send the PaymentInfoGuid link to the PaymentInfoDetail page in the same folder.
	/// </summary>
	/// <param name="sender">Sender, as object.</param>
	/// <param name="e">Intersoft WebGrid RowEventArgs.</param>
	protected void wgPaymentInfo_InitializeRow(object sender, ISWG.RowEventArgs e)
	{
		if (e.Row.Type == ISWG.RowType.Record &&
			e.Row.Table.Name == "PaymentInfoCollection")
		{
			string PaymentInfoGuidHyperlink = "PaymentInfoDetail.aspx?PaymentInfoGuid=" +
				e.Row.Cells.GetNamedItem("PaymentInfoGuid").Value;

			// configure the column as Hyperlink
			wgPaymentInfo.RootTable.Columns.GetNamedItem("AmazonToken").ColumnType =
				ISWG.ColumnType.HyperLink;

			// configure the HyperlinkFormatString
			wgPaymentInfo.RootTable.Columns.GetNamedItem("AmazonToken").HyperlinkFormatString =
				PaymentInfoGuidHyperlink;

			wgPaymentInfo.RootTable.Columns.GetNamedItem("PaymentInfoGuid").HyperlinkDisplayText =
				e.Row.Cells.GetNamedItem("AmazonToken").Text;
		}
	}
}