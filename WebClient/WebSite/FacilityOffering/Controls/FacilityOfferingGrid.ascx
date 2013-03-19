<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FacilityOfferingGrid.ascx.cs" Inherits="FacilityOffering_Controls_FacilityOfferingGrid" %>

<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>
<%@ Register Assembly="ISNet.WebUI.ISDataSource, Version=1.0.1500.1, Culture=neutral, PublicKeyToken=c4184ef0d326354b"
	Namespace="ISNet.WebUI.DataSource" TagPrefix="ISDataSource" %>
<%@ Register Assembly="ISNet.WebUI.WebGrid" Namespace="ISNet.WebUI.WebGrid" TagPrefix="ISWebGrid" %>

<ISWebGrid:WebGrid ID="wgFacilityOffering" runat="server" Height="346px" UseDefaultStyle="True"
	Width="100%" DataMember="FacilityOfferingCollection" DataSourceID="isdFacilityOffering" OnInitializeRow="wgFacilityOffering_InitializeRow">
	<RootTable Caption="Facility Offering Collection" DataKeyField="FacilityGuid" DataMember="FacilityOfferingCollection">
		<Columns>
			<ISWebGrid:WebGridColumn Name="FacilityGuid" DataMember="FacilityGuid" Caption="Facility" 
				Width="200px" EditType="WebComboNET" WebComboID="wcFacilityOfferingFacility" DataType="System.Guid">
				<ValueList DataSourceID="isdFacilityOfferingFacility" DataMember="FacilityCollection"
					DataValueField="FacilityGuid" DataTextField="PDC"/>
			</ISWebGrid:WebGridColumn>
			<ISWebGrid:WebGridColumn Name="OfferingGuid" DataMember="OfferingGuid" Caption="Offering" 
				Width="200px" EditType="WebComboNET" WebComboID="wcFacilityOfferingOffering" DataType="System.Guid">
				<ValueList DataSourceID="isdFacilityOfferingOffering" DataMember="OfferingCollection"
					DataValueField="OfferingGuid" DataTextField="PDC"/>
			</ISWebGrid:WebGridColumn>
			<ISWebGrid:WebGridColumn Name="IsChecked" DataMember="IsChecked" Caption="Is Checked"
				Width="175px" InputRequired="true" InputRequiredErrorText="Please fill in 'Is Checked'." />
		</Columns>
	</RootTable>
	<LayoutSettings AllowAddNew="Yes" AllowEdit="Yes" AllowDelete="Yes" AllowSorting="Yes" AllowFilter="Yes"
		AutoWidth="true" PagingMode="ClassicPaging" PagingSize="10" PagingStyleUI="Slider" PagingDetectPartialGroupRows="True">
	</LayoutSettings>
</ISWebGrid:WebGrid>
<ISDataSource:ISDataSource ID="isdFacilityOffering" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.FacilityOfferingCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.FacilityOffering" TableName="FacilityOfferingCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" OldValuesParameterFormatString="Original_{0}"
			SelectMethod="GetFacilityOfferings" InsertMethod="InsertFacilityOffering" UpdateMethod="UpdateFacilityOffering" DeleteMethod="DeleteFacilityOffering">
			<InsertParameters>
				<asp:Parameter Name="facilityOffering" Type="Object" />
			</InsertParameters>
			<UpdateParameters>
				<asp:Parameter Name="facilityOffering" Type="Object" />
			</UpdateParameters>
			<DeleteParameters>
				<asp:Parameter Name="facilityOffering" Type="Object" />
			</DeleteParameters>
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>