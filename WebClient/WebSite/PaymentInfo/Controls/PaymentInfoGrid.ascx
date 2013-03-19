<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaymentInfoGrid.ascx.cs" Inherits="PaymentInfo_Controls_PaymentInfoGrid" %>

<%@ Register Assembly="ISNet.WebUI.WebCombo" Namespace="ISNet.WebUI.WebCombo" TagPrefix="ISWebCombo" %>
<%@ Register Assembly="ISNet.WebUI.ISDataSource, Version=1.0.1500.1, Culture=neutral, PublicKeyToken=c4184ef0d326354b"
	Namespace="ISNet.WebUI.DataSource" TagPrefix="ISDataSource" %>
<%@ Register Assembly="ISNet.WebUI.WebGrid" Namespace="ISNet.WebUI.WebGrid" TagPrefix="ISWebGrid" %>

<ISWebGrid:WebGrid ID="wgPaymentInfo" runat="server" Height="346px" UseDefaultStyle="True"
	Width="100%" DataMember="PaymentInfoCollection" DataSourceID="isdPaymentInfo" OnInitializeRow="wgPaymentInfo_InitializeRow">
	<RootTable Caption="Payment Info Collection" DataKeyField="PaymentInfoGuid" DataMember="PaymentInfoCollection">
		<Columns>
			<ISWebGrid:WebGridColumn Name="PaymentInfoGuid" DataMember="PaymentInfoGuid" Caption="Payment Info Guid"
				Width="200px" EditType="NoEdit" Visible="false" DataType="System.String" DefaultValue="{00000000-0000-0000-0000-000000000000}" />
			<ISWebGrid:WebGridColumn Name="PaymentInfoID" DataMember="PaymentInfoID" Caption="Payment Info ID"
				Width="100px" EditType="NoEdit" />
			<ISWebGrid:WebGridColumn Name="AmazonToken" DataMember="AmazonToken" Caption="Amazon Token"
				Width="150px" TextboxMaxlength="100" InputRequired="true" InputRequiredErrorText="Please fill in 'Amazon Token'." />
		</Columns>
	</RootTable>
	<LayoutSettings AllowAddNew="Yes" AllowEdit="Yes" AllowDelete="Yes" AllowSorting="Yes" AllowFilter="Yes"
		AutoWidth="true" PagingMode="ClassicPaging" PagingSize="10" PagingStyleUI="Slider" PagingDetectPartialGroupRows="True">
	</LayoutSettings>
</ISWebGrid:WebGrid>
<ISDataSource:ISDataSource ID="isdPaymentInfo" runat="server" SchemaName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.PaymentInfoCollection"
	SchemaType="CustomObject" LoadOnDemand="True" EnableCaching="No" UseCachedDataOnFirstLoad="No">
	<Tables>
		<ISDataSource:ISDataSourceTable DataObjectTypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.PaymentInfo" TableName="PaymentInfoCollection"
			TypeName="ConcordMfg.PremierSeniorSolutions.Client.ViewModels.DataAccess" OldValuesParameterFormatString="Original_{0}"
			SelectMethod="GetPaymentInfos" InsertMethod="InsertPaymentInfo" UpdateMethod="UpdatePaymentInfo" DeleteMethod="DeletePaymentInfo">
			<InsertParameters>
				<asp:Parameter Name="paymentInfo" Type="Object" />
			</InsertParameters>
			<UpdateParameters>
				<asp:Parameter Name="paymentInfo" Type="Object" />
			</UpdateParameters>
			<DeleteParameters>
				<asp:Parameter Name="paymentInfo" Type="Object" />
			</DeleteParameters>
		</ISDataSource:ISDataSourceTable>
	</Tables>
</ISDataSource:ISDataSource>