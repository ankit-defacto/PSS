
namespace PSS.WebWithAuth.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Web;
    using System.Web.Mvc;
    using ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;
    using ConcordMfg.PremierSeniorSolutions.WebService.BusinessLogic;
    using PSS.WebWithAuth.Caching;
    using PSS.WebWithAuth.Infrastructure;
    using PSS.WebWithAuth.ViewModels;

    /// <summary>
    /// Base controller
    /// </summary>
    public class PSSBaseController : Controller
    {
        // constant table data - cached
        protected IList<ListingType> ListingTypes
        {
            get
            {
                string cacheName = "listingtypes";
                var listingtypes = CacheManager.Retrieve<IList<ListingType>>(cacheName);
                if (listingtypes != null)
                {
                    return listingtypes;
                }
                
                listingtypes = new ListingTypeLogic().GetAllListingType();
                //Get Listing Type Name with price
                listingtypes = (from i in listingtypes
                               select new ListingType { ListingTypeGuid = i.ListingTypeGuid,ListingTypeName=i.ListingTypeName+" $"+Convert.ToString(i.ListingTypePrice),ListingTypePrice=i.ListingTypePrice  })
                               .ToList();
                CacheManager.Put<IList<ListingType>>(cacheName, listingtypes);
                return listingtypes;
            }
        }

        // constant table data - cached
        protected IList<Offering> OfferingsAll
        {
            get
            {
                string cacheName = "offerings";
                IList<Offering> offerings = CacheManager.Retrieve<IList<Offering>>(cacheName);
                if (offerings != null)
                {
                    return offerings;
                }

                var ologic = new OfferingLogic();
                offerings = ologic.GetAllOffering();
                CacheManager.Put<IList<Offering>>(cacheName, offerings);
                return offerings;
            }
        }

        // constant table data - cached
        protected IList<TypeOfCareViewModel> TypesOfCareDefinitions
        {
            get
            {
                string cacheName = "typesofcaredef";
                IList<TypeOfCareViewModel> typesofcare = CacheManager.Retrieve<IList<TypeOfCareViewModel>>(cacheName);
                if (typesofcare != null)
                {
                    return typesofcare;
                }
                
                var offerings = this.OfferingsAll;
                typesofcare = new List<TypeOfCareViewModel>();
                offerings.ToList().ForEach(o =>
                {
                    typesofcare.Add(o.ToTypeOfCare(false));
                });
                CacheManager.Put<IList<TypeOfCareViewModel>>(cacheName, typesofcare);
                return typesofcare;
            }
        }

        // city state zip table data - cached (rare changes in this table)
        protected IList<CityStateZip> CityStateZipAll
        {
            get
            {
                string cacheName = "citystatezip";
                IList<CityStateZip> citystatezip = CacheManager.Retrieve<IList<CityStateZip>>(cacheName);
                if (citystatezip != null)
                {
                    return citystatezip;
                }
                
                citystatezip = new CityStateZipLogic().GetAllCityStateZip();
                CacheManager.Put<IList<CityStateZip>>(cacheName, citystatezip);
                return citystatezip;
            }
        }

        protected ActionResult ShowCreate()
        {
            if (Request.IsAuthenticated)
            {
                AccountLogic accountLogic = new AccountLogic();
                AccountViewModel accountVM = accountLogic.GetByEmail(User.Identity.Name);
                // If an account does not exist, help user create one.
                if (null == accountVM)
                {
                    return RedirectToAction("Create", "Account");
                }
                else
                {
                    // redirect user to requested url before authentication
                    var redirectUrl = SessionHandler.Current.ReturnUrl;
                    if (!string.IsNullOrEmpty(redirectUrl) && Url.IsLocalUrl(redirectUrl))
                    {
                        return Redirect(redirectUrl);
                    }
                    
                    return RedirectToAction("View", "Account");
                }
            }

            return RedirectToAction("Search", "Search");
        }

        protected void AddListingTypesToListing(ListingViewModelEdit listingModel)
        {
            var list = this.ListingTypes;
            SelectList sl = new SelectList(list, "ListingTypeGuid", "ListingTypeName");
            listingModel.ListingTypeSelectList = sl;
            if (listingModel.ListingTypeGuid == Guid.Empty)
            {
                listingModel.ListingTypeGuid = list.First().ListingTypeGuid;
            }
        }

        protected void AddTypesOfCareToListing(ListingViewModelEdit listing)
        {
            var ologic = new OfferingLogic();
            var offerings = this.OfferingsAll;
            var offeringsForThisFacility = ologic.GetOfferingsForFacility(listing.FacilityGuid);
            var typesofcare = new List<TypeOfCareViewModel>();
            offerings.ToList().ForEach(o =>
            {
                var checkd = offeringsForThisFacility.FirstOrDefault(otf => otf.OfferingGuid == o.OfferingGuid) != null;
                typesofcare.Add(o.ToTypeOfCare(checkd));
            });
            listing.TypeOfCareList = typesofcare;
        }

        // contains styling
        protected void AddFacilityPhotoToListing(ListingViewModelEdit listing, bool generateEmpty)
        {
            FacilityPhotoLogic photologic = new FacilityPhotoLogic();
            var photos = photologic.GetFacilityPhotosForFacilityByFacilityGuid(listing.FacilityGuid).ToViewModelList();

            photos.ToList().ForEach(f =>
            {
                f.Uid = string.Format("{0}", f.FacilityPhotoGuid);
                f.CssStyle = "fieldRow";
            });
            if (generateEmpty)
            {
                //// add additional text boxes
                int limit = 20 - photos.Count;
                for (int i = 0; i < limit; i++)
                {
                    photos.Add(new FacilityPhotoViewModel { FacilityGuid = listing.FacilityGuid, Uid = string.Format("{0:00}", i), CssStyle = "hidden" });
                }
            }

            listing.FacilityPhotos = photos;
        }

        protected ActionResult WebsiteRedirect(string url)
        {
            return Redirect(url);
        }
    }
}