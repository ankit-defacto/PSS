
namespace PSS.WebWithAuth.ViewModels
{
    using PagedList;

    /// <summary>
    /// Search results view model
    /// </summary>
    public class SearchResultsViewModel
    {
        /// <summary>
        /// ctor
        /// </summary>
        public SearchResultsViewModel()
        {
        }

        /// <summary>
        /// Gets or sets current search filter used
        /// </summary>
        public SearchFilterViewModel CurrentFilter { get; set; }

        /// <summary>
        /// Gets results based on current search filter
        /// </summary>
        public IPagedList<SearchResultViewModel> CurrentResults { get; set; }
    }
}