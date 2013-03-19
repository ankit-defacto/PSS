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

public partial class FacilityLocationCriteria_Controls_FacilityLocationCriteriaGrid : System.Web.UI.UserControl
{
	private bool _needsRefresh = false;

	protected void Page_Load(object sender, EventArgs e)
	{
		wgFacilityLocationCriteria.InitializePostBack += new ISWG.PostBackEventHandler(wgFacilityLocationCriteria_InitializePostBack);
		wgFacilityLocationCriteria.Unload += new EventHandler(wgFacilityLocationCriteria_Unload);
	}

	void wgFacilityLocationCriteria_InitializePostBack(object sender, ISWG.PostbackEventArgs e)
	{
		if (wgFacilityLocationCriteria.ActionName == "AddRow")
		{
			_needsRefresh = true;
		}
	}

	void wgFacilityLocationCriteria_Unload(object sender, EventArgs e)
	{
		if (_needsRefresh)
		{
			_needsRefresh = false;

			//isdFacilityLocationCriteria.DataBind();
			//isdFacilityLocationCriteria.DoSelect();
			//isdFacilityLocationCriteria.Select();

			//wgFacilityLocationCriteria.DataBind();
			//wgFacilityLocationCriteria.GetChanges();
			//wgFacilityLocationCriteria.RebindDataSource();
			//wgFacilityLocationCriteria.Reset();

			// This is the current working solution. Hopefully one of the above will work instead.
			// Comment this line out to debug. The refresh hides error messages.
			this.Response.Redirect("~/FacilityLocationCriteria/FacilityLocationCriteriaGrid.aspx");
		}
	}

	/// <summary>
	/// Builds to the link button to send the FacilityGuidCityStateZipGuid link to the FacilityLocationCriteriaDetail page in the same folder.
	/// </summary>
	/// <param name="sender">Sender, as object.</param>
	/// <param name="e">Intersoft WebGrid RowEventArgs.</param>
	protected void wgFacilityLocationCriteria_InitializeRow(object sender, ISWG.RowEventArgs e)
	{
		if (e.Row.Type == ISWG.RowType.Record &&
			e.Row.Table.Name == "FacilityLocationCriteriaCollection")
		{
			string FacilityGuidCityStateZipGuidHyperlink = "FacilityLocationCriteriaDetail.aspx?FacilityGuidCityStateZipGuid=" +
				e.Row.Cells.GetNamedItem("FacilityGuidCityStateZipGuid").Value;

			// configure the column as Hyperlink
			wgFacilityLocationCriteria.RootTable.Columns.GetNamedItem("FacilityGuid").ColumnType =
				ISWG.ColumnType.HyperLink;

			// configure the HyperlinkFormatString
			wgFacilityLocationCriteria.RootTable.Columns.GetNamedItem("FacilityGuid").HyperlinkFormatString =
				FacilityGuidCityStateZipGuidHyperlink;

			wgFacilityLocationCriteria.RootTable.Columns.GetNamedItem("FacilityGuidCityStateZipGuid").HyperlinkDisplayText =
				e.Row.Cells.GetNamedItem("FacilityGuid").Text;
		}
	}
}