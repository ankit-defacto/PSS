
namespace PSS.WebWithAuth.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using PSS.WebWithAuth.Infrastructure;    

    /// <summary>
    /// Type of care view model class
    /// </summary>
    public class TypeOfCareViewModel
    {
        /// <summary>
        /// Gets or sets type of care guid
        /// </summary>
        [Required]
        public Guid TypeOfCareGuid { get; set; }

        /// <summary>
        /// Gets or sets type of care name
        /// </summary>
        [Display(Name = "Type of care")]
        public string TypeOfCareName { get; set; }

        /// <summary>
        /// Gets or sets if type of care is selected
        /// </summary>
        [Required]
        public bool Checked { get; set; }

        public string SeoName
        {
            get
            {
                return SeoUtilities.URLFriendly(this.TypeOfCareName.RemoveDots());
            }
        }
    }
}