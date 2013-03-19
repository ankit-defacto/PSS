
namespace PSS.WebWithAuth.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Search filter VM with facility guid added
    /// </summary>
    public class SearchFilterWithFacilityViewModel : SearchFilterViewModel
    {
        /// <summary>
        /// Gets or sets facility guid
        /// </summary>
        public Guid FacilityGuid { get; set; }
    }
}