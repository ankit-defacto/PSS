<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FacilityAuditGrid.ascx.cs" Inherits="FacilityAudit_Controls_FacilityAuditGrid" %>

<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>
<%@ Register Assembly="ISNet.WebUI.ISDataSource, Version=1.0.1500.1, Culture=neutral, PublicKeyToken=c4184ef0d326354b"
	Namespace="ISNet.WebUI.DataSource" TagPrefix="ISDataSource" %>
<%@ Register Assembly="ISNet.WebUI.WebGrid" Namespace="ISNet.WebUI.WebGrid" TagPrefix="ISWebGrid" %>

<ISWebGrid:WebGrid ID="wgFacilityAudit" runat="server" Height="346px" UseDefaultStyle="True"
	Width="100%" DataMember="FacilityAuditCollection" DataSourceID="isdFacilityAudit" OnInitializeRow="wgFacilityAudit_InitializeRow">
	<RootTable Caption="Facility Audit Collection" DataKeyField="FacilityAuditGuid" DataMember="FacilityAuditCollection">
		<Columns>
			<ISWebGrid:WebGridColumn Name="FacilityAuditGuid" DataMember="FacilityAuditGuid" Caption="Facility Audit Guid"
				Width="200px" EditType="NoEdit" Visible="false" DataType="System.String" DefaultValue="{00000000-0000-0000-0000-000000000000}" />
			<ISWebGrid:WebGridColumn Name="FacilityGuid" DataMember="FacilityGuid" Caption="Facility"
				Width="200px" EditType="WebComboNET" WebComboID="wcFacilityAuditFacility" DataType="System.Guid">
				<ValueList DataSourceID="isdFacilityAuditFacility" DataMember="FacilityCollection"
					DataValueField="FacilityGuid" DataTextField="PDC"/>
			</ISWebGrid:WebGridColumn>
			<ISWebGrid:WebGridColumn Name="FacilityID" DataMember="FacilityID" Caption="Facility ID"
				Width="100px" TextboxMaxlength="11" InputRequired="true" InputRequiredErrorText="Please fill in 'Facility ID'." />
			<ISWebGrid:WebGridColumn Name="FacilityName" DataMember="FacilityName" Caption="Facility Name"
				Width="150px" TextboxMaxlength="50" InputRequired="true" InputRequiredErrorText="Please fill in 'Facility Name'." />
			<ISWebGrid:WebGridColumn Name="Exerpt" DataMember="Exerpt" Caption="Exerpt"
				Width="150px" TextboxMaxlength="200" InputRequired="true" InputRequiredErrorText="Please fill in 'Exerpt'." />
			<ISWebGrid:WebGridColumn Name="Description" DataMember="Description" Caption="Description"
				Width="150px" TextboxMaxlength="500" InputRequired="true" InputRequiredErrorText="Please fill in 'Description'." />
			<ISWebGrid:WebGridColumn Name="Address" DataMember="Address" Caption="Address"
				Width="150px" TextboxMaxlength="100" InputRequired="true" InputRequiredErrorText="Please fill in 'Address'." />
			<ISWebGrid:WebGridColumn Name="CityStateZipGuid" DataMember="CityStateZipGuid" Caption="City State Zip"
				Width="200px" EditType="WebComboNET" WebComboID="wcFacilityAuditCityStateZip" DataType="System.Guid">
				<ValueList DataSourceID="isdFacilityAuditCityStateZip" DataMember="CityStateZipCollection"
					DataValueField="CityStateZipGuid" DataTextField="PDC"/>
			</ISWebGrid:WebGridColumn>
			<ISWebGrid:WebGridColumn Name="PhoneNumber" DataMember="PhoneNumber" Caption="Phone Number"
				Width="150px" TextboxMaxlength="10" InputRequired="true" InputRequiredErrorText="Please fill in 'Phone Number'." />
			<ISWebGrid:WebGridColumn Name="Email" DataMember="Email" Caption="Email"
				Width="150px" TextboxMaxlength="100" InputRequired="true" InputRequiredErrorText="Please fill in 'Email'." />
			<ISWebGrid:WebGridColumn Name="Website" DataMember="Website" Caption="Website"
				Width="150px" TextboxMaxlength="100" InputRequired="true" InputRequiredErrorText="Please fill in 'Website'." />
			<ISWebGrid:WebGridColumn Name="ClientGuid" DataMember="ClientGuid" Caption="Client"
				Width="200px" EditType="WebComboNET" WebComboID="wcFacilityAuditClient" DataType="System.Guid">
				<ValueList DataSourceID="isdFacilityAuditClient" DataMember="ClientCollection"
					DataValueField="ClientGuid" DataTextField="PDC"/>
			</ISWebGrid:WebGridColumn>
			<ISWebGrid:WebGridColumn Name="ListingTypeGuid" DataMember="ListingTypeGuid" Caption="Listing Type"
				Width="200px" EditType="WebComboNET" WebComboID="wcFacilityAuditListingType" DataType="System.Guid">
				<ValueList DataSourceID="isdFacilityAuditListingType" DataMember="ListingTypeCollection"
					DataValueField="ListingTypeGuid" DataTextField="PDC"/>
			</ISWebGrid:WebGridColumn>
			<ISWebGrid:WebGridColumn Name="PublicPhotoFileUri" DataMember="PublicPhotoFileUri" Caption="Public Photo File Uri"
				Width="150px" TextboxMaxlength="100" InputRequired="true" InputRequiredErrorText="Please fill in 'Public Photo File Uri'." />
			<ISWebGrid:WebGridColumn Name="DateModified" DataMember="DateModified" Caption="Date Modified"
				Width="175px" InputRequired="true" InputRequiredErrorText="Please fill in 'Date Modified'." />
		</Columns>
	</RootTable>
	<LayoutSettings AllowAddNew="Yes" AllowEdit="Yes" AllowDelete="Yes" AllowSorting="Yes" AllowFilter="Yes"
		AutoWidth="true" PagingMode="ClassicPaging" PagingSize="10" PagingStyleUI="Slider" PagingDetectPartialGroupRows="True">
	</LayoutSettings>
