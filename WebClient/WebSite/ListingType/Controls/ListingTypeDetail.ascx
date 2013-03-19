<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListingTypeDetail.ascx.cs" Inherits="ListingType_Controls_ListingTypeDetail" %>

<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>
<%@ Register Assembly="ISNet.WebUI.ISDataSource, Version=1.0.1500.1, Culture=neutral, PublicKeyToken=c4184ef0d326354b"
	Namespace="ISNet.WebUI.DataSource" TagPrefix="ISDataSource" %>
<%@ Register Assembly="ISNet.WebUI.WebDesktop" Namespace="ISNet.WebUI.WebDesktop" TagPrefix="ISWebDesktop" %>
<%@ Register Assembly="ISNet.WebUI.WebInput" Namespace="ISNet.WebUI.WebControls" TagPrefix="ISWebInput" %>

<asp:FormView ID="fvListingType" runat="server" DataSourceID="odsListingType" DataKeyNames="ListingTypeGuid" AllowPaging="false" DefaultMode="ReadOnly">
	<EmptyDataTemplate>
		No data retrieved.<br />
		<asp:LinkButton ID="btnNew" runat="server" CausesValidation="false" CommandName="New" Text="New"></asp:LinkButton>
	</EmptyDataTemplate>
	<EditItemTemplate>
		<table>
			<tr><td>Listing Type Guid</td><td><asp:Label ID="lblListingTypeGuid" runat="server" Text='<%# Bind("ListingTypeGuid") %>' /></td></tr>
			<tr><td>Listing Type Name:</td><td><asp:TextBox ID="txtListingTypeName" runat="server" Text='<%# Bind("ListingTypeName") %>' Width="150px" MaxLength="50" /></td></tr>
		</table>
		<asp:LinkButton ID="btnUpdate" runat="server" CausesValidation="true" CommandName="Update" Text="Update"></asp:LinkButton>
		<asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
		<asp:LinkButton ID="btnCancel" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
	</EditItemTemplate>
	<ItemTemplate>
		<table>
			<tr><td>Listing Type Guid</td><td><asp:Label ID="lblListingTypeGuid" runat="server" Text='<%# Bind("ListingTypeGuid") %>' /></td></tr>
			<tr><td>Listing Type Name:</td><td><asp:Label ID="lblListingTypeName" runat="server" Text='<%# Bind("ListingTypeName") %>' /></td></tr>
		</table>
		<asp:LinkButton ID="btnEdit" runat="server" CausesValidation="true" CommandName="Edit" Text="Edit"></asp:LinkButton>
		<asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
		<asp:LinkButton ID="btnNew" runat="server" CausesValidation="false" CommandName="New" Text="New"></asp:LinkButton>
	</ItemTemplate>
	<InsertItemTemplate>
		<table>
			<tr><td>Listing Type Name:</td><td><asp:TextBox ID="txtListingTypeName" runat="server" Text='<%# Bind("ListingTypeName") %>' Width="150px" MaxLength="50" /><br /></td></tr>
		</table>
		<asp:Label ID="lblListingTypeGuid" runat="server" Text='<%# Bind("ListingTypeGuid") %>' Visible="false">{00000000-0000-0000-0000-000000000000}</asp:Label><br />
		<asp:LinkButton ID="btnInsert" runat="server" CausesValidation="true" CommandName="Insert" Text="Insert"></asp:LinkButton>
		<asp:LinkButton ID="btnCancel" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
	</InsertItemTemplate>
</asp:FormView>
<asp:ObjectDataSource ID="odsListingType" runat="server" DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.ListingType"
	OldValuesParameterFormatString="original_{0}" TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess"
	SelectMethod="GetListingType" InsertMethod="InsertListingType"
	UpdateMethod="UpdateListingType" DeleteMethod="DeleteListingType">
	<SelectParameters>
		<asp:QueryStringParameter Name="listingTypeGuid" QueryStringField="ListingTypeGuid" Type="String" />
	</SelectParameters>
	<InsertParameters>
		<%--<asp:Parameter Name="listingType" Type="Object" />--%>
		<asp:Parameter Name="listingTypeName" Type="String" />
	</InsertParameters>
</asp:ObjectDataSource>