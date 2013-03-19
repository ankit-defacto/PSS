<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="test_page.aspx.cs" Inherits="PSSWebPages.test_page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<form runat="server">
		<asp:ScriptManager runat="server"/>
		<pssPages:TestPage runat="server" />
	</form>
</asp:Content>
