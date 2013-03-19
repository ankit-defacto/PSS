<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FacilityLocationCriteriaGrid.ascx.cs" Inherits="FacilityLocationCriteria_Controls_FacilityLocationCriteriaGrid" %>

<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>
<%@ Register Assembly="ISNet.WebUI.ISDataSource, Version=1.0.1500.1, Culture=neutral, PublicKeyToken=c4184ef0d326354b"
	Namespace="ISNet.WebUI.DataSource" TagPrefix="ISDataSource" %>
<%@ Register Assembly="ISNet.WebUI.WebGrid" Namespace="ISNet.WebUI.WebGrid" TagPrefix="ISWebGrid" %>

<ISWebGrid:WebGrid ID="wgFacilityLocationCriteria" runat="server" Height="346px" UseDefaultStyle="True"
	Width="100%" DataMember="FacilityLocationCriteriaCollection" DataSourceID="isdFacilityLocationCriteria" OnInitializeRow="wgFacilityLocationCriteria_InitializeRow">
	<RootTable Caption="Facility Location Criteria Collection" DataKeyField="FacilityGuid" DataMember="FacilityLocationCriteriaCollection">
		<Columns>
			<ISWebGrid:WebGridColumn Name="FacilityGuid" DataMember="FacilityGuid" Caption="Facility" 
				Width="200px" EditType="WebComboNET" WebComboID="wcFacilityLocationCriteriaFacility" DataType="System.Guid">
				<ValueList DataSourceID="isdFacilityLocationCriteriaFacility" DataMember="FacilityCollection"
					DataValueField="FacilityGuid" DataTextField="PDC"/>
			</ISWebGrid:WebGridColumn>
			<ISWebGrid:WebGridColumn Name="CityStateZipGuid" DataMember="CityStateZipGuid" Caption="City State Zip" 
				Width="200px" EditType="WebComboNET" WebComboID="wcFacilityLocationCriteriaCityStateZip" DataType="System.Guid">
				<ValueList DataSourceID="isdFacilityLocationCriteriaCityStateZip" DataMember="CityStateZipCollection"
					DataValueField="CityStateZipGuid" DataTextField="PDC"/>
			</ISWebGrid:WebGridColumn>
		</Columns>
	</RootTable>
	<LayoutSettings AllowAddNew="Yes" AllowEdit="Yes" AllowDelete="Yes" AllowSorting="Yes" AllowFilter="Yes"
		AutoWidth="true" PagingMode="ClassicPaging" PagingSize="10" PagingStyleUI="Slider" PagingDetectPartialGroupRows="True">
	</LayoutSettings>
</ISWebGrid:WebGrid>
<ISDataSource:ISDataSource ID="isdFacilityLocationCriteria" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.FacilityLocationCriteriaCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.FacilityLocationCriteria" TableName="FacilityLocationCriteriaCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" OldValuesParameterFormatString="Original_{0}"
			SelectMethod="GetFacilityLocationCriterias" InsertMethod="InsertFacilityLocationCriteria" UpdateMethod="UpdateFacilityLocationCriteria" DeleteMethod="DeleteFacilityLocationCriteria">
			<InsertParameters>
				<asp:Parameter Name="facilityLocationCriteria" Type="Object" />
			</InsertParameters>
			<UpdateParameters>
				<asp:Parameter Name="facilityLocationCriteria" Type="Object" />
			</UpdateParameters>
			<DeleteParameters>
				<asp:Parameter Name="facilityLocationCriteria" Type="Object" />
			</DeleteParameters>
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>