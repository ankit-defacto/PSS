<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FacilityGrid.ascx.cs" Inherits="Facility_Controls_FacilityGrid" %>

<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>
<%@ Register Assembly="ISNet.WebUI.ISDataSource, Version=1.0.1500.1, Culture=neutral, PublicKeyToken=c4184ef0d326354b"
	Namespace="ISNet.WebUI.DataSource" TagPrefix="ISDataSource" %>
<%@ Register Assembly="ISNet.WebUI.WebGrid" Namespace="ISNet.WebUI.WebGrid" TagPrefix="ISWebGrid" %>

<ISWebGrid:WebGrid ID="wgFacility" runat="server" Height="346px" UseDefaultStyle="True"
	Width="100%" DataMember="FacilityCollection" DataSourceID="isdFacility" OnInitializeRow="wgFacility_InitializeRow">
	<RootTable Caption="Facility Collection" DataKeyField="FacilityGuid" DataMember="FacilityCollection">
		<Columns>
			<ISWebGrid:WebGridColumn Name="FacilityGuid" DataMember="FacilityGuid" Caption="Facility Guid"
				Width="200px" EditType="NoEdit" Visible="false" DataType="System.String" DefaultValue="{00000000-0000-0000-0000-000000000000}" />
			<ISWebGrid:WebGridColumn Name="FacilityID" DataMember="FacilityID" Caption="Facility ID"
				Width="100px" EditType="NoEdit" />
			<ISWebGrid:WebGridColumn Name="FacilityName" DataMember="FacilityName" Caption="Facility Name"
				Width="150px" TextboxMaxlength="50" InputRequired="true" InputRequiredErrorText="Please fill in 'Facility Name'." />
			<ISWebGrid:WebGridColumn Name="Exerpt" DataMember="Exerpt" Caption="Exerpt"
				Width="150px" TextboxMaxlength="200" InputRequired="true" InputRequiredErrorText="Please fill in 'Exerpt'." />
			<ISWebGrid:WebGridColumn Name="Description" DataMember="Description" Caption="Description"
				Width="150px" TextboxMaxlength="500" InputRequired="true" InputRequiredErrorText="Please fill in 'Description'." />
			<ISWebGrid:WebGridColumn Name="Address" DataMember="Address" Caption="Address"
				Width="150px" TextboxMaxlength="100" InputRequired="true" InputRequiredErrorText="Please fill in 'Address'." />
			<ISWebGrid:WebGridColumn Name="CityStateZipGuid" DataMember="CityStateZipGuid" Caption="City State Zip"
				Width="200px" EditType="WebComboNET" WebComboID="wcFacilityCityStateZip" DataType="System.Guid">
				<ValueList DataSourceID="isdFacilityCityStateZip" DataMember="CityStateZipCollection"
					DataValueField="CityStateZipGuid" DataTextField="PDC"/>
			</ISWebGrid:WebGridColumn>
			<ISWebGrid:WebGridColumn Name="PhoneNumber" DataMember="PhoneNumber" Caption="Phone Number"
				Width="150px" TextboxMaxlength="10" InputRequired="true" InputRequiredErrorText="Please fill in 'Phone Number'." />
			<ISWebGrid:WebGridColumn Name="Email" DataMember="Email" Caption="Email"
				Width="150px" TextboxMaxlength="100" InputRequired="true" InputRequiredErrorText="Please fill in 'Email'." />
			<ISWebGrid:WebGridColumn Name="Website" DataMember="Website" Caption="Website"
				Width="150px" TextboxMaxlength="100" InputRequired="true" InputRequiredErrorText="Please fill in 'Website'." />
			<ISWebGrid:WebGridColumn Name="ClientGuid" DataMember="ClientGuid" Caption="Client"
				Width="200px" EditType="WebComboNET" WebComboID="wcFacilityClient" DataType="System.Guid">
				<ValueList DataSourceID="isdFacilityClient" DataMember="ClientCollection"
					DataValueField="ClientGuid" DataTextField="PDC"/>
			</ISWebGrid:WebGridColumn>
			<ISWebGrid:WebGridColumn Name="ListingTypeGuid" DataMember="ListingTypeGuid" Caption="Listing Type"
				Width="200px" EditType="WebComboNET" WebComboID="wcFacilityListingType" DataType="System.Guid">
				<ValueList DataSourceID="isdFacilityListingType" DataMember="ListingTypeCollection"
					DataValueField="ListingTypeGuid" DataTextField="PDC"/>
			</ISWebGrid:WebGridColumn>
			<ISWebGrid:WebGridColumn Name="PublicPhotoFileUri" DataMember="PublicPhotoFileUri" Caption="Public Photo File Uri"
				Width="150px" TextboxMaxlength="100" InputRequired="true" InputRequiredErrorText="Please fill in 'Public Photo File Uri'." />
		</Columns>
	</RootTable>
	<LayoutSettings AllowAddNew="Yes" AllowEdit="Yes" AllowDelete="Yes" AllowSorting="Yes" AllowFilter="Yes"
		AutoWidth="true" PagingMode="ClassicPaging" PagingSize="10" PagingStyleUI="Slider" PagingDetectPartialGroupRows="True">
	</LayoutSettings>
</ISWebGrid:WebGrid>
<ISWebCombo:WebCombo ID="wcFacilityCityStateZip" runat="server" DataSourceID="isdFacilityCityStateZip"
	DataValueField="CityStateZipGuid" DataTextField="City"
	Height="20px" Width="200px" UseDefaultStyle="True">
</ISWebCombo:WebCombo>
<ISWebCombo:WebCombo ID="wcFacilityClient" runat="server" DataSourceID="isdFacilityClient"
	DataValueField="ClientGuid" DataTextField="ClientName"
	Height="20px" Width="200px" UseDefaultStyle="True">
</ISWebCombo:WebCombo>
<ISWebCombo:WebCombo ID="wcFacilityListingType" runat="server" DataSourceID="isdFacilityListingType"
	DataValueField="ListingTypeGuid" DataTextField="ListingTypeName"
	Height="20px" Width="200px" UseDefaultStyle="True">
</ISWebCombo:WebCombo>
<ISDataSource:ISDataSource ID="isdFacility" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.FacilityCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.Facility" TableName="FacilityCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" OldValuesParameterFormatString="Original_{0}"
			SelectMethod="GetFacilities" InsertMethod="InsertFacility" UpdateMethod="UpdateFacility" DeleteMethod="DeleteFacility">
			<InsertParameters>
				<asp:Parameter Name="facility" Type="Object" />
			</InsertParameters>
			<UpdateParameters>
				<asp:Parameter Name="facility" Type="Object" />
			</UpdateParameters>
			<DeleteParameters>
				<asp:Parameter Name="facility" Type="Object" />
			</DeleteParameters>
		</ISDataSource:ISDataSourceTable>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.CityStateZipWithFacility"
			SelectMethod="GetCityStateZipWithFacility"
			TableName="CityStateZipWithFacilityCollection" TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess">
		</ISDataSource:ISDataSourceTable>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.OfferingWithFacility"
			SelectMethod="GetOfferingWithFacility"
			TableName="OfferingWithFacilityCollection" TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess">
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>
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