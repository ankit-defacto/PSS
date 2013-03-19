<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OfferingWithFacilityTab.ascx.cs" Inherits="Facility_Controls_OfferingWithFacilityTab" %>

<%@ Register Assembly="ISNet.WebUI.ISDataSource, Version=1.0.1500.1, Culture=neutral, PublicKeyToken=c4184ef0d326354b"
	Namespace="ISNet.WebUI.DataSource" TagPrefix="ISDataSource" %>
<%@ Register Assembly="ISNet.WebUI.WebGrid" Namespace="ISNet.WebUI.WebGrid" TagPrefix="ISWebGrid" %>
<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>

<div>
	<asp:UpdatePanel ID="upOfferingNotFor" runat="server" UpdateMode="Conditional">
	<ContentTemplate>
			<ISWebCombo:WebCombo ID="wcOfferingsNotForFacility" runat="server" DataSourceID="isdsOfferingsNotForFacility"
				DataValueField="OfferingGuid" DataTextField="OfferingName"
				Height="20px" Width="200px" UseDefaultStyle="True">
			</ISWebCombo:WebCombo>
		IsChecked: <asp:TextBox ID="txtIsChecked" runat="server" />
		<asp:Button ID="btnAddOfferingToFacility" runat="server" Text="Add Offering To Facility" OnClick="btnAddOfferingToFacility_Click" />		  
	</ContentTemplate>
	</asp:UpdatePanel>
</div>
<br />

<div>
	<asp:UpdatePanel ID="upOfferingWith" runat="server" UpdateMode="Conditional">
	<ContentTemplate>
		<ISWebGrid:WebGrid ID="wgOfferingWithFacility" runat="server" Height="250px"
			Width="600px" DataSourceID="isdsOfferingsWithFacility" UseDefaultStyle="True" >
			<RootTable Caption="Offerings" DataKeyField="OfferingGuid">
				<Columns>
					<ISWebGrid:WebGridColumn AllowGrouping="No" AllowSizing="No" AllowSorting="No" Bound="False"
						ColumnType="CheckBox" EditType="NoEdit" IsRowChecker="True" Name="selectionColumn" ShowInSelectColumns="No"
						Width="25px" />
					<ISWebGrid:WebGridColumn Name="OfferingID" DataMember="OfferingID" Caption="Offering ID"
						Width="100px" EditType="NoEdit" DataType="System.Int32" />
					<ISWebGrid:WebGridColumn Name="OfferingName" DataMember="OfferingName" Caption="Offering Name"
						Width="150px" EditType="NoEdit" DataType="System.String" />
					<ISWebGrid:WebGridColumn Name="IsChecked" DataMember="IsChecked" Caption="Is Checked"
						Width="175px" EditType="NoEdit" DataType="System.Boolean" />
					<ISWebGrid:WebGridColumn Name="FacilityGuid" DataMember="FacilityGuid" Caption="Facility Guid" Visible="false"
						Width="200px" EditType="NoEdit" DataType="System.Guid" />
					<ISWebGrid:WebGridColumn Name="OfferingGuid" DataMember="OfferingGuid" Caption="Offering Guid" Visible="false"
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
	<asp:Button ID="btnDeleteOfferingFromFacility" runat="server" Text="Delete Selected Offering From Facility" OnClick="btnDeleteOfferingFromFacility_Click" />		   
</div>
<div>
	<asp:LinkButton ID="linkAddOffering" runat="server" PostBackUrl="~/Offering/OfferingDetail.aspx" Text="Create Offering" />
</div>

<asp:UpdatePanel ID="upOfferingDataSources" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<ISDataSource:ISDataSource ID="isdsOfferingsWithFacility" runat="server"
	SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.OfferingWithFacilityCollection" SchemaType="CustomObject"
	LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.OfferingWithFacility"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" TableName="OfferingWithFacility"
			OldValuesParameterFormatString="Original_{0}"
			SelectMethod="GetOfferingsWithFacilityForFacility" UpdateMethod="UpdateOfferingWithFacility">
			<SelectParameters>
				<asp:QueryStringParameter name="facilityGuid" QueryStringField="FacilityGuid" />
			</SelectParameters>
			<UpdateParameters>
				<asp:Parameter Name="facility" Type="Object" />
			</UpdateParameters>
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>
<ISDataSource:ISDataSource ID="isdsOfferingsNotForFacility" runat="server"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.Offering"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" TableName="OfferingsNotForFacility"
			SelectMethod="GetOfferingsNotForFacility">
			<SelectParameters>
				<asp:QueryStringParameter name="facilityGuid" QueryStringField="FacilityGuid" />
			</SelectParameters>
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>
</ContentTemplate>
</asp:UpdatePanel>