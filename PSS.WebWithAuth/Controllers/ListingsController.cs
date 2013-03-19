using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;
using ConcordMfg.PremierSeniorSolutions.WebService.BusinessLogic;
using PSS.WebWithAuth.Infrastructure;
using PSS.WebWithAuth.ViewModels;

namespace PSS.WebWithAuth.Controllers
{
    [Authorize]
    [ValidateAntiForgeryTokenWrapper(HttpVerbs.Post, Configurations.AntiForgeryTokenSalt)]
	public class ListingsController : PSSBaseController
    {
        [Authorize(Roles = "user")]
		[HttpGet()]
        [HandleError]
        [RequireHttps]
        public ActionResult Create() //AccountViewModel account
		{
            // Copy over the possibly applicable data to the listing so the user doesn't have to type it twice if it's the same as the account info.
            ListingViewModelEdit listing = new ListingViewModelEdit();
            //plamen: instead of copy get available account data and use
            AccountLogic accountLogic = new AccountLogic();
            var accountVM = accountLogic.GetByEmail(User.Identity.Name);

            ClientCardInfoLogic ClientCardInfoLogic = new ClientCardInfoLogic();

            if (accountVM != null)
            {
                var clientCardInfo = ClientCardInfoLogic.GetByClientGuid(accountVM.ClientGuid);
                if (null == clientCardInfo)
                    return RedirectToAction("ClientCardInfo","Account");
                listing = accountVM.FeedListing();
                this.AddListingTypesToListing(listing);
                this.AddTypesOfCareToListing(listing);
                this.AddFacilityPhotoToListing(listing, true);
            }

            listing.SaveButtonText = listing.ActionName = "Create";
			// If logged in, show the form.
			return View(listing);
		}

        [Authorize(Roles = "user")]
		[HttpPost()]
        [HandleError]
        [RequireHttps]
		public ActionResult Create(ListingViewModelEdit listing)
		{
            if (ModelState.IsValid)
            {
                var savedlisting = this.SaveListing(listing, true);
                //return RedirectToAction("See", "Listings", new { facilityGuid = savedlisting.FacilityGuid });
                return SeeResult(savedlisting.FacilityGuid);
            }
            else
            {
                ModelState.AddModelError("FormSubmit", "Create listing - errors detected");
                this.AddListingTypesToListing(listing);
                this.AddTypesOfCareToListing(listing);
                this.AddFacilityPhotoToListing(listing, true);
                return View(listing);
            }
		}

        [Authorize(Roles = "user")]
        [HttpGet]
        [HandleError]
		public ActionResult See(Guid facilityGuid)
		{
            ListingLogic listingLogic = new ListingLogic();
			ListingViewModel listing = listingLogic.GetListingByFacilityGuid(facilityGuid);

            if (null != listing)
            {
                ListingViewModelEdit listingnew = listing.ToEdit();
                this.AddListingTypesToListing(listingnew);
                this.AddTypesOfCareToListing(listingnew);
                this.AddFacilityPhotoToListing(listingnew, false);

                return View(listingnew);
            }

            return RedirectToAction("Create", "Listings");
		}

