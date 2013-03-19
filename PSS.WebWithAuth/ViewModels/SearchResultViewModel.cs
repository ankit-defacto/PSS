
namespace PSS.WebWithAuth.ViewModels
{
    using System;
    using System.Collections.Generic;
    using ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;
    using PSS.WebWithAuth.Infrastructure;
    using PSS.WebWithAuth.Models;

    /// <summary>
    /// Search result view model
    /// </summary>
    public class SearchResultViewModel
    {
        /// <summary>
        /// Gets or sets facility guid
        /// </summary>
        public Guid FacilityGuid { get; set; }

        /// <summary>
        /// Gets or sets facility name
        /// </summary>
        public string FacilityName { get; set; }

        /// <summary>
        /// Gets or sets facility description (excerpt in model)
        /// </summary>
        public string FacilityShortDescription { get; set; }

        /// <summary>
        /// Gets or sets facility website
        /// </summary>
        public string Website { get; set; }

        /// <summary>
        /// Gets or sets facility photo uri
        /// </summary>
        public string PhotoUri { get; set; }

        /// <summary>
        /// Gets or sets facility address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets city state and zip
        /// </summary>
        public CityStateZip CityStateZip { get; set; }

        // geocoding properties
        /// <summary>
        /// Gets or sets location for this address
        /// </summary>
        public PSSLocation Geolocation { get; set; }

        /// <summary>
        /// Gets formatted address for geocode request
        /// </summary>
        public string GeocodeAddress
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Address) && this.CityStateZip != null)
                {
                    string address = String.Format("{0} {1}, {2} {3}", 
                            this.Address, this.CityStateZip.City ?? "", this.CityStateZip.State ?? "", this.CityStateZip.ZipCode ?? "");
                    return address;
                }
                else
                {
                    return "empty";
                }
            }
        }

        /// <summary>
        /// Gets html attributes for this result item
        /// </summary>
        public IDictionary<string, object> HtmlAttributes
        {
            get
            {
                var attribs = new Dictionary<string, object>();
                attribs.Add("id", this.FacilityGuid);
                attribs.Add("class", "details");
                return attribs;
            }
        }
    }
}