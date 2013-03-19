<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ClientGrid.ascx.cs" Inherits="Client_Controls_ClientGrid" %>

<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>
<%@ Register Assembly="ISNet.WebUI.ISDataSource, Version=1.0.1500.1, Culture=neutral, PublicKeyToken=c4184ef0d326354b"
	Namespace="ISNet.WebUI.DataSource" TagPrefix="ISDataSource" %>
<%@ Register Assembly="ISNet.WebUI.WebGrid" Namespace="ISNet.WebUI.WebGrid" TagPrefix="ISWebGrid" %>

<ISWebGrid:WebGrid ID="wgClient" runat="server" Height="346px" UseDefaultStyle="True"
	Width="100%" DataMember="ClientCollection" DataSourceID="isdClient" OnInitializeRow="wgClient_InitializeRow">
	<RootTable Caption="Client Collection" DataKeyField="ClientGuid" DataMember="ClientCollection">
		<Columns>
			<ISWebGrid:WebGridColumn Name="ClientGuid" DataMember="ClientGuid" Caption="Client Guid"
				Width="200px" EditType="NoEdit" Visible="false" DataType="System.String" DefaultValue="{00000000-0000-0000-0000-000000000000}" />
			<ISWebGrid:WebGridColumn Name="ClientID" DataMember="ClientID" Caption="Client ID"
				Width="100px" EditType="NoEdit" />
			<ISWebGrid:WebGridColumn Name="ClientName" DataMember="ClientName" Caption="Client Name"
				Width="150px" TextboxMaxlength="100" InputRequired="true" InputRequiredErrorText="Please fill in 'Client Name'." />
			<ISWebGrid:WebGridColumn Name="PhoneNumber" DataMember="PhoneNumber" Caption="Phone Number"
				Width="150px" TextboxMaxlength="10" InputRequired="true" InputRequiredErrorText="Please fill in 'Phone Number'." />
			<ISWebGrid:WebGridColumn Name="Email" DataMember="Email" Caption="Email"
				Width="150px" TextboxMaxlength="100" InputRequired="true" InputRequiredErrorText="Please fill in 'Email'." />
			<ISWebGrid:WebGridColumn Name="Address" DataMember="Address" Caption="Address"
				Width="150px" TextboxMaxlength="100" InputRequired="true" InputRequiredErrorText="Please fill in 'Address'." />
			<ISWebGrid:WebGridColumn Name="CityStateZipGuid" DataMember="CityStateZipGuid" Caption="City State Zip"
				Width="200px" EditType="WebComboNET" WebComboID="wcClientCityStateZip" DataType="System.Guid">
				<ValueList DataSourceID="isdClientCityStateZip" DataMember="CityStateZipCollection"
					DataValueField="CityStateZipGuid" DataTextField="PDC"/>
			</ISWebGrid:WebGridColumn>
			<ISWebGrid:WebGridColumn Name="PaymentInfoGuid" DataMember="PaymentInfoGuid" Caption="Payment Info"
				Width="200px" EditType="WebComboNET" WebComboID="wcClientPaymentInfo" DataType="System.Guid">
				<ValueList DataSourceID="isdClientPaymentInfo" DataMember="PaymentInfoCollection"
					DataValueField="PaymentInfoGuid" DataTextField="PDC"/>
			</ISWebGrid:WebGridColumn>
			<ISWebGrid:WebGridColumn Name="FederatedID" DataMember="FederatedID" Caption="Federated ID"
				Width="150px" TextboxMaxlength="100" />
			<ISWebGrid:WebGridColumn Name="FederatedKey" DataMember="FederatedKey" Caption="Federated Key"
				Width="150px" TextboxMaxlength="400" />
			<ISWebGrid:WebGridColumn Name="FederatedIDProvider" DataMember="FederatedIDProvider" Caption="Federated ID Provider"
				Width="150px" TextboxMaxlength="50" />
			<ISWebGrid:WebGridColumn Name="Username" DataMember="Username" Caption="Username"
				Width="150px" TextboxMaxlength="50" />
			<ISWebGrid:WebGridColumn Name="HashedPassword" DataMember="HashedPassword" Caption="Hashed Password"
				Width="150px" TextboxMaxlength="200" />
		</Columns>
	</RootTable>
	<LayoutSettings AllowAddNew="Yes" AllowEdit="Yes" AllowDelete="Yes" AllowSorting="Yes" AllowFilter="Yes"
		AutoWidth="true" PagingMode="ClassicPaging" PagingSize="10" PagingStyleUI="Slider" PagingDetectPartialGroupRows="True">
	</LayoutSettings>
</ISWebGrid:WebGrid>
<ISWebCombo:WebCombo ID="wcClientCityStateZip" runat="server" DataSourceID="isdClientCityStateZip"
	DataValueField="CityStateZipGuid" DataTextField="City"
	Height="20px" Width="200px" UseDefaultStyle="True">
</ISWebCombo:WebCombo>
<ISWebCombo:WebCombo ID="wcClientPaymentInfo" runat="server" DataSourceID="isdClientPaymentInfo"
	DataValueField="PaymentInfoGuid" DataTextField="AmazonToken"
	Height="20px" Width="200px" UseDefaultStyle="True">
</ISWebCombo:WebCombo>
<ISDataSource:ISDataSource ID="isdClient" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.ClientCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.Client" TableName="ClientCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" OldValuesParameterFormatString="Original_{0}"
			SelectMethod="GetClients" InsertMethod="InsertClient" UpdateMethod="UpdateClient" DeleteMethod="DeleteClient">
			<InsertParameters>
				<asp:Parameter Name="client" Type="Object" />
			</InsertParameters>
			<UpdateParameters>
				<asp:Parameter Name="client" Type="Object" />
			</UpdateParameters>
			<DeleteParameters>
				<asp:Parameter Name="client" Type="Object" />
			</DeleteParameters>
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>
<ISDataSource:ISDataSource ID="isdClientCityStateZip" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.CityStateZipCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.CityStateZip" TableName="CityStateZipCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" SelectMethod="GetCityStateZips">
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>
<ISDataSource:ISDataSource ID="isdClientPaymentInfo" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.PaymentInfoCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.PaymentInfo" TableName="PaymentInfoCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" SelectMethod="GetPaymentInfos">
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>