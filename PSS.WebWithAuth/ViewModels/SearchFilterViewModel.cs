
namespace PSS.WebWithAuth.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using PSS.WebWithAuth.Infrastructure;

    /// <summary>
    /// Search filter class
    /// </summary>
    public class SearchFilterViewModel
    {               
        ////Geolocation storage
        /// <summary>
        /// Gets or sets latitude
        /// </summary>
        public double? Latitude { get; set; }

        /// <summary>
        /// Gets or sets longitude
        /// </summary>
        public double? Longitude { get; set; }

        /// <summary>
        /// Gets or sets geolocation status
        /// </summary>
        public Enums.GeolocationStates GeolocationStatus { get; set; }

        /// <summary>
        /// Gets or sets city search filter
        /// </summary>
        [Display(Name = "City", Prompt = "City")]
        [StringLength(25)]
        public string CityFilter { get; set; }

        /// <summary>
        /// Gets or sets state search filter
        /// </summary>
        [Display(Name = "State", Prompt = "State")]
        [StringLength(25)]
        public string StateFilter { get; set; }

        /// <summary>
        /// Gets or sets zip search filter
        /// </summary>
        [Display(Name = "Zip code", Prompt = "Zip code")]
        [RegularExpression(@"\d{0,5}", ErrorMessage = "Enter number value up to 5 digits")]        
        public string ZipFilter { get; set; }

        /// <summary>
        /// Gets or sets type of care search filter
        /// </summary>
        public IList<TypeOfCareViewModel> TypeOfCareFilter { get; set; }

        /// <summary>
        /// Gets or sets current page (to restore from details to search results transition)
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Gets or sets search type
        /// </summary>
        public Enums.SearchTypes SearchType { get; set; }

        /// <summary>
        /// Gets flag for empty city/state/zip
        /// </summary>
        public bool CityStateZipEmpty
        {
            get
            {
                return string.IsNullOrEmpty(this.CityFilter) &&
                        string.IsNullOrEmpty(this.StateFilter) &&
                            string.IsNullOrEmpty(this.ZipFilter);
            }
        }

        /// <summary>
        /// Gets formatted address to use in geocoding requests
        /// Format is: "{address} {city}, {state} {zip}"
        /// </summary>
        public string CityStateZipGeocodeFormatted
        {
            get
            {                
                return string.Format("{0}, {1} {2}", this.CityFilter ?? "", this.StateFilter ?? "", this.ZipFilter ?? "").Trim();
            }
        }
        
        public string TypesOfCareSeoParameterFormatted
        {
            get
            {
                if (this.TypeOfCareFilter == null)
                {
                    return "";
                }

                string tcseo = string.Join("~", this.TypeOfCareFilter
                    .Where(tc => tc.Checked).Select(tc => tc.SeoName));
                return tcseo;
            }
        }

        /// <summary>
        /// Fills types of care from external (cached) list
        /// </summary>
        /// <param name="tocList"></param>
        public void FillList(IList<TypeOfCareViewModel> tocList)
        {
            this.TypeOfCareFilter = tocList;
        }

        /// <summary>
        /// Sets filter page (needed in html helpers)
        /// </summary>
        /// <param name="page">The page</param>
        /// <returns>Search filter</returns>
        public SearchFilterViewModel SetPage(int page)
        {
            this.Page = page;
            return this;
        }

        /// <summary>
        /// Sets only names for types of care (restores object after post)
        /// </summary>
        /// <param name="tocList">Type of care list (full)</param>
        public void SetTypeOfCareNames(IList<TypeOfCareViewModel> tocList)
        {
            if (this.TypeOfCareFilter != null)
            {
                foreach (var toc in this.TypeOfCareFilter)
                {
                    var tocWithName = tocList.SingleOrDefault(tc => tc.TypeOfCareGuid == toc.TypeOfCareGuid);
                    toc.TypeOfCareName = tocWithName == null ? string.Empty : tocWithName.TypeOfCareName;
                }
            }
        }
    }
}