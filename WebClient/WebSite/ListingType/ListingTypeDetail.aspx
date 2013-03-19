<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListingTypeDetail.aspx.cs" Inherits="ListingType_ListingTypeDetail" %>

<%@ Register Assembly="ISNet.WebUI.WebDesktop" Namespace="ISNet.WebUI.WebDesktop"
	TagPrefix="ISWebDesktop" %>
<%@ Register TagPrefix="uc" TagName="ListingTypeDetail" Src="~/ListingType/Controls/ListingTypeDetail.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>ListingType Detail</title>
	<link href="~/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
		<div id="header">
			<h2>Listing Type Detail</h2>
		</div>
		<div id="columnLeft">
			<asp:TreeView ID="TreeView1" runat="server" DataSourceID="SiteMapDataSource1" ShowLines="True">
			</asp:TreeView>
		</div>
		<div id="columnRight">
			<div id="sitemap">
				<asp:SiteMapPath ID="SiteMapPath1" runat="server">
				</asp:SiteMapPath>
			</div>
			<br />
			<div id="dataGrid">
				<uc:ListingTypeDetail ID="ListingTypeDetail1" runat="server" />
			</div>
		</div>
		<br />
		<div id="footer">
			<h3>Related Links</h3>
			<div>
				<asp:LinkButton ID="btnListingTypeHeirarchicalGrid" runat="server" Text="ListingType Heirarchical Grid" PostBackUrl="~/ListingType/ListingTypeHeirarchicalGrid.aspx" />
				&nbsp;
				<asp:LinkButton ID="btnListingTypeGrid" runat="server" Text="ListingType Grid" PostBackUrl="~/ListingType/ListingTypeGrid.aspx" />
				&nbsp;
				<asp:LinkButton ID="btnClickGrid" runat="server" Text="Click Grid" PostBackUrl="~/Click/ClickGrid.aspx" />
				&nbsp;
				<asp:LinkButton ID="btnFacilityGrid" runat="server" Text="Facility Grid" PostBackUrl="~/Facility/FacilityGrid.aspx" />
				&nbsp;
				<asp:LinkButton ID="btnFacilityAuditGrid" runat="server" Text="FacilityAudit Grid" PostBackUrl="~/FacilityAudit/FacilityAuditGrid.aspx" />
			</div>
		</div>
		<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
	</form>
</body>
</html>
	