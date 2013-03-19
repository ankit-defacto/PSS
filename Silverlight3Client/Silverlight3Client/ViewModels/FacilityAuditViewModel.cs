﻿/*	Generated by CodeGen written by Concord Mfg
 *  Transform file used: BEViewModel (v0.1.0.0).xslt
 *  Date generated: 3/28/2012 12:46:36 PM
 *  CodeGen version: 0.1.0.0  */

using System;
using System.Collections.Generic;
using ConcordMfg.PremierSeniorSolutions.Client.Models;


namespace ConcordMfg.PremierSeniorSolutions.Client.ViewModels
{
	/// <summary>
	/// View Model for Facility Audit (FacilityAudit).
	/// </summary>
	public class FacilityAuditViewModel : NotifyPropertyChangedBaseWithOwner
	{
		#region Private Fields
		protected Guid _facilityAuditGuid = Guid.Empty;
		protected Guid _facilityGuid = Guid.Empty;
		protected int _facilityID = 0;
		protected string _facilityName = null;
		protected string _exerpt = null;
		protected string _description = null;
		protected string _address = null;
		protected Guid _cityStateZipGuid = Guid.Empty;
		protected string _phoneNumber = null;
		protected string _email = null;
		protected string _website = null;
		protected Guid _clientGuid = Guid.Empty;
		protected Guid _listingTypeGuid = Guid.Empty;
		protected string _publicPhotoFileUri = null;
		protected DateTime _dateModified = default(DateTime);

		private string _facilityGuid_Facility_FacilityName = null;
		private string _cityStateZipGuid_CityStateZip_City = null;
		private string _clientGuid_Client_ClientName = null;
		private string _listingTypeGuid_ListingType_ListingTypeName = null;

		private FacilityViewModel _facilityGuid_Facility = null;
		private CityStateZipViewModel _cityStateZipGuid_CityStateZip = null;
		private ClientViewModel _clientGuid_Client = null;
		private ListingTypeViewModel _listingTypeGuid_ListingType = null;
		#endregion


		#region Constructors
		public FacilityAuditViewModel()
		{
		}

		public FacilityAuditViewModel(Guid facilityAuditGuid, Guid facilityGuid, int facilityID, string facilityName, string exerpt, string description, string address, Guid cityStateZipGuid, string phoneNumber, string email, string website, Guid clientGuid, Guid listingTypeGuid, string publicPhotoFileUri, DateTime dateModified)
		{
			this.FacilityAuditGuid = facilityAuditGuid;
			this.FacilityGuid = facilityGuid;
			this.FacilityID = facilityID;
			this.FacilityName = facilityName;
			this.Exerpt = exerpt;
			this.Description = description;
			this.Address = address;
			this.CityStateZipGuid = cityStateZipGuid;
			this.PhoneNumber = phoneNumber;
			this.Email = email;
			this.Website = website;
			this.ClientGuid = clientGuid;
			this.ListingTypeGuid = listingTypeGuid;
			this.PublicPhotoFileUri = publicPhotoFileUri;
			this.DateModified = dateModified;
		}
		#endregion


		#region Private GetAndSet Methods

