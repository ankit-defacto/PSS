<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaymentInfoAuditDetail.ascx.cs" Inherits="PaymentInfoAudit_Controls_PaymentInfoAuditDetail" %>

<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>
<%@ Register Assembly="ISNet.WebUI.ISDataSource, Version=1.0.1500.1, Culture=neutral, PublicKeyToken=c4184ef0d326354b"
	Namespace="ISNet.WebUI.DataSource" TagPrefix="ISDataSource" %>
<%@ Register Assembly="ISNet.WebUI.WebDesktop" Namespace="ISNet.WebUI.WebDesktop" TagPrefix="ISWebDesktop" %>
<%@ Register Assembly="ISNet.WebUI.WebInput" Namespace="ISNet.WebUI.WebControls" TagPrefix="ISWebInput" %>

<asp:FormView ID="fvPaymentInfoAudit" runat="server" DataSourceID="odsPaymentInfoAudit" DataKeyNames="PaymentInfoAuditGuid" AllowPaging="false" DefaultMode="ReadOnly">
	<EmptyDataTemplate>
		No data retrieved.<br />
		<asp:LinkButton ID="btnNew" runat="server" CausesValidation="false" CommandName="New" Text="New"></asp:LinkButton>
	</EmptyDataTemplate>
	<EditItemTemplate>
		<table>
			<tr><td>Payment Info Audit Guid</td><td><asp:Label ID="lblPaymentInfoAuditGuid" runat="server" Text='<%# Bind("PaymentInfoAuditGuid") %>' /></td></tr>
			<tr><td>Payment Info Guid Payment Info:</td><td><ISWebCombo:WebCombo ID="wcPaymentInfo" runat="server" UseDefaultStyle="True" DataSourceID="isdPaymentInfoAuditPaymentInfo" DataTextField="PDC" DataValueField="PaymentInfoGuid" Height="20px" Width="200px" /></td></tr>
			<tr><td>Payment Info ID:</td><td><ISWebInput:WebInput ID="wiPaymentInfoID" runat="server" NumericInput="true" /></td></tr>
			<tr><td>Amazon Token:</td><td><asp:TextBox ID="txtAmazonToken" runat="server" Text='<%# Bind("AmazonToken") %>' Width="150px" MaxLength="100" TextMode="MultiLine" /></td></tr>
			<tr><td>Date Modified:</td><td><asp:TextBox ID="txtDateModified" runat="server" Text='<%# Bind("DateModified") %>' Width="175px" /></td></tr>
		</table>
		<asp:Label ID="lblPaymentInfoGuid" runat="server" Text='<%# Eval("PaymentInfoGuid") %>' Visible="false" />
		<asp:Label ID="lblPaymentInfoID" runat="server" Text='<%# Eval("PaymentInfoID") %>' Visible="false" />
		<asp:LinkButton ID="btnUpdate" runat="server" CausesValidation="true" CommandName="Update" Text="Update"></asp:LinkButton>
		<asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
		<asp:LinkButton ID="btnCancel" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
	</EditItemTemplate>
	<ItemTemplate>
		<table>
			<tr><td>Payment Info Audit Guid</td><td><asp:Label ID="lblPaymentInfoAuditGuid" runat="server" Text='<%# Bind("PaymentInfoAuditGuid") %>' /></td></tr>
			<tr><td>Amazon Token:</td><td><asp:Label ID="txtPaymentInfo" runat="server" Text='<%# Bind("PaymentInfoGuidPDC") %>' /></td></tr>
			<tr><td>Payment Info ID:</td><td><asp:Label ID="lblPaymentInfoID" runat="server" Text='<%# Bind("PaymentInfoID") %>' /></td></tr>
			<tr><td>Amazon Token:</td><td><asp:Label ID="lblAmazonToken" runat="server" Text='<%# Bind("AmazonToken") %>' /></td></tr>
			<tr><td>Date Modified:</td><td><asp:Label ID="lblDateModified" runat="server" Text='<%# Bind("DateModified") %>' /></td></tr>
		</table>
		<asp:LinkButton ID="btnEdit" runat="server" CausesValidation="true" CommandName="Edit" Text="Edit"></asp:LinkButton>
		<asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
		<asp:LinkButton ID="btnNew" runat="server" CausesValidation="false" CommandName="New" Text="New"></asp:LinkButton>
	</ItemTemplate>
	<InsertItemTemplate>
		<table>
			<tr><td>Payment Info:</td><td><ISWebCombo:WebCombo ID="wcPaymentInfo" runat="server" UseDefaultStyle="True" DataSourceID="isdPaymentInfoAuditPaymentInfo" DataTextField="PDC" DataValueField="PaymentInfoGuid" Height="20px" Width="200px" /></td></tr>
			<tr><td>Payment Info ID:</td><td><ISWebInput:WebInput ID="wiPaymentInfoID" runat="server" NumericInput="true" /><br /></td></tr>
			<tr><td>Amazon Token:</td><td><asp:TextBox ID="txtAmazonToken" runat="server" Text='<%# Bind("AmazonToken") %>' Width="150px" MaxLength="100" TextMode="MultiLine" /><br /></td></tr>
			<tr><td>Date Modified:</td><td><asp:TextBox ID="txtDateModified" runat="server" Text='<%# Bind("DateModified") %>' Width="175px" /><br /></td></tr>
		</table>
		<asp:Label ID="lblPaymentInfoAuditGuid" runat="server" Text='<%# Bind("PaymentInfoAuditGuid") %>' Visible="false">{00000000-0000-0000-0000-000000000000}</asp:Label><br />
		<asp:LinkButton ID="btnInsert" runat="server" CausesValidation="true" CommandName="Insert" Text="Insert"></asp:LinkButton>
		<asp:LinkButton ID="btnCancel" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
	</InsertItemTemplate>
</asp:FormView>
<asp:ObjectDataSource ID="odsPaymentInfoAudit" runat="server" DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.PaymentInfoAudit"
	OldValuesParameterFormatString="original_{0}" TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess"
	SelectMethod="GetPaymentInfoAudit" InsertMethod="InsertPaymentInfoAudit"
	UpdateMethod="UpdatePaymentInfoAudit" DeleteMethod="DeletePaymentInfoAudit">
	<SelectParameters>
		<asp:QueryStringParameter Name="paymentInfoAuditGuid" QueryStringField="PaymentInfoAuditGuid" Type="String" />
	</SelectParameters>
	<InsertParameters>
		<%--<asp:Parameter Name="paymentInfoAudit" Type="Object" />--%>
		<asp:Parameter Name="paymentInfoGuid" Type="String" />
		<asp:Parameter Name="paymentInfoID" Type="Int32" />
		<asp:Parameter Name="amazonToken" Type="String" />
		<asp:Parameter Name="dateModified" Type="DateTime" />
	</InsertParameters>
</asp:ObjectDataSource>
<ISDataSource:ISDataSource ID="isdPaymentInfoAuditPaymentInfo" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.PaymentInfoCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.PaymentInfo" TableName="PaymentInfoCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" SelectMethod="GetPaymentInfos">
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>