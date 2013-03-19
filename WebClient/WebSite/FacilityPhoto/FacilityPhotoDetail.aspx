<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FacilityPhotoDetail.aspx.cs" Inherits="FacilityPhoto_FacilityPhotoDetail" %>

<%@ Register Assembly="ISNet.WebUI.WebDesktop" Namespace="ISNet.WebUI.WebDesktop"
	TagPrefix="ISWebDesktop" %>
<%@ Register TagPrefix="uc" TagName="FacilityPhotoDetail" Src="~/FacilityPhoto/Controls/FacilityPhotoDetail.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>FacilityPhoto Detail</title>
	<link href="~/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
		<div id="header">
			<h2>FacilityPhoto Detail</h2>
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
				<uc:FacilityPhotoDetail ID="FacilityPhotoDetail1" runat="server" />
			</div>
		</div>
		<br />
		<div id="footer">
			<h3>Related Links</h3>
			<div>
				<asp:LinkButton ID="btnFacilityPhotoGrid" runat="server" Text="FacilityPhoto Grid" PostBackUrl="~/FacilityPhoto/FacilityPhotoGrid.aspx" />
			</div>
		</div>
		<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
	</form>
</body>
</html>
	