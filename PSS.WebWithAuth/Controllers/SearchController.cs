using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;
using ConcordMfg.PremierSeniorSolutions.WebService.BusinessLogic;
using GeoCoding;
using GeoCoding.Google;
using PagedList;
using PSS.WebWithAuth.Filters;
using PSS.WebWithAuth.Infrastructure;
using PSS.WebWithAuth.Models;
using PSS.WebWithAuth.ViewModels;
using DevTrends.MvcDonutCaching;

namespace PSS.WebWithAuth.Controllers
{
    public class SearchController : PSSBaseController
    {
        // move this to config or make a user parameter
        private const double RADIUS = 100;
        private const int PAGESIZE = 5;

        // Send old search form JSON to seo search form
        [HttpPost]
        [HandleJsonError]
        public ActionResult GetSeoParameters(SearchFilterViewModel filter)
        {
            if (filter != null)
            {
                filter.SetTypeOfCareNames(this.TypesOfCareDefinitions);

                return Json(
                    new
                    {
                        typesofcare = filter.TypesOfCareSeoParameterFormatted
                    });
            }

            return Json(new { typesofcare = "" });
        }
        
        //
        // GET: /Search/

        [HttpGet]
        [HandleError]
        public virtual ActionResult Search(SeoSearchFilterViewModel seofilter)
        {
            var filter = this.RestoreFilter(seofilter);
            if (SessionHandler.Current.UserGeolocation == null)
            {
                SessionHandler.Current.UserGeolocation =
                    new PSSLocation
                    {
                        GeolocationStatus = Enums.GeolocationStates.WaitingForResolve
                    };
            }
            else
            {
                SessionHandler.Current.UserGeolocation.GeolocationStatus = Enums.GeolocationStates.ResolveNotPossible;
            }
            // set geolocation data on first action loading
            if (filter.Latitude.HasValue && filter.Longitude.HasValue && filter.SearchType == Enums.SearchTypes.Undefined)
            {
                SessionHandler.Current.UserGeolocation.Latitude = filter.Latitude.Value;
                SessionHandler.Current.UserGeolocation.Longitude = filter.Longitude.Value;
                SessionHandler.Current.UserGeolocation.GeolocationStatus = Enums.GeolocationStates.Resolved;
            }

            filter.GeolocationStatus = SessionHandler.Current.UserGeolocation.GeolocationStatus;
                        
            return View(filter);
        }

        [HttpGet]
        [HandleError]
        public ActionResult ShowFacilitiesNearYou(SeoSearchFilterViewModel seofilter)
        {
            var filter = this.RestoreFilter(seofilter);
            if (SessionHandler.Current.UserGeolocation.GeolocationStatus == Enums.GeolocationStates.WaitingForResolve)
            {
                return View();
            }

            var location = SessionHandler.Current.UserGeolocation;
            filter.Latitude = location.Latitude;
            filter.Longitude = location.Longitude;
            filter.GeolocationStatus = location.GeolocationStatus;
            filter.SearchType = Enums.SearchTypes.Distance;
            var resultsViewModel = this.SearchFacilities(filter, 1);
            return PartialView("Search/_SearchResultsPartial", resultsViewModel);
        }

        [HttpGet]
        [HandleError]
        [DonutOutputCache(CacheProfile = "CacheSearch")]
        public ActionResult SearchResults(SeoSearchFilterViewModel seofilter, int? page)
        {
            var filter = this.RestoreFilter(seofilter);
            filter.SearchType = Enums.SearchTypes.Filtered;
            var resultsViewModel = this.SearchFacilities(filter, page);
            return View(resultsViewModel);
        }

        [HttpGet]
        [HandleError]
        [DonutOutputCache(CacheProfile = "CacheSearch")]
        public ActionResult SearchResultsWide(SeoSearchFilterViewModel seofilter, int? page)
        {
            var filter = this.RestoreFilter(seofilter);
            filter.SearchType = Enums.SearchTypes.FilteredDistance;
            var resultsViewModel = this.SearchFacilities(filter, page);
            return View("SearchResults", resultsViewModel);
        }

        [HttpGet]
        [HandleError]
        [DonutOutputCache(CacheProfile = "CacheSearch")]
        public ActionResult ListingDetails(Guid facilityGuid, SeoSearchFilterViewModel seofilter)
        {
            var filter = this.RestoreFilter(seofilter);
            ListingLogic llogic = new ListingLogic();
            ListingViewModelEdit listingnew = llogic.GetListingByFacilityGuid(facilityGuid).ToEdit();
            var csz = this.CityStateZipAll.FirstOrDefault(c => c.CityStateZipGuid == listingnew.CityStateZipGuid);
            this.AddTypesOfCareToListing(listingnew);
            this.AddFacilityPhotoToListing(listingnew, false);
            var details = listingnew.ToListingDetails(csz, filter);
            return View(details);
        }

        [HttpGet]
        public JsonResult GetMarker(string title, string city, string state, string zip, string address)
        {
            return Json(new Marker(title, new CityStateZip { City = city, State = state, ZipCode = zip }, address), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]        
        public ActionResult GeoCodeTest(string address)
        {
            IGeoCoder coder = new GoogleGeoCoder();
            var res = coder.GeoCode(address);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        
        private SearchFilterViewModel RestoreFilter(SeoSearchFilterViewModel seoFilter)
        {
            return seoFilter.ToSearchFilter(this.TypesOfCareDefinitions);
        }
        
        // general search by all criteria
        private SearchResultsViewModel SearchFacilities(SearchFilterViewModel filter, int? page)
        {
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1) 
            int pageminus1 = pageNumber - 1;
            int totalCount = 0;
            IList<SearchResultViewModel> results = new List<SearchResultViewModel>();
            FacilityLogic flogic = new FacilityLogic();
            var allFound = 
                filter.SearchType == Enums.SearchTypes.Distance ? 
                    this.SearchByDistance(filter, flogic, pageminus1, PAGESIZE, out totalCount ) :
                        filter.SearchType == Enums.SearchTypes.Filtered ?
                            this.SearchByFilter(filter, flogic, pageminus1, PAGESIZE, out totalCount) :
                                this.SearchByDistanceFilter(filter, flogic, pageminus1, PAGESIZE, out totalCount);
            allFound.ForEach(f =>
            {
                var csz = this.CityStateZipAll.FirstOrDefault(c => c.CityStateZipGuid == f.CityStateZipGuid);
                results.Add(f.ToSearchResult(csz));
            });

            var resultsPage = new StaticPagedList<SearchResultViewModel>(results, pageNumber, PAGESIZE, totalCount);
            filter.Page = pageNumber;
            return new SearchResultsViewModel { CurrentFilter = filter, CurrentResults = resultsPage };
        }

        private List<Facility> SearchByFilter(SearchFilterViewModel filter, FacilityLogic flogic, int page, int pageSize, out int totalCount)
        {
            var allFound = flogic.GetAllFacilityFilter(
                new CityStateZip
                {
                    City = filter.CityFilter ?? "",
                    State = filter.StateFilter ?? "",
                    ZipCode = filter.ZipFilter ?? ""
                },
                filter.TypeOfCareFilter.ToOfferingListCheckedOnly(),
                false, page, pageSize, out totalCount
            );
            return allFound;
        }

        private List<Facility> SearchByDistance(SearchFilterViewModel filter, FacilityLogic flogic, int page, int pageSize, out int totalCount)
        {
            // distance radius is in miles
            var allFound = flogic.GetAllFacilityByDistance(
                new DistanceParameters
                {
                    Latitude = filter.Latitude.Value,
                    Longitude = filter.Longitude.Value,
                    DistanceRadius = RADIUS
                },
                page, pageSize, out totalCount
            );
            return allFound;
        }

        private List<Facility> SearchByDistanceFilter(SearchFilterViewModel filter, FacilityLogic flogic, int page, int pageSize, out int totalCount)
        {
            // distance radius is in miles
            var allFound = flogic.GetAllFacilityByDistanceFilter(                
                new DistanceParameters
                {
                    Latitude = filter.Latitude.Value,
                    Longitude = filter.Longitude.Value,
                    DistanceRadius = RADIUS
                },
                filter.TypeOfCareFilter.ToOfferingListCheckedOnly(),
                false, page, pageSize, out totalCount
            );
            return allFound;
        }
    }
}