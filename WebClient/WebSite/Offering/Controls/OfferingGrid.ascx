<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OfferingGrid.ascx.cs" Inherits="Offering_Controls_OfferingGrid" %>

<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>
<%@ Register Assembly="ISNet.WebUI.ISDataSource, Version=1.0.1500.1, Culture=neutral, PublicKeyToken=c4184ef0d326354b"
	Namespace="ISNet.WebUI.DataSource" TagPrefix="ISDataSource" %>
<%@ Register Assembly="ISNet.WebUI.WebGrid" Namespace="ISNet.WebUI.WebGrid" TagPrefix="ISWebGrid" %>

<ISWebGrid:WebGrid ID="wgOffering" runat="server" Height="346px" UseDefaultStyle="True"
	Width="100%" DataMember="OfferingCollection" DataSourceID="isdOffering" OnInitializeRow="wgOffering_InitializeRow">
	<RootTable Caption="Offering Collection" DataKeyField="OfferingGuid" DataMember="OfferingCollection">
		<Columns>
			<ISWebGrid:WebGridColumn Name="OfferingGuid" DataMember="OfferingGuid" Caption="Offering Guid"
				Width="200px" EditType="NoEdit" Visible="false" DataType="System.String" DefaultValue="{00000000-0000-0000-0000-000000000000}" />
			<ISWebGrid:WebGridColumn Name="OfferingID" DataMember="OfferingID" Caption="Offering ID"
				Width="100px" EditType="NoEdit" />
			<ISWebGrid:WebGridColumn Name="OfferingName" DataMember="OfferingName" Caption="Offering Name"
				Width="150px" TextboxMaxlength="50" InputRequired="true" InputRequiredErrorText="Please fill in 'Offering Name'." />
		</Columns>
	</RootTable>
	<LayoutSettings AllowAddNew="Yes" AllowEdit="Yes" AllowDelete="Yes" AllowSorting="Yes" AllowFilter="Yes"
		AutoWidth="true" PagingMode="ClassicPaging" PagingSize="10" PagingStyleUI="Slider" PagingDetectPartialGroupRows="True">
	</LayoutSettings>
</ISWebGrid:WebGrid>
<ISDataSource:ISDataSource ID="isdOffering" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.OfferingCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.Offering" TableName="OfferingCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" OldValuesParameterFormatString="Original_{0}"
			SelectMethod="GetOfferings" InsertMethod="InsertOffering" UpdateMethod="UpdateOffering" DeleteMethod="DeleteOffering">
			<InsertParameters>
				<asp:Parameter Name="offering" Type="Object" />
			</InsertParameters>
			<UpdateParameters>
				<asp:Parameter Name="offering" Type="Object" />
			</UpdateParameters>
			<DeleteParameters>
				<asp:Parameter Name="offering" Type="Object" />
			</DeleteParameters>
		</ISDataSource:ISDataSourceTable>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.FacilityWithOffering"
			SelectMethod="GetFacilityWithOffering"
			TableName="FacilityWithOfferingCollection" TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess">
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>