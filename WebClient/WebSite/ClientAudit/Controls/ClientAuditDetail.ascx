<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ClientAuditDetail.ascx.cs" Inherits="ClientAudit_Controls_ClientAuditDetail" %>

<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>
<%@ Register Assembly="ISNet.WebUI.ISDataSource, Version=1.0.1500.1, Culture=neutral, PublicKeyToken=c4184ef0d326354b"
	Namespace="ISNet.WebUI.DataSource" TagPrefix="ISDataSource" %>
<%@ Register Assembly="ISNet.WebUI.WebDesktop" Namespace="ISNet.WebUI.WebDesktop" TagPrefix="ISWebDesktop" %>
<%@ Register Assembly="ISNet.WebUI.WebInput" Namespace="ISNet.WebUI.WebControls" TagPrefix="ISWebInput" %>

<asp:FormView ID="fvClientAudit" runat="server" DataSourceID="odsClientAudit" DataKeyNames="ClientAuditGuid" AllowPaging="false" DefaultMode="ReadOnly">
	<EmptyDataTemplate>
		No data retrieved.<br />
		<asp:LinkButton ID="btnNew" runat="server" CausesValidation="false" CommandName="New" Text="New"></asp:LinkButton>
	</EmptyDataTemplate>
	<EditItemTemplate>
		<table>
			<tr><td>Client Audit Guid</td><td><asp:Label ID="lblClientAuditGuid" runat="server" Text='<%# Bind("ClientAuditGuid") %>' /></td></tr>
			<tr><td>Client Guid Client:</td><td><ISWebCombo:WebCombo ID="wcClient" runat="server" UseDefaultStyle="True" DataSourceID="isdClientAuditClient" DataTextField="PDC" DataValueField="ClientGuid" Height="20px" Width="200px" /></td></tr>
			<tr><td>Client ID:</td><td><ISWebInput:WebInput ID="wiClientID" runat="server" NumericInput="true" /></td></tr>
			<tr><td>Client Name:</td><td><asp:TextBox ID="txtClientName" runat="server" Text='<%# Bind("ClientName") %>' Width="150px" MaxLength="100" TextMode="MultiLine" /></td></tr>
			<tr><td>Phone Number:</td><td><asp:TextBox ID="txtPhoneNumber" runat="server" Text='<%# Bind("PhoneNumber") %>' Width="150px" MaxLength="10" /></td></tr>
			<tr><td>Email:</td><td><asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>' Width="150px" MaxLength="100" TextMode="MultiLine" /></td></tr>
			<tr><td>Address:</td><td><asp:TextBox ID="txtAddress" runat="server" Text='<%# Bind("Address") %>' Width="150px" MaxLength="100" TextMode="MultiLine" /></td></tr>
			<tr><td>City State Zip Guid City State Zip:</td><td><ISWebCombo:WebCombo ID="wcCityStateZip" runat="server" UseDefaultStyle="True" DataSourceID="isdClientAuditCityStateZip" DataTextField="PDC" DataValueField="CityStateZipGuid" Height="20px" Width="200px" /></td></tr>
			<tr><td>Payment Info Guid Payment Info:</td><td><ISWebCombo:WebCombo ID="wcPaymentInfo" runat="server" UseDefaultStyle="True" DataSourceID="isdClientAuditPaymentInfo" DataTextField="PDC" DataValueField="PaymentInfoGuid" Height="20px" Width="200px" /></td></tr>
			<tr><td>Federated ID:</td><td><asp:TextBox ID="txtFederatedID" runat="server" Text='<%# Bind("FederatedID") %>' Width="150px" MaxLength="100" TextMode="MultiLine" /></td></tr>
			<tr><td>Federated Key:</td><td><asp:TextBox ID="txtFederatedKey" runat="server" Text='<%# Bind("FederatedKey") %>' Width="150px" MaxLength="400" TextMode="MultiLine" /></td></tr>
			<tr><td>Federated ID Provider:</td><td><asp:TextBox ID="txtFederatedIDProvider" runat="server" Text='<%# Bind("FederatedIDProvider") %>' Width="150px" MaxLength="50" /></td></tr>
			<tr><td>Username:</td><td><asp:TextBox ID="txtUsername" runat="server" Text='<%# Bind("Username") %>' Width="150px" MaxLength="50" /></td></tr>
			<tr><td>Hashed Password:</td><td><asp:TextBox ID="txtHashedPassword" runat="server" Text='<%# Bind("HashedPassword") %>' Width="150px" MaxLength="200" TextMode="MultiLine" /></td></tr>
			<tr><td>Date Modified:</td><td><asp:TextBox ID="txtDateModified" runat="server" Text='<%# Bind("DateModified") %>' Width="175px" /></td></tr>
		</table>
		<asp:Label ID="lblClientGuid" runat="server" Text='<%# Eval("ClientGuid") %>' Visible="false" />
		<asp:Label ID="lblClientID" runat="server" Text='<%# Eval("ClientID") %>' Visible="false" />
		<asp:Label ID="lblCityStateZipGuid" runat="server" Text='<%# Eval("CityStateZipGuid") %>' Visible="false" />
		<asp:Label ID="lblPaymentInfoGuid" runat="server" Text='<%# Eval("PaymentInfoGuid") %>' Visible="false" />
		<asp:LinkButton ID="btnUpdate" runat="server" CausesValidation="true" CommandName="Update" Text="Update"></asp:LinkButton>
		<asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
		<asp:LinkButton ID="btnCancel" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
	</EditItemTemplate>
	<ItemTemplate>
		<table>
			<tr><td>Client Audit Guid</td><td><asp:Label ID="lblClientAuditGuid" runat="server" Text='<%# Bind("ClientAuditGuid") %>' /></td></tr>
			<tr><td>Client Name:</td><td><asp:Label ID="txtClient" runat="server" Text='<%# Bind("ClientGuidPDC") %>' /></td></tr>
			<tr><td>Client ID:</td><td><asp:Label ID="lblClientID" runat="server" Text='<%# Bind("ClientID") %>' /></td></tr>
			<tr><td>Client Name:</td><td><asp:Label ID="lblClientName" runat="server" Text='<%# Bind("ClientName") %>' /></td></tr>
			<tr><td>Phone Number:</td><td><asp:Label ID="lblPhoneNumber" runat="server" Text='<%# Bind("PhoneNumber") %>' /></td></tr>
			<tr><td>Email:</td><td><asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>' /></td></tr>
			<tr><td>Address:</td><td><asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>' /></td></tr>
			<tr><td>City:</td><td><asp:Label ID="txtCityStateZip" runat="server" Text='<%# Bind("CityStateZipGuidPDC") %>' /></td></tr>
			<tr><td>Amazon Token:</td><td><asp:Label ID="txtPaymentInfo" runat="server" Text='<%# Bind("PaymentInfoGuidPDC") %>' /></td></tr>
			<tr><td>Federated ID:</td><td><asp:Label ID="lblFederatedID" runat="server" Text='<%# Bind("FederatedID") %>' /></td></tr>
			<tr><td>Federated Key:</td><td><asp:Label ID="lblFederatedKey" runat="server" Text='<%# Bind("FederatedKey") %>' /></td></tr>
			<tr><td>Federated ID Provider:</td><td><asp:Label ID="lblFederatedIDProvider" runat="server" Text='<%# Bind("FederatedIDProvider") %>' /></td></tr>
			<tr><td>Username:</td><td><asp:Label ID="lblUsername" runat="server" Text='<%# Bind("Username") %>' /></td></tr>
			<tr><td>Hashed Password:</td><td><asp:Label ID="lblHashedPassword" runat="server" Text='<%# Bind("HashedPassword") %>' /></td></tr>
			<tr><td>Date Modified:</td><td><asp:Label ID="lblDateModified" runat="server" Text='<%# Bind("DateModified") %>' /></td></tr>
		</table>
		<asp:LinkButton ID="btnEdit" runat="server" CausesValidation="true" CommandName="Edit" Text="Edit"></asp:LinkButton>
		<asp:LinkButton ID="btnDelete" runat="server" CausesValidation="false" CommandName="Delete" Text="Delete"></asp:LinkButton>
		<asp:LinkButton ID="btnNew" runat="server" CausesValidation="false" CommandName="New" Text="New"></asp:LinkButton>
	</ItemTemplate>
	<InsertItemTemplate>
		<table>
			<tr><td>Client:</td><td><ISWebCombo:WebCombo ID="wcClient" runat="server" UseDefaultStyle="True" DataSourceID="isdClientAuditClient" DataTextField="PDC" DataValueField="ClientGuid" Height="20px" Width="200px" /></td></tr>
			<tr><td>Client ID:</td><td><ISWebInput:WebInput ID="wiClientID" runat="server" NumericInput="true" /><br /></td></tr>
			<tr><td>Client Name:</td><td><asp:TextBox ID="txtClientName" runat="server" Text='<%# Bind("ClientName") %>' Width="150px" MaxLength="100" TextMode="MultiLine" /><br /></td></tr>
			<tr><td>Phone Number:</td><td><asp:TextBox ID="txtPhoneNumber" runat="server" Text='<%# Bind("PhoneNumber") %>' Width="150px" MaxLength="10" /><br /></td></tr>
			<tr><td>Email:</td><td><asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>' Width="150px" MaxLength="100" TextMode="MultiLine" /><br /></td></tr>
			<tr><td>Address:</td><td><asp:TextBox ID="txtAddress" runat="server" Text='<%# Bind("Address") %>' Width="150px" MaxLength="100" TextMode="MultiLine" /><br /></td></tr>
			<tr><td>City State Zip:</td><td><ISWebCombo:WebCombo ID="wcCityStateZip" runat="server" UseDefaultStyle="True" DataSourceID="isdClientAuditCityStateZip" DataTextField="PDC" DataValueField="CityStateZipGuid" Height="20px" Width="200px" /></td></tr>
			<tr><td>Payment Info:</td><td><ISWebCombo:WebCombo ID="wcPaymentInfo" runat="server" UseDefaultStyle="True" DataSourceID="isdClientAuditPaymentInfo" DataTextField="PDC" DataValueField="PaymentInfoGuid" Height="20px" Width="200px" /></td></tr>
			<tr><td>Federated ID:</td><td><asp:TextBox ID="txtFederatedID" runat="server" Text='<%# Bind("FederatedID") %>' Width="150px" MaxLength="100" TextMode="MultiLine" /><br /></td></tr>
			<tr><td>Federated Key:</td><td><asp:TextBox ID="txtFederatedKey" runat="server" Text='<%# Bind("FederatedKey") %>' Width="150px" MaxLength="400" TextMode="MultiLine" /><br /></td></tr>
			<tr><td>Federated ID Provider:</td><td><asp:TextBox ID="txtFederatedIDProvider" runat="server" Text='<%# Bind("FederatedIDProvider") %>' Width="150px" MaxLength="50" /><br /></td></tr>
			<tr><td>Username:</td><td><asp:TextBox ID="txtUsername" runat="server" Text='<%# Bind("Username") %>' Width="150px" MaxLength="50" /><br /></td></tr>
			<tr><td>Hashed Password:</td><td><asp:TextBox ID="txtHashedPassword" runat="server" Text='<%# Bind("HashedPassword") %>' Width="150px" MaxLength="200" TextMode="MultiLine" /><br /></td></tr>
			<tr><td>Date Modified:</td><td><asp:TextBox ID="txtDateModified" runat="server" Text='<%# Bind("DateModified") %>' Width="175px" /><br /></td></tr>
		</table>
		<asp:Label ID="lblClientAuditGuid" runat="server" Text='<%# Bind("ClientAuditGuid") %>' Visible="false">{00000000-0000-0000-0000-000000000000}</asp:Label><br />
		<asp:LinkButton ID="btnInsert" runat="server" CausesValidation="true" CommandName="Insert" Text="Insert"></asp:LinkButton>
		<asp:LinkButton ID="btnCancel" runat="server" CausesValidation="false" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
	</InsertItemTemplate>
