﻿/*  Generated by CodeGen written by Concord Mfg.
 *  Transform file used: NamedBusinessEntity (v0.1.0.0).xslt
 *  Date generated: 3/28/2012 12:46:02 PM
 *  CodeGen version: 0.1.0.0  */

using System;
using System.Collections.Generic;

namespace ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities
{
    /// <summary>
    /// Client Business Entity
    /// </summary>
    public partial class Client : IComparer<Client>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of Client as a business entity.
        /// </summary>
        public Client()
        {
        }

        /// <summary>
        /// Initializes a new instance of Client as a business entity with its properties that are not auto assigned.
        /// </summary>
		/// <param name="clientGuid">Client Guid</param>
		/// <param name="clientID">Client ID</param>
		/// <param name="clientName">Client Name</param>
		/// <param name="phoneNumber">Phone Number</param>
		/// <param name="email">Email</param>
		/// <param name="address">Address</param>
		/// <param name="cityStateZipGuid">City State Zip Guid</param>
		/// <param name="paymentInfoGuid">Payment Info Guid</param>
		/// <param name="federatedID">Federated ID</param>
		/// <param name="federatedKey">Federated Key</param>
		/// <param name="federatedIDProvider">Federated ID Provider</param>
		/// <param name="username">Username</param>
		/// <param name="hashedPassword">Hashed Password</param>
        public Client(Guid clientGuid, int clientID, string clientName, string phoneNumber, string email, string address, Guid cityStateZipGuid, Guid paymentInfoGuid, string federatedID, string federatedKey, string federatedIDProvider,
            string username, string hashedPassword,  bool isWavered, int freeDays, decimal credits, bool isSuspended,bool isFlagged, bool isActive)
        {
			_clientGuid = clientGuid;
			_clientID = clientID;
			_clientName = clientName;
			_phoneNumber = phoneNumber;
			_email = email;
			_address = address;
			_cityStateZipGuid = cityStateZipGuid;
			_paymentInfoGuid = paymentInfoGuid;
			_federatedID = federatedID;
			_federatedKey = federatedKey;
			_federatedIDProvider = federatedIDProvider;
			_username = username;
            _hashedPassword = hashedPassword;
            //_pauseAccount = accountPaused;
            _isWaiverd = isWavered;
            _freeDays = freeDays;
            _credits = credits;
            _isSuspended = isSuspended;
            _isFlagged = isFlagged;
            _isActive = isActive;
        }
        #endregion


        #region Overridden Methods
        public override string ToString()
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder();

            result.AppendFormat("ClientGuid: {0}. ", this.ClientGuid.ToString());
            result.AppendFormat("ClientID: {0}. ", this.ClientID.ToString());
            result.AppendFormat("ClientName: {0}. ", this.ClientName);
            result.AppendFormat("PhoneNumber: {0}. ", this.PhoneNumber);
            result.AppendFormat("Email: {0}. ", this.Email);
            result.AppendFormat("Address: {0}. ", this.Address);
            result.AppendFormat("CityStateZipGuid: {0}. ", this.CityStateZipGuid.ToString());
            result.AppendFormat("PaymentInfoGuid: {0}. ", this.PaymentInfoGuid.ToString());
            result.AppendFormat("FederatedID: {0}. ", this.FederatedID);
            result.AppendFormat("FederatedKey: {0}. ", this.FederatedKey);
            result.AppendFormat("FederatedIDProvider: {0}. ", this.FederatedIDProvider);
            result.AppendFormat("Username: {0}. ", this.Username);
            result.AppendFormat("HashedPassword: {0}. ", this.HashedPassword);
            result.AppendFormat("AccountPaused: {0}. ", this.AccountPaused);
            result.AppendFormat("IsWaiverd: {0}. ", this.IsWaiverd);
            result.AppendFormat("FreeDays: {0}. ", this.FreeDays);
            result.AppendFormat("AccountBalance: {0}. ", this.Credits);
            result.AppendFormat("IsSuspended: {0}. ", this.IsSuspended);
            result.AppendFormat("IsFlagged: {0}. ", this.IsFlagged);
            result.AppendFormat("IsActive: {0}. ", this.IsActive);

