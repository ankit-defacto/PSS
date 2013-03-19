<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FacilityPhotoDetail.ascx.cs" Inherits="FacilityPhoto_Controls_FacilityPhotoDetail" %>

<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>
<%@ Register Assembly="ISNet.WebUI.ISDataSource, Version=1.0.1500.1, Culture=neutral, PublicKeyToken=c4184ef0d326354b"
	Namespace="ISNet.WebUI.DataSource" TagPrefix="ISDataSource" %>
<%@ Register Assembly="ISNet.WebUI.WebDesktop" Namespace="ISNet.WebUI.WebDesktop" TagPrefix="ISWebDesktop" %>
<%@ Register Assembly="ISNet.WebUI.WebInput" Namespace="ISNet.WebUI.WebControls" TagPrefix="ISWebInput" %>

<asp:FormView ID="fvFacilityPhoto" runat="server" DataSourceID="odsFacilityPhoto" DataKeyNames="FacilityPhotoGuid" AllowPaging="false" DefaultMode="ReadOnly">
	<EmptyDataTemplate>
		No data retrieved.<br />
		<asp:LinkButton ID="btnNew" runat="server" CausesValidation="false" CommandName="New" Text="New"></asp:LinkButton>
	</EmptyDataTemplate>
	<EditItemTemplate>
		<table>
			<tr><td>Photo Guid</td><td><asp:Label ID="lblFacilityPhotoGuid" runat="server" Text='<%# Bind("FacilityPhotoGuid") %>' /></td></tr>
			<tr><td>Photo Uri:</td><td><asp:TextBox ID="txtPhotoUri" runat="server" Text='<%# Bind("PhotoUri") %>' Width="150px" MaxLength="200" TextMode="MultiLine" /></td></tr>
			<tr><td>Facility Guid Facility:</td><td><ISWebCombo:WebCombo ID="wcFacility" runat="server" UseDefaultStyle="True" DataSourceID="isdFacilityPhotoFacility" DataTextField="PDC" DataValueField="FacilityGuid" Height="20px" Width="200px" /></td></tr>
		</table>
		<asp:Label ID="lblFacilityGuid" runat="server" Text='<%# Eval("FacilityGuid") %>' Visible="false" />
		<asp:LinkButton ID="btnUpdate" runat="server" CausesValidation="true" CommandName="Update" Text="Update"></asp:LinkButton>
		<asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
		<asp:LinkButton ID="btnCancel" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
	</EditItemTemplate>
	<ItemTemplate>
		<table>
			<tr><td>Photo Guid</td><td><asp:Label ID="lblFacilityPhotoGuid" runat="server" Text='<%# Bind("FacilityPhotoGuid") %>' /></td></tr>
			<tr><td>Photo Uri:</td><td><asp:Label ID="lblPhotoUri" runat="server" Text='<%# Bind("PhotoUri") %>' /></td></tr>
			<tr><td>Facility Name:</td><td><asp:Label ID="txtFacility" runat="server" Text='<%# Bind("FacilityGuidPDC") %>' /></td></tr>
		</table>
		<asp:LinkButton ID="btnEdit" runat="server" CausesValidation="true" CommandName="Edit" Text="Edit"></asp:LinkButton>
		<asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
		<asp:LinkButton ID="btnNew" runat="server" CausesValidation="false" CommandName="New" Text="New"></asp:LinkButton>
	</ItemTemplate>
	<InsertItemTemplate>
		<table>
			<tr><td>Photo Uri:</td><td><asp:TextBox ID="txtPhotoUri" runat="server" Text='<%# Bind("PhotoUri") %>' Width="150px" MaxLength="200" TextMode="MultiLine" /><br /></td></tr>
			<tr><td>Facility:</td><td><ISWebCombo:WebCombo ID="wcFacility" runat="server" UseDefaultStyle="True" DataSourceID="isdFacilityPhotoFacility" DataTextField="PDC" DataValueField="FacilityGuid" Height="20px" Width="200px" /></td></tr>
		</table>
		<asp:Label ID="lblFacilityPhotoGuid" runat="server" Text='<%# Bind("FacilityPhotoGuid") %>' Visible="false">{00000000-0000-0000-0000-000000000000}</asp:Label><br />
		<asp:LinkButton ID="btnInsert" runat="server" CausesValidation="true" CommandName="Insert" Text="Insert"></asp:LinkButton>
		<asp:LinkButton ID="btnCancel" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
	</InsertItemTemplate>
</asp:FormView>
<asp:ObjectDataSource ID="odsFacilityPhoto" runat="server" DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.FacilityPhoto"
	OldValuesParameterFormatString="original_{0}" TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess"
	SelectMethod="GetFacilityPhoto" InsertMethod="InsertFacilityPhoto"
	UpdateMethod="UpdateFacilityPhoto" DeleteMethod="DeleteFacilityPhoto">
	<SelectParameters>
		<asp:QueryStringParameter Name="facilityPhotoGuid" QueryStringField="FacilityPhotoGuid" Type="String" />
	</SelectParameters>
	<InsertParameters>
		<%--<asp:Parameter Name="facilityPhoto" Type="Object" />--%>
		<asp:Parameter Name="photoUri" Type="String" />
		<asp:Parameter Name="facilityGuid" Type="String" />
	</InsertParameters>
</asp:ObjectDataSource>
<ISDataSource:ISDataSource ID="isdFacilityPhotoFacility" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.FacilityCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.Facility" TableName="FacilityCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" SelectMethod="GetFacilities">
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>