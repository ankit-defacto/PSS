<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CityStateZipDetail.aspx.cs" Inherits="CityStateZip_CityStateZipDetail" %>

<%@ Register Assembly="ISNet.WebUI.WebDesktop" Namespace="ISNet.WebUI.WebDesktop"
	TagPrefix="ISWebDesktop" %>
<%@ Register TagPrefix="uc" TagName="CityStateZipDetail" Src="~/CityStateZip/Controls/CityStateZipDetail.ascx" %>
<%@ Register TagPrefix="uc" TagName="FacilityWithCityStateZipTab" Src="~/CityStateZip/Controls/FacilityWithCityStateZipTab.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>CityStateZip Detail</title>
	<link href="~/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
    <asp:ScriptManager ID="smCityStateZip" runat="server"></asp:ScriptManager>
		<div id="header">
			<h2>City State Zip Detail</h2>
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
				<uc:CityStateZipDetail ID="CityStateZipDetail1" runat="server" />
			</div>
		</div>
		<br />
		<h3>Associated Tables</h3>
		<div>
			<uc:FacilityWithCityStateZipTab ID="FacilityWithCityStateZipTab1" runat="server" />
		</div>
		<div id="footer">
			<h3>Related Links</h3>
			<div>
				<asp:LinkButton ID="btnCityStateZipHeirarchicalGrid" runat="server" Text="CityStateZip Heirarchical Grid" PostBackUrl="~/CityStateZip/CityStateZipHeirarchicalGrid.aspx" />
				&nbsp;
				<asp:LinkButton ID="btnCityStateZipGrid" runat="server" Text="CityStateZip Grid" PostBackUrl="~/CityStateZip/CityStateZipGrid.aspx" />
				&nbsp;
				<asp:LinkButton ID="btnFacilityGrid" runat="server" Text="Facility Grid" PostBackUrl="~/Facility/FacilityGrid.aspx" />
				&nbsp;
				<asp:LinkButton ID="btnFacilityAuditGrid" runat="server" Text="FacilityAudit Grid" PostBackUrl="~/FacilityAudit/FacilityAuditGrid.aspx" />
				&nbsp;
				<asp:LinkButton ID="btnFacilityGrid" runat="server" Text="Facility Grid" PostBackUrl="~/Facility/FacilityGrid.aspx" />
				&nbsp;
				<asp:LinkButton ID="btnClientGrid" runat="server" Text="Client Grid" PostBackUrl="~/Client/ClientGrid.aspx" />
				&nbsp;
				<asp:LinkButton ID="btnClientAuditGrid" runat="server" Text="ClientAudit Grid" PostBackUrl="~/ClientAudit/ClientAuditGrid.aspx" />
			</div>
		</div>
		<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
	</form>
</body>
</html>
	