﻿/*  Generated by CodeGen written by Concord Mfg.
 * Transform file used: JoinDAEntity (v0.2.0.0).xslt
 * Date generated: 3/28/2012 12:45:58 PM
 * CodeGen version: 0.2.0.0  */

using System;

namespace ConcordMfg.PremierSeniorSolutions.WebService.DataAccess
{
	/// <summary>
	/// CityStateZipWithFacility Data Access Entity
	/// </summary>
	/// <remarks>
	/// This is the CityStateZip class joined on facility identifier.
	/// </remarks>
	public partial class CityStateZipWithFacility : CityStateZip
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the CityStateZipWithFacility data access entity.
		/// </summary>
		/// <remarks>This class is a cityStateZip with facility identifier.</remarks>
		public CityStateZipWithFacility()
		{
		}
		#endregion


		#region Public Properties

		/// <summary>
		/// Facility Guid from Facility.
		/// </summary>
		public Guid Facility_FacilityGuid
		{
			get { return _facility_FacilityGuid; }
			set { _facility_FacilityGuid = value; }
		}

		#endregion


		#region Private Fields

		/// <summary>
		/// The FacilityGuid column from the Facility table.
		/// </summary>
		private Guid _facility_FacilityGuid = Guid.Empty;

		#endregion
	}
}