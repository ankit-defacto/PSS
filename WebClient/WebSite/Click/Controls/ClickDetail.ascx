<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ClickDetail.ascx.cs" Inherits="Click_Controls_ClickDetail" %>

<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>
<%@ Register Assembly="ISNet.WebUI.ISDataSource, Version=1.0.1500.1, Culture=neutral, PublicKeyToken=c4184ef0d326354b"
	Namespace="ISNet.WebUI.DataSource" TagPrefix="ISDataSource" %>
<%@ Register Assembly="ISNet.WebUI.WebDesktop" Namespace="ISNet.WebUI.WebDesktop" TagPrefix="ISWebDesktop" %>
<%@ Register Assembly="ISNet.WebUI.WebInput" Namespace="ISNet.WebUI.WebControls" TagPrefix="ISWebInput" %>

<asp:FormView ID="fvClick" runat="server" DataSourceID="odsClick" DataKeyNames="ClickGuid" AllowPaging="false" DefaultMode="ReadOnly">
	<EmptyDataTemplate>
		No data retrieved.<br />
		<asp:LinkButton ID="btnNew" runat="server" CausesValidation="false" CommandName="New" Text="New"></asp:LinkButton>
	</EmptyDataTemplate>
	<EditItemTemplate>
		<table>
			<tr><td>Click Guid</td><td><asp:Label ID="lblClickGuid" runat="server" Text='<%# Bind("ClickGuid") %>' /></td></tr>
			<tr><td>Facility Guid Facility:</td><td><ISWebCombo:WebCombo ID="wcFacility" runat="server" UseDefaultStyle="True" DataSourceID="isdClickFacility" DataTextField="PDC" DataValueField="FacilityGuid" Height="20px" Width="200px" /></td></tr>
			<tr><td>Listing Type Guid Listing Type:</td><td><ISWebCombo:WebCombo ID="wcListingType" runat="server" UseDefaultStyle="True" DataSourceID="isdClickListingType" DataTextField="PDC" DataValueField="ListingTypeGuid" Height="20px" Width="200px" /></td></tr>
			<tr><td>Time Stamp:</td><td><asp:TextBox ID="txtTimeStamp" runat="server" Text='<%# Bind("TimeStamp") %>' Width="175px" /></td></tr>
		</table>
		<asp:Label ID="lblFacilityGuid" runat="server" Text='<%# Eval("FacilityGuid") %>' Visible="false" />
		<asp:Label ID="lblListingTypeGuid" runat="server" Text='<%# Eval("ListingTypeGuid") %>' Visible="false" />
		<asp:LinkButton ID="btnUpdate" runat="server" CausesValidation="true" CommandName="Update" Text="Update"></asp:LinkButton>
		<asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
		<asp:LinkButton ID="btnCancel" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
	</EditItemTemplate>
	<ItemTemplate>
		<table>
			<tr><td>Click Guid</td><td><asp:Label ID="lblClickGuid" runat="server" Text='<%# Bind("ClickGuid") %>' /></td></tr>
			<tr><td>Facility Name:</td><td><asp:Label ID="txtFacility" runat="server" Text='<%# Bind("FacilityGuidPDC") %>' /></td></tr>
			<tr><td>Listing Type Name:</td><td><asp:Label ID="txtListingType" runat="server" Text='<%# Bind("ListingTypeGuidPDC") %>' /></td></tr>
			<tr><td>Time Stamp:</td><td><asp:Label ID="lblTimeStamp" runat="server" Text='<%# Bind("TimeStamp") %>' /></td></tr>
		</table>
		<asp:LinkButton ID="btnEdit" runat="server" CausesValidation="true" CommandName="Edit" Text="Edit"></asp:LinkButton>
		<asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
		<asp:LinkButton ID="btnNew" runat="server" CausesValidation="false" CommandName="New" Text="New"></asp:LinkButton>
	</ItemTemplate>
	<InsertItemTemplate>
		<table>
			<tr><td>Facility:</td><td><ISWebCombo:WebCombo ID="wcFacility" runat="server" UseDefaultStyle="True" DataSourceID="isdClickFacility" DataTextField="PDC" DataValueField="FacilityGuid" Height="20px" Width="200px" /></td></tr>
			<tr><td>Listing Type:</td><td><ISWebCombo:WebCombo ID="wcListingType" runat="server" UseDefaultStyle="True" DataSourceID="isdClickListingType" DataTextField="PDC" DataValueField="ListingTypeGuid" Height="20px" Width="200px" /></td></tr>
			<tr><td>Time Stamp:</td><td><asp:TextBox ID="txtTimeStamp" runat="server" Text='<%# Bind("TimeStamp") %>' Width="175px" /><br /></td></tr>
		</table>
		<asp:Label ID="lblClickGuid" runat="server" Text='<%# Bind("ClickGuid") %>' Visible="false">{00000000-0000-0000-0000-000000000000}</asp:Label><br />
		<asp:LinkButton ID="btnInsert" runat="server" CausesValidation="true" CommandName="Insert" Text="Insert"></asp:LinkButton>
		<asp:LinkButton ID="btnCancel" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
	</InsertItemTemplate>
</asp:FormView>
<asp:ObjectDataSource ID="odsClick" runat="server" DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.Click"
	OldValuesParameterFormatString="original_{0}" TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess"
	SelectMethod="GetClick" InsertMethod="InsertClick"
	UpdateMethod="UpdateClick" DeleteMethod="DeleteClick">
	<SelectParameters>
		<asp:QueryStringParameter Name="clickGuid" QueryStringField="ClickGuid" Type="String" />
	</SelectParameters>
	<InsertParameters>
		<%--<asp:Parameter Name="click" Type="Object" />--%>
		<asp:Parameter Name="facilityGuid" Type="String" />
		<asp:Parameter Name="listingTypeGuid" Type="String" />
		<asp:Parameter Name="timeStamp" Type="DateTime" />
	</InsertParameters>
</asp:ObjectDataSource>
<ISDataSource:ISDataSource ID="isdClickFacility" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.FacilityCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.Facility" TableName="FacilityCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" SelectMethod="GetFacilities">
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>
<ISDataSource:ISDataSource ID="isdClickListingType" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.ListingTypeCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.ListingType" TableName="ListingTypeCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" SelectMethod="GetListingTypes">
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>