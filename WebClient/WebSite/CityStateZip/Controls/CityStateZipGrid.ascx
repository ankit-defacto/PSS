<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CityStateZipGrid.ascx.cs" Inherits="CityStateZip_Controls_CityStateZipGrid" %>

<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>
<%@ Register Assembly="ISNet.WebUI.ISDataSource, Version=1.0.1500.1, Culture=neutral, PublicKeyToken=c4184ef0d326354b"
	Namespace="ISNet.WebUI.DataSource" TagPrefix="ISDataSource" %>
<%@ Register Assembly="ISNet.WebUI.WebGrid" Namespace="ISNet.WebUI.WebGrid" TagPrefix="ISWebGrid" %>

<ISWebGrid:WebGrid ID="wgCityStateZip" runat="server" Height="346px" UseDefaultStyle="True"
	Width="100%" DataMember="CityStateZipCollection" DataSourceID="isdCityStateZip" OnInitializeRow="wgCityStateZip_InitializeRow">
	<RootTable Caption="City State Zip Collection" DataKeyField="CityStateZipGuid" DataMember="CityStateZipCollection">
		<Columns>
			<ISWebGrid:WebGridColumn Name="CityStateZipGuid" DataMember="CityStateZipGuid" Caption="City State Zip Guid"
				Width="200px" EditType="NoEdit" Visible="false" DataType="System.String" DefaultValue="{00000000-0000-0000-0000-000000000000}" />
			<ISWebGrid:WebGridColumn Name="City" DataMember="City" Caption="City"
				Width="150px" TextboxMaxlength="50" InputRequired="true" InputRequiredErrorText="Please fill in 'City'." />
			<ISWebGrid:WebGridColumn Name="State" DataMember="State" Caption="State"
				Width="150px" TextboxMaxlength="50" InputRequired="true" InputRequiredErrorText="Please fill in 'State'." />
			<ISWebGrid:WebGridColumn Name="ZipCode" DataMember="ZipCode" Caption="Zip Code"
				Width="150px" TextboxMaxlength="5" InputRequired="true" InputRequiredErrorText="Please fill in 'Zip Code'." />
		</Columns>
	</RootTable>
	<LayoutSettings AllowAddNew="Yes" AllowEdit="Yes" AllowDelete="Yes" AllowSorting="Yes" AllowFilter="Yes"
		AutoWidth="true" PagingMode="ClassicPaging" PagingSize="10" PagingStyleUI="Slider" PagingDetectPartialGroupRows="True">
	</LayoutSettings>
</ISWebGrid:WebGrid>
<ISDataSource:ISDataSource ID="isdCityStateZip" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.CityStateZipCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.CityStateZip" TableName="CityStateZipCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" OldValuesParameterFormatString="Original_{0}"
			SelectMethod="GetCityStateZips" InsertMethod="InsertCityStateZip" UpdateMethod="UpdateCityStateZip" DeleteMethod="DeleteCityStateZip">
			<InsertParameters>
				<asp:Parameter Name="cityStateZip" Type="Object" />
			</InsertParameters>
			<UpdateParameters>
				<asp:Parameter Name="cityStateZip" Type="Object" />
			</UpdateParameters>
			<DeleteParameters>
				<asp:Parameter Name="cityStateZip" Type="Object" />
			</DeleteParameters>
		</ISDataSource:ISDataSourceTable>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.FacilityWithCityStateZip"
			SelectMethod="GetFacilityWithCityStateZip"
			TableName="FacilityWithCityStateZipCollection" TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess">
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>