</ISWebGrid:WebGrid>
<ISWebCombo:WebCombo ID="wcFacilityAuditFacility" runat="server" DataSourceID="isdFacilityAuditFacility"
	DataValueField="FacilityGuid" DataTextField="FacilityName"
	Height="20px" Width="200px" UseDefaultStyle="True">
</ISWebCombo:WebCombo>
<ISWebCombo:WebCombo ID="wcFacilityAuditCityStateZip" runat="server" DataSourceID="isdFacilityAuditCityStateZip"
	DataValueField="CityStateZipGuid" DataTextField="City"
	Height="20px" Width="200px" UseDefaultStyle="True">
</ISWebCombo:WebCombo>
<ISWebCombo:WebCombo ID="wcFacilityAuditClient" runat="server" DataSourceID="isdFacilityAuditClient"
	DataValueField="ClientGuid" DataTextField="ClientName"
	Height="20px" Width="200px" UseDefaultStyle="True">
</ISWebCombo:WebCombo>
<ISWebCombo:WebCombo ID="wcFacilityAuditListingType" runat="server" DataSourceID="isdFacilityAuditListingType"
	DataValueField="ListingTypeGuid" DataTextField="ListingTypeName"
	Height="20px" Width="200px" UseDefaultStyle="True">
</ISWebCombo:WebCombo>
<ISDataSource:ISDataSource ID="isdFacilityAudit" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.FacilityAuditCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.FacilityAudit" TableName="FacilityAuditCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" OldValuesParameterFormatString="Original_{0}"
			SelectMethod="GetFacilityAudits" InsertMethod="InsertFacilityAudit" UpdateMethod="UpdateFacilityAudit" DeleteMethod="DeleteFacilityAudit">
			<InsertParameters>
				<asp:Parameter Name="facilityAudit" Type="Object" />
			</InsertParameters>
			<UpdateParameters>
				<asp:Parameter Name="facilityAudit" Type="Object" />
			</UpdateParameters>
			<DeleteParameters>
				<asp:Parameter Name="facilityAudit" Type="Object" />
			</DeleteParameters>
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>
<ISDataSource:ISDataSource ID="isdFacilityAuditFacility" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.FacilityCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.Facility" TableName="FacilityCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" SelectMethod="GetFacilities">
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>
<ISDataSource:ISDataSource ID="isdFacilityAuditCityStateZip" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.CityStateZipCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.CityStateZip" TableName="CityStateZipCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" SelectMethod="GetCityStateZips">
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>
<ISDataSource:ISDataSource ID="isdFacilityAuditClient" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.ClientCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.Client" TableName="ClientCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" SelectMethod="GetClients">
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>
<ISDataSource:ISDataSource ID="isdFacilityAuditListingType" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.ListingTypeCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.ListingType" TableName="ListingTypeCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" SelectMethod="GetListingTypes">
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>