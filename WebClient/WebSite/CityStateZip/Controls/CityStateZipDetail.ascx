<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CityStateZipDetail.ascx.cs" Inherits="CityStateZip_Controls_CityStateZipDetail" %>

<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>
<%@ Register Assembly="ISNet.WebUI.ISDataSource, Version=1.0.1500.1, Culture=neutral, PublicKeyToken=c4184ef0d326354b"
	Namespace="ISNet.WebUI.DataSource" TagPrefix="ISDataSource" %>
<%@ Register Assembly="ISNet.WebUI.WebDesktop" Namespace="ISNet.WebUI.WebDesktop" TagPrefix="ISWebDesktop" %>
<%@ Register Assembly="ISNet.WebUI.WebInput" Namespace="ISNet.WebUI.WebControls" TagPrefix="ISWebInput" %>

<asp:FormView ID="fvCityStateZip" runat="server" DataSourceID="odsCityStateZip" DataKeyNames="CityStateZipGuid" AllowPaging="false" DefaultMode="ReadOnly">
	<EmptyDataTemplate>
		No data retrieved.<br />
		<asp:LinkButton ID="btnNew" runat="server" CausesValidation="false" CommandName="New" Text="New"></asp:LinkButton>
	</EmptyDataTemplate>
	<EditItemTemplate>
		<table>
			<tr><td>City State Zip Guid</td><td><asp:Label ID="lblCityStateZipGuid" runat="server" Text='<%# Bind("CityStateZipGuid") %>' /></td></tr>
			<tr><td>City:</td><td><asp:TextBox ID="txtCity" runat="server" Text='<%# Bind("City") %>' Width="150px" MaxLength="50" /></td></tr>
			<tr><td>State:</td><td><asp:TextBox ID="txtState" runat="server" Text='<%# Bind("State") %>' Width="150px" MaxLength="50" /></td></tr>
			<tr><td>Zip Code:</td><td><asp:TextBox ID="txtZipCode" runat="server" Text='<%# Bind("ZipCode") %>' Width="150px" MaxLength="5" /></td></tr>
		</table>
		<asp:LinkButton ID="btnUpdate" runat="server" CausesValidation="true" CommandName="Update" Text="Update"></asp:LinkButton>
		<asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
		<asp:LinkButton ID="btnCancel" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
	</EditItemTemplate>
	<ItemTemplate>
		<table>
			<tr><td>City State Zip Guid</td><td><asp:Label ID="lblCityStateZipGuid" runat="server" Text='<%# Bind("CityStateZipGuid") %>' /></td></tr>
			<tr><td>City:</td><td><asp:Label ID="lblCity" runat="server" Text='<%# Bind("City") %>' /></td></tr>
			<tr><td>State:</td><td><asp:Label ID="lblState" runat="server" Text='<%# Bind("State") %>' /></td></tr>
			<tr><td>Zip Code:</td><td><asp:Label ID="lblZipCode" runat="server" Text='<%# Bind("ZipCode") %>' /></td></tr>
		</table>
		<asp:LinkButton ID="btnEdit" runat="server" CausesValidation="true" CommandName="Edit" Text="Edit"></asp:LinkButton>
		<asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
		<asp:LinkButton ID="btnNew" runat="server" CausesValidation="false" CommandName="New" Text="New"></asp:LinkButton>
	</ItemTemplate>
	<InsertItemTemplate>
		<table>
			<tr><td>City:</td><td><asp:TextBox ID="txtCity" runat="server" Text='<%# Bind("City") %>' Width="150px" MaxLength="50" /><br /></td></tr>
			<tr><td>State:</td><td><asp:TextBox ID="txtState" runat="server" Text='<%# Bind("State") %>' Width="150px" MaxLength="50" /><br /></td></tr>
			<tr><td>Zip Code:</td><td><asp:TextBox ID="txtZipCode" runat="server" Text='<%# Bind("ZipCode") %>' Width="150px" MaxLength="5" /><br /></td></tr>
		</table>
		<asp:Label ID="lblCityStateZipGuid" runat="server" Text='<%# Bind("CityStateZipGuid") %>' Visible="false">{00000000-0000-0000-0000-000000000000}</asp:Label><br />
		<asp:LinkButton ID="btnInsert" runat="server" CausesValidation="true" CommandName="Insert" Text="Insert"></asp:LinkButton>
		<asp:LinkButton ID="btnCancel" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
	</InsertItemTemplate>
</asp:FormView>
<asp:ObjectDataSource ID="odsCityStateZip" runat="server" DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.CityStateZip"
	OldValuesParameterFormatString="original_{0}" TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess"
	SelectMethod="GetCityStateZip" InsertMethod="InsertCityStateZip"
	UpdateMethod="UpdateCityStateZip" DeleteMethod="DeleteCityStateZip">
	<SelectParameters>
		<asp:QueryStringParameter Name="cityStateZipGuid" QueryStringField="CityStateZipGuid" Type="String" />
	</SelectParameters>
	<InsertParameters>
		<%--<asp:Parameter Name="cityStateZip" Type="Object" />--%>
		<asp:Parameter Name="city" Type="String" />
		<asp:Parameter Name="state" Type="String" />
		<asp:Parameter Name="zipCode" Type="String" />
	</InsertParameters>
</asp:ObjectDataSource>