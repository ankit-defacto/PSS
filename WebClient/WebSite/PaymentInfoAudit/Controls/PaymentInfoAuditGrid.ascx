<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaymentInfoAuditGrid.ascx.cs" Inherits="PaymentInfoAudit_Controls_PaymentInfoAuditGrid" %>

<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>
<%@ Register Assembly="ISNet.WebUI.ISDataSource, Version=1.0.1500.1, Culture=neutral, PublicKeyToken=c4184ef0d326354b"
	Namespace="ISNet.WebUI.DataSource" TagPrefix="ISDataSource" %>
<%@ Register Assembly="ISNet.WebUI.WebGrid" Namespace="ISNet.WebUI.WebGrid" TagPrefix="ISWebGrid" %>

<ISWebGrid:WebGrid ID="wgPaymentInfoAudit" runat="server" Height="346px" UseDefaultStyle="True"
	Width="100%" DataMember="PaymentInfoAuditCollection" DataSourceID="isdPaymentInfoAudit" OnInitializeRow="wgPaymentInfoAudit_InitializeRow">
	<RootTable Caption="Payment Info Audit Collection" DataKeyField="PaymentInfoAuditGuid" DataMember="PaymentInfoAuditCollection">
		<Columns>
			<ISWebGrid:WebGridColumn Name="PaymentInfoAuditGuid" DataMember="PaymentInfoAuditGuid" Caption="Payment Info Audit Guid"
				Width="200px" EditType="NoEdit" Visible="false" DataType="System.String" DefaultValue="{00000000-0000-0000-0000-000000000000}" />
			<ISWebGrid:WebGridColumn Name="PaymentInfoGuid" DataMember="PaymentInfoGuid" Caption="Payment Info"
				Width="200px" EditType="WebComboNET" WebComboID="wcPaymentInfoAuditPaymentInfo" DataType="System.Guid">
				<ValueList DataSourceID="isdPaymentInfoAuditPaymentInfo" DataMember="PaymentInfoCollection"
					DataValueField="PaymentInfoGuid" DataTextField="PDC"/>
			</ISWebGrid:WebGridColumn>
			<ISWebGrid:WebGridColumn Name="PaymentInfoID" DataMember="PaymentInfoID" Caption="Payment Info ID"
				Width="100px" TextboxMaxlength="11" InputRequired="true" InputRequiredErrorText="Please fill in 'Payment Info ID'." />
			<ISWebGrid:WebGridColumn Name="AmazonToken" DataMember="AmazonToken" Caption="Amazon Token"
				Width="150px" TextboxMaxlength="100" InputRequired="true" InputRequiredErrorText="Please fill in 'Amazon Token'." />
			<ISWebGrid:WebGridColumn Name="DateModified" DataMember="DateModified" Caption="Date Modified"
				Width="175px" InputRequired="true" InputRequiredErrorText="Please fill in 'Date Modified'." />
		</Columns>
	</RootTable>
	<LayoutSettings AllowAddNew="Yes" AllowEdit="Yes" AllowDelete="Yes" AllowSorting="Yes" AllowFilter="Yes"
		AutoWidth="true" PagingMode="ClassicPaging" PagingSize="10" PagingStyleUI="Slider" PagingDetectPartialGroupRows="True">
	</LayoutSettings>
</ISWebGrid:WebGrid>
<ISWebCombo:WebCombo ID="wcPaymentInfoAuditPaymentInfo" runat="server" DataSourceID="isdPaymentInfoAuditPaymentInfo"
	DataValueField="PaymentInfoGuid" DataTextField="AmazonToken"
	Height="20px" Width="200px" UseDefaultStyle="True">
</ISWebCombo:WebCombo>
<ISDataSource:ISDataSource ID="isdPaymentInfoAudit" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.PaymentInfoAuditCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.PaymentInfoAudit" TableName="PaymentInfoAuditCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" OldValuesParameterFormatString="Original_{0}"
			SelectMethod="GetPaymentInfoAudits" InsertMethod="InsertPaymentInfoAudit" UpdateMethod="UpdatePaymentInfoAudit" DeleteMethod="DeletePaymentInfoAudit">
			<InsertParameters>
				<asp:Parameter Name="paymentInfoAudit" Type="Object" />
			</InsertParameters>
			<UpdateParameters>
				<asp:Parameter Name="paymentInfoAudit" Type="Object" />
			</UpdateParameters>
			<DeleteParameters>
				<asp:Parameter Name="paymentInfoAudit" Type="Object" />
			</DeleteParameters>
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>
<ISDataSource:ISDataSource ID="isdPaymentInfoAuditPaymentInfo" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.PaymentInfoCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.PaymentInfo" TableName="PaymentInfoCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" SelectMethod="GetPaymentInfos">
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>