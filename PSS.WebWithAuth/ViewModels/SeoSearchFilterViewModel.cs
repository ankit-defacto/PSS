
namespace PSS.WebWithAuth.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    public class SeoSearchFilterViewModel
    {
        /// <summary>
        /// Gets or sets page
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Gets or sets search type (as string)
        /// </summary>
        public string SearchType { get; set; }

        /// <summary>
        /// Gets or sets city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets state
        /// </summary>
        public string State { get; set; }
        
        /// <summary>
        /// Gets or sets zip code
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// Gets or sets types of care as concatenated SEO formatted string
        /// </summary>
        public string TypesOfCare { get; set; }

        /// <summary>
        /// Gets or sets latitude
        /// </summary>
        public double? Latitude { get; set; }

        /// <summary>
        /// Gets or sets longitude
        /// </summary>
        public double? Longitude { get; set; }
        

        /// <summary>
        /// Restores original type of care view model list from query string formatted parameter
        /// </summary>
        /// <param name="typesOfCareList">Types of care definitions (from cache)</param>
        /// <returns>Type of care VM collection</returns>
        public IList<TypeOfCareViewModel> RestoreTypesOfCare(IList<TypeOfCareViewModel> typesOfCareList)
        {
            var typesofcarerestored = new List<TypeOfCareViewModel>(typesOfCareList);
            typesofcarerestored.ForEach(tc => tc.Checked = false);
            if (!string.IsNullOrEmpty(this.TypesOfCare))
            {
                var typesofcarecheckedArray = this.TypesOfCare.Split('~');
                typesOfCareList.ToList().ForEach(tc =>
                {
                    tc.Checked = typesofcarecheckedArray.Contains(tc.SeoName);
                });
            }

            return typesOfCareList;
        }
    }
}