		private void GetAndSetFacilityGuid_Facility(Guid facilityGuid)
		{
			if (Guid.Empty != facilityGuid &&
				(null == _facilityGuid_Facility || _facilityGuid_Facility.FacilityGuid != facilityGuid))
			{
				try
				{
					this.FacilityGuid_Facility = DataAccess.GetFacility(facilityGuid);
					this.FacilityGuid_Facility_FacilityName = _facilityGuid_Facility.FacilityName;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		private void GetAndSetCityStateZipGuid_CityStateZip(Guid cityStateZipGuid)
		{
			if (Guid.Empty != cityStateZipGuid &&
				(null == _cityStateZipGuid_CityStateZip || _cityStateZipGuid_CityStateZip.CityStateZipGuid != cityStateZipGuid))
			{
				try
				{
					this.CityStateZipGuid_CityStateZip = DataAccess.GetCityStateZip(cityStateZipGuid);
					this.CityStateZipGuid_CityStateZip_City = _cityStateZipGuid_CityStateZip.City;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		private void GetAndSetClientGuid_Client(Guid clientGuid)
		{
			if (Guid.Empty != clientGuid &&
				(null == _clientGuid_Client || _clientGuid_Client.ClientGuid != clientGuid))
			{
				try
				{
					this.ClientGuid_Client = DataAccess.GetClient(clientGuid);
					this.ClientGuid_Client_ClientName = _clientGuid_Client.ClientName;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		private void GetAndSetListingTypeGuid_ListingType(Guid listingTypeGuid)
		{
			if (Guid.Empty != listingTypeGuid &&
				(null == _listingTypeGuid_ListingType || _listingTypeGuid_ListingType.ListingTypeGuid != listingTypeGuid))
			{
				try
				{
					this.ListingTypeGuid_ListingType = DataAccess.GetListingType(listingTypeGuid);
					this.ListingTypeGuid_ListingType_ListingTypeName = _listingTypeGuid_ListingType.ListingTypeName;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}
		#endregion


		#region Public Properties

		public Guid FacilityAuditGuid
		{
			get { return _facilityAuditGuid; }
			set
			{
				_facilityAuditGuid = value;
				RaisePropertyChanged("FacilityAuditGuid");
			}
		}

		public Guid FacilityGuid
		{
			get { return _facilityGuid; }
			set
			{
				_facilityGuid = value;
				RaisePropertyChanged("FacilityGuid");
				this.GetAndSetFacilityGuid_Facility(value);
			}
		}

		public int FacilityID
		{
			get { return _facilityID; }
			set
			{
				_facilityID = value;
				RaisePropertyChanged("FacilityID");
			}
		}

		public string FacilityName
		{
			get { return _facilityName; }
			set
			{
				_facilityName = value;
				RaisePropertyChanged("FacilityName");
			}
		}

		public string Exerpt
		{
			get { return _exerpt; }
			set
			{
				_exerpt = value;
				RaisePropertyChanged("Exerpt");
			}
		}

		public string Description
		{
			get { return _description; }
			set
			{
				_description = value;
				RaisePropertyChanged("Description");
			}
		}

		public string Address
		{
			get { return _address; }
			set
			{
				_address = value;
				RaisePropertyChanged("Address");
			}
		}

		public Guid CityStateZipGuid
		{
			get { return _cityStateZipGuid; }
			set
			{
				_cityStateZipGuid = value;
				RaisePropertyChanged("CityStateZipGuid");
				this.GetAndSetCityStateZipGuid_CityStateZip(value);
			}
		}

		public string PhoneNumber
		{
			get { return _phoneNumber; }
			set
			{
				_phoneNumber = value;
				RaisePropertyChanged("PhoneNumber");
			}
		}

		public string Email
		{
			get { return _email; }
			set
			{
				_email = value;
				RaisePropertyChanged("Email");
			}
		}

		public string Website
		{
			get { return _website; }
			set
			{
				_website = value;
				RaisePropertyChanged("Website");
			}
		}

		public Guid ClientGuid
		{
			get { return _clientGuid; }
			set
			{
				_clientGuid = value;
				RaisePropertyChanged("ClientGuid");
				this.GetAndSetClientGuid_Client(value);
			}
		}

		public Guid ListingTypeGuid
		{
			get { return _listingTypeGuid; }
			set
			{
				_listingTypeGuid = value;
				RaisePropertyChanged("ListingTypeGuid");
				this.GetAndSetListingTypeGuid_ListingType(value);
			}
		}

		public string PublicPhotoFileUri
		{
			get { return _publicPhotoFileUri; }
			set
			{
				_publicPhotoFileUri = value;
				RaisePropertyChanged("PublicPhotoFileUri");
			}
		}

		public DateTime DateModified
		{
			get { return _dateModified; }
			set
			{
				_dateModified = value;
				RaisePropertyChanged("DateModified");
			}
		}

		public string FacilityGuid_Facility_FacilityName
		{
			get
			{ return _facilityGuid_Facility_FacilityName; }
			set
			{
				if (Guid.Empty != value)
				{
					_facilityGuid_Facility_FacilityName = value;
					RaisePropertyChanged("FacilityGuid_Facility_FacilityName");
				}
			}
		}

		public string CityStateZipGuid_CityStateZip_City
		{
			get
			{ return _cityStateZipGuid_CityStateZip_City; }
			set
			{
				if (Guid.Empty != value)
				{
					_cityStateZipGuid_CityStateZip_City = value;
					RaisePropertyChanged("CityStateZipGuid_CityStateZip_City");
				}
			}
		}

		public string ClientGuid_Client_ClientName
		{
			get
			{ return _clientGuid_Client_ClientName; }
			set
			{
				if (Guid.Empty != value)
				{
					_clientGuid_Client_ClientName = value;
					RaisePropertyChanged("ClientGuid_Client_ClientName");
				}
			}
		}

		public string ListingTypeGuid_ListingType_ListingTypeName
		{
			get
			{ return _listingTypeGuid_ListingType_ListingTypeName; }
			set
			{
				if (Guid.Empty != value)
				{
					_listingTypeGuid_ListingType_ListingTypeName = value;
					RaisePropertyChanged("ListingTypeGuid_ListingType_ListingTypeName");
				}
			}
		}

		/// <summary>
		/// Gets and sets Facility related through FacilityGuid.
		/// </summary>
		public FacilityViewModel FacilityGuid_Facility
		{
			get
			{
				if (Guid.Empty != _facilityGuid && null == _facilityGuid_Facility)
				{ this.GetAndSetFacilityGuid_Facility(_facilityGuid); }
				return _facilityGuid_Facility;
			}
			set
			{
				if (Guid.Empty != value)
				{
					_facilityGuid_Facility = value;
					RaisePropertyChanged("FacilityGuid_Facility");
				}
			}
		}

		public string FacilityGuidPDC
		{
			get
			{
				if (null == this.FacilityGuid_Facility || this.FacilityGuid == Guid.Empty)
					return "*Unassigned*";
				return this.FacilityGuid_Facility.PDC;
			}
			set { ; }
		}

		/// <summary>
		/// Gets and sets City State Zip related through CityStateZipGuid.
		/// </summary>
		public CityStateZipViewModel CityStateZipGuid_CityStateZip
		{
			get
			{
				if (Guid.Empty != _cityStateZipGuid && null == _cityStateZipGuid_CityStateZip)
				{ this.GetAndSetCityStateZipGuid_CityStateZip(_cityStateZipGuid); }
				return _cityStateZipGuid_CityStateZip;
			}
			set
			{
				if (Guid.Empty != value)
				{
					_cityStateZipGuid_CityStateZip = value;
					RaisePropertyChanged("CityStateZipGuid_CityStateZip");
				}
			}
		}

		public string CityStateZipGuidPDC
		{
			get
			{
				if (null == this.CityStateZipGuid_CityStateZip || this.CityStateZipGuid == Guid.Empty)
					return "*Unassigned*";
				return this.CityStateZipGuid_CityStateZip.PDC;
			}
			set { ; }
		}

		/// <summary>
		/// Gets and sets Client related through ClientGuid.
		/// </summary>
		public ClientViewModel ClientGuid_Client
		{
			get
			{
				if (Guid.Empty != _clientGuid && null == _clientGuid_Client)
				{ this.GetAndSetClientGuid_Client(_clientGuid); }
				return _clientGuid_Client;
			}
			set
			{
				if (Guid.Empty != value)
				{
					_clientGuid_Client = value;
					RaisePropertyChanged("ClientGuid_Client");
				}
			}
		}

		public string ClientGuidPDC
		{
			get
			{
				if (null == this.ClientGuid_Client || this.ClientGuid == Guid.Empty)
					return "*Unassigned*";
				return this.ClientGuid_Client.PDC;
			}
			set { ; }
		}

		/// <summary>
		/// Gets and sets Listing Type related through ListingTypeGuid.
		/// </summary>
		public ListingTypeViewModel ListingTypeGuid_ListingType
		{
			get
			{
				if (Guid.Empty != _listingTypeGuid && null == _listingTypeGuid_ListingType)
				{ this.GetAndSetListingTypeGuid_ListingType(_listingTypeGuid); }
				return _listingTypeGuid_ListingType;
			}
			set
			{
				if (Guid.Empty != value)
				{
					_listingTypeGuid_ListingType = value;
					RaisePropertyChanged("ListingTypeGuid_ListingType");
				}
			}
		}

		public string ListingTypeGuidPDC
		{
			get
			{
				if (null == this.ListingTypeGuid_ListingType || this.ListingTypeGuid == Guid.Empty)
					return "*Unassigned*";
				return this.ListingTypeGuid_ListingType.PDC;
			}
			set { ; }
		}

		public string PDC
		{
			get { return this.ToString(); }
			set { ; }
		}
		#endregion


		#region Overrides
		public override string ToString()
		{
			return FacilityName;
		}
		#endregion
	}
}