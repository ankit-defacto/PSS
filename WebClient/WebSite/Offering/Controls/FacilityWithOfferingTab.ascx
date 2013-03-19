<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FacilityWithOfferingTab.ascx.cs" Inherits="Offering_Controls_FacilityWithOfferingTab" %>

<%@ Register Assembly="ISNet.WebUI.ISDataSource, Version=1.0.1500.1, Culture=neutral, PublicKeyToken=c4184ef0d326354b"
	Namespace="ISNet.WebUI.DataSource" TagPrefix="ISDataSource" %>
<%@ Register Assembly="ISNet.WebUI.WebGrid" Namespace="ISNet.WebUI.WebGrid" TagPrefix="ISWebGrid" %>
<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>

<div>
	<asp:UpdatePanel ID="upFacilityNotFor" runat="server" UpdateMode="Conditional">
	<ContentTemplate>
			<ISWebCombo:WebCombo ID="wcFacilitiesNotForOffering" runat="server" DataSourceID="isdsFacilitiesNotForOffering"
				DataValueField="FacilityGuid" DataTextField="FacilityName"
				Height="20px" Width="200px" UseDefaultStyle="True">
			</ISWebCombo:WebCombo>
		IsChecked: <asp:TextBox ID="txtIsChecked" runat="server" />
		<asp:Button ID="btnAddFacilityToOffering" runat="server" Text="Add Facility To Offering" OnClick="btnAddFacilityToOffering_Click" />		  
	</ContentTemplate>
	</asp:UpdatePanel>
</div>
<br />

<div>
	<asp:UpdatePanel ID="upFacilityWith" runat="server" UpdateMode="Conditional">
	<ContentTemplate>
		<ISWebGrid:WebGrid ID="wgFacilityWithOffering" runat="server" Height="250px"
			Width="600px" DataSourceID="isdsFacilitiesWithOffering" UseDefaultStyle="True" >
			<RootTable Caption="Facilities" DataKeyField="FacilityGuid">
				<Columns>
					<ISWebGrid:WebGridColumn AllowGrouping="No" AllowSizing="No" AllowSorting="No" Bound="False"
						ColumnType="CheckBox" EditType="NoEdit" IsRowChecker="True" Name="selectionColumn" ShowInSelectColumns="No"
						Width="25px" />
					<ISWebGrid:WebGridColumn Name="FacilityID" DataMember="FacilityID" Caption="Facility ID"
						Width="100px" EditType="NoEdit" DataType="System.Int32" />
					<ISWebGrid:WebGridColumn Name="FacilityName" DataMember="FacilityName" Caption="Facility Name"
						Width="150px" EditType="NoEdit" DataType="System.String" />
					<ISWebGrid:WebGridColumn Name="Exerpt" DataMember="Exerpt" Caption="Exerpt"
						Width="150px" EditType="NoEdit" DataType="System.String" />
					<ISWebGrid:WebGridColumn Name="Description" DataMember="Description" Caption="Description"
						Width="150px" EditType="NoEdit" DataType="System.String" />
					<ISWebGrid:WebGridColumn Name="Address" DataMember="Address" Caption="Address"
						Width="150px" EditType="NoEdit" DataType="System.String" />
					<ISWebGrid:WebGridColumn Name="CityStateZipGuid" DataMember="CityStateZipGuid" Caption="City State Zip Guid"
						Width="200px" EditType="NoEdit" DataType="System.Guid" />
					<ISWebGrid:WebGridColumn Name="PhoneNumber" DataMember="PhoneNumber" Caption="Phone Number"
						Width="150px" EditType="NoEdit" DataType="System.String" />
					<ISWebGrid:WebGridColumn Name="Email" DataMember="Email" Caption="Email"
						Width="150px" EditType="NoEdit" DataType="System.String" />
					<ISWebGrid:WebGridColumn Name="Website" DataMember="Website" Caption="Website"
						Width="150px" EditType="NoEdit" DataType="System.String" />
					<ISWebGrid:WebGridColumn Name="ClientGuid" DataMember="ClientGuid" Caption="Client Guid"
						Width="200px" EditType="NoEdit" DataType="System.Guid" />
					<ISWebGrid:WebGridColumn Name="ListingTypeGuid" DataMember="ListingTypeGuid" Caption="Listing Type Guid"
						Width="200px" EditType="NoEdit" DataType="System.Guid" />
					<ISWebGrid:WebGridColumn Name="PublicPhotoFileUri" DataMember="PublicPhotoFileUri" Caption="Public Photo File Uri"
						Width="150px" EditType="NoEdit" DataType="System.String" />
					<ISWebGrid:WebGridColumn Name="IsChecked" DataMember="IsChecked" Caption="Is Checked"
						Width="175px" EditType="NoEdit" DataType="System.Boolean" />
					<ISWebGrid:WebGridColumn Name="FacilityGuid" DataMember="FacilityGuid" Caption="Facility Guid" Visible="false"
						Width="200px" EditType="NoEdit" DataType="System.Guid" />
					<ISWebGrid:WebGridColumn Name="OfferingGuid" DataMember="OfferingGuid" Caption="Offering Guid" Visible="false"
						Width="200px" EditType="NoEdit" DataType="System.Guid" />
				</Columns>
			</RootTable>
			<LayoutSettings AllowSorting="Yes" AllowFilter="Yes" AllowColumnMove="Yes">
			</LayoutSettings>
		</ISWebGrid:WebGrid>
	</ContentTemplate>
	</asp:UpdatePanel>
</div>
<br />

<div>
	<asp:Button ID="btnDeleteFacilityFromOffering" runat="server" Text="Delete Selected Facility From Offering" OnClick="btnDeleteFacilityFromOffering_Click" />		   
</div>
<div>
	<asp:LinkButton ID="linkAddFacility" runat="server" PostBackUrl="~/Facility/FacilityDetail.aspx" Text="Create Facility" />
</div>

<asp:UpdatePanel ID="upFacilityDataSources" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<ISDataSource:ISDataSource ID="isdsFacilitiesWithOffering" runat="server"
	SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.FacilityWithOfferingCollection" SchemaType="CustomObject"
	LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.FacilityWithOffering"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" TableName="FacilityWithOffering"
			OldValuesParameterFormatString="Original_{0}"
			SelectMethod="GetFacilitiesWithOfferingForOffering" UpdateMethod="UpdateFacilityWithOffering">
			<SelectParameters>
				<asp:QueryStringParameter name="offeringGuid" QueryStringField="OfferingGuid" />
			</SelectParameters>
			<UpdateParameters>
				<asp:Parameter Name="offering" Type="Object" />
			</UpdateParameters>
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>
<ISDataSource:ISDataSource ID="isdsFacilitiesNotForOffering" runat="server"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.Facility"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" TableName="FacilitiesNotForOffering"
			SelectMethod="GetFacilitiesNotForOffering">
			<SelectParameters>
				<asp:QueryStringParameter name="offeringGuid" QueryStringField="OfferingGuid" />
			</SelectParameters>
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>
</ContentTemplate>
</asp:UpdatePanel>