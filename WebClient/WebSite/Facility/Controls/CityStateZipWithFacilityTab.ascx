<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CityStateZipWithFacilityTab.ascx.cs" Inherits="Facility_Controls_CityStateZipWithFacilityTab" %>

<%@ Register Assembly="ISNet.WebUI.ISDataSource, Version=1.0.1500.1, Culture=neutral, PublicKeyToken=c4184ef0d326354b"
	Namespace="ISNet.WebUI.DataSource" TagPrefix="ISDataSource" %>
<%@ Register Assembly="ISNet.WebUI.WebGrid" Namespace="ISNet.WebUI.WebGrid" TagPrefix="ISWebGrid" %>
<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>

<div>
	<asp:UpdatePanel ID="upCityStateZipNotFor" runat="server" UpdateMode="Conditional">
	<ContentTemplate>
			<ISWebCombo:WebCombo ID="wcCityStateZipsNotForFacility" runat="server" DataSourceID="isdsCityStateZipsNotForFacility"
				DataValueField="CityStateZipGuid" DataTextField="City"
				Height="20px" Width="200px" UseDefaultStyle="True">
			</ISWebCombo:WebCombo>
		<asp:Button ID="btnAddCityStateZipToFacility" runat="server" Text="Add CityStateZip To Facility" OnClick="btnAddCityStateZipToFacility_Click" />		  
	</ContentTemplate>
	</asp:UpdatePanel>
</div>
<br />

<div>
	<asp:UpdatePanel ID="upCityStateZipWith" runat="server" UpdateMode="Conditional">
	<ContentTemplate>
		<ISWebGrid:WebGrid ID="wgCityStateZipWithFacility" runat="server" Height="250px"
			Width="600px" DataSourceID="isdsCityStateZipsWithFacility" UseDefaultStyle="True" >
			<RootTable Caption="CityStateZips" DataKeyField="CityStateZipGuid">
				<Columns>
					<ISWebGrid:WebGridColumn AllowGrouping="No" AllowSizing="No" AllowSorting="No" Bound="False"
						ColumnType="CheckBox" EditType="NoEdit" IsRowChecker="True" Name="selectionColumn" ShowInSelectColumns="No"
						Width="25px" />
					<ISWebGrid:WebGridColumn Name="City" DataMember="City" Caption="City"
						Width="150px" EditType="NoEdit" DataType="System.String" />
					<ISWebGrid:WebGridColumn Name="State" DataMember="State" Caption="State"
						Width="150px" EditType="NoEdit" DataType="System.String" />
					<ISWebGrid:WebGridColumn Name="ZipCode" DataMember="ZipCode" Caption="Zip Code"
						Width="150px" EditType="NoEdit" DataType="System.String" />
					<ISWebGrid:WebGridColumn Name="FacilityGuid" DataMember="FacilityGuid" Caption="Facility Guid" Visible="false"
						Width="200px" EditType="NoEdit" DataType="System.Guid" />
					<ISWebGrid:WebGridColumn Name="CityStateZipGuid" DataMember="CityStateZipGuid" Caption="City State Zip Guid" Visible="false"
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
	<asp:Button ID="btnDeleteCityStateZipFromFacility" runat="server" Text="Delete Selected CityStateZip From Facility" OnClick="btnDeleteCityStateZipFromFacility_Click" />		   
</div>
<div>
	<asp:LinkButton ID="linkAddCityStateZip" runat="server" PostBackUrl="~/CityStateZip/CityStateZipDetail.aspx" Text="Create CityStateZip" />
</div>

<asp:UpdatePanel ID="upCityStateZipDataSources" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<ISDataSource:ISDataSource ID="isdsCityStateZipsWithFacility" runat="server"
	SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.CityStateZipWithFacilityCollection" SchemaType="CustomObject"
	LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.CityStateZipWithFacility"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" TableName="CityStateZipWithFacility"
			OldValuesParameterFormatString="Original_{0}"
			SelectMethod="GetCityStateZipsWithFacilityForFacility" UpdateMethod="UpdateCityStateZipWithFacility">
			<SelectParameters>
				<asp:QueryStringParameter name="facilityGuid" QueryStringField="FacilityGuid" />
			</SelectParameters>
			<UpdateParameters>
				<asp:Parameter Name="facility" Type="Object" />
			</UpdateParameters>
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>
<ISDataSource:ISDataSource ID="isdsCityStateZipsNotForFacility" runat="server"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.CityStateZip"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" TableName="CityStateZipsNotForFacility"
			SelectMethod="GetCityStateZipsNotForFacility">
			<SelectParameters>
				<asp:QueryStringParameter name="facilityGuid" QueryStringField="FacilityGuid" />
			</SelectParameters>
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>
</ContentTemplate>
</asp:UpdatePanel>