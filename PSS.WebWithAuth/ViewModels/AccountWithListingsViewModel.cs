
namespace PSS.WebWithAuth.ViewModels
{
    using System.Collections.Generic;
    using ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;

    /// <summary>
    /// Account with listings VM class
    /// </summary>
    public class AccountWithListingsViewModel : AccountViewModel
    {
        private IList<FacilityAudit> _accountListings;

        /// <summary>
        /// Gets or sets account listings
        /// </summary>
        public IList<FacilityAudit> AccountListings 
        {
            get
            {
                if (null == this._accountListings)
                {
                    this._accountListings = new List<FacilityAudit>();
                }

                return this._accountListings;
            }
            set
            {
                this._accountListings = value;
            }
        }


        private ClientCardInfoViewModel _clientCardInfoVM;

        public ClientCardInfoViewModel clientCardInfoVM
        {
            get
            {
                if (null == this._clientCardInfoVM)
                {
                    this._clientCardInfoVM = new ClientCardInfoViewModel();
                }

                return this._clientCardInfoVM;
            }
            set
            {
                this._clientCardInfoVM = value;
            }
        }
    }
}