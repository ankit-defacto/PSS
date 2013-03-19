<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FacilityGrid.aspx.cs" Inherits="Facility_FacilityGrid" %>

<%@ Register TagPrefix="ucgrid" TagName="FacilityGrid" Src="~/Facility/Controls/FacilityGrid.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Facility Grid</title>
	<link href="~/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
	    <div id="company"><h1>Premier Senior Solutions</h1></div>
		<div id="header">
			<h2>Facility Grid</h2>
		</div>
		<div id="columnLeft">
			<asp:TreeView ID="TreeView1" runat="server" DataSourceID="SiteMapDataSource1" ShowLines="True"></asp:TreeView>
		</div>
		<div id="columnRight">
			<div id="sitemap">
				<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:Button ID="btnAddNewFacility" runat="server" Text="Add New Facility" />
			</div>
			<br />
			<div id="links">
				<asp:LinkButton ID="btnFacilityHeirarchicalGrid" runat="server" Text="Facility Heirarchical Grid" PostBackUrl="~/Facility/FacilityHeirarchicalGrid.aspx" />
				&nbsp;
				&nbsp;
				<asp:LinkButton ID="btnClickGrid" runat="server" Text="Click Grid" PostBackUrl="~/Click/ClickGrid.aspx" />
				&nbsp;
				<asp:LinkButton ID="btnFacilityPhotoGrid" runat="server" Text="FacilityPhoto Grid" PostBackUrl="~/FacilityPhoto/FacilityPhotoGrid.aspx" />
				&nbsp;
				<asp:LinkButton ID="btnCityStateZipGrid" runat="server" Text="CityStateZip Grid" PostBackUrl="~/CityStateZip/CityStateZipGrid.aspx" />
				&nbsp;
				<asp:LinkButton ID="btnOfferingGrid" runat="server" Text="Offering Grid" PostBackUrl="~/Offering/OfferingGrid.aspx" />
				&nbsp;
				<asp:LinkButton ID="btnFacilityAuditGrid" runat="server" Text="FacilityAudit Grid" PostBackUrl="~/FacilityAudit/FacilityAuditGrid.aspx" />
			</div>
			<br />
			<div id="dataGrid">
				<ucgrid:FacilityGrid ID="FacilityGrid1" runat="server" />
			</div>
		</div>
		<br />
		<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
	</form>
</body>
</html>