<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="CreateProfile.aspx.cs" Inherits="PSSWebPages.Sketches.CreateProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<link href="../Styles/basic.css" rel="stylesheet" type="text/css" />
	<link href="../Styles/create.css" rel="stylesheet" type="text/css" />
	<script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<form id="createAccountForm" method="post" action="CreateProfile.aspx" runat="server">
	<div class="fixedWidthMedContainer roundedBorder bottomspacing1">
		<p class="Header fixedWidthMedContainer">We're glad you've chosen to create an account with Premier Senior Solutions.</p>
		<div id="formParentDiv" class="roundedBorder newBlueBG bottomspacing1">
			<p class="sidespacing topspacing1 bold">We will need the information of the person who will be managing this account.</p>
			<h2 class="indent2 topspacing3">Company Information</h2>
			<div id="formContainer">
				<div class="profileHeight column formLabels indent1">
					<div>Company name</div>
					<div>First name</div>
					<div>Last name</div>
					<div>Email</div>
					<div>Phone Number</div>
					<div>Address</div>
					<div>City</div>
					<div>State</div>
					<div>Zip Code</div>
				</div>
				<div class="profileHeight column formInputs indent1">
					<asp:TextBox id="acctCompanyName" Text="ABC Company LLC" runat="server" />
					<asp:TextBox id="acctFirstName" Text="Funny" runat="server" />
					<asp:TextBox id="acctLastName" Text="Name" runat="server" />
					<asp:TextBox id="acctEmail" Text="client@example.com" runat="server" />
					<asp:TextBox id="acctPhoneNumber" Text="(425) 555-7777" runat="server" />
					<asp:TextBox id="acctAddress" Text="700 Bellevue Way NE" runat="server" />
					<asp:TextBox id="acctCity" Text="Bellevue" runat="server" />
					<asp:TextBox id="acctState" Text="WA" runat="server" />
					<asp:TextBox id="acctZipCode" Text="98004" runat="server" />
				</div>
				<div id="checklistContainer" class="profileHeight column indent2">
					<h4>Account Checklist</h4>
					<div id="checklistCompanyName">Company Name</div>
					<div id="checklistFirstName">First name</div>
					<div id="checklistLastName">Last name</div>
					<div id="checklistEmail">Email</div>
					<div id="checklistPhoneNumber">Phone Number</div>
					<div id="checklistAddress">Address</div>
					<div id="checklistCity">City</div>
					<div id="checklistState">State</div>
					<div id="checklistZipCode">Zip</div>
					<div id="checklistPayment">Payment Info</div>
					<div id="checklistNoItems">All filled out</div>
				</div>
				<div class="blank"></div>
				<h2 class="indent2 topspacing3">Payment Info</h2>
				<button id="paymentButton" type="button" class="button topspacing1">Connect Payment System</button>
				<asp:Button id="submitButton" CssClass="button indent1 topspacing3" Text="Continue" OnClick="submitButton_click" runat="server"/>
			</div>
		</div>
	</div>
</form>

</asp:Content>

<asp:Content ContentPlaceHolderID="JavascriptCode" ID="JS" runat="server">
<script type="text/javascript">

		$(document).ready(function () {
			$('#checklistNoItems').hide();
		});


	$('#MainContent_acctCompanyName').blur(function () {
		if ($('#MainContent_acctCompanyName').val() != null && $('#MainContent_acctCompanyName').val() != '') {
			$('#checklistCompanyName').hide();
			checkChecklist();
		} else {
			$('#checklistCompanyName').show();
			$('#checklistNoItems').hide();
		}
	})

	$('#MainContent_acctFirstName').blur(function () {
		if ($('#MainContent_acctFirstName').val() != null && $('#MainContent_acctFirstName').val() != '') {
			$('#checklistFirstName').hide();
			checkChecklist();
		} else {
			$('#checklistFirstName').show();
			$('#checklistNoItems').hide();
		}
	})

	$('#MainContent_acctLastName').blur(function () {
		if ($('#MainContent_acctLastName').val() != null && $('#MainContent_acctLastName').val() != '') {
			$('#checklistLastName').hide();
			checkChecklist();
		} else {
			$('#checklistLastName').show();
			$('#checklistNoItems').hide();
		}
	})

	$('#MainContent_acctEmail').blur(function () {
		if ($('#MainContent_acctEmail').val() != null && $('#MainContent_acctEmail').val() != '') {
			$('#checklistEmail').hide();
			checkChecklist();
		} else {
			$('#checklistEmail').show();
			$('#checklistNoItems').hide();
		}
	})

	$('#MainContent_acctPhoneNumber').blur(function () {
		if ($('#MainContent_acctPhoneNumber').val() != null && $('#MainContent_acctPhoneNumber').val() != '') {
			$('#checklistPhoneNumber').hide();
			checkChecklist();
		} else {
			$('#checklistPhoneNumber').show();
			$('#checklistNoItems').hide();
		}
	})

	$('#MainContent_acctAddress').blur(function () {
		if ($('#MainContent_acctAddress').val() != null && $('#MainContent_acctAddress').val() != '') {
			$('#checklistAddress').hide();
			checkChecklist();
		} else {
			$('#checklistAddress').show();
			$('#checklistNoItems').hide();
		}
	})

	$('#MainContent_acctCity').blur(function () {
		if ($('#MainContent_acctCity').val() != null && $('#MainContent_acctCity').val() != '') {
			$('#checklistCity').hide();
			checkChecklist();
		} else {
			$('#checklistCity').show();
			$('#checklistNoItems').hide();
		}
	})

	$('#MainContent_acctState').blur(function () {
		if ($('#MainContent_acctState').val() != null && $('#MainContent_acctState').val() != '') {
			$('#checklistState').hide();
			checkChecklist();
		} else {
			$('#checklistState').show();
			$('#checklistNoItems').hide();
		}
	})

	$('#MainContent_acctZipCode').blur(function () {
		if ($('#MainContent_acctZipCode').val() != null && $('#MainContent_acctZipCode').val() != '') {
			$('#checklistZipCode').hide();
			checkChecklist();
		} else {
			$('#checklistZipCode').show();
			$('#checklistNoItems').hide();
		}
	})

	$('#paymentButton').click(function () {
		if ($('#checklistPayment').is(":visible")) {
			$('#checklistPayment').hide();
			checkChecklist();
		} else {
			$('#checklistPayment').show();
			$('#checklistNoItems').hide();
		}
	})

	function checkChecklist() {
		if ($('#checklistCompanyName').is(':hidden') &&
			 $('#checklistFirstName').is(':hidden') &&
			 $('#checklistLastName').is(':hidden') &&
			 $('#checklistEmail').is(':hidden') &&
			 $('#checklistPhoneNumber').is(':hidden') &&
			 $('#checklistAddress').is(':hidden') &&
			 $('#checklistCity').is(':hidden') &&
			 $('#checklistState').is(':hidden') &&
			 $('#checklistZipCode').is(':hidden') &&
			 $('#checklistPayment').is(':hidden')
			 ) {
			$('#checklistNoItems').show();
			$('#MainContent_submitButton').css('background', '#00FF00');
		}
		else {
			$('#checklistNoItems').hide();
			$('#MainContent_submitButton').css('background', '#FFFFFF');
		}
	}

</script>
</asp:Content>