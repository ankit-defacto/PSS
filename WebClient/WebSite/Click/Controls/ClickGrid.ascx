<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ClickGrid.ascx.cs" Inherits="Click_Controls_ClickGrid" %>

<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>
<%@ Register Assembly="ISNet.WebUI.ISDataSource, Version=1.0.1500.1, Culture=neutral, PublicKeyToken=c4184ef0d326354b"
	Namespace="ISNet.WebUI.DataSource" TagPrefix="ISDataSource" %>
<%@ Register Assembly="ISNet.WebUI.WebGrid" Namespace="ISNet.WebUI.WebGrid" TagPrefix="ISWebGrid" %>

<ISWebGrid:WebGrid ID="wgClick" runat="server" Height="346px" UseDefaultStyle="True"
	Width="100%" DataMember="ClickCollection" DataSourceID="isdClick" OnInitializeRow="wgClick_InitializeRow">
	<RootTable Caption="Click Collection" DataKeyField="ClickGuid" DataMember="ClickCollection">
		<Columns>
			<ISWebGrid:WebGridColumn Name="ClickGuid" DataMember="ClickGuid" Caption="Click Guid"
				Width="200px" EditType="NoEdit" Visible="false" DataType="System.String" DefaultValue="{00000000-0000-0000-0000-000000000000}" />
			<ISWebGrid:WebGridColumn Name="FacilityGuid" DataMember="FacilityGuid" Caption="Facility"
				Width="200px" EditType="WebComboNET" WebComboID="wcClickFacility" DataType="System.Guid">
				<ValueList DataSourceID="isdClickFacility" DataMember="FacilityCollection"
					DataValueField="FacilityGuid" DataTextField="PDC"/>
			</ISWebGrid:WebGridColumn>
			<ISWebGrid:WebGridColumn Name="ListingTypeGuid" DataMember="ListingTypeGuid" Caption="Listing Type"
				Width="200px" EditType="WebComboNET" WebComboID="wcClickListingType" DataType="System.Guid">
				<ValueList DataSourceID="isdClickListingType" DataMember="ListingTypeCollection"
					DataValueField="ListingTypeGuid" DataTextField="PDC"/>
			</ISWebGrid:WebGridColumn>
			<ISWebGrid:WebGridColumn Name="TimeStamp" DataMember="TimeStamp" Caption="Time Stamp"
				Width="175px" InputRequired="true" InputRequiredErrorText="Please fill in 'Time Stamp'." />
		</Columns>
	</RootTable>
	<LayoutSettings AllowAddNew="Yes" AllowEdit="Yes" AllowDelete="Yes" AllowSorting="Yes" AllowFilter="Yes"
		AutoWidth="true" PagingMode="ClassicPaging" PagingSize="10" PagingStyleUI="Slider" PagingDetectPartialGroupRows="True">
	</LayoutSettings>
</ISWebGrid:WebGrid>
<ISWebCombo:WebCombo ID="wcClickFacility" runat="server" DataSourceID="isdClickFacility"
	DataValueField="FacilityGuid" DataTextField="FacilityName"
	Height="20px" Width="200px" UseDefaultStyle="True">
</ISWebCombo:WebCombo>
<ISWebCombo:WebCombo ID="wcClickListingType" runat="server" DataSourceID="isdClickListingType"
	DataValueField="ListingTypeGuid" DataTextField="ListingTypeName"
	Height="20px" Width="200px" UseDefaultStyle="True">
</ISWebCombo:WebCombo>
<ISDataSource:ISDataSource ID="isdClick" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.ClickCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.Click" TableName="ClickCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" OldValuesParameterFormatString="Original_{0}"
			SelectMethod="GetClicks" InsertMethod="InsertClick" UpdateMethod="UpdateClick" DeleteMethod="DeleteClick">
			<InsertParameters>
				<asp:Parameter Name="click" Type="Object" />
			</InsertParameters>
			<UpdateParameters>
				<asp:Parameter Name="click" Type="Object" />
			</UpdateParameters>
			<DeleteParameters>
				<asp:Parameter Name="click" Type="Object" />
			</DeleteParameters>
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>
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