<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OfferingDetail.ascx.cs" Inherits="Offering_Controls_OfferingDetail" %>

<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>
<%@ Register Assembly="ISNet.WebUI.ISDataSource, Version=1.0.1500.1, Culture=neutral, PublicKeyToken=c4184ef0d326354b"
	Namespace="ISNet.WebUI.DataSource" TagPrefix="ISDataSource" %>
<%@ Register Assembly="ISNet.WebUI.WebDesktop" Namespace="ISNet.WebUI.WebDesktop" TagPrefix="ISWebDesktop" %>
<%@ Register Assembly="ISNet.WebUI.WebInput" Namespace="ISNet.WebUI.WebControls" TagPrefix="ISWebInput" %>

<asp:FormView ID="fvOffering" runat="server" DataSourceID="odsOffering" DataKeyNames="OfferingGuid" AllowPaging="false" DefaultMode="ReadOnly">
	<EmptyDataTemplate>
		No data retrieved.<br />
		<asp:LinkButton ID="btnNew" runat="server" CausesValidation="false" CommandName="New" Text="New"></asp:LinkButton>
	</EmptyDataTemplate>
	<EditItemTemplate>
		<table>
			<tr><td>Offering Guid</td><td><asp:Label ID="lblOfferingGuid" runat="server" Text='<%# Bind("OfferingGuid") %>' /></td></tr>
			<tr><td>Offering ID</td><td><asp:Label ID="lblOfferingID" runat="server" Text='<%# Bind("OfferingID") %>' /></td></tr>
			<tr><td>Offering Name:</td><td><asp:TextBox ID="txtOfferingName" runat="server" Text='<%# Bind("OfferingName") %>' Width="150px" MaxLength="50" /></td></tr>
		</table>
		<asp:LinkButton ID="btnUpdate" runat="server" CausesValidation="true" CommandName="Update" Text="Update"></asp:LinkButton>
		<asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
		<asp:LinkButton ID="btnCancel" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
	</EditItemTemplate>
	<ItemTemplate>
		<table>
			<tr><td>Offering Guid</td><td><asp:Label ID="lblOfferingGuid" runat="server" Text='<%# Bind("OfferingGuid") %>' /></td></tr>
			<tr><td>Offering ID:</td><td><asp:Label ID="lblOfferingID" runat="server" Text='<%# Bind("OfferingID") %>' /></td></tr>
			<tr><td>Offering Name:</td><td><asp:Label ID="lblOfferingName" runat="server" Text='<%# Bind("OfferingName") %>' /></td></tr>
		</table>
		<asp:LinkButton ID="btnEdit" runat="server" CausesValidation="true" CommandName="Edit" Text="Edit"></asp:LinkButton>
		<asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
		<asp:LinkButton ID="btnNew" runat="server" CausesValidation="false" CommandName="New" Text="New"></asp:LinkButton>
	</ItemTemplate>
	<InsertItemTemplate>
		<table>
			<tr><td>Offering Name:</td><td><asp:TextBox ID="txtOfferingName" runat="server" Text='<%# Bind("OfferingName") %>' Width="150px" MaxLength="50" /><br /></td></tr>
		</table>
		<asp:Label ID="lblOfferingGuid" runat="server" Text='<%# Bind("OfferingGuid") %>' Visible="false">{00000000-0000-0000-0000-000000000000}</asp:Label><br />
    <asp:Label ID="lblOfferingID" runat="server" Text='<%# Bind("OfferingID") %>' Visible="false" >-1</asp:Label><br />
		<asp:LinkButton ID="btnInsert" runat="server" CausesValidation="true" CommandName="Insert" Text="Insert"></asp:LinkButton>
		<asp:LinkButton ID="btnCancel" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
	</InsertItemTemplate>
</asp:FormView>
<asp:ObjectDataSource ID="odsOffering" runat="server" DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.Offering"
	OldValuesParameterFormatString="original_{0}" TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess"
	SelectMethod="GetOffering" InsertMethod="InsertOffering"
	UpdateMethod="UpdateOffering" DeleteMethod="DeleteOffering">
	<SelectParameters>
		<asp:QueryStringParameter Name="offeringGuid" QueryStringField="OfferingGuid" Type="String" />
	</SelectParameters>
	<InsertParameters>
		<%--<asp:Parameter Name="offering" Type="Object" />--%>
		<asp:Parameter Name="offeringName" Type="String" />
	</InsertParameters>
</asp:ObjectDataSource>