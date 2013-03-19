<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListingTypeGrid.ascx.cs" Inherits="ListingType_Controls_ListingTypeGrid" %>

<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>
<%@ Register Assembly="ISNet.WebUI.ISDataSource, Version=1.0.1500.1, Culture=neutral, PublicKeyToken=c4184ef0d326354b"
	Namespace="ISNet.WebUI.DataSource" TagPrefix="ISDataSource" %>
<%@ Register Assembly="ISNet.WebUI.WebGrid" Namespace="ISNet.WebUI.WebGrid" TagPrefix="ISWebGrid" %>

<ISWebGrid:WebGrid ID="wgListingType" runat="server" Height="346px" UseDefaultStyle="True"
	Width="100%" DataMember="ListingTypeCollection" DataSourceID="isdListingType" OnInitializeRow="wgListingType_InitializeRow">
	<RootTable Caption="Listing Type Collection" DataKeyField="ListingTypeGuid" DataMember="ListingTypeCollection">
		<Columns>
			<ISWebGrid:WebGridColumn Name="ListingTypeGuid" DataMember="ListingTypeGuid" Caption="Listing Type Guid"
				Width="200px" EditType="NoEdit" Visible="false" DataType="System.String" DefaultValue="{00000000-0000-0000-0000-000000000000}" />
			<ISWebGrid:WebGridColumn Name="ListingTypeName" DataMember="ListingTypeName" Caption="Listing Type Name"
				Width="150px" TextboxMaxlength="50" InputRequired="true" InputRequiredErrorText="Please fill in 'Listing Type Name'." />
		</Columns>
	</RootTable>
	<LayoutSettings AllowAddNew="Yes" AllowEdit="Yes" AllowDelete="Yes" AllowSorting="Yes" AllowFilter="Yes"
		AutoWidth="true" PagingMode="ClassicPaging" PagingSize="10" PagingStyleUI="Slider" PagingDetectPartialGroupRows="True">
	</LayoutSettings>
</ISWebGrid:WebGrid>
<ISDataSource:ISDataSource ID="isdListingType" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.ListingTypeCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.ListingType" TableName="ListingTypeCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" OldValuesParameterFormatString="Original_{0}"
			SelectMethod="GetListingTypes" InsertMethod="InsertListingType" UpdateMethod="UpdateListingType" DeleteMethod="DeleteListingType">
			<InsertParameters>
				<asp:Parameter Name="listingType" Type="Object" />
			</InsertParameters>
			<UpdateParameters>
				<asp:Parameter Name="listingType" Type="Object" />
			</UpdateParameters>
			<DeleteParameters>
				<asp:Parameter Name="listingType" Type="Object" />
			</DeleteParameters>
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>