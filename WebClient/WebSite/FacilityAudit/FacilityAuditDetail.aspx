<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FacilityAuditDetail.aspx.cs" Inherits="FacilityAudit_FacilityAuditDetail" %>

<%@ Register Assembly="ISNet.WebUI.WebDesktop" Namespace="ISNet.WebUI.WebDesktop"
	TagPrefix="ISWebDesktop" %>
<%@ Register TagPrefix="uc" TagName="FacilityAuditDetail" Src="~/FacilityAudit/Controls/FacilityAuditDetail.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>FacilityAudit Detail</title>
	<link href="~/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
		<div id="header">
			<h2>Facility Audit Detail</h2>
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
				<uc:FacilityAuditDetail ID="FacilityAuditDetail1" runat="server" />
			</div>
		</div>
		<br />
		<div id="footer">
			<h3>Related Links</h3>
			<div>
				<asp:LinkButton ID="btnFacilityAuditGrid" runat="server" Text="FacilityAudit Grid" PostBackUrl="~/FacilityAudit/FacilityAuditGrid.aspx" />
			</div>
		</div>
		<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
	</form>
</body>
</html>
	