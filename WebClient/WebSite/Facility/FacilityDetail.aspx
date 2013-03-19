<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FacilityDetail.aspx.cs" Inherits="Facility_FacilityDetail" %>

<%@ Register Assembly="ISNet.WebUI.WebDesktop" Namespace="ISNet.WebUI.WebDesktop"
	TagPrefix="ISWebDesktop" %>
<%@ Register TagPrefix="uc" TagName="FacilityDetail" Src="~/Facility/Controls/FacilityDetail.ascx" %>
<%@ Register TagPrefix="uc" TagName="CityStateZipWithFacilityTab" Src="~/Facility/Controls/CityStateZipWithFacilityTab.ascx" %>
<%@ Register TagPrefix="uc" TagName="OfferingWithFacilityTab" Src="~/Facility/Controls/OfferingWithFacilityTab.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Facility Detail</title>
	<link href="~/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
    <asp:ScriptManager ID="smFacility" runat="server"></asp:ScriptManager>
		<div id="header">
			<h2>Facility Detail</h2>
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
				<uc:FacilityDetail ID="FacilityDetail1" runat="server" />
			</div>
		</div>
		<br />
		<h3>Associated Tables</h3>
		<div>
			<uc:CityStateZipWithFacilityTab ID="CityStateZipWithFacilityTab1" runat="server" />
			<uc:OfferingWithFacilityTab ID="OfferingWithFacilityTab1" runat="server" />
		</div>
		<div id="footer">
			<h3>Related Links</h3>
			<div>
				<asp:LinkButton ID="btnFacilityHeirarchicalGrid" runat="server" Text="Facility Heirarchical Grid" PostBackUrl="~/Facility/FacilityHeirarchicalGrid.aspx" />
				&nbsp;
				<asp:LinkButton ID="btnFacilityGrid" runat="server" Text="Facility Grid" PostBackUrl="~/Facility/FacilityGrid.aspx" />
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
		</div>
		<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
	</form>
</body>
</html>
	