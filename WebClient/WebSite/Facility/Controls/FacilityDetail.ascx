<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FacilityDetail.ascx.cs" Inherits="Facility_Controls_FacilityDetail" %>

<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>
<%@ Register Assembly="ISNet.WebUI.ISDataSource, Version=1.0.1500.1, Culture=neutral, PublicKeyToken=c4184ef0d326354b"
	Namespace="ISNet.WebUI.DataSource" TagPrefix="ISDataSource" %>
<%@ Register Assembly="ISNet.WebUI.WebDesktop" Namespace="ISNet.WebUI.WebDesktop" TagPrefix="ISWebDesktop" %>
<%@ Register Assembly="ISNet.WebUI.WebInput" Namespace="ISNet.WebUI.WebControls" TagPrefix="ISWebInput" %>

<asp:FormView ID="fvFacility" runat="server" DataSourceID="odsFacility" DataKeyNames="FacilityGuid" AllowPaging="false" DefaultMode="ReadOnly">
	<EmptyDataTemplate>
		No data retrieved.<br />
		<asp:LinkButton ID="btnNew" runat="server" CausesValidation="false" CommandName="New" Text="New"></asp:LinkButton>
	</EmptyDataTemplate>
	<EditItemTemplate>
		<table>
			<tr><td>Facility Guid</td><td><asp:Label ID="lblFacilityGuid" runat="server" Text='<%# Bind("FacilityGuid") %>' /></td></tr>
			<tr><td>Facility ID</td><td><asp:Label ID="lblFacilityID" runat="server" Text='<%# Bind("FacilityID") %>' /></td></tr>
			<tr><td>Facility Name:</td><td><asp:TextBox ID="txtFacilityName" runat="server" Text='<%# Bind("FacilityName") %>' Width="150px" MaxLength="50" /></td></tr>
			<tr><td>Exerpt:</td><td><asp:TextBox ID="txtExerpt" runat="server" Text='<%# Bind("Exerpt") %>' Width="150px" MaxLength="200" TextMode="MultiLine" /></td></tr>
			<tr><td>Description:</td><td><asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>' Width="150px" MaxLength="500" TextMode="MultiLine" /></td></tr>
			<tr><td>Address:</td><td><asp:TextBox ID="txtAddress" runat="server" Text='<%# Bind("Address") %>' Width="150px" MaxLength="100" TextMode="MultiLine" /></td></tr>
			<tr><td>City State Zip Guid City State Zip:</td><td><ISWebCombo:WebCombo ID="wcCityStateZip" runat="server" UseDefaultStyle="True" DataSourceID="isdFacilityCityStateZip" DataTextField="PDC" DataValueField="CityStateZipGuid" Height="20px" Width="200px" /></td></tr>
			<tr><td>Phone Number:</td><td><asp:TextBox ID="txtPhoneNumber" runat="server" Text='<%# Bind("PhoneNumber") %>' Width="150px" MaxLength="10" /></td></tr>
			<tr><td>Email:</td><td><asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>' Width="150px" MaxLength="100" TextMode="MultiLine" /></td></tr>
			<tr><td>Website:</td><td><asp:TextBox ID="txtWebsite" runat="server" Text='<%# Bind("Website") %>' Width="150px" MaxLength="100" TextMode="MultiLine" /></td></tr>
			<tr><td>Client Guid Client:</td><td><ISWebCombo:WebCombo ID="wcClient" runat="server" UseDefaultStyle="True" DataSourceID="isdFacilityClient" DataTextField="PDC" DataValueField="ClientGuid" Height="20px" Width="200px" /></td></tr>
			<tr><td>Listing Type Guid Listing Type:</td><td><ISWebCombo:WebCombo ID="wcListingType" runat="server" UseDefaultStyle="True" DataSourceID="isdFacilityListingType" DataTextField="PDC" DataValueField="ListingTypeGuid" Height="20px" Width="200px" /></td></tr>
			<tr><td>Public Photo File Uri:</td><td><asp:TextBox ID="txtPublicPhotoFileUri" runat="server" Text='<%# Bind("PublicPhotoFileUri") %>' Width="150px" MaxLength="100" TextMode="MultiLine" /></td></tr>
		</table>
		<asp:Label ID="lblCityStateZipGuid" runat="server" Text='<%# Eval("CityStateZipGuid") %>' Visible="false" />
		<asp:Label ID="lblClientGuid" runat="server" Text='<%# Eval("ClientGuid") %>' Visible="false" />
		<asp:Label ID="lblListingTypeGuid" runat="server" Text='<%# Eval("ListingTypeGuid") %>' Visible="false" />
		<asp:LinkButton ID="btnUpdate" runat="server" CausesValidation="true" CommandName="Update" Text="Update"></asp:LinkButton>
		<asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
		<asp:LinkButton ID="btnCancel" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
	</EditItemTemplate>
	<ItemTemplate>
		<table>
			<tr><td>Facility Guid</td><td><asp:Label ID="lblFacilityGuid" runat="server" Text='<%# Bind("FacilityGuid") %>' /></td></tr>
			<tr><td>Facility ID:</td><td><asp:Label ID="lblFacilityID" runat="server" Text='<%# Bind("FacilityID") %>' /></td></tr>
			<tr><td>Facility Name:</td><td><asp:Label ID="lblFacilityName" runat="server" Text='<%# Bind("FacilityName") %>' /></td></tr>
			<tr><td>Exerpt:</td><td><asp:Label ID="lblExerpt" runat="server" Text='<%# Bind("Exerpt") %>' /></td></tr>
			<tr><td>Description:</td><td><asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>' /></td></tr>
			<tr><td>Address:</td><td><asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>' /></td></tr>
			<tr><td>City:</td><td><asp:Label ID="txtCityStateZip" runat="server" Text='<%# Bind("CityStateZipGuidPDC") %>' /></td></tr>
			<tr><td>Phone Number:</td><td><asp:Label ID="lblPhoneNumber" runat="server" Text='<%# Bind("PhoneNumber") %>' /></td></tr>
			<tr><td>Email:</td><td><asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>' /></td></tr>
			<tr><td>Website:</td><td><asp:Label ID="lblWebsite" runat="server" Text='<%# Bind("Website") %>' /></td></tr>
			<tr><td>Client Name:</td><td><asp:Label ID="txtClient" runat="server" Text='<%# Bind("ClientGuidPDC") %>' /></td></tr>
			<tr><td>Listing Type Name:</td><td><asp:Label ID="txtListingType" runat="server" Text='<%# Bind("ListingTypeGuidPDC") %>' /></td></tr>
			<tr><td>Public Photo File Uri:</td><td><asp:Label ID="lblPublicPhotoFileUri" runat="server" Text='<%# Bind("PublicPhotoFileUri") %>' /></td></tr>
		</table>
		<asp:LinkButton ID="btnEdit" runat="server" CausesValidation="true" CommandName="Edit" Text="Edit"></asp:LinkButton>
		<asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
		<asp:LinkButton ID="btnNew" runat="server" CausesValidation="false" CommandName="New" Text="New"></asp:LinkButton>
	</ItemTemplate>
	<InsertItemTemplate>
		<table>
			<tr><td>Facility Name:</td><td><asp:TextBox ID="txtFacilityName" runat="server" Text='<%# Bind("FacilityName") %>' Width="150px" MaxLength="50" /><br /></td></tr>
			<tr><td>Exerpt:</td><td><asp:TextBox ID="txtExerpt" runat="server" Text='<%# Bind("Exerpt") %>' Width="150px" MaxLength="200" TextMode="MultiLine" /><br /></td></tr>
			<tr><td>Description:</td><td><asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>' Width="150px" MaxLength="500" TextMode="MultiLine" /><br /></td></tr>
			<tr><td>Address:</td><td><asp:TextBox ID="txtAddress" runat="server" Text='<%# Bind("Address") %>' Width="150px" MaxLength="100" TextMode="MultiLine" /><br /></td></tr>
			<tr><td>City State Zip:</td><td><ISWebCombo:WebCombo ID="wcCityStateZip" runat="server" UseDefaultStyle="True" DataSourceID="isdFacilityCityStateZip" DataTextField="PDC" DataValueField="CityStateZipGuid" Height="20px" Width="200px" /></td></tr>
			<tr><td>Phone Number:</td><td><asp:TextBox ID="txtPhoneNumber" runat="server" Text='<%# Bind("PhoneNumber") %>' Width="150px" MaxLength="10" /><br /></td></tr>
			<tr><td>Email:</td><td><asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>' Width="150px" MaxLength="100" TextMode="MultiLine" /><br /></td></tr>
			<tr><td>Website:</td><td><asp:TextBox ID="txtWebsite" runat="server" Text='<%# Bind("Website") %>' Width="150px" MaxLength="100" TextMode="MultiLine" /><br /></td></tr>
			<tr><td>Client:</td><td><ISWebCombo:WebCombo ID="wcClient" runat="server" UseDefaultStyle="True" DataSourceID="isdFacilityClient" DataTextField="PDC" DataValueField="ClientGuid" Height="20px" Width="200px" /></td></tr>
			<tr><td>Listing Type:</td><td><ISWebCombo:WebCombo ID="wcListingType" runat="server" UseDefaultStyle="True" DataSourceID="isdFacilityListingType" DataTextField="PDC" DataValueField="ListingTypeGuid" Height="20px" Width="200px" /></td></tr>
			<tr><td>Public Photo File Uri:</td><td><asp:TextBox ID="txtPublicPhotoFileUri" runat="server" Text='<%# Bind("PublicPhotoFileUri") %>' Width="150px" MaxLength="100" TextMode="MultiLine" /><br /></td></tr>
		</table>
		<asp:Label ID="lblFacilityGuid" runat="server" Text='<%# Bind("FacilityGuid") %>' Visible="false">{00000000-0000-0000-0000-000000000000}</asp:Label><br />
    <asp:Label ID="lblFacilityID" runat="server" Text='<%# Bind("FacilityID") %>' Visible="false" >-1</asp:Label><br />
		<asp:LinkButton ID="btnInsert" runat="server" CausesValidation="true" CommandName="Insert" Text="Insert"></asp:LinkButton>
		<asp:LinkButton ID="btnCancel" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
	</InsertItemTemplate>
