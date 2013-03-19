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
	/// View Model for Facility Location Criteria (FacilityLocationCriteria).
	/// </summary>
	public class FacilityLocationCriteriaViewModel : NotifyPropertyChangedBaseWithOwner
	{
		#region Private Fields
		protected Guid _facilityGuid = Guid.Empty;
		protected Guid _cityStateZipGuid = Guid.Empty;


		#endregion


		#region Constructors
		public FacilityLocationCriteriaViewModel()
		{
		}

		public FacilityLocationCriteriaViewModel(Guid facilityGuid, Guid cityStateZipGuid)
		{
			this.FacilityGuid = facilityGuid;
			this.CityStateZipGuid = cityStateZipGuid;
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
		#endregion


		#region Public Properties

		public Guid FacilityGuid
		{
			get { return _facilityGuid; }
			set
			{
				_facilityGuid = value;
				RaisePropertyChanged("FacilityGuid");
			}
		}

		public Guid CityStateZipGuid
		{
			get { return _cityStateZipGuid; }
			set
			{
				_cityStateZipGuid = value;
				RaisePropertyChanged("CityStateZipGuid");
			}
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
			return FacilityGuid.ToString();
		}
		#endregion
	}
}