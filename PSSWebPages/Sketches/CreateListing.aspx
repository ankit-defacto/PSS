<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="CreateListing.aspx.cs" Inherits="PSSWebPages.Sketches.CreateListing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<link href="../Styles/basic.css" rel="stylesheet" type="text/css" />
	<link href="../Styles/create.css" rel="stylesheet" type="text/css" />
	<%--<link href="../Styles/listing.css" rel="stylesheet" type="text/css" />--%>
	<script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<form id="createAccountForm" method="post" action="CreateListing.aspx" runat="server">
	<div class="fixedWidthMedContainer roundedBorder fullheight">
		<p class="Header fixedWidthMedContainer">We're glad you've chosen to list your facility with Premier Senior Solutions.</p>
		<div id="formParentDiv" class="roundedBorder newBlueBG">
			<p class="sidespacing">We will need the information of the person who will be managing this facility.</p>
			<h2 class="indent2">Facility Information</h2>
			<div id="formContainer" class="column">
				<div class="formLabels listingHeight">
					<div>Facility name</div>
					<div>Excerpt</div>
					<div>Description</div>
					<div>Phone Number</div>
					<div>Email</div>
					<div>Website</div>
					<div>Address</div>
					<div>City</div>
					<div>State</div>
					<div>Zip Code</div>
					<div>Listing Type</div>
					<div>Photo Url</div>
				</div>
				<div class="formInputs listingHeight">
					<asp:TextBox id="facFacilityName" Text="ABC Care Facility" runat="server" />
					<asp:TextBox id="facExcerpt" Text="Short excerpt" runat="server" />
					<asp:TextBox id="facDescription" Text="Longer description" runat="server" />
					<asp:TextBox id="facPhoneNumber" Text="(425) 555-5555" runat="server" />
					<asp:TextBox id="facEmail" Text="client@example.com" runat="server" />
					<asp:TextBox id="facWebsite" Text="http://www.example.com" runat="server" />
					<asp:TextBox id="facAddress" Text="700 Bellevue Way NE" runat="server" />
					<asp:TextBox id="facCity" Text="Bellevue" runat="server" />
					<asp:TextBox id="facState" Text="WA" runat="server" />
					<asp:TextBox id="facZipCode" Text="98004" runat="server" />
					<asp:TextBox id="facListingType" Text="Full care center" runat="server" />
					<asp:TextBox id="facPhotoUri" Text="http://www.google.com/intl/en_com/images/srpr/logo3w.png" runat="server" />
					<asp:Label id="clientGuidTxt" Text="" runat="server" Visible="false"  />
				</div>
				<%--<div class="blank"/>--%>
				<h2 class="indent2">Payment Info</h2>
				<button id="paymentButton" type="button" class="button topspacing1">Connect Payment System</button>
				<br />
				<asp:Button id="submitButton" CssClass="button indent1" Text="Continue" OnClick="submitButton_click" runat="server"/>
			</div>
			<div id="checklistContainer" class="column indent3">
				<h4>Facility Checklist</h4>
				<div id="checklistFacilityName">Facility Name</div>
				<div id="checklistExcerpt">Excerpt</div>
				<div id="checklistDescription">Description</div>
				<div id="checklistPhoneNumber">Phone Number</div>
				<div id="checklistEmail">Email</div>
				<div id="checklistWebsite">Website</div>
				<div id="checklistAddress">Address</div>
				<div id="checklistCity">City</div>
				<div id="checklistState">State</div>
				<div id="checklistZipCode">Zip</div>
				<div id="checklistListingType">Listing Type</div>
				<div id="checklistPhotoUri">Photo Url</div>
				<div id="checklistNoItems" style="visibility: hidden;">All filled out</div>
			</div>
			<div class="blank"/>
		</div>
	</div>
</form>

</asp:Content>