</asp:FormView>
<asp:ObjectDataSource ID="odsFacility" runat="server" DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.Facility"
	OldValuesParameterFormatString="original_{0}" TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess"
	SelectMethod="GetFacility" InsertMethod="InsertFacility"
	UpdateMethod="UpdateFacility" DeleteMethod="DeleteFacility">
	<SelectParameters>
		<asp:QueryStringParameter Name="facilityGuid" QueryStringField="FacilityGuid" Type="String" />
	</SelectParameters>
	<InsertParameters>
		<%--<asp:Parameter Name="facility" Type="Object" />--%>
		<asp:Parameter Name="facilityName" Type="String" />
		<asp:Parameter Name="exerpt" Type="String" />
		<asp:Parameter Name="description" Type="String" />
		<asp:Parameter Name="address" Type="String" />
		<asp:Parameter Name="cityStateZipGuid" Type="String" />
		<asp:Parameter Name="phoneNumber" Type="String" />
		<asp:Parameter Name="email" Type="String" />
		<asp:Parameter Name="website" Type="String" />
		<asp:Parameter Name="clientGuid" Type="String" />
		<asp:Parameter Name="listingTypeGuid" Type="String" />
		<asp:Parameter Name="publicPhotoFileUri" Type="String" />
	</InsertParameters>
</asp:ObjectDataSource>
<ISDataSource:ISDataSource ID="isdFacilityCityStateZip" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.CityStateZipCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.CityStateZip" TableName="CityStateZipCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" SelectMethod="GetCityStateZips">
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>
<ISDataSource:ISDataSource ID="isdFacilityClient" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.ClientCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.Client" TableName="ClientCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" SelectMethod="GetClients">
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>
<ISDataSource:ISDataSource ID="isdFacilityListingType" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.ListingTypeCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.ListingType" TableName="ListingTypeCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" SelectMethod="GetListingTypes">
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>