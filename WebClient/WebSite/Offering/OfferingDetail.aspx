<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OfferingDetail.aspx.cs" Inherits="Offering_OfferingDetail" %>

<%@ Register Assembly="ISNet.WebUI.WebDesktop" Namespace="ISNet.WebUI.WebDesktop"
	TagPrefix="ISWebDesktop" %>
<%@ Register TagPrefix="uc" TagName="OfferingDetail" Src="~/Offering/Controls/OfferingDetail.ascx" %>
<%@ Register TagPrefix="uc" TagName="FacilityWithOfferingTab" Src="~/Offering/Controls/FacilityWithOfferingTab.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Offering Detail</title>
	<link href="~/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
    <asp:ScriptManager ID="smOffering" runat="server"></asp:ScriptManager>
		<div id="header">
			<h2>Offering Detail</h2>
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
				<uc:OfferingDetail ID="OfferingDetail1" runat="server" />
			</div>
		</div>
		<br />
		<h3>Associated Tables</h3>
		<div>
			<uc:FacilityWithOfferingTab ID="FacilityWithOfferingTab1" runat="server" />
		</div>
		<div id="footer">
			<h3>Related Links</h3>
			<div>
				<asp:LinkButton ID="btnOfferingHeirarchicalGrid" runat="server" Text="Offering Heirarchical Grid" PostBackUrl="~/Offering/OfferingHeirarchicalGrid.aspx" />
				&nbsp;
				<asp:LinkButton ID="btnOfferingGrid" runat="server" Text="Offering Grid" PostBackUrl="~/Offering/OfferingGrid.aspx" />
				&nbsp;
				<asp:LinkButton ID="btnFacilityGrid" runat="server" Text="Facility Grid" PostBackUrl="~/Facility/FacilityGrid.aspx" />
			</div>
		</div>
		<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
	</form>
</body>
</html>
	