        [Authorize(Roles = "user")]
        [HttpGet]
        [HandleError]
        public ActionResult Delete(Guid facilityGuid)
        {
            ListingLogic listingLogic = new ListingLogic();
            var listingToDelete = listingLogic.GetListingByFacilityGuid(facilityGuid);
            if (listingToDelete != null)
            {
                return View(listingToDelete);
            }

            return View();
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        [HandleError]
		public ActionResult Delete(Guid facilityGuid, FormCollection collection)
		{
			var user = Membership.GetUser();
			string email = user.UserName;
			ListingLogic listingLogic = new ListingLogic();
			bool success = listingLogic.Delete(facilityGuid, email);

            return RedirectToAction("List");
		}

		#region Brandons work

		[HttpGet]
        [HandleError]
		public ActionResult Edit(Guid facilityGuid)
		{
			// Get account object from db
			ListingLogic listingLogic = new ListingLogic();
			ListingViewModel listing = listingLogic.GetListingByFacilityGuid(facilityGuid);
            ListingViewModelEdit listingnew = listing.ToEdit();
            listingnew.SaveButtonText = "Save";
            listingnew.ActionName = "Edit";
            this.AddListingTypesToListing(listingnew);
            this.AddTypesOfCareToListing(listingnew);
            this.AddFacilityPhotoToListing(listingnew, true);            

			return View(listingnew);
		}
                    
		[HttpPost()]
        [HandleError]
		public ActionResult Edit(ListingViewModelEdit listing)
		{          
            this.AddListingTypesToListing(listing);
            if (ModelState.IsValid)
            {
                var savedlisting = this.SaveListing(listing, false);
                return SeeResult(savedlisting.FacilityGuid);
            }
            else
            {
                ModelState.AddModelError("FormSubmit", "Save listing - errors detected");
                this.AddListingTypesToListing(listing);
                this.AddTypesOfCareToListing(listing);
                this.AddFacilityPhotoToListing(listing, true);
                return View(listing);
            }
		}
        
        [HttpGet]
        [HandleError]
		public ActionResult List()
		{
			var user = Membership.GetUser();
            if (user == null)
            {
                return RedirectToAction("Create", "Account");
            }

			string email = user.UserName;
			AccountLogic accountLogic = new AccountLogic();
			AccountViewModel accountVM = accountLogic.GetByEmail(email);

            if (accountVM != null)
            {
                ListingLogic listingLogic = new ListingLogic();
                IEnumerable<ListingViewModel> listings = listingLogic.GetListingByClientGuid(accountVM.ClientGuid);
                return View(listings);
            }
            else
            {
                return RedirectToAction("Create", "Account");
            }
		}

		#endregion

        public ActionResult Upload()
        {
            return View();
        }

        #region Private methods

        private ListingViewModelEdit SaveListing(ListingViewModelEdit listing, bool insert)
        {
            // try to find first city record and if not found insert new
            CityStateZipLogic cszLogic = new CityStateZipLogic();
            CityStateZip csz = cszLogic.GetCityStateZipByCityStateZipGuid(listing.CityStateZipGuid);
            csz = new CityStateZip(listing.CityStateZipGuid, listing.City, listing.State, listing.ZipCode);
            csz = cszLogic.InsertCityStateZip(csz);
            listing.CityStateZipGuid = csz.CityStateZipGuid;
            //price
            ListingTypeLogic listingTypeLogic = new ListingTypeLogic();
            ListingType listingType = listingTypeLogic.GetListingTypeByListingTypeGuid(listing.ListingTypeGuid);

            Facility facility = listing.ToFacility();
            FacilityLogic facilityLogic = new FacilityLogic();
            
            if (insert)
            {
                //Add Facility Price from listing list
                facility.Price = listingType.ListingTypePrice;

                facility = facilityLogic.InsertFacility(facility);
                listing.FacilityGuid = facility.FacilityGuid;
                listing.FacilityID = facility.FacilityID;
                //// add facilityguid to photos
                listing.FacilityPhotos.ToList().ForEach(ff => ff.FacilityGuid = listing.FacilityGuid);
            }
            else
            {
                facility.FacilityGuid = listing.FacilityGuid;
                // if listing type change then price from listing list
                Facility oldfacility = facilityLogic.GetFacilityByFacilityGuid(listing.FacilityGuid);
                if (oldfacility.ListingTypeGuid != facility.ListingTypeGuid)
                    facility.Price = listingType.ListingTypePrice;
                else
                    facility.Price = oldfacility.Price;
                facilityLogic.UpdateFacility(facility);
            }

            this.SaveTypesOfCare(listing);
            this.SaveListingPhotos(listing.FacilityPhotos.ToList());

            return listing;
        }

        private void SaveTypesOfCare(ListingViewModelEdit listing)
        {
            FacilityOfferingLogic fologic = new FacilityOfferingLogic();
            // offerings (types of care) processing
            listing.TypeOfCareList.ToList().ForEach(tc =>
            {
                var exists = fologic.GetFacilityOfferingByFacilityGuidOfferingGuid(listing.FacilityGuid, tc.TypeOfCareGuid);
                // checked but not present in database
                if (tc.Checked && exists == null)
                {
                    fologic.InsertFacilityOffering(tc.ToFacilityOffering(listing.FacilityGuid));
                }

                // not checked but present in database
                if (!tc.Checked && exists != null)
                {
                    fologic.DeleteFacilityOffering(tc.ToFacilityOffering(listing.FacilityGuid));
                }
            });
        }

        private void SaveListingPhotos(IList<FacilityPhotoViewModel> photos)
        {
            FacilityPhotoLogic photologic = new FacilityPhotoLogic();
            foreach (var photo in photos)
            {
                // move to mapping
                var facilityphoto = new FacilityPhoto { FacilityGuid = photo.FacilityGuid, FacilityPhotoGuid = photo.FacilityPhotoGuid, PhotoUri = photo.PhotoUri ?? "" };
                // replace this with better check
                if (facilityphoto.PhotoUri.Length > 5 && facilityphoto.FacilityPhotoGuid == Guid.Empty)
                {// add case
                    photologic.InsertFacilityPhoto(facilityphoto);
                }

                if (string.IsNullOrEmpty(facilityphoto.PhotoUri) && facilityphoto.FacilityPhotoGuid != Guid.Empty)
                {// delete case
                    photologic.DeleteFacilityPhoto(facilityphoto);
                }

                if (facilityphoto.PhotoUri.Length > 5 && facilityphoto.FacilityPhotoGuid != Guid.Empty)
                {// update case
                    photologic.UpdateFacilityPhoto(facilityphoto);
                }
            }
        }

        private RedirectToRouteResult SeeResult(Guid facilityGuid)
        {
            return RedirectToAction("See", "Listings", new { facilityGuid = facilityGuid });
        }
        #endregion

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
	}
}