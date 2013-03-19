
namespace PSS.WebWithAuth.ViewModels
{
    using System;

    /// <summary>
    /// Photo slider entity class
    /// </summary>
    public class PhotoSliderViewModel
    {
        /// <summary>
        /// Gets or sets photo guid
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets photo uri
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// Gets or sets alt text for img tag
        /// </summary>
        public string Alt { get; set; }
    }
}