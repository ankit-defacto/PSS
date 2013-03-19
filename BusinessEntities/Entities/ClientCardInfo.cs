using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Globalization;
namespace ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities
{
    /// <summary>
    /// ClientCardInfo Business Entity
    /// </summary>
    public partial class ClientCardInfo: IComparer<ClientCardInfo>
    {

       #region Constructors
        /// <summary>
        /// Initializes a new instance of ClientCardInfo as a business entity.
        /// </summary>
        public ClientCardInfo( )
        {
        }

        /// <summary>
        /// Initializes a new instance of ClientCardInfo as a business entity with its properties that are not auto assigned.
        /// </summary>
       
        public ClientCardInfo(Guid ClientCardGuid, Guid ClientGuid, string  CardType,string CardHolderNameOnCard,string CardNumber,string CvvNumber,Int16 ExpMonth,Int16 ExpYear )
        {
			_clientCardGuid = ClientCardGuid;
			_clientGuid = ClientGuid;
            _cardtype = CardType;
            _cardHolderNameOnCard=CardHolderNameOnCard;
            _cardNumber=CardNumber;
            _cvvNumber=CvvNumber;
            _expMonth=ExpMonth;
            _expYear=ExpYear;
        }
        #endregion


        #region IComparer<ClientCardInfo> Members

        /// <summary>
        /// Compares two ListingTypes. Compares PK and id fields separate from other fields.
        /// </summary>
        /// <param name="a">ListingType A</param>
        /// <param name="b">ListingType B</param>
        /// <returns>If the PK or ID are different, returns 1.
        /// If any other fields are different, returns -1.
        /// If all fields are identical, return 0.</returns>
        public int Compare(ClientCardInfo a, ClientCardInfo b)
        {
            if (a._clientCardGuid != _clientCardGuid)
            { return 1; }

            if (a._cardHolderNameOnCard != b.CardHolderNameOnCard)
            { return -1; }

            return 0;
        }

        #endregion




        #region Public Properties

        //[Required]
        public Guid ClientCardGuid 
        { 
            get
            {
                return _clientCardGuid;
            }
            set
            {
                _clientCardGuid=value;
            }
        }

        //[Required]
        public Guid ClientGuid 
        { 
            get
            {
             return _clientGuid;   
            }
            set
            {
                _clientGuid=value;
            }
        }

        //[Required]
        public string CardType
        {
            get
            {
                return _cardtype;
            }
            set
            {
                _cardtype = value;
            }
        }

        //[Required(ErrorMessage="Card-Holder Name is required")]
        //[DataType(DataType.Text)]
        //[StringLength(50,ErrorMessage="Minimum 5 Character required",MinimumLength=5)]
        public string CardHolderNameOnCard
        {
            get
            {
                return _cardHolderNameOnCard;
            }
            set
            {
                _cardHolderNameOnCard = value;
            }
        }

        //[Required]
        //[RegularExpression(@"\d{8,20}", ErrorMessage = "Invalid card No")]
        public string CardNumber
        {
            get
            {
                return _cardNumber;
            }
            set
            {
                _cardNumber = value;
            }
        }

        //[Required]
        //[RegularExpression(@"\d{3}",ErrorMessage="Enter only 3 digits (XXX)")]
        public string CvvNumber
        {
            get
            {
                return _cvvNumber;
            }
            set
            {
                _cvvNumber = value;
            }
        }

        //[Required]
        //[Range(1, 12, ErrorMessage = "Invalid Month")]
        //[RegularExpression(@"\d{1,2}", ErrorMessage = "Invalid month (eg. 08 for August)")]
        public Int16 ExpMonth
        {
            get
            {
                return _expMonth;
            }
            set
            {
                _expMonth = value;
            }
        }

        //[Required]
        //[Range(2013, 2050, ErrorMessage = "Expiry year must be in between 2013 to 2050")]
        //[RegularExpression(@"\d{4}", ErrorMessage = "Invalid Year (eg. 2019)")]
        public Int16 ExpYear
        {
            get
            {
                return _expYear;
            }
            set
            {
                _expYear = value;
            }

        }

        #endregion 

        #region Private Feilds

        /// <summary>
        /// The ClientCard Guid field.
        /// </summary>
		private Guid _clientCardGuid = Guid.Empty;

             /// <summary>
        /// The Client Guid field.
        /// </summary>
		private Guid _clientGuid = Guid.Empty;

                  /// <summary>
        /// The Card Type field.
        /// </summary>
		private string _cardtype = string.Empty;
               /// <summary>
   

                /// <summary>
        /// The Card Holder Name On Card field.
        /// </summary>
        private string _cardHolderNameOnCard = string.Empty;
                /// <summary>
        /// The Card number field.
        /// </summary>
		private string _cardNumber = string.Empty;
             /// <summary>
        /// The Card number cvv field.
        /// </summary>
		private string _cvvNumber = string.Empty;
            /// <summary>
        /// The Card expiration month field.
        /// </summary>
        private Int16 _expMonth;
           /// <summary>
        /// The Card expiration year field.
        /// </summary>
        private Int16 _expYear;
        #endregion




    }
}