<asp:Content ContentPlaceHolderID="JavascriptCode" ID="JS" runat="server">
<script>

	$(document).ready(function () {
	});


	$('#MainContent_facFacilityName').blur(function () {
		if ($('#MainContent_facFacilityName').val() != null && $('#MainContent_facFacilityName').val() != '') {
			$('#checklistFacilityName').hide();
			checkChecklist();
		} else {
			$('#checklistFacilityName').show();
			$('#checklistNoItems').hide();
		}
	})

	$('#MainContent_facExcerpt').blur(function () {
		if ($('#MainContent_facExcerpt').val() != null && $('#MainContent_facExcerpt').val() != '') {
			$('#checklistExcerpt').hide();
			checkChecklist();
		} else {
			$('#checklistExcerpt').show();
			$('#checklistNoItems').hide();
		}
	})

	$('#MainContent_facDescription').blur(function () {
		if ($('#MainContent_facDescription').val() != null && $('#MainContent_facDescription').val() != '') {
			$('#checklistDescription').hide();
			checkChecklist();
		} else {
			$('#checklistDescription').show();
			$('#checklistNoItems').hide();
		}
	})

	$('#MainContent_facPhoneNumber').blur(function () {
		if ($('#MainContent_facPhoneNumber').val() != null && $('#MainContent_facPhoneNumber').val() != '') {
			$('#checklistPhoneNumber').hide();
			checkChecklist();
		} else {
			$('#checklistPhoneNumber').show();
			$('#checklistNoItems').hide();
		}
	})

	$('#MainContent_facEmail').blur(function () {
		if ($('#MainContent_facEmail').val() != null && $('#MainContent_facEmail').val() != '') {
			$('#checklistEmail').hide();
			checkChecklist();
		} else {
			$('#checklistEmail').show();
			$('#checklistNoItems').hide();
		}
	})

	$('#MainContent_facWebsite').blur(function () {
		if ($('#MainContent_facWebsite').val() != null && $('#MainContent_facWebsite').val() != '') {
			$('#checklistWebsite').hide();
			checkChecklist();
		} else {
			$('#checklistWebsite').show();
			$('#checklistNoItems').hide();
		}
	})

	$('#MainContent_facAddress').blur(function () {
		if ($('#MainContent_facAddress').val() != null && $('#MainContent_facAddress').val() != '') {
			$('#checklistAddress').hide();
			checkChecklist();
		} else {
			$('#checklistAddress').show();
			$('#checklistNoItems').hide();
		}
	})

	$('#MainContent_facCity').blur(function () {
		if ($('#MainContent_facCity').val() != null && $('#MainContent_facCity').val() != '') {
			$('#checklistCity').hide();
			checkChecklist();
		} else {
			$('#checklistCity').show();
			$('#checklistNoItems').hide();
		}
	})

	$('#MainContent_facState').blur(function () {
		if ($('#MainContent_facState').val() != null && $('#MainContent_facState').val() != '') {
			$('#checklistState').hide();
			checkChecklist();
		} else {
			$('#checklistState').show();
			$('#checklistNoItems').hide();
		}
	})

	$('#MainContent_facZipCode').blur(function () {
		if ($('#MainContent_facZipCode').val() != null && $('#MainContent_facZipCode').val() != '') {
			$('#checklistZipCode').hide();
			checkChecklist();
		} else {
			$('#checklistZipCode').show();
			$('#checklistNoItems').hide();
		}
	})

	$('#MainContent_facListingType').blur(function () {
		if ($('#MainContent_facListingType').val() != null && $('#MainContent_facListingType').val() != '') {
			$('#checklistListingType').hide();
			checkChecklist();
		} else {
			$('#checklistListingType').show();
			$('#checklistNoItems').hide();
		}
	})

	$('#MainContent_facPhotoUri').blur(function () {
		if ($('#MainContent_facPhotoUri').val() != null && $('#MainContent_facPhotoUri').val() != '') {
			$('#checklistPhotoUri').hide();
			checkChecklist();
		} else {
			$('#checklistPhotoUri').show();
			$('#checklistNoItems').hide();
		}
	})

	function checkChecklist() {
		if ($('#checklistFacilityName').is(':hidden') &&
			 $('#checklistExcerpt').is(':hidden') &&
			 $('#checklistDescription').is(':hidden') &&
			 $('#checklistPhoneNumber').is(':hidden') &&
			 $('#checklistEmail').is(':hidden') &&
			 $('#checklistWebsite').is(':hidden') &&
			 $('#checklistAddress').is(':hidden') &&
			 $('#checklistCity').is(':hidden') &&
			 $('#checklistState').is(':hidden') &&
			 $('#checklistZipCode').is(':hidden') &&
			 $('#checklistListingType').is(':hidden') &&
			 $('#checklistPhotoUri').is(':hidden')
			 ) {
			$('#checklistNoItems').show();
			$('#submitButton').css('background', '#00FF00');
		}
		else {
			$('#checklistNoItems').hide();
		}
	}
</script>
</asp:Content>