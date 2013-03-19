<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FacilityPhotoGrid.ascx.cs" Inherits="FacilityPhoto_Controls_FacilityPhotoGrid" %>

<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>
<%@ Register Assembly="ISNet.WebUI.ISDataSource, Version=1.0.1500.1, Culture=neutral, PublicKeyToken=c4184ef0d326354b"
	Namespace="ISNet.WebUI.DataSource" TagPrefix="ISDataSource" %>
<%@ Register Assembly="ISNet.WebUI.WebGrid" Namespace="ISNet.WebUI.WebGrid" TagPrefix="ISWebGrid" %>

<ISWebGrid:WebGrid ID="wgFacilityPhoto" runat="server" Height="346px" UseDefaultStyle="True"
	Width="100%" DataMember="FacilityPhotoCollection" DataSourceID="isdFacilityPhoto" OnInitializeRow="wgFacilityPhoto_InitializeRow">
	<RootTable Caption="FacilityPhoto Collection" DataKeyField="FacilityPhotoGuid" DataMember="FacilityPhotoCollection">
		<Columns>
			<ISWebGrid:WebGridColumn Name="FacilityPhotoGuid" DataMember="FacilityPhotoGuid" Caption="Photo Guid"
				Width="200px" EditType="NoEdit" Visible="false" DataType="System.String" DefaultValue="{00000000-0000-0000-0000-000000000000}" />
			<ISWebGrid:WebGridColumn Name="PhotoUri" DataMember="PhotoUri" Caption="Photo Uri"
				Width="150px" TextboxMaxlength="200" InputRequired="true" InputRequiredErrorText="Please fill in 'Photo Uri'." />
			<ISWebGrid:WebGridColumn Name="FacilityGuid" DataMember="FacilityGuid" Caption="Facility"
				Width="200px" EditType="WebComboNET" WebComboID="wcFacilityPhotoFacility" DataType="System.Guid">
				<ValueList DataSourceID="isdFacilityPhotoFacility" DataMember="FacilityCollection"
					DataValueField="FacilityGuid" DataTextField="PDC"/>
			</ISWebGrid:WebGridColumn>
		</Columns>
	</RootTable>
	<LayoutSettings AllowAddNew="Yes" AllowEdit="Yes" AllowDelete="Yes" AllowSorting="Yes" AllowFilter="Yes"
		AutoWidth="true" PagingMode="ClassicPaging" PagingSize="10" PagingStyleUI="Slider" PagingDetectPartialGroupRows="True">
	</LayoutSettings>
</ISWebGrid:WebGrid>
<ISWebCombo:WebCombo ID="wcFacilityPhotoFacility" runat="server" DataSourceID="isdFacilityPhotoFacility"
	DataValueField="FacilityGuid" DataTextField="FacilityName"
	Height="20px" Width="200px" UseDefaultStyle="True">
</ISWebCombo:WebCombo>
<ISDataSource:ISDataSource ID="isdFacilityPhoto" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.FacilityPhotoCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.FacilityPhoto" TableName="FacilityPhotoCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" OldValuesParameterFormatString="Original_{0}"
			SelectMethod="GetFacilityPhotos" InsertMethod="InsertFacilityPhoto" UpdateMethod="UpdateFacilityPhoto" DeleteMethod="DeleteFacilityPhoto">
			<InsertParameters>
				<asp:Parameter Name="facilityPhoto" Type="Object" />
			</InsertParameters>
			<UpdateParameters>
				<asp:Parameter Name="facilityPhoto" Type="Object" />
			</UpdateParameters>
			<DeleteParameters>
				<asp:Parameter Name="facilityPhoto" Type="Object" />
			</DeleteParameters>
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>
<ISDataSource:ISDataSource ID="isdFacilityPhotoFacility" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.FacilityCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.Facility" TableName="FacilityCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" SelectMethod="GetFacilities">
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>