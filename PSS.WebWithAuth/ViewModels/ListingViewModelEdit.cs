
namespace PSS.WebWithAuth.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;

    /// <summary>
    /// Extending existing view model to add suport for the listing screens
    /// </summary>
    public class ListingViewModelEdit : ListingViewModel
    {
        /// <summary>
        /// Gets or sets images for photo slider
        /// </summary>
        public IEnumerable<FacilityPhotoViewModel> FacilityPhotos { get; set; }

        /// <summary>
        /// Gets or sets type of care select list helper
        /// </summary>
        public IEnumerable<SelectListItem> ListingTypeSelectList { get; set; }
                
        /// <summary>
        /// Gets or sets selected listing type guid
        /// </summary>
        [Required(ErrorMessage = "You must select an option for Listing Type")]   
        public override Guid ListingTypeGuid { get; set; }
        
        /// <summary>
        /// Gets or sets types of care
        /// </summary>
        public IList<TypeOfCareViewModel> TypeOfCareList { get; set; }

        /// <summary>
        /// Gets or sets submit button text
        /// </summary>
        public string SaveButtonText { get; set; }

        /// <summary>
        /// Gets or sets action name (view is partial and used for create / edit)
        /// </summary>
        public string ActionName { get; set; }
    }
}