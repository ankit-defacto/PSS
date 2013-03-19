
namespace PSS.WebWithAuth.ViewModels
{
    using ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;

    /// <summary>
    /// View model for facility photo with style and uid properties
    /// </summary>
    public class FacilityPhotoViewModel : FacilityPhoto
    {
        /// <summary>
        /// Gets or sets css style to inform front end how to display
        /// </summary>
        public string CssStyle { get; set; }

        /// <summary>
        /// Gets or sets unique id for the entity for easy selection with jquery
        /// </summary>
        public string Uid { get; set; }
    }
}