            return result.ToString();
        }
        #endregion


        #region IComparer<Client> Members

        /// <summary>
        /// Compares two Clients. Compares PK and id fields separate from other fields.
        /// </summary>
        /// <param name="a">Client A</param>
        /// <param name="b">Client B</param>
        /// <returns>If the PK or ID are different, returns 1.
        /// If any other fields are different, returns -1.
        /// If all fields are identical, return 0.</returns>
        public int Compare(Client a, Client b)
        {
            if (a._clientGuid != b._clientGuid)
            { return 1; }

            if (a._clientID != b._clientID)
            { return 1; }

            if (a._clientName != b._clientName)
            { return -1; }

            if (a._phoneNumber != b._phoneNumber)
            { return -1; }

            if (a._email != b._email)
            { return -1; }

            if (a._address != b._address)
            { return -1; }

            if (a._cityStateZipGuid != b._cityStateZipGuid)
            { return -1; }

            if (a._paymentInfoGuid != b._paymentInfoGuid)
            { return -1; }

            if (a._federatedID != b._federatedID)
            { return -1; }

            if (a._federatedKey != b._federatedKey)
            { return -1; }

            if (a._federatedIDProvider != b._federatedIDProvider)
            { return -1; }

            if (a._username != b._username)
            { return -1; }

            if (a._hashedPassword != b._hashedPassword)
            { return -1; }

            if (a.accountPaused != b.accountPaused)
            { return -1; }

            if (a.IsWaiverd != b.IsWaiverd)
            { return -1; }

            if (a.FreeDays != b.FreeDays)
            { return -1; }

            if (a.Credits != b.Credits)
            { return -1; }

            if (a.IsSuspended != b.IsSuspended)
            { return -1; }

            if (a.IsFlagged != b.IsFlagged)
            { return -1; }

            if (a.IsActive != b.IsActive)
            { return -1; }

            return 0;
        }

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets or sets the Client Guid.
        /// </summary>
		public Guid ClientGuid
		{
			get { return _clientGuid; }
			set { _clientGuid = value; }
		}
	
        /// <summary>
        /// Gets or sets the Client ID.
        /// </summary>
		public int ClientID
		{
			get { return _clientID; }
			set { _clientID = value; }
		}
	
        /// <summary>
        /// Gets or sets the Client Name.
        /// </summary>
		public string ClientName
		{
			get { return _clientName; }
			set { _clientName = value; }
		}
	
        /// <summary>
        /// Gets or sets the Phone Number.
        /// </summary>
		public string PhoneNumber
		{
			get { return _phoneNumber; }
			set { _phoneNumber = value; }
		}
	
        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}
	
        /// <summary>
        /// Gets or sets the Address.
        /// </summary>
		public string Address
		{
			get { return _address; }
			set { _address = value; }
		}
	
        /// <summary>
        /// Gets or sets the City State Zip Guid.
        /// </summary>
		public Guid CityStateZipGuid
		{
			get { return _cityStateZipGuid; }
			set { _cityStateZipGuid = value; }
		}
	
        /// <summary>
        /// Gets or sets the Payment Info Guid.
        /// </summary>
		public Guid PaymentInfoGuid
		{
			get { return _paymentInfoGuid; }
			set { _paymentInfoGuid = value; }
		}
	
        /// <summary>
        /// Gets or sets the Federated ID.
        /// </summary>
		public string FederatedID
		{
			get { return _federatedID; }
			set { _federatedID = value; }
		}
	
        /// <summary>
        /// Gets or sets the Federated Key.
        /// </summary>
		public string FederatedKey
		{
			get { return _federatedKey; }
			set { _federatedKey = value; }
		}
	
        /// <summary>
        /// Gets or sets the Federated ID Provider.
        /// </summary>
		public string FederatedIDProvider
		{
			get { return _federatedIDProvider; }
			set { _federatedIDProvider = value; }
		}
	
        /// <summary>
        /// Gets or sets the Username.
        /// </summary>
		public string Username
		{
			get { return _username; }
			set { _username = value; }
		}
	
        /// <summary>
        /// Gets or sets the Hashed Password.
        /// </summary>
		public string HashedPassword
		{
			get { return _hashedPassword; }
			set { _hashedPassword = value; }
		}

        /// <summary>
        /// Gets or sets account status
        /// </summary>
        public bool AccountPaused
        {
            get { return this.accountPaused; }
            set { this.accountPaused = value; }
        }

        public bool IsWaiverd
        {
            get { return this._isWaiverd; }
            set { this._isWaiverd = value; }
        }

        public int FreeDays
        {
            get { return this._freeDays; }
            set { this._freeDays = value; }
        }

        public decimal Credits
        {
            get { return this._credits; }
            set { this._credits = value; }
        }

        public bool IsSuspended
        {
            get { return this._isSuspended; }
            set { this._isSuspended = value; }
        }

        public bool IsFlagged
        {
            get { return this._isFlagged; }
            set { this._isFlagged = value; }
        }

        public bool IsActive
        {
            get { return this._isActive; }
            set { this._isActive = value; }
        }

        #endregion


        #region Private Fields

        /// <summary>
        /// The Client Guid field.
        /// </summary>
		private Guid _clientGuid = Guid.Empty;

        /// <summary>
        /// The Client ID field.
        /// </summary>
		private int _clientID = 0;

        /// <summary>
        /// The Client Name field.
        /// </summary>
		private string _clientName = null;

        /// <summary>
        /// The Phone Number field.
        /// </summary>
		private string _phoneNumber = null;

        /// <summary>
        /// The Email field.
        /// </summary>
		private string _email = null;

        /// <summary>
        /// The Address field.
        /// </summary>
		private string _address = null;

        /// <summary>
        /// The City State Zip Guid field.
        /// </summary>
		private Guid _cityStateZipGuid = Guid.Empty;

        /// <summary>
        /// The Payment Info Guid field.
        /// </summary>
		private Guid _paymentInfoGuid = Guid.Empty;

        /// <summary>
        /// The Federated ID field.
        /// </summary>
		private string _federatedID = null;

        /// <summary>
        /// The Federated Key field.
        /// </summary>
		private string _federatedKey = null;

        /// <summary>
        /// The Federated ID Provider field.
        /// </summary>
		private string _federatedIDProvider = null;

        /// <summary>
        /// The Username field.
        /// </summary>
		private string _username = null;

        /// <summary>
        /// The Hashed Password field.
        /// </summary>
		private string _hashedPassword = null;

        /// <summary>
        /// Is client account active?
        /// </summary>

        private bool accountPaused;

        private bool _isWaiverd = false;

        private int _freeDays = 0;

        private decimal _credits = 0;

        private bool _isSuspended = false;

        private bool _isFlagged = false;

        private bool _isActive = true;

        #endregion
    }
  
}