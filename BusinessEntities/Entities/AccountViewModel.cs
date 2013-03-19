using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities
{
    public class AccountViewModel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the City State Zip Guid.
        /// </summary>
        [Required]
        public Guid CityStateZipGuid
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the City.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string City
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the State.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string State
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Zip Code.
        /// </summary>
        [Required]
        [StringLength(5)]
        public string ZipCode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Payment Info Guid.
        /// </summary>
        [Required]
        public Guid PaymentInfoGuid
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Payment Info ID.
        /// </summary>
        [Required]
        public int PaymentInfoID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Amazon Token.
        /// </summary>        
        public string AmazonToken
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Client Guid.
        /// </summary>
        public Guid ClientGuid
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Client ID.
        /// </summary>
        [Required]
        public int ClientID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Client Name.
        /// </summary>
        [Required]
        public string ClientName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Phone Number.
        /// </summary>
        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        [RegularExpression(@"\d{10}")]
        public string PhoneNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Email.
        /// </summary>        
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Address.
        /// </summary>
        [Required]
        public string Address
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Federated ID.
        /// </summary>
        public string FederatedID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Federated Key.
        /// </summary>
        public string FederatedKey
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Federated ID Provider.
        /// </summary>
        public string FederatedIDProvider
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets account activity
        /// </summary>
        [UIHint("ActiveNotActive")]
        [Display(Name = "Account paused")]
        public bool PauseAccount { get; set; }

        public bool IsWaiverd { get; set; }

        public int FreeDays { get; set; }

        public decimal AccountBalance { get; set; }

        public bool IsSuspended { get; set; }

        public bool IsFlagged { get; set; }

        public bool IsActive { get; set; }

        #endregion
    }
}