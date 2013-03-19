<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaymentInfoDetail.ascx.cs" Inherits="PaymentInfo_Controls_PaymentInfoDetail" %>

<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>
<%@ Register Assembly="ISNet.WebUI.ISDataSource, Version=1.0.1500.1, Culture=neutral, PublicKeyToken=c4184ef0d326354b"
	Namespace="ISNet.WebUI.DataSource" TagPrefix="ISDataSource" %>
<%@ Register Assembly="ISNet.WebUI.WebDesktop" Namespace="ISNet.WebUI.WebDesktop" TagPrefix="ISWebDesktop" %>
<%@ Register Assembly="ISNet.WebUI.WebInput" Namespace="ISNet.WebUI.WebControls" TagPrefix="ISWebInput" %>

<asp:FormView ID="fvPaymentInfo" runat="server" DataSourceID="odsPaymentInfo" DataKeyNames="PaymentInfoGuid" AllowPaging="false" DefaultMode="ReadOnly">
	<EmptyDataTemplate>
		No data retrieved.<br />
		<asp:LinkButton ID="btnNew" runat="server" CausesValidation="false" CommandName="New" Text="New"></asp:LinkButton>
	</EmptyDataTemplate>
	<EditItemTemplate>
		<table>
			<tr><td>Payment Info Guid</td><td><asp:Label ID="lblPaymentInfoGuid" runat="server" Text='<%# Bind("PaymentInfoGuid") %>' /></td></tr>
			<tr><td>Payment Info ID</td><td><asp:Label ID="lblPaymentInfoID" runat="server" Text='<%# Bind("PaymentInfoID") %>' /></td></tr>
			<tr><td>Amazon Token:</td><td><asp:TextBox ID="txtAmazonToken" runat="server" Text='<%# Bind("AmazonToken") %>' Width="150px" MaxLength="100" TextMode="MultiLine" /></td></tr>
		</table>
		<asp:LinkButton ID="btnUpdate" runat="server" CausesValidation="true" CommandName="Update" Text="Update"></asp:LinkButton>
		<asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
		<asp:LinkButton ID="btnCancel" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
	</EditItemTemplate>
	<ItemTemplate>
		<table>
			<tr><td>Payment Info Guid</td><td><asp:Label ID="lblPaymentInfoGuid" runat="server" Text='<%# Bind("PaymentInfoGuid") %>' /></td></tr>
			<tr><td>Payment Info ID:</td><td><asp:Label ID="lblPaymentInfoID" runat="server" Text='<%# Bind("PaymentInfoID") %>' /></td></tr>
			<tr><td>Amazon Token:</td><td><asp:Label ID="lblAmazonToken" runat="server" Text='<%# Bind("AmazonToken") %>' /></td></tr>
		</table>
		<asp:LinkButton ID="btnEdit" runat="server" CausesValidation="true" CommandName="Edit" Text="Edit"></asp:LinkButton>
		<asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
		<asp:LinkButton ID="btnNew" runat="server" CausesValidation="false" CommandName="New" Text="New"></asp:LinkButton>
	</ItemTemplate>
	<InsertItemTemplate>
		<table>
			<tr><td>Amazon Token:</td><td><asp:TextBox ID="txtAmazonToken" runat="server" Text='<%# Bind("AmazonToken") %>' Width="150px" MaxLength="100" TextMode="MultiLine" /><br /></td></tr>
		</table>
		<asp:Label ID="lblPaymentInfoGuid" runat="server" Text='<%# Bind("PaymentInfoGuid") %>' Visible="false">{00000000-0000-0000-0000-000000000000}</asp:Label><br />
    <asp:Label ID="lblPaymentInfoID" runat="server" Text='<%# Bind("PaymentInfoID") %>' Visible="false" >-1</asp:Label><br />
		<asp:LinkButton ID="btnInsert" runat="server" CausesValidation="true" CommandName="Insert" Text="Insert"></asp:LinkButton>
		<asp:LinkButton ID="btnCancel" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
	</InsertItemTemplate>
</asp:FormView>
<asp:ObjectDataSource ID="odsPaymentInfo" runat="server" DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.PaymentInfo"
	OldValuesParameterFormatString="original_{0}" TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess"
	SelectMethod="GetPaymentInfo" InsertMethod="InsertPaymentInfo"
	UpdateMethod="UpdatePaymentInfo" DeleteMethod="DeletePaymentInfo">
	<SelectParameters>
		<asp:QueryStringParameter Name="paymentInfoGuid" QueryStringField="PaymentInfoGuid" Type="String" />
	</SelectParameters>
	<InsertParameters>
		<%--<asp:Parameter Name="paymentInfo" Type="Object" />--%>
		<asp:Parameter Name="amazonToken" Type="String" />
	</InsertParameters>
</asp:ObjectDataSource>