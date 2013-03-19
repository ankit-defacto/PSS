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
	/// Data Contract Class - FacilityLocationCriteria
	/// </summary>
	[DataContract(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.DataContracts/2007/01", Name = "FacilityLocationCriteria")]
	public partial class FacilityLocationCriteria
	{
		#region Constructors
		public FacilityLocationCriteria()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the Task data contract class given its required properties.
		/// </summary>
		/// <param name="facilityGuid">Facility Guid</param>
		/// <param name="cityStateZipGuid">City State Zip Guid</param>
		public FacilityLocationCriteria(Guid facilityGuid, Guid cityStateZipGuid)
		{
			_facilityGuid = facilityGuid;
			_cityStateZipGuid = cityStateZipGuid;
		}
		#endregion


		#region Public Properties
		
		/// <summary>
		/// Facility Guid from FacilityLocationCriteria.
		/// </summary>
		[DataMember(IsRequired = true, Name = "FacilityGuid", Order = 0)]
		public Guid FacilityGuid
		{
			get { return _facilityGuid; }
			set { _facilityGuid = value; }
		}
	
		/// <summary>
		/// City State Zip Guid from FacilityLocationCriteria.
		/// </summary>
		[DataMember(IsRequired = true, Name = "CityStateZipGuid", Order = 1)]
		public Guid CityStateZipGuid
		{
			get { return _cityStateZipGuid; }
			set { _cityStateZipGuid = value; }
		}
	
        #endregion


		#region Private Fields
		private Guid _facilityGuid = Guid.Empty;
		private Guid _cityStateZipGuid = Guid.Empty;
		#endregion
	}

}
	