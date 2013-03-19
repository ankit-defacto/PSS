<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentInfoDetail.aspx.cs" Inherits="PaymentInfo_PaymentInfoDetail" %>

<%@ Register Assembly="ISNet.WebUI.WebDesktop" Namespace="ISNet.WebUI.WebDesktop"
	TagPrefix="ISWebDesktop" %>
<%@ Register TagPrefix="uc" TagName="PaymentInfoDetail" Src="~/PaymentInfo/Controls/PaymentInfoDetail.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>PaymentInfo Detail</title>
	<link href="~/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
		<div id="header">
			<h2>Payment Info Detail</h2>
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
				<uc:PaymentInfoDetail ID="PaymentInfoDetail1" runat="server" />
			</div>
		</div>
		<br />
		<div id="footer">
			<h3>Related Links</h3>
			<div>
				<asp:LinkButton ID="btnPaymentInfoHeirarchicalGrid" runat="server" Text="PaymentInfo Heirarchical Grid" PostBackUrl="~/PaymentInfo/PaymentInfoHeirarchicalGrid.aspx" />
				&nbsp;
				<asp:LinkButton ID="btnPaymentInfoGrid" runat="server" Text="PaymentInfo Grid" PostBackUrl="~/PaymentInfo/PaymentInfoGrid.aspx" />
				&nbsp;
				<asp:LinkButton ID="btnPaymentInfoAuditGrid" runat="server" Text="PaymentInfoAudit Grid" PostBackUrl="~/PaymentInfoAudit/PaymentInfoAuditGrid.aspx" />
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
	