</asp:FormView>
<asp:ObjectDataSource ID="odsClientAudit" runat="server" DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.ClientAudit"
	OldValuesParameterFormatString="original_{0}" TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess"
	SelectMethod="GetClientAudit" InsertMethod="InsertClientAudit"
	UpdateMethod="UpdateClientAudit" DeleteMethod="DeleteClientAudit">
	<SelectParameters>
		<asp:QueryStringParameter Name="clientAuditGuid" QueryStringField="ClientAuditGuid" Type="String" />
	</SelectParameters>
	<InsertParameters>
		<%--<asp:Parameter Name="clientAudit" Type="Object" />--%>
		<asp:Parameter Name="clientGuid" Type="String" />
		<asp:Parameter Name="clientID" Type="Int32" />
		<asp:Parameter Name="clientName" Type="String" />
		<asp:Parameter Name="phoneNumber" Type="String" />
		<asp:Parameter Name="email" Type="String" />
		<asp:Parameter Name="address" Type="String" />
		<asp:Parameter Name="cityStateZipGuid" Type="String" />
		<asp:Parameter Name="paymentInfoGuid" Type="String" />
		<asp:Parameter Name="federatedID" Type="String" />
		<asp:Parameter Name="federatedKey" Type="String" />
		<asp:Parameter Name="federatedIDProvider" Type="String" />
		<asp:Parameter Name="username" Type="String" />
		<asp:Parameter Name="hashedPassword" Type="String" />
		<asp:Parameter Name="dateModified" Type="DateTime" />
	</InsertParameters>
</asp:ObjectDataSource>
<ISDataSource:ISDataSource ID="isdClientAuditClient" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.ClientCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.Client" TableName="ClientCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" SelectMethod="GetClients">
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>
<ISDataSource:ISDataSource ID="isdClientAuditCityStateZip" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.CityStateZipCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.CityStateZip" TableName="CityStateZipCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" SelectMethod="GetCityStateZips">
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>
<ISDataSource:ISDataSource ID="isdClientAuditPaymentInfo" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.PaymentInfoCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.PaymentInfo" TableName="PaymentInfoCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" SelectMethod="GetPaymentInfos">
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>