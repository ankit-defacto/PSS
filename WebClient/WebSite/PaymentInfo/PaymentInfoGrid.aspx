<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentInfoGrid.aspx.cs" Inherits="PaymentInfo_PaymentInfoGrid" %>

<%@ Register TagPrefix="ucgrid" TagName="PaymentInfoGrid" Src="~/PaymentInfo/Controls/PaymentInfoGrid.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Payment Info Grid</title>
	<link href="~/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
	    <div id="company"><h1>Premier Senior Solutions</h1></div>
		<div id="header">
			<h2>Payment Info Grid</h2>
		</div>
		<div id="columnLeft">
			<asp:TreeView ID="TreeView1" runat="server" DataSourceID="SiteMapDataSource1" ShowLines="True"></asp:TreeView>
		</div>
		<div id="columnRight">
			<div id="sitemap">
				<asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:Button ID="btnAddNewPaymentInfo" runat="server" Text="Add New PaymentInfo" />
			</div>
			<br />
			<div id="links">
				<asp:LinkButton ID="btnPaymentInfoHeirarchicalGrid" runat="server" Text="PaymentInfo Heirarchical Grid" PostBackUrl="~/PaymentInfo/PaymentInfoHeirarchicalGrid.aspx" />
				&nbsp;
				&nbsp;
				<asp:LinkButton ID="btnPaymentInfoAuditGrid" runat="server" Text="PaymentInfoAudit Grid" PostBackUrl="~/PaymentInfoAudit/PaymentInfoAuditGrid.aspx" />
				&nbsp;
				<asp:LinkButton ID="btnClientGrid" runat="server" Text="Client Grid" PostBackUrl="~/Client/ClientGrid.aspx" />
				&nbsp;
				<asp:LinkButton ID="btnClientAuditGrid" runat="server" Text="ClientAudit Grid" PostBackUrl="~/ClientAudit/ClientAuditGrid.aspx" />
			</div>
			<br />
			<div id="dataGrid">
				<ucgrid:PaymentInfoGrid ID="PaymentInfoGrid1" runat="server" />
			</div>
		</div>
		<br />
		<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
	</form>
</body>
</html>