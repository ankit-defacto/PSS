<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentInfoAuditGrid.aspx.cs" Inherits="PaymentInfoAudit_PaymentInfoAuditGrid" %>

<%@ Register TagPrefix="ucgrid" TagName="PaymentInfoAuditGrid" Src="~/PaymentInfoAudit/Controls/PaymentInfoAuditGrid.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Payment Info Audit Grid</title>
	<link href="~/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
	    <div id="company"><h1>Premier Senior Solutions</h1></div>
		<div id="header">
			<h2>Payment Info Audit Grid</h2>
		</div>
		<div id="columnLeft">
			<asp:TreeView ID="TreeView1" runat="server" DataSourceID="SiteMapDataSource1" ShowLines="True"></asp:TreeView>
		</div>
		<div id="columnRight">
			<div id="sitemap">
				<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:Button ID="btnAddNewPaymentInfoAudit" runat="server" Text="Add New PaymentInfoAudit" />
			</div>
			<br />
			<div id="links">
			</div>
			<br />
			<div id="dataGrid">
				<ucgrid:PaymentInfoAuditGrid ID="PaymentInfoAuditGrid1" runat="server" />
			</div>
		</div>
		<br />
		<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
	</form>
</body>
</html>