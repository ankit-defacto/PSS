<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListingTypeGrid.aspx.cs" Inherits="ListingType_ListingTypeGrid" %>

<%@ Register TagPrefix="ucgrid" TagName="ListingTypeGrid" Src="~/ListingType/Controls/ListingTypeGrid.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Listing Type Grid</title>
	<link href="~/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
	    <div id="company"><h1>Premier Senior Solutions</h1></div>
		<div id="header">
			<h2>Listing Type Grid</h2>
		</div>
		<div id="columnLeft">
			<asp:TreeView ID="TreeView1" runat="server" DataSourceID="SiteMapDataSource1" ShowLines="True"></asp:TreeView>
		</div>
		<div id="columnRight">
			<div id="sitemap">
				<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:Button ID="btnAddNewListingType" runat="server" Text="Add New ListingType" />
			</div>
			<br />
			<div id="links">
				<asp:LinkButton ID="btnListingTypeHeirarchicalGrid" runat="server" Text="ListingType Heirarchical Grid" PostBackUrl="~/ListingType/ListingTypeHeirarchicalGrid.aspx" />
				&nbsp;
				&nbsp;
				<asp:LinkButton ID="btnClickGrid" runat="server" Text="Click Grid" PostBackUrl="~/Click/ClickGrid.aspx" />
				&nbsp;
				<asp:LinkButton ID="btnFacilityGrid" runat="server" Text="Facility Grid" PostBackUrl="~/Facility/FacilityGrid.aspx" />
				&nbsp;
				<asp:LinkButton ID="btnFacilityAuditGrid" runat="server" Text="FacilityAudit Grid" PostBackUrl="~/FacilityAudit/FacilityAuditGrid.aspx" />
			</div>
			<br />
			<div id="dataGrid">
				<ucgrid:ListingTypeGrid ID="ListingTypeGrid1" runat="server" />
			</div>
		</div>
		<br />
		<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
	</form>
</body>
</html>