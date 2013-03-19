
namespace PSS.WebWithAuth.ViewModels
{
    using System.Collections.Generic;

    /// <summary>
    /// Listing details VM (search result details)
    /// </summary>
    public class ListingDetailsViewModel : SearchResultViewModel
    {
        /// <summary>
        /// Gets or sets description
        /// </summary>
        public string FacilityLongDescription { get; set; }

        /// <summary>
        /// Gets or sets current search filter used
        /// </summary>
        public SearchFilterViewModel CurrentFilter { get; set; }

        /// <summary>
        /// Gets or sets photos list
        /// </summary>
        public IList<PhotoSliderViewModel> Photos { get; set; }

        /// <summary>
        /// Gets or sets offered types of care
        /// </summary>
        public IList<TypeOfCareViewModel> TypeOfCareList { get; set; }
    }
}