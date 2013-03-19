using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;
using ConcordMfg.PremierSeniorSolutions.WebService.BusinessLogic;
using PSS.WebWithAuth.Infrastructure;
using PSS.WebWithAuth.ViewModels;

namespace PSS.WebWithAuth.Controllers
{
    /// <summary>
    /// Account controller class
    /// </summary>
	public partial class AccountController : Controller
	{
        private GitAssertion GitAssertion
        {
            get
            {
                GitApiClient gitClient = new GitApiClient();
                // Ask google identity toolkit who is signed in.
                GitAssertion assertion = gitClient.Verify();
                return assertion;
            }
        }

        public PartialViewResult LoginStatus()
        {
            return PartialView("_LogOnPartial");
        }

        // Gitkit callback method
        [HttpPost]
        [HandleError]
        public virtual ActionResult Callback()
		{
			GitAssertion assertion = GitAssertion;
			string BaseSiteUrl = Request.Url.Scheme + "://" + Request.Url.Authority.TrimEnd('/');

			ViewBag.FederatedResponse = GitApiClient.FederatedError;
			ViewBag.GitRedirectUrl = BaseSiteUrl + Url.Action("See", "Account");

			// If an email address comes back...
			if (!string.IsNullOrEmpty(assertion.VerifiedEmail))
			{
                ViewBag.FederatedResponse = GitApiClient.FederatedSuccess;
                SessionHandler.Current.GitAssertion = assertion;
                // Check asp.net membership for a user.
				MembershipUser user = Membership.GetUser(assertion.VerifiedEmail);
				if (user == null)
				{
					// If a user does not exist in the asp.net membership...					
					// Create the new user, only using their email address as username and a random guid for a password.
                    user = Membership.CreateUser(assertion.VerifiedEmail, Guid.NewGuid().ToString(), assertion.VerifiedEmail);
                    Roles.AddUserToRole(user.UserName, "user");
					// then specify the location of that page.
					//ViewBag.GitRedirectUrl = BaseSiteUrl + Url.Action(MVC.Account.FederatedRegister());
				}
                if (user.IsApproved == false)
                {
                    return View();
                }

                FormsAuthentication.SetAuthCookie(user.UserName, true);
                //if you wanted to collect more details before creating the user account,
                ViewBag.GitRedirectUrl = BaseSiteUrl + Url.Action("Create", "Account");
			}

			return View();
		}

        // Gitkit UserStatus method
        [HandleError]
        public virtual JsonResult UserStatus(string email)
        {
            var userData = Membership.GetUser(email);
            //if the user was switching accounts we need make sure we log out the previous user.
            //logout
            Session.Abandon();
            FormsAuthentication.SignOut();

            if (userData != null && userData.IsApproved != false)
            {
                var authUser = Membership.GetUser(userData.UserName);
                var user = new { displayName = authUser.UserName, photoUrl = "", registered = true, legacy = false };
                return Json(user);
            }
            else
            {
                var user = new { displayName = "", photoUrl = "", registered = false, legacy = false };
                return Json(user);
            }
        }

		//public ViewResult LogIn()	
        public ActionResult LogIn()	
        {
            // If already login then show admin panel
            var user = Membership.GetUser();
            if (user != null && Roles.GetRolesForUser(user.UserName).Contains("admin"))
                return RedirectToAction("AccountList","Admin");
            if (user != null && Roles.GetRolesForUser(user.UserName).Contains("user"))
                return RedirectToAction("Index", "Home");
            // save requested url to restore after authentication
            string returnurl = Request.QueryString["ReturnUrl"];
            if (!string.IsNullOrEmpty(returnurl))
            {
                SessionHandler.Current.ReturnUrl = returnurl;
            }
			return View();
		}

        // Gitkit local login
        [HttpPost]
        public virtual ActionResult LogIn(LogOnModel model, string returnUrl)
        {
            if (model.UserName == string.Empty && model.Email == string.Empty)
            {
                //ModelState.AddModelError("username", "username or email is required");
                return Json(new { status = "username or email is required" });
            }
            else if (string.IsNullOrEmpty(model.UserName))
            {
                model.UserName = Membership.GetUserNameByEmail(model.Email);
            }

            if (ModelState.IsValid)
            { 
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    var user = Membership.GetUser(model.UserName);

                    if (Roles.IsUserInRole(model.UserName, "admin") || user.IsApproved == false)
                        return Json(new { status = "passwordError" });
                       
                    SessionHandler.Current.GitAssertion = new GitAssertion()
                    {
                        VerifiedEmail = user.Email,
                        FirstName = model.UserName
                    };
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);

                    if (Request.IsAjaxRequest())
                    {
                        return Json(new { status = "ok", displayName = user.UserName, photoUrl = "" });
                    }
                   
                
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    //ModelState.AddModelError("", "The user name or password provided is incorrect.");                    
                }
            }

            // If we got this far, something failed, redisplay form
            //return View(model);
            return Json(new { status = "passwordError" });
        }

        //authorise for all user and admin
        [Authorize]
        [HandleError]
        [HttpGet]
        public ActionResult LogOff()
        {
            Session.Abandon();
            
            FormsAuthentication.SignOut();
           
           
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "user")]
		[HttpGet()]
        [HandleError]
		public ActionResult Create()
		{
			// If logged in, show the appropriate view.
			var user = Membership.GetUser();
			if (null == user)
			{
				// If they don't yet have an account, show the create account view.
                //plamen: account shouldn't be created without membership user
                ModelState.AddModelError("accountCreate", "Membership user not created. Repeat the login process.");
				return View();
			}
			else
			{
				// If they have an account, show the edit account view.
				AccountLogic logic = new AccountLogic();
				AccountViewModel account = logic.GetByEmail(user.UserName);
                if (account != null)
                {
            
                    return RedirectToAction("See");
                }
                else
                {
                    
                    return View();
                }
			}
		}

        [Authorize(Roles = "user")]
		[HttpPost()]
        [ValidateAntiForgeryToken(Salt = Configurations.AntiForgeryTokenSalt)]
        [HandleError]
		public ActionResult Create(AccountViewModel account)
		{
            // todo: implement some create account wizard when have more information
            if (!ModelState.IsValid)
            {
                return View(account);
            }

			// If logged in, show the appropriate view.
			var user = Membership.GetUser();
            if (user == null)
            {
                return RedirectToAction("Create");
            }

			ClientLogic clientLogic = new ClientLogic();
			// UserName is the email address they signed in with.
			Client possibleClient = clientLogic.GetClientByEmail(user.UserName);

			// If an account already exists for the user, show them the See page.
			if (null != possibleClient)
			{
                return RedirectToAction("See");
			}

            this.SaveAccount(clientLogic, account, user, true);
            return RedirectToAction("See");
		}

        [Authorize(Roles = "user")]
        [HttpGet]
        [HandleError]
		public ActionResult See()
		{
			AccountLogic accountLogic = new AccountLogic();
			AccountViewModel accountVM = accountLogic.GetByEmail(User.Identity.Name);

			// If an account does not exist, help user create one.
			if (null == accountVM)
			{
                return RedirectToAction("Create", "Account");
			}
			// If it does exist, show it.
			else
			{
                AccountWithListingsViewModel accountWithListings = accountVM.WithListings();
                ListingLogic llogic = new ListingLogic();
                var listings = llogic.GetListingsWithDateModifiedByClientGuid(accountWithListings.ClientGuid);
                accountWithListings.AccountListings = listings.ToList();
                ClientCardInfoLogic ClientCardInfoLogic = new ClientCardInfoLogic();
                var ccinfo= ClientCardInfoLogic.GetByClientGuid(accountWithListings.ClientGuid);

                ClientCardInfoViewModel clientCardInfoVM = new ClientCardInfoViewModel();
                if (ccinfo != null)
                    clientCardInfoVM = DecryptCCinfo(ccinfo);
                accountWithListings.clientCardInfoVM = clientCardInfoVM;

                return View(accountWithListings);
			}			
		}

        [Authorize(Roles = "user")]
        [RequireHttps]
        [HandleError]
        public ActionResult ClientCardInfo()
        {
            ViewBag.cardType = GetCardTypes();
            ViewBag.expiryMonth = GetExpiryMonths();
            ViewBag.expiryYear = GetExpiryYears();
            return View();
        }

        [Authorize(Roles = "user")]
        [HandleError]
        [HttpPost]
        [RequireHttps]
        public ActionResult ClientCardInfo(ClientCardInfoViewModel clientCardInfoVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please correct the errors and try again.");
                return View(clientCardInfoVM);
            }

            var user = Membership.GetUser();
            if (user == null)
                return RedirectToAction("Create");

            ClientLogic clientLogic = new ClientLogic();
            // UserName is the email address they signed in with.
            Client possibleClient = clientLogic.GetClientByEmail(user.UserName);

            // If an account already exists for the user, show them the See page.
            if (null == possibleClient)
                return RedirectToAction("Create");
            clientCardInfoVM.ClientGuid = possibleClient.ClientGuid;
            this.SaveClientCardInfo(clientCardInfoVM, true);
            return RedirectToAction("See");
        }

        [Authorize(Roles = "user")]
        [RequireHttps]
        [HandleError]
        public ActionResult EditClientCardInfo(Guid ClientGuid)
        {
            ClientCardInfoLogic ClientCardInfoLogic = new ClientCardInfoLogic();
            ClientCardInfo ccinfo = ClientCardInfoLogic.GetByClientGuid(ClientGuid);
            ClientCardInfoViewModel clientCardInfoVM = new ClientCardInfoViewModel();
            if (ccinfo != null)
                clientCardInfoVM = DecryptCCinfo(ccinfo);
            ViewBag.cardType = GetCardTypes();
            ViewBag.expiryMonth = GetExpiryMonths();
            ViewBag.expiryYear = GetExpiryYears();
            return View(clientCardInfoVM);
        }

        [Authorize(Roles = "user")]
        [HandleError]
        [HttpPost]
        [RequireHttps]
        public ActionResult EditClientCardInfo(ClientCardInfoViewModel clientCardInfoVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please correct the errors and try again.");
                return View(clientCardInfoVM);
            }

            var user = Membership.GetUser();
            if (user == null)
            {
                return RedirectToAction("Create");
            }

            ClientLogic clientLogic = new ClientLogic();
            Client possibleClient = clientLogic.GetClientByEmail(user.UserName);

            if (null == possibleClient)
            {
                return RedirectToAction("Create");
            }
            clientCardInfoVM.ClientGuid = possibleClient.ClientGuid;
            this.SaveClientCardInfo(clientCardInfoVM, false);
            return RedirectToAction("see");
        }

		#region Brandons work

        [Authorize]
		[HttpGet()]
        [HandleError]
		public ViewResult Edit(Guid accountGuid)
		{
			// Get account object from db
			AccountLogic logic = new AccountLogic();
			AccountViewModel account = logic.GetByPK(accountGuid);

			return View(account);
		}

        [Authorize]
		[HttpPost()]
        [ValidateAntiForgeryToken(Salt = Configurations.AntiForgeryTokenSalt)]
        [HandleError]
		public ActionResult Edit(AccountViewModel account)
		{
            if (!ModelState.IsValid)
            {
                return View(account);
            }

			// Call business logic to insert the data.
			ClientLogic clientLogic = new ClientLogic();
			Client possibleClient = clientLogic.GetClientByEmail(account.Email);
		   
			if (null == possibleClient)
			{
                return RedirectToAction("See");
			}

            this.SaveAccount(clientLogic, account, Membership.GetUser(), false);
            return RedirectToAction("See");
		}

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken(Salt = Configurations.AntiForgeryTokenSalt)]
        [HandleError]
        public ActionResult AccountToggle(AccountViewModel account)
        {
            ClientLogic clientLogic = new ClientLogic();
            Client client = clientLogic.GetClientByClientGuid(account.ClientGuid);
            if (null == client)
            {
                return RedirectToAction("See");
            }
            // toggle account paused flag
            client.AccountPaused = !account.PauseAccount;
            clientLogic.UpdateClient(client);
            
            return RedirectToAction("See");
        }

		#endregion

        #region Private methods

        private void AddPaymentInfoToAccount(AccountViewModel account, PaymentInfo paymentInfo)
        {
            Common.ValidateArgument<AccountViewModel>(account, "account");
            Common.ValidateArgument<PaymentInfo>(paymentInfo, "paymentInfo");
            
            PaymentInfoLogic piLogic = new PaymentInfoLogic();
            PaymentInfo existingPaymentInfo = piLogic.GetPaymentInfoByPaymentInfoGuid(paymentInfo.PaymentInfoGuid);
            if (existingPaymentInfo == null || existingPaymentInfo.PaymentInfoGuid == Guid.Empty)
            {
                paymentInfo = piLogic.InsertPaymentInfo(paymentInfo);
            }
            else
            {
                paymentInfo.PaymentInfoGuid = existingPaymentInfo.PaymentInfoGuid;
                piLogic.UpdatePaymentInfo(paymentInfo);
                paymentInfo = piLogic.GetPaymentInfoByPaymentInfoGuid(paymentInfo.PaymentInfoGuid);
            }

            account.PaymentInfoGuid = paymentInfo.PaymentInfoGuid;
        }

        private void AddCityStateZipToAccount(AccountViewModel account, CityStateZip cityStateZip)
        {
            Common.ValidateArgument<AccountViewModel>(account, "account");
            Common.ValidateArgument<CityStateZip>(cityStateZip, "cityStateZip");

            CityStateZipLogic cszLogic = new CityStateZipLogic();
            cityStateZip = cszLogic.InsertCityStateZip(cityStateZip);
            account.CityStateZipGuid = cityStateZip.CityStateZipGuid;
        }

        private void SaveAccount(ClientLogic clientLogic, AccountViewModel account, MembershipUser user, bool insert)
        {
            // Call business logic to insert the data.
            // todo: move to mapping
            CityStateZip cityStateZip = new CityStateZip
            {
                City = account.City,
                State = account.State,
                ZipCode = account.ZipCode
            };
            this.AddCityStateZipToAccount(account, cityStateZip);

            PaymentInfo paymentInfo = new PaymentInfo
            {
                AmazonToken = User.Identity.Name
            };
            this.AddPaymentInfoToAccount(account, paymentInfo);

            Client client = new Client();
            client.ClientName = account.ClientName;
            client.PhoneNumber = account.PhoneNumber;
            client.Email = user.UserName;
            client.Address = account.Address;
            client.CityStateZipGuid = account.CityStateZipGuid;
            client.PaymentInfoGuid = account.PaymentInfoGuid;
            // pause account - in create view is always false
            client.AccountPaused = account.PauseAccount;
            if (insert)
            {
                if (SessionHandler.Current.GitAssertion != null)
                {
                    GitAssertion assertion = SessionHandler.Current.GitAssertion;
                    client.FederatedIDProvider = assertion.Authority;
                    client.FederatedID = assertion.Identifier;
                    client.FederatedKey = user.ProviderUserKey.ToString();
                }

                client = clientLogic.InsertClient(client);
                account.ClientGuid = client.ClientGuid;
                account.ClientID = client.ClientID;
            }
            else
            {
                client.IsWaiverd = account.IsWaiverd;
                client.FreeDays = account.FreeDays;
                client.Credits = account.AccountBalance;
                client.IsSuspended = account.IsSuspended;
                client.IsActive = account.IsActive;
                client.ClientGuid = account.ClientGuid; // Had to add this......                
                clientLogic.UpdateClient(client);
            }
        }
        
        private string SetKey()
        {
            return "SamplePrivateKey";
        }

        private void SaveClientCardInfo(ClientCardInfoViewModel clientCardInfoVM, bool insert)
        {
            ClientCardInfoLogic logic = new ClientCardInfoLogic();
            ClientCardInfo clientCardInfo = new ClientCardInfo();

            clientCardInfo.CardType = clientCardInfoVM.CardType;
            clientCardInfo.CardHolderNameOnCard = Cryptographer.Encrypt(clientCardInfoVM.CardHolderNameOnCard, SetKey());
            clientCardInfo.CardNumber = Cryptographer.Encrypt(clientCardInfoVM.CardNumber, SetKey());
            clientCardInfo.ClientCardGuid= clientCardInfoVM.ClientCardGuid;
            clientCardInfo.ClientGuid = clientCardInfoVM.ClientGuid;
            clientCardInfo.CvvNumber = Cryptographer.Encrypt(clientCardInfoVM.CvvNumber, SetKey());
            clientCardInfo.ExpMonth = clientCardInfoVM.ExpMonth;
            clientCardInfo.ExpYear = clientCardInfoVM.ExpYear;
            if (insert)
                logic.InsertClientCardInfo(clientCardInfo);
            else
                logic.UpdateClientCardInfo(clientCardInfo);
        }

        private ClientCardInfoViewModel DecryptCCinfo(ClientCardInfo model)
        {            
            ClientCardInfoViewModel clientCardInfoVM = new ClientCardInfoViewModel();
            clientCardInfoVM.CardType = model.CardType;
            clientCardInfoVM.CardHolderNameOnCard = Cryptographer.Decrypt(model.CardHolderNameOnCard,SetKey());
            clientCardInfoVM.CardNumber = Cryptographer.Decrypt(model.CardNumber,SetKey());
            clientCardInfoVM.ClientCardGuid = model.ClientCardGuid;
            clientCardInfoVM.ClientGuid = model.ClientGuid;
            clientCardInfoVM.CvvNumber = Cryptographer.Decrypt(model.CvvNumber, SetKey());
            clientCardInfoVM.ExpMonth = model.ExpMonth;
            clientCardInfoVM.ExpYear = model.ExpYear;
            return clientCardInfoVM;
        }

        private SelectList GetCardTypes()
        {
            var cardTypes = new SelectList(new[]
                                          {
                                              new {ID="Visa",Name="Visa"},
                                              new{ID="MasterCard",Name="MasterCard"},
                                              new{ID="Discover",Name="Discover"},
                                              new{ID="AmericanExpress",Name="AmericanExpress"},
                                          },
                              "ID", "Name", 1);
            return cardTypes;
        }

        private SelectList GetExpiryMonths()
        {
            var expiryMonth = new SelectList(new[]
                                          {
                                              new {ID="1",Name="1"},
                                              new{ID="2",Name="2"},
                                              new{ID="3",Name="3"},
                                              new{ID="4",Name="4"},
                                              new {ID="5",Name="5"},
                                              new{ID="6",Name="6"},
                                              new{ID="7",Name="7"},
                                              new{ID="8",Name="8"},
                                              new {ID="9",Name="9"},
                                              new{ID="10",Name="10"},
                                              new{ID="11",Name="11"},
                                              new{ID="12",Name="12"},
                                          },
                            "ID", "Name", 1);
            return expiryMonth;

        }

        private SelectList GetExpiryYears()
        {
            var expiryYears = new SelectList(new[]
                                          {
                                              new{ID="2013",Name="2013"},
                                              new{ID="2014",Name="2014"},
                                              new{ID="2015",Name="2015"},
                                              new{ID="2016",Name="2016"},
                                              new{ID="2017",Name="2017"},
                                              new{ID="2018",Name="2018"},
                                              new{ID="2019",Name="2019"},
                                              new{ID="2020",Name="2020"},
                                              new{ID="2021",Name="2021"},
                                              new{ID="2022",Name="2022"},
                                              new{ID="2023",Name="2023"},
                                              new{ID="2024",Name="2024"},
                                              new{ID="2025",Name="2025"},
                                              new{ID="2026",Name="2026"},
                                              new{ID="2027",Name="2027"},      
                                              new{ID="2028",Name="2028"},
                                              new{ID="2029",Name="2029"},
                                              new{ID="2030",Name="2030"},   
                                          },
                           "ID", "Name", 1);
            return expiryYears;
        }

        #endregion

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
		{
			// See http://go.microsoft.com/fwlink/?LinkID=177550 for
			// a full list of status codes.
			switch (createStatus)
			{
				case MembershipCreateStatus.DuplicateUserName:
					return "User name already exists. Please enter a different user name.";

				case MembershipCreateStatus.DuplicateEmail:
					return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

				case MembershipCreateStatus.InvalidPassword:
					return "The password provided is invalid. Please enter a valid password value.";

				case MembershipCreateStatus.InvalidEmail:
					return "The e-mail address provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidAnswer:
					return "The password retrieval answer provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidQuestion:
					return "The password retrieval question provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidUserName:
					return "The user name provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.ProviderError:
					return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

				case MembershipCreateStatus.UserRejected:
					return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

				default:
					return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
			}
		}
		#endregion
	}
}