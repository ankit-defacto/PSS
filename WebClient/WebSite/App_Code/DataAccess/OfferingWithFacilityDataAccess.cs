﻿/*  Generated by CodeGen written by Concord Mfg.
 * Transform file used: JoinDataAccess (v0.1.0.0).xslt
 * Date generated: 3/28/2012 12:46:18 PM
 * CodeGen version: 0.1.0.0  */

using System;
using System.ComponentModel;
using ConcordMfg.PremierSeniorSolutions.Client.Tools;

namespace ConcordMfg.PremierSeniorSolutions.Client.ViewModels
{
	/// <summary>
	/// Access the data for the OfferingWithFacility class.
	/// </summary>
	// [DataObject]
	public partial class DataAccess
	{
		#region Private Fields
		private static ConcordMfg.PremierSeniorSolutions.WebService.Client.OfferingWithFacilitySvc.OfferingWithFacilityClient
			_offeringWithFacilityClient = new ConcordMfg.PremierSeniorSolutions.WebService.Client.OfferingWithFacilitySvc.OfferingWithFacilityClient();
		#endregion


		#region Public Methods
		/// <summary>
		/// Retrieves OfferingWithFacility from the web service.
		/// </summary>
		/// <returns>A Collection of all OfferingWithFacility.</returns>
		[DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
		public static OfferingWithFacilityCollection GetOfferingWithFacility()
		{
			ConcordMfg.PremierSeniorSolutions.WebService.Client.OfferingWithFacilitySvc.OfferingWithFacility[] offeringsWithFacility =
				_offeringWithFacilityClient.GetAllOfferingWithFacility();
			OfferingWithFacilityCollection result = new OfferingWithFacilityCollection(
				offeringsWithFacility.ToViewModels());
			return result;
		}

		/*
		/// <summary>
		/// Retrieves a OfferingWithFacility Collection from the web service.
		/// </summary>
		/// <param name="offeringGuid">Offering Guid</param>
		/// <returns>A Collection of OfferingWithFacility.</returns>
		[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
		public static OfferingWithFacilityCollection GetOfferingsWithFacilityForOffering(Guid offeringGuid)
		{
			ConcordMfg.PremierSeniorSolutions.WebService.Client.OfferingWithFacilitySvc.OfferingWithFacility[] offeringsWithFacility =
				_offeringWithFacilityClient.GetOfferingWithFacilityByOfferingGuid(offeringGuid);
			OfferingWithFacilityCollection result = new OfferingWithFacilityCollection(
				offeringsWithFacility.ToViewModels());
			return result;
		}
		*/

		/// <summary>
		/// Retrieves a OfferingWithFacility Collection from the web service.
		/// </summary>
		/// <param name="facilityGuid">Facility Guid</param>
		/// <returns>A Collection of OfferingWithFacility.</returns>
		[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
		public static OfferingWithFacilityCollection GetOfferingsWithFacilityForFacility(Guid facilityGuid)
		{
			ConcordMfg.PremierSeniorSolutions.WebService.Client.OfferingWithFacilitySvc.OfferingWithFacility[] offeringsWithFacility =
				_offeringWithFacilityClient.GetOfferingWithFacilityByFacilityGuid(facilityGuid);
			OfferingWithFacilityCollection result = new OfferingWithFacilityCollection(
				offeringsWithFacility.ToViewModels());
			return result;
		}

		
		#endregion
	}
}