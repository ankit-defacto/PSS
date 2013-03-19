﻿/*  Generated by CodeGen written by Concord Mfg.
 *  Transform file used: BEDataContract (v0.0.6.5).xslt
 *  Date generated: 3/28/2012 12:46:07 PM
 *  CodeGen version: 0.1.0.0  */

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConcordMfg.PremierSeniorSolutions.WebService.DataContracts
{
	/// <summary>
	/// Data Contract Class - FacilityOffering
	/// </summary>
	[DataContract(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.DataContracts/2007/01", Name = "FacilityOffering")]
	public partial class FacilityOffering
	{
		#region Constructors
		public FacilityOffering()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the Task data contract class given its required properties.
		/// </summary>
		/// <param name="facilityGuid">Facility Guid</param>
		/// <param name="offeringGuid">Offering Guid</param>
		/// <param name="isChecked">Is Checked</param>
		public FacilityOffering(Guid facilityGuid, Guid offeringGuid, bool isChecked)
		{
			_facilityGuid = facilityGuid;
			_offeringGuid = offeringGuid;
			_isChecked = isChecked;
		}
		#endregion


		#region Public Properties
		
		/// <summary>
		/// Facility Guid from FacilityOffering.
		/// </summary>
		[DataMember(IsRequired = true, Name = "FacilityGuid", Order = 0)]
		public Guid FacilityGuid
		{
			get { return _facilityGuid; }
			set { _facilityGuid = value; }
		}
	
		/// <summary>
		/// Offering Guid from FacilityOffering.
		/// </summary>
		[DataMember(IsRequired = true, Name = "OfferingGuid", Order = 1)]
		public Guid OfferingGuid
		{
			get { return _offeringGuid; }
			set { _offeringGuid = value; }
		}
	
		/// <summary>
		/// Is Checked from FacilityOffering.
		/// </summary>
		[DataMember(IsRequired = true, Name = "IsChecked", Order = 2)]
		public bool IsChecked
		{
			get { return _isChecked; }
			set { _isChecked = value; }
		}
	
        #endregion


		#region Private Fields
		private Guid _facilityGuid = Guid.Empty;
		private Guid _offeringGuid = Guid.Empty;
		private bool _isChecked = false;
		#endregion
	}

}
	