﻿/*	Generated by CodeGen written by Concord Mfg
	*  Transform file used: JoinBusinessEntity (v0.1.0.0).xslt
	*  Date generated: 3/28/2012 12:46:17 PM
	*  CodeGen version: 0.1.0.0  */

using System;
using System.Collections;
using System.Collections.Generic;
using ISNet.WebUI.DataSource;

namespace ConcordMfg.PremierSeniorSolutions.Client.ViewModels
{
	/// <summary>
	/// The OfferingWithFacility class of the web UI tier.
	/// </summary>
	public class OfferingWithFacility
	{
		#region Private Fields
		private ConcordMfg.PremierSeniorSolutions.WebService.Client.OfferingWithFacilitySvc.OfferingWithFacility _offeringWithFacility = null;
		private IEnumerable _owner;
		#endregion


		#region Constructors
		/// <summary>
		/// Initializes a new instance of OfferingWithFacility class for the UI tier.
		/// </summary>
		public OfferingWithFacility()
		{
			_offeringWithFacility = new ConcordMfg.PremierSeniorSolutions.WebService.Client.OfferingWithFacilitySvc.OfferingWithFacility();
		}

		/// <summary>
		/// Initializes a new instance of OfferingWithFacility class for the UI tier taking a proxy client object as input.
		/// </summary>
		/// <param name="offeringWithFacility">OfferingWithFacility proxy client object.</param>
		public OfferingWithFacility(ConcordMfg.PremierSeniorSolutions.WebService.Client.OfferingWithFacilitySvc.OfferingWithFacility offeringWithFacility)
		{
			_offeringWithFacility = offeringWithFacility;
		}

		/// <summary>
		/// Initializes a new instance of Offering class given its properties for the UI tier.
		/// </summary>
		/// <param name="offeringGuid">Offering Guid</param>
		/// <param name="offeringID">Offering ID</param>
		/// <param name="offeringName">Offering Name</param>
		/// <param name="facilityGuid">Facility Guid</param>
		public OfferingWithFacility(Guid offeringGuid, int offeringID, string offeringName, Guid facilityGuid)
			: this()
		{
			_offeringWithFacility.OfferingGuid = offeringGuid;
			_offeringWithFacility.OfferingID = offeringID;
			_offeringWithFacility.OfferingName = offeringName;
			_offeringWithFacility.FacilityGuid = facilityGuid;
		}
		#endregion


		#region Properties

		/// <summary>
		/// Gets and sets Offering Guid from Offering.
		/// </summary>
		[PrimaryKey()]
		[Caption("Offering Guid")]
		public Guid OfferingGuid
		{
			get { return _offeringWithFacility.OfferingGuid; }
			set { _offeringWithFacility.OfferingGuid = value; }
		}
		/// <summary>
		/// Gets and sets Offering ID from Offering.
		/// </summary>
		[AutoIncrement()]
		[Caption("Offering ID")]
		public int OfferingID
		{
			get { return _offeringWithFacility.OfferingID; }
			set { _offeringWithFacility.OfferingID = value; }
		}
		/// <summary>
		/// Gets and sets Offering Name from Offering.
		/// </summary>
		[Caption("Offering Name")]
		public string OfferingName
		{
			get { return _offeringWithFacility.OfferingName; }
			set { _offeringWithFacility.OfferingName = value; }
		}
		/// <summary>
		/// Gets and sets Facility Guid from Facility.
		/// </summary>
		[Caption("Facility Guid")]
		public Guid FacilityGuid
		{
			get { return _offeringWithFacility.FacilityGuid; }
			set { _offeringWithFacility.FacilityGuid = value; }
		}
		/// <summary>
		/// Gets and sets Is Checked from Facility Offering.
		/// </summary>
		[Caption("Is Checked from Facility Offering")]
		public bool FacilityOffering_IsChecked
		{
			get { return _offeringWithFacility.FacilityOffering_IsChecked; }
			set { _offeringWithFacility.FacilityOffering_IsChecked = value; }
		}

		/// <summary>
		/// Gets and sets the collection that  belongs to.
		/// </summary>
		internal IEnumerable Owner
		{
			get { return _owner; }
			set { _owner = value; }
		}
		#endregion


		#region Methods
		/// <summary>
		/// Updates the class.
		/// </summary>
		public void Update()
		{
		}

		/// <summary>
		/// Deletes this from the owned collection class.
		/// </summary>
		public void Delete()
		{
			OfferingWithFacilityCollection owner = this.Owner as OfferingWithFacilityCollection;
			owner.Remove(this);
		}
		#endregion
	}
}