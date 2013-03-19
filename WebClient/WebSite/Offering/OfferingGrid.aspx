<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OfferingGrid.aspx.cs" Inherits="Offering_OfferingGrid" %>

<%@ Register TagPrefix="ucgrid" TagName="OfferingGrid" Src="~/Offering/Controls/OfferingGrid.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Offering Grid</title>
	<link href="~/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
	    <div id="company"><h1>Premier Senior Solutions</h1></div>
		<div id="header">
			<h2>Offering Grid</h2>
		</div>
		<div id="columnLeft">
			<asp:TreeView ID="TreeView1" runat="server" DataSourceID="SiteMapDataSource1" ShowLines="True"></asp:TreeView>
		</div>
		<div id="columnRight">
			<div id="sitemap">
				<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:Button ID="btnAddNewOffering" runat="server" Text="Add New Offering" />
			</div>
			<br />
			<div id="links">
				<asp:LinkButton ID="btnOfferingHeirarchicalGrid" runat="server" Text="Offering Heirarchical Grid" PostBackUrl="~/Offering/OfferingHeirarchicalGrid.aspx" />
				&nbsp;
				&nbsp;
				<asp:LinkButton ID="btnFacilityGrid" runat="server" Text="Facility Grid" PostBackUrl="~/Facility/FacilityGrid.aspx" />
			</div>
			<br />
			<div id="dataGrid">
				<ucgrid:OfferingGrid ID="OfferingGrid1" runat="server" />
			</div>
		</div>
		<br />
		<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
	</form>
</body>
</html>