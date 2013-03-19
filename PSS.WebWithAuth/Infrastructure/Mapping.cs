
namespace PSS.WebWithAuth.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;
    using PSS.WebWithAuth.Models;
    using PSS.WebWithAuth.ViewModels;

    /// <summary>
    /// Mapping class
    /// </summary>
    public static class Mapping
    {
        /// <summary>
        /// Adds listings to account view model
        /// </summary>
        /// <param name="accountVM">Account view model</param>
        /// <returns>Account view model with listings</returns>
        public static AccountWithListingsViewModel WithListings(this AccountViewModel accountVM)
        {
            return Mapper.Map<AccountViewModel, AccountWithListingsViewModel>(accountVM);
        }

        /// <summary>
        /// Maps offering business entity to type of care
        /// </summary>
        /// <param name="offering">The offering BE</param>
        /// <param name="checkd">Is checked flag</param>
        /// <returns>Type of care view model</returns>
        public static TypeOfCareViewModel ToTypeOfCare(this Offering offering, bool checkd)
        {
            return new TypeOfCareViewModel
            {
                TypeOfCareGuid = offering.OfferingGuid,
                TypeOfCareName = offering.OfferingName,
                Checked = checkd
            };
        }

        /// <summary>
        /// Maps type of care to offering business entity
        /// </summary>
        /// <param name="typeofcare">Type of care VM</param>
        /// <returns>Offering BE</returns>
        public static Offering ToOffering(this TypeOfCareViewModel typeofcare)
        {
            return new Offering
            {
                OfferingGuid = typeofcare.TypeOfCareGuid,
                OfferingName = typeofcare.TypeOfCareName
            };
        }

        /// <summary>
        /// Maps type of care to facility offering
        /// </summary>
        /// <param name="typeofcare">Type of care VM</param>
        /// <param name="facilityGuid">Facility guid</param>
        /// <returns>Facility offering BE</returns>
        public static FacilityOffering ToFacilityOffering(this TypeOfCareViewModel typeofcare, Guid facilityGuid) 
        {
            return new FacilityOffering(facilityGuid, typeofcare.TypeOfCareGuid);
        }

        /// <summary>
        /// Maps checked types of care to offering collection
        /// </summary>
        /// <param name="typesofcare">Types of care list (checked only)</param>
        /// <returns>Offering collection</returns>
        public static IEnumerable<Offering> ToOfferingListCheckedOnly(this IEnumerable<TypeOfCareViewModel> typesofcare)
        {
            IList<Offering> output = new List<Offering>();
            foreach (var tc in typesofcare)
            {
                if (tc.Checked)
                {
                    output.Add(tc.ToOffering());
                }
            }

            return output;
        }

        /// <summary>
        /// Maps listing VM to listing edit (extended) VM
        /// </summary>
        /// <param name="listingBE">Listing VM</param>
        /// <returns>Listing edit VM</returns>
        public static ListingViewModelEdit ToEdit(this ListingViewModel listingBE)
        {
            return Mapper.Map<ListingViewModel, ListingViewModelEdit>(listingBE);
        }

        /// <summary>
        /// Adds data from account to listing
        /// </summary>
        /// <param name="accountBE">Account VM</param>
        /// <returns></returns>
        public static ListingViewModelEdit FeedListing(this AccountViewModel accountBE)
        {
            return Mapper.Map<AccountViewModel, ListingViewModelEdit>(accountBE);
        }

        /// <summary>
        /// Maps listing VM to facility BE
        /// </summary>
        /// <param name="listingVM">Listing VM</param>
        /// <returns>Facility BE</returns>
        public static Facility ToFacility(this ListingViewModelEdit listingVM)
        {
            return Mapper.Map<ListingViewModelEdit, Facility>(listingVM);
        }

        /// <summary>
        /// Maps Facility and City/state zip to Search result VM
        /// </summary>
        /// <param name="facilityBE">Facility BE</param>
        /// <param name="csz">City state zip BE</param>
        /// <returns>Search result VM</returns>
        public static SearchResultViewModel ToSearchResult(this Facility facilityBE, CityStateZip csz)
        {
            return new SearchResultViewModel
            {
                CityStateZip = csz,
                FacilityShortDescription = facilityBE.Exerpt,
                PhoneNumber = facilityBE.PhoneNumber,
                FacilityGuid = facilityBE.FacilityGuid,
                FacilityName = facilityBE.FacilityName,
                PhotoUri = facilityBE.PublicPhotoFileUri,
                Website = facilityBE.Website,
                Address = facilityBE.Address,
                Geolocation = new PSSLocation { Latitude = facilityBE.Latitude, Longitude = facilityBE.Longitude }
            };
        }

        /// <summary>
        /// Maps facility photos BE collection to facility photo VM collection
        /// </summary>
        /// <param name="facilityphotos">Facility photos collection</param>
        /// <returns>Facility photo VM collection</returns>
        public static IList<FacilityPhotoViewModel> ToViewModelList(this IList<FacilityPhoto> facilityphotos)
        {
            var retlist = new List<FacilityPhotoViewModel>();
            foreach (var fphoto in facilityphotos)
            {
                retlist.Add(Mapper.Map<FacilityPhoto, FacilityPhotoViewModel>(fphoto));
            }

            return retlist;
        }

        /// <summary>
        /// Maps facility photo VM collection to facility photos BE collection
        /// </summary>
        /// <param name="facilityVMphotos">Facility photo VM collection</param>
        /// <returns>Facility photos collection</returns>
        public static IList<FacilityPhoto> ToFacilityList(this IList<FacilityPhotoViewModel> facilityVMphotos)
        {
            var retlist = new List<FacilityPhoto>();
            foreach (var fphoto in facilityVMphotos)
            {
                retlist.Add(Mapper.Map<FacilityPhotoViewModel, FacilityPhoto>(fphoto));
            }

            return retlist;
        }

        /// <summary>
        /// Maps facility photo VM to slider VM
        /// </summary>
        /// <param name="facilityPhotoVM">Facility photo VM</param>
        /// <returns>Photo slider VM</returns>
        public static PhotoSliderViewModel ToPhotoSlider(this FacilityPhotoViewModel facilityPhotoVM)
        {
            return new PhotoSliderViewModel
            {
                Id = facilityPhotoVM.FacilityPhotoGuid,
                Alt = facilityPhotoVM.PhotoUri,
                Uri = facilityPhotoVM.PhotoUri
            };
        }

        /// <summary>
        /// Maps Facility photo VM collection to photo slider VM collection
        /// </summary>
        /// <param name="facilityPhotosVM">Facility photos VM collection</param>
        /// <returns>Photo slider VM collection</returns>
        public static IList<PhotoSliderViewModel> ToPhotoSliderList(this IEnumerable<FacilityPhotoViewModel> facilityPhotosVM)
        {
            var retlist = new List<PhotoSliderViewModel>();
            facilityPhotosVM.ToList().ForEach(f =>
            {
                retlist.Add(f.ToPhotoSlider());
            });
            return retlist;
        }

        /// <summary>
        /// Maps listing edit VM to listing details (search action) and adds city/state/zip
        /// </summary>
        /// <param name="listingEdit">Listing edit VM</param>
        /// <param name="cityStateZip">City state zip data</param>
        /// <param name="filter">Search filter VM</param>
        /// <returns>Listing details VM</returns>
        public static ListingDetailsViewModel ToListingDetails(this ListingViewModelEdit listingEdit, CityStateZip cityStateZip, SearchFilterViewModel filter)
        {
            return new ListingDetailsViewModel
            {
                CityStateZip = cityStateZip,
                FacilityGuid = listingEdit.FacilityGuid,
                FacilityName = listingEdit.FacilityName,
                FacilityShortDescription = listingEdit.Exerpt,
                FacilityLongDescription = listingEdit.Description,
                Address = listingEdit.Address,
                Website = listingEdit.Website,
                PhoneNumber = listingEdit.PhoneNumber,
                PhotoUri = listingEdit.PublicPhotoFileUri,
                Photos = listingEdit.FacilityPhotos.ToPhotoSliderList(),
                TypeOfCareList = listingEdit.TypeOfCareList,
                CurrentFilter = filter,
                Geolocation = new PSSLocation { Latitude = listingEdit.Latitude, Longitude = listingEdit.Longitude }
            };
        }

        /// <summary>
        /// Maps search filter with facility guid to search filter VM
        /// </summary>
        /// <param name="filterFacility">Search filter with facility guid</param>
        /// <returns>Search filter VM</returns>
        public static SearchFilterViewModel ToSearchFilter(this SearchFilterWithFacilityViewModel filterFacility)
        {
            return Mapper.Map<SearchFilterWithFacilityViewModel, SearchFilterViewModel>(filterFacility);
        }

        /// <summary>
        /// Decorates search filter with facility guid
        /// </summary>
        /// <param name="filter">Search filter VM</param>
        /// <param name="facilityGuid">Facility guid</param>
        /// <returns>Search filter with facility guid VM</returns>
        public static SearchFilterWithFacilityViewModel ToSearchFilterWithFacility(this SearchFilterViewModel filter, Guid facilityGuid) 
        {
            var filterWithFacility = Mapper.Map<SearchFilterViewModel, SearchFilterWithFacilityViewModel>(filter);
            filterWithFacility.FacilityGuid = facilityGuid;
            return filterWithFacility;
        }

        /// <summary>
        /// Maps SEO search filter VM to search filter VM
        /// </summary>
        /// <param name="seoFilter">SEO search filter VM</param>
        /// <param name="typesOfCare">Types of care collection</param>
        /// <returns>Search filter VM</returns>
        public static SearchFilterViewModel ToSearchFilter(this SeoSearchFilterViewModel seoFilter, IList<TypeOfCareViewModel> typesOfCare)
        {
            Enums.SearchTypes searchType = Enums.SearchTypes.Undefined;
            bool b = Enum.TryParse<Enums.SearchTypes>(seoFilter.SearchType, true, out searchType);
            var filter = new SearchFilterViewModel
            {
                Page = seoFilter.Page,
                Latitude = seoFilter.Latitude,
                Longitude = seoFilter.Longitude,
                SearchType = searchType,
                TypeOfCareFilter = seoFilter.RestoreTypesOfCare(typesOfCare),
                CityFilter = seoFilter.City,
                StateFilter = seoFilter.State,
                ZipFilter = seoFilter.Zip
            };
            return filter;
        }

        /// <summary>
        /// Maps search filter VM to SEO search filter VM
        /// </summary>
        /// <param name="filter">Search filter VM</param>
        /// <returns>SEO search filter VM</returns>
        public static SeoSearchFilterViewModel ToSeoSearchFilter(this SearchFilterViewModel filter)
        {
            return new SeoSearchFilterViewModel
            {
                Page = filter.Page,
                Latitude = filter.Latitude,
                Longitude = filter.Longitude,
                SearchType = filter.SearchType.ToString(),
                TypesOfCare = filter.TypesOfCareSeoParameterFormatted,
                City = filter.CityFilter,
                State = filter.StateFilter,
                Zip = filter.ZipFilter
            };
        }

        /// <summary>
        /// Maps search filter VM to SEO search filter as new object
        /// </summary>
        /// <param name="filter">Search filter VM</param>
        /// <returns>Object SEO</returns>
        public static object ToSeoSearchFilterObject(this SearchFilterViewModel filter)
        {
            if (null == filter)
            {
                return new { };
            }

            return new 
            {
                page = filter.Page,
                latitude = filter.Latitude,
                longitude = filter.Longitude,
                searchType = filter.SearchType.ToString(),
                typesofcare = filter.TypesOfCareSeoParameterFormatted,
                city = filter.CityFilter,
                state = filter.StateFilter,
                zip = filter.ZipFilter
            };
        }

        /// <summary>
        /// Maps search filter with facility guid VM to object
        /// </summary>
        /// <param name="filterFacility">Search filter with facility guid</param>
        /// <returns>Object SEO</returns>
        public static object ToSeoSearchFilterObject(this SearchFilterWithFacilityViewModel filterFacility)
        {
            if (null == filterFacility)
            {
                return new { };
            }

            return new
            {
                page = filterFacility.Page,
                latitude = filterFacility.Latitude,
                longitude = filterFacility.Longitude,
                searchType = filterFacility.SearchType.ToString(),
                typesofcare = filterFacility.TypesOfCareSeoParameterFormatted,
                city = filterFacility.CityFilter,
                state = filterFacility.StateFilter,
                zip = filterFacility.ZipFilter,
                facilityguid = filterFacility.FacilityGuid
            };
        }
    }
}