using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Cryptography;
using ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;
using ConcordMfg.PremierSeniorSolutions.WebService.BusinessLogic;
using PSS.WebWithAuth.Infrastructure;
using PSS.WebWithAuth.ViewModels;
using System.Linq.Expressions;
using System.Net.Mail;
using System.IO;
using System.Configuration;
using System.Text;
using System.Globalization;
using System.Web.Configuration;
using System.Net.Configuration;
namespace PSS.WebWithAuth.Controllers
{
    [RequireHttps]
    public class AdminController : PSSBaseController
    {
        [RequireHttps]
        public ActionResult LogIn()
        {
            //Membership.CreateUser("admin@test.com", "123456", "admin@test.com");
            //Roles.AddUserToRole("admin@test.com", "admin");

            //MembershipCreateStatus msg = new MembershipCreateStatus();
            //Membership.CreateUser("admin3@test.com", "123456", "admin3@test.com","Who is your favourite Player ?","Ronaldo",true,out msg);
            //Roles.AddUserToRole("admin3@test.com", "admin");
            var user = Membership.GetUser();
            if (user != null && Roles.GetRolesForUser(user.UserName).Contains("admin"))
                return RedirectToAction("AccountList");
            if (user != null && Roles.GetRolesForUser(user.UserName).Contains("user"))
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [RequireHttps]
        public ActionResult LogIn(LogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    var user = Membership.GetUser(model.UserName);
                    if (Roles.IsUserInRole(model.UserName, "admin"))
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, true);
                        return RedirectToAction("AccountList");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Access denied. Contact system administrator for help.");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                    return View(model);
                }

            }
            return View(model);
        }
        [RequireHttps]
        public ActionResult ForgotPwd()
        {
            return View();
        }

        [HttpPost]
        [RequireHttps]
        public ActionResult ForgotPwd(LogInViewModel model)
        {
                var user=Membership.GetUser(model.UserName);
                if(user!=null)
                {
                    if (Roles.GetRolesForUser(user.UserName).Contains("admin"))
                    {
                            //var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                            //var random = new Random();
                            //var newPassword = new string(
                            //    Enumerable.Repeat(chars, 16)
                            //              .Select(s => s[random.Next(s.Length)])
                            //              .ToArray());
                            //if (SendMail(user.UserName, newPassword))
                            //{
                        //    user.ChangePassword(user.ResetPassword(), newPassword);
                        if (user.PasswordQuestion == null || user.PasswordQuestion == "")
                            ModelState.AddModelError("", "Cannot proceed further. No secuirty question exist.");
                        else
                        {
                            ViewBag.Error = "";
                            ViewBag.UserName = Convert.ToString(user.UserName);
                            ViewBag.SecurityQuestion = Convert.ToString(user.PasswordQuestion);
                            return View("VerifyAccount");
                        }
                            //}
                            //else
                            //    ModelState.AddModelError("", "Network Error. Please try again later after sometime.");
                    }
                    else
                        ModelState.AddModelError("", "Access denied. Contact system administrator for help.");
                } 
                else
                {
                    ModelState.AddModelError("", "Email does not exists");
                }
                return View(model);
        }

        [HttpPost]
        [RequireHttps]
        public ViewResult VerifyAccount()
        {
            ViewBag.Error = "";
            var user = Membership.GetUser(Request.Form["UserName"],false);
            string answer = Request.Form["Answer"];
            try
            {
                Membership.Provider.ResetPassword(user.UserName, answer);
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var random = new Random();
                var newPassword = new string(
                    Enumerable.Repeat(chars, 16)
                              .Select(s => s[random.Next(s.Length)])
                              .ToArray());
                if (SendMail(user.UserName, newPassword))
                {  
                    user.ChangePassword(user.ResetPassword(answer), newPassword);
                    ViewBag.Error = "New Password sent to your mail successfully";
                }
                else
                {
                    ViewBag.Error = "Network Error";
                }
            }
            catch {
                ViewBag.Error = "Security answer don't matches. Please try again.";
            }
            ViewBag.UserName = Request.Form["UserName"];
            ViewBag.SecurityQuestion = Request.Form["PasswordQuestion"];
            return View("VerifyAccount");
        }

        [Authorize(Roles = "admin")]        
        [HandleError]
        [RequireHttps]
        public ActionResult EditPassword()
        {
            return View();
        }

        [Authorize(Roles = "admin")]        
        [HandleError]
        [HttpPost]
        [RequireHttps]
        public ActionResult EditPassword(UserPasswordChangeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = Membership.GetUser();
                try
                {
                    if (user.ChangePassword(model.Password, model.NewPassword))
                        ModelState.AddModelError("", "Password successfully changed .");
                    else
                        ModelState.AddModelError("", "Incorrect Password .");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            else
            {
                ModelState.AddModelError("", "Please correct errors and try again.");
            }
            return View(model);
        }
        
        [Authorize(Roles = "admin")]        
        [HandleError]
        [RequireHttps]
        public ActionResult Listingtypes()
        {
           return View();
        }

        #region "Client Grid Functions"

        [Authorize(Roles = "admin")]
        [RequireHttps]
        [HandleError]
        public ActionResult AccountList()
        {
            return View();
        }

        [HttpPost()]
        [Authorize(Roles = "admin")]
        [RequireHttps]
        [HandleError]
        public string DeleteAccount(string[] id,string type)
        {
            try
            {
                for (int i = 0; i < id.Length; i++)
                {
                    Guid clientGuid = new Guid(id[i]);
                    ClientLogic clientLogic = new ClientLogic();
                    Client client = clientLogic.GetClientByClientGuid(clientGuid);
                    // Client Delete Code .....
                    MembershipUser user = Membership.GetUser(client.Email);
                    if (user != null)
                    {
                        user.IsApproved = false;
                        Membership.UpdateUser(user);
                    }
                    // Client Account Deleted
                    client.IsActive = false;
                    clientLogic.UpdateClient(client);
                    //Delete Listing linked to the client account
                    ListingLogic listingLogic = new ListingLogic();
                    var facilities = listingLogic.GetListingByClientGuid(clientGuid);
                    if (facilities != null)
                    {
                        foreach (var facility in facilities)
                        {
                            listingLogic.Delete(facility.FacilityGuid, client.Email);
                        }
                    }
                }

                return "Account Deleted Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Authorize(Roles = "admin")]
        [RequireHttps]
        [HandleError]
        public ActionResult Create()
        {
            return View("Create");
        }

        [Authorize(Roles = "admin")]
        [RequireHttps]
        [HandleError]
        [HttpPost()]
        public JsonResult AddUserClient(UserClientViewModel model)
        {
            try
            {
                var user = Membership.GetUser(model.Email);
                if (user != null)
                    return Json(new { msg = "User already exists" });

                Membership.CreateUser(model.Email, model.Passowrd, model.Email);
                Roles.AddUserToRole(model.Email, "user");
                // todo: implement some create account wizard when have more information
                if (!ModelState.IsValid)
                    return Json(new { msg = "There are some errors. Please check and try again" });
                ClientLogic clientLogic = new ClientLogic();
                Client possibleClient = clientLogic.GetClientByEmail(model.Email);
                if (null != possibleClient)
                    return Json(new { msg = "Client already exists" });

                AccountViewModel account = new AccountViewModel();
                account.Email = model.Email;
                account.ClientName = model.ClientName;
                account.Address = model.Address;
                account.State = model.State;
                account.City = model.City;
                account.ZipCode = model.ZipCode;
                account.PhoneNumber = model.PhoneNumber;

                this.SaveAccount(clientLogic, account, model.Email, true);
                return Json(new { msg = "ok" });
            }
            catch (Exception ex)
            {
                return Json(new { msg = ex.Message });
            }
        }

        [HttpPost()]
        [Authorize(Roles = "admin")]
        [RequireHttps]
        [HandleError]
        public string PauseAccount(string[] id,string type)
        {
            try
            {
                AccountViewModel account = new AccountViewModel();
                for (int i = 0; i < id.Length; i++)
                {
                    Guid accountGuid = new Guid(id[i]);

                    // Get account object from db
                    AccountLogic logic = new AccountLogic();
                    account = logic.GetByPK(accountGuid);
                    if (type == "ac" && account.PauseAccount == false) continue;
                    if (type == "de" && account.PauseAccount == true) continue;
                    switch (type)
                    {
                        case "ac":
                            account.PauseAccount = false;
                            break;
                        case "de":
                            account.PauseAccount = true;
                            break;
                        default:
                            if (account.PauseAccount)
                                account.PauseAccount = false;
                            else
                                account.PauseAccount = true;
                            break;
                    }
                    ClientLogic clientLogic = new ClientLogic();
                    Client possibleClient = clientLogic.GetClientByEmail(account.Email);
                    this.SaveAccount(clientLogic, account, account.Email, false);
                }

                return "Account " + (account.PauseAccount== false?"Actived ":"Deactivated ") +"Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost()]
        [Authorize(Roles = "admin")]
        [RequireHttps]
        [HandleError]
        public string SuspendAccount(string[] id, string type)
        {
            try
            {
                AccountViewModel account = new AccountViewModel();
                for (int i = 0; i < id.Length; i++)
                {
                    Guid accountGuid = new Guid(id[i]);

                    // Get account object from db
                    AccountLogic logic = new AccountLogic();
                    account = logic.GetByPK(accountGuid);
                    if (type == "su")
                        if (account.IsSuspended == true) continue; else account.IsSuspended = true;
                    else
                        if (account.IsSuspended == false) continue; else account.IsSuspended = false;
                    ClientLogic clientLogic = new ClientLogic();
                    Client possibleClient = clientLogic.GetClientByEmail(account.Email);
                    this.SaveAccount(clientLogic, account, account.Email, false);
                }

                return "Account " + (account.IsSuspended == true ? "Suspended " : "Continued ") + "Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Authorize(Roles = "admin")]
        [RequireHttps]
        [HandleError]
        public ActionResult FaciltyPrice()
        {
            ListingTypeLogic listingTypeLogic = new ListingTypeLogic();
            var listingTypes = listingTypeLogic.GetAllListingType();
            List<SetFacilityPriceViewModel> model = new List<SetFacilityPriceViewModel>();
            foreach (var items in listingTypes)
            {
                SetFacilityPriceViewModel listItem = new SetFacilityPriceViewModel();
                listItem.ListingTypeGuid = items.ListingTypeGuid;
                listItem.ListingTypeName = items.ListingTypeName+" $"+Convert.ToDecimal(items.ListingTypePrice);
                listItem.IsChecked = false;
                model.Add(listItem);
            }
            return View("SetFaciltyPrice", model);
        }

        [Authorize(Roles = "admin")]
        [RequireHttps]
        [HandleError]
        [HttpPost]
        public JsonResult SetFaciltyPrice(string clientGuidList, List<SetFacilityPriceViewModel> model)
        {
            string[] clientGuidToArray = clientGuidList.Split(',');
            try
            {
                for (int i = 0; i < clientGuidToArray.Length; i++)
                {
                    Guid clientGuid = new Guid(clientGuidToArray[i]);
                    for (int j = 0; j < model.Count; j++)
                    {
                        if (model[j].IsChecked)
                        {
                            Guid listingTypeGuid = model[j].ListingTypeGuid;
                            FacilityLogic faciltyLogic = new FacilityLogic();
                            List<Facility> facilityList = faciltyLogic.GetFacilityByClientAndListingTypeGuid(clientGuid, listingTypeGuid);
                            foreach (var item in facilityList)
                            {
                                Facility fac = new Facility();
                                fac.Address = item.Address;
                                fac.CityStateZipGuid = item.CityStateZipGuid;
                                fac.ClientGuid = item.ClientGuid;
                                fac.Description = item.Description;
                                fac.Email = item.Email;
                                fac.Exerpt = item.Exerpt;
                                fac.FacilityGuid = item.FacilityGuid;
                                fac.FacilityID = item.FacilityID;
                                fac.FacilityName = item.FacilityName;
                                fac.ListingTypeGuid = item.ListingTypeGuid;
                                fac.Latitude = item.Latitude;
                                fac.PhoneNumber = item.PhoneNumber;
                                fac.PublicPhotoFileUri = item.PublicPhotoFileUri;
                                fac.Price = model[j].ListingPrice;
                                fac.Website = item.Website;
                                faciltyLogic.UpdateFacility(fac);
                            }
                        }
                    }
                }
                return Json(new { msg = "ok" });
            }
            catch (Exception ex)
            {
                return Json(new { msg = ex.Message });
            }
        }

        [Authorize(Roles = "admin")]
        [RequireHttps]
        [HandleError]
        public ActionResult ClientAccount(string clientGuid)
        {
            AccountLogic accountLogic = new AccountLogic();
            AccountViewModel accountVM = accountLogic.GetByPK(new Guid(clientGuid));
            AccountWithListingsViewModel accountWithListings = accountVM.WithListings();
            ListingLogic llogic = new ListingLogic();
            var listings = llogic.GetListingsWithDateModifiedByClientGuid(accountWithListings.ClientGuid);
            accountWithListings.AccountListings = listings.ToList();
            ClientCardInfoLogic ClientCardInfoLogic = new ClientCardInfoLogic();
            var ccinfo=ClientCardInfoLogic.GetByClientGuid(accountWithListings.ClientGuid);

            ClientCardInfoViewModel clientCardInfoVM = new ClientCardInfoViewModel();
            if (ccinfo != null)
                clientCardInfoVM = DecryptCCinfo(ccinfo);

            accountWithListings.clientCardInfoVM = clientCardInfoVM;

            return View(accountWithListings);
        }

        [HttpGet()]
        [Authorize(Roles = "admin")]
        [RequireHttps]
        [HandleError]
        public ViewResult EditClient(Guid clientGuid)
        {
            // Get account object from db
            AccountLogic logic = new AccountLogic();
            AccountViewModel account = logic.GetByPK(clientGuid);

            return View(account);

        }

        [Authorize(Roles = "admin")]
        [RequireHttps]
        [HttpPost()]
        [ValidateAntiForgeryToken(Salt = Configurations.AntiForgeryTokenSalt)]
        [HandleError]
        public ActionResult EditClient(AccountViewModel account)
        {
            if (!ModelState.IsValid)
            {
                return View(account);
            }

            // Call business logic to insert the data.
            ClientLogic clientLogic = new ClientLogic();
            Client possibleClient = clientLogic.GetClientByEmail(account.Email);

            if (null != possibleClient)
                this.SaveAccount(clientLogic, account, account.Email, false);
            return RedirectToAction("ClientAccount", "admin", new { clientGuid = account.ClientGuid });
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [RequireHttps]
        [HandleError]
        public ActionResult SeeListing(Guid facilityGuid)
        {
            ListingLogic listingLogic = new ListingLogic();
            ListingViewModel listing = listingLogic.GetListingByFacilityGuid(facilityGuid);

            if (null != listing)
            {
                ListingViewModelEdit listingnew = listing.ToEdit();
                this.AddListingTypesToListing(listingnew);
                this.AddTypesOfCareToListing(listingnew);
                this.AddFacilityPhotoToListing(listingnew, false);

                return View("SeeListing", listingnew);
            }

            return RedirectToAction("Create", "Listings");
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [RequireHttps]
        [HandleError]
        public ActionResult SetListingPrice(ListingViewModelEdit listing)
        {
            FacilityLogic facilityLogic = new FacilityLogic();
            Facility facility = facilityLogic.GetFacilityByFacilityGuid(listing.FacilityGuid);
            facility.Price = listing.Price;
            facilityLogic.UpdateFacility(facility);
            return RedirectToAction("SeeListing", new { facilityGuid = listing.FacilityGuid });
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [RequireHttps]
        [HandleError]
        public ActionResult ClientAccount(AccountWithListingsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please correct errors and try again.");
                return View(model);
            }
            // Get account object from db
            AccountLogic logic = new AccountLogic();
            AccountViewModel account = logic.GetByPK(model.ClientGuid);

            // Call business logic to insert the data.
            ClientLogic clientLogic = new ClientLogic();
            Client possibleClient = clientLogic.GetClientByClientGuid(account.ClientGuid);

            if (null != possibleClient)
            {
                account.IsWaiverd = model.IsWaiverd;
                account.FreeDays = model.FreeDays;
                account.AccountBalance = model.AccountBalance;

                this.SaveAccount(clientLogic, account, account.Email, false);
            }
            return RedirectToAction("ClientAccount", new { clientGuid = Convert.ToString(model.ClientGuid) });
        }

        [Authorize(Roles = "admin")]
        [RequireHttps]
        [HandleError]
        public ActionResult ClientCardInfo(Guid ClientGuid)
        {
            ViewBag.cardType = GetCardTypes();
            ViewBag.expiryMonth = GetExpiryMonths();
            ViewBag.expiryYear = GetExpiryYears();
            ClientCardInfoViewModel model = new ClientCardInfoViewModel();
            model.ClientGuid = ClientGuid;
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [RequireHttps]
        [HandleError]
        public ActionResult ClientCardInfo(ClientCardInfoViewModel clientCardInfoVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please correct the errors and try again.");
                return View(clientCardInfoVM);
            }
            this.SaveClientCardInfo(clientCardInfoVM, true);
            return RedirectToAction("ClientAccount", new { clientGuid = clientCardInfoVM.ClientGuid });
        }

        [Authorize(Roles = "admin")]
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

        [HttpPost]
        [Authorize(Roles = "admin")]
        [RequireHttps]
        [HandleError]
        public ActionResult EditClientCardInfo(ClientCardInfoViewModel clientCardInfoVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please correct the errors and try again.");
                return View(clientCardInfoVM);
            }
            this.SaveClientCardInfo(clientCardInfoVM, false);
            return RedirectToAction("ClientAccount", new { clientGuid = clientCardInfoVM.ClientGuid });
        }
 
        #endregion

        #region "Grid for Client/Accounts"

        public JsonResult ClientGrid(string sidx, string sord, int page, int rows,
                bool _search, string searchField, string searchOper, string searchString)
        {
            // Get the list of Client Accounts
            AccountLogic accountLogic = new AccountLogic();
            var accounts = accountLogic.GetAll();

            // If search, filter the list against the search condition.
            var filteredAccounts = accounts;
            if (_search)
                filteredAccounts = SerachIQueryable(accounts, searchField, searchOper, searchString);

            // Sort the Account list
            var sortedAccounts = SortIQueryable<AccountViewModel>(filteredAccounts, sidx, sord);

            // Calculate the total number of pages
            var totalRecords = filteredAccounts.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / (double)rows);

            // Prepare the data to fit the requirement of jQGrid
            var data = (from items in sortedAccounts
                        select new
                        {
                            i = items.ClientID.ToString(),
                            cell = new string[] {
                                items.ClientGuid.ToString(),
                                items.IsFlagged==true?"showFlag":"hideFlag",
                                items.ClientName.ToString(), 
                                items.Address +" "+ items.City +" "+ items.State +" "+ items.ZipCode,
                                items.Email,
                                items.IsWaiverd==true?"Yes":"No",
                                items.FreeDays.ToString(),
                                items.AccountBalance.ToString(),
                                items.IsSuspended==true?"Yes":"No",
                                items.PauseAccount==true?"Deactive":"Active"
                            }
                        }).ToArray();

            // Send the data to the jQGrid
            var jsonData = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = data.Skip((page - 1) * rows).Take(rows)
            };

            return Json(jsonData);
        }

        //Serach records on the base of serach filter and field name
        private IQueryable<T> SerachIQueryable<T>(IQueryable<T> data, string fieldName, string searchOper,string searchValue)
        {
            if (searchOper != "")
            {
                switch (searchOper)
                {
                    case "eq":
                        data = data.Where(s => typeof(AccountViewModel).GetProperty(fieldName)
                            .GetValue(s, null).ToString().Equals(searchValue));
                        break;
                    case "ne":
                        data = data.Where(s => !typeof(AccountViewModel).GetProperty(fieldName)
                            .GetValue(s, null).ToString().Contains(searchValue));
                        break;
                    case "bw":
                        data = data.Where(s => typeof(AccountViewModel).GetProperty(fieldName)
                            .GetValue(s, null).ToString().StartsWith(searchValue));
                        break;
                    case "bn":
                        data = data.Where(s => !typeof(AccountViewModel).GetProperty(fieldName)
                            .GetValue(s, null).ToString().StartsWith(searchValue));
                        break;
                    case "ew":
                        data = data.Where(s => typeof(AccountViewModel).GetProperty(fieldName)
                            .GetValue(s, null).ToString().EndsWith(searchValue));
                        break;
                    case "en":
                        data = data.Where(s => !typeof(AccountViewModel).GetProperty(fieldName)
                            .GetValue(s, null).ToString().EndsWith(searchValue));
                        break;
                    case "cn":
                        data = data.Where(s => typeof(AccountViewModel).GetProperty(fieldName)
                            .GetValue(s, null).ToString().Contains(searchValue));
                        break;
                    default: //"nc"                        
                        data = data.Where(s => !typeof(AccountViewModel).GetProperty(fieldName)
                            .GetValue(s, null).ToString().Contains(searchValue));
                        break;
                }
            }
            //else
            //{
            //    data = data.Where(s => typeof(AccountViewModel).GetProperty(fieldName)
            //                .GetValue(s, null) == null);
            //}
            return data;
        }

        // Utility method to sort IQueryable given a field name as "string"
        // May consider to put in a cental place to be shared
        private IQueryable<T> SortIQueryable<T>(IQueryable<T> data, string fieldName, string sortOrder)
        {
            if (string.IsNullOrWhiteSpace(fieldName)) return data;
            if (string.IsNullOrWhiteSpace(sortOrder)) return data;

            var param = Expression.Parameter(typeof(T), "i");
            Expression conversion = Expression.Convert(Expression.Property(param, fieldName), typeof(object));
            var mySortExpression = Expression.Lambda<Func<T, object>>(conversion, param);

            return (sortOrder == "desc") ? data.OrderByDescending(mySortExpression)
                : data.OrderBy(mySortExpression);


        }

        #endregion

        #region Grid for Listing type

        public JsonResult Listingtype(string sidx, string sord, int page, int rows,bool _search, string searchField, string searchOper, string searchString)
        {
            // Get the list of Listing Types           
            ListingTypeLogic listingTypeLogic = new ListingTypeLogic();
            var listingTypes = listingTypeLogic.GetAllListingType();

            // If search, filter the list against the search condition.
            //var filteredAccounts = accounts;
            //if (_search)
            //    filteredAccounts = SerachIQueryable(accounts, searchField, searchOper, searchString);

            // Sort the Account list
            //var sortedAccounts = SortIQueryable<AccountViewModel>(filteredAccounts, sidx, sord);

            //// Calculate the total number of pages
            //var totalRecords = filteredAccounts.Count();
            //var totalPages = (int)Math.Ceiling((double)totalRecords / (double)rows);

            // Prepare the data to fit the requirement of jQGrid
            int i=0;
            var data = (from items in listingTypes
                        select new
                        {
                            i =Convert.ToString(i++),
                            cell = new string[] {
                            items.ListingTypeGuid.ToString(),
                            items.ListingTypeName,
                            items.ListingTypePrice.ToString()
                            }
                        }).ToArray();

            // Send the data to the jQGrid
            var jsonData = new
            {
                total = 1,
                page = page,
                records = listingTypes.Count,
                rows = data.Skip((page - 1) * rows).Take(5)
            };

            return Json(jsonData);
        }

        [Authorize(Roles = "admin")]
        
        [HandleError]
        public ActionResult SeeListingType(string id,string master)
        {
            ListingTypeLogic listingTypeLogic = new ListingTypeLogic();
            ListingType listingType = listingTypeLogic.GetListingTypeByListingTypeGuid(new Guid(id));
            ListingTypeViewModel objListingtypeviewModel = new ListingTypeViewModel();
            objListingtypeviewModel.ListingTypeGuid = listingType.ListingTypeGuid;
            objListingtypeviewModel.ListingTypeName = listingType.ListingTypeName;
            objListingtypeviewModel.ListingTypePrice = listingType.ListingTypePrice;
            //return PartialView("SeeListingType", listingType);
         //   return View("SeeListingType",master,listingType);
            return View("SeeListingType", master, objListingtypeviewModel);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        
        [HandleError]
        public JsonResult SaveListingType(ListingTypeViewModel objListingTypeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ListingTypeLogic listingTypeLogic = new ListingTypeLogic();
                    ListingType objListingType = new ListingType();
                    objListingType.ListingTypeGuid = objListingTypeViewModel.ListingTypeGuid;
                    objListingType.ListingTypeName = objListingTypeViewModel.ListingTypeName;
                    objListingType.ListingTypePrice = objListingTypeViewModel.ListingTypePrice;
                    listingTypeLogic.UpdateListingType(objListingType);
                    // return View("Listingtypes");
                    return Json(new { msg = "ok" });
                }
                else
                {
                    return Json(new { msg = "There are some errors. Please check and try again" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { msg = ex.Message });
            }
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

        private void SaveAccount(ClientLogic clientLogic, AccountViewModel account,string username, bool insert)
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
            //client.ClientID = account.ClientID;
            client.ClientName = account.ClientName;
            client.PhoneNumber = account.PhoneNumber;
            // Filed Changed
            client.Email = username;
            client.Address = account.Address;
            client.CityStateZipGuid = account.CityStateZipGuid;

            client.PaymentInfoGuid = account.PaymentInfoGuid;
            // pause account - in create view is always false
            client.AccountPaused = account.PauseAccount;
            if (insert)
            {
                client = clientLogic.InsertClient(client);
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

        private void SaveClientCardInfo(ClientCardInfoViewModel clientCardInfoVM, bool insert)
        {
            ClientCardInfoLogic logic = new ClientCardInfoLogic();
            ClientCardInfo clientCardInfo = new ClientCardInfo();

            clientCardInfo.CardType = clientCardInfoVM.CardType;
            clientCardInfo.CardHolderNameOnCard = Cryptographer.Encrypt(clientCardInfoVM.CardHolderNameOnCard, SetKey());
            clientCardInfo.CardNumber = Cryptographer.Encrypt(clientCardInfoVM.CardNumber, SetKey());
            clientCardInfo.ClientCardGuid = clientCardInfoVM.ClientCardGuid;
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
            clientCardInfoVM.CardHolderNameOnCard = Cryptographer.Decrypt(model.CardHolderNameOnCard, SetKey());
            clientCardInfoVM.CardNumber = Cryptographer.Decrypt(model.CardNumber, SetKey());
            clientCardInfoVM.ClientCardGuid = model.ClientCardGuid;
            clientCardInfoVM.ClientGuid = model.ClientGuid;
            clientCardInfoVM.CvvNumber = Cryptographer.Decrypt(model.CvvNumber, SetKey());
            clientCardInfoVM.ExpMonth = model.ExpMonth;
            clientCardInfoVM.ExpYear = model.ExpYear;
            return clientCardInfoVM;
        }

        private string SetKey()
        {  
            return "SamplePrivateKey";           
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


        private bool SendMail(string username,string newPassword)
        {
            Configuration configurationFile = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
            MailSettingsSectionGroup mailSettings = configurationFile.GetSectionGroup("system.net/mailSettings") as MailSettingsSectionGroup;
            string from = mailSettings.Smtp.Network.UserName;
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = mailSettings.Smtp.Network.EnableSsl;
            client.Host = mailSettings.Smtp.Network.Host;
            client.Port = mailSettings.Smtp.Network.Port;
            // setup Smtp authentication
            System.Net.NetworkCredential credentials =
            new System.Net.NetworkCredential(from, mailSettings.Smtp.Network.Password);
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(from);
            msg.To.Add(new MailAddress(username));
            msg.Subject = "PSS LogIn Password";
            msg.IsBodyHtml = true;
            string sBody;
            string htmlEmailFormat = Server.MapPath("~/Content/RecoveryMail.htm");
            var reader = new StreamReader(Server.MapPath("~/Content/RecoveryMail.htm"));
            sBody = reader.ReadToEnd();
            sBody = sBody.Replace("<%username%>", username);
            sBody = sBody.Replace("<%password%>", newPassword);
            msg.Body = sBody;
            try
            {
                client.Send(msg);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
