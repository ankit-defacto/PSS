﻿/*  Generated by CodeGen written by Concord Mfg.
 * Transform file used: JoinCollection (v0.1.0.0).xslt
 * Date generated: 3/28/2012 12:46:18 PM
 * CodeGen version: 0.1.0.0  */

using System;
using System.Collections;
using System.Collections.Generic;
using ISNet.WebUI.DataSource;

namespace ConcordMfg.PremierSeniorSolutions.Client.Models
{
	/// <summary>
	/// The collection of OfferingWithFacility.
	/// </summary>
	public class OfferingWithFacilityCollection : CollectionBase, IHierarchicalList, IObjectRelations
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the OfferingWithFacilityCollection class for the UI tier.
		/// </summary>
		public OfferingWithFacilityCollection()
		{
		}

		/// <summary>
		/// Initializes a new instance of the OfferingWithFacilityCollection class for the UI tier
		/// given a list of offeringsWithFacility.
		/// </summary>
		/// <param name="offeringWithFacilityList">The offeringsWithFacility.</param>
		public OfferingWithFacilityCollection(IEnumerable<OfferingWithFacility> offeringWithFacilityList)
		{
			foreach (OfferingWithFacility offeringWithFacility in offeringWithFacilityList)
			{
				this.Add(offeringWithFacility);
			}
		}

		#endregion

		#region Methods
		/// <summary>
		/// Adds a OfferingWithFacility to the collection.
		/// </summary>
		/// <param name="offeringWithFacility">The offeringWithFacility to add.</param>
		public void Add(OfferingWithFacility offeringWithFacility)
		{
			//offeringWithFacility.Owner = this;
			List.Add(offeringWithFacility);
		}

		/// <summary>
		/// Removes OfferingWithFacility at the index offset.
		/// </summary>
		/// <param name="index">The offset into the collection.</param>
		/// <returns>true, if the removal was successful; otherwise, false.</returns>
		public bool Remove(int index)
		{
			try
			{
				List.RemoveAt(index);
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Removes OfferingWithFacility from the collection.
		/// </summary>
		/// <param name="offeringWithFacility">The offeringWithFacility to remove.</param>
		public void Remove(OfferingWithFacility offeringWithFacility)
		{
			List.Remove(offeringWithFacility);
		}

		/// <summary>
		/// Gets OfferingWithFacility at the index offset.
		/// </summary>
		/// <param name="index">The offset into the collection.</param>
		/// <returns>The offeringWithFacility.</returns>
		public OfferingWithFacility Item(int index)
		{
			return List[index] as OfferingWithFacility;
		}

		/// <summary>
		/// Retrieves OfferingWithFacility for .
		/// </summary>
		
		/// <param name="offeringGuid">Offering Guid</param>
		/// <param name="facilityGuid">Facility Guid</param>
		/// <returns>OfferingWithFacility that contains the identifiers.</returns>
		public OfferingWithFacility FindByID(Guid offeringGuid, Guid facilityGuid)
		{
			foreach (OfferingWithFacility offeringWithFacility in this.InnerList)
			{
				if (offeringWithFacility.OfferingGuid == offeringGuid && offeringWithFacility.FacilityGuid == facilityGuid)
					return offeringWithFacility;
			}
			return null;
		}
		#endregion

		#region IHierarchicalList Members

		/// <summary>
		/// Gets the item type.
		/// </summary>
		public Type ItemType
		{
			get { return typeof(OfferingWithFacility); }
		}

		#endregion

		#region IObjectRelations Members

		/// <summary>
		/// Gets the relations array from ObjectRelations.
		/// </summary>
		public ArrayList Relations
		{
			get
			{
				ArrayList relations = new ArrayList();

				relations.Add(new ISDataSourceObjectRelation(
					typeof(OfferingWithFacilityCollection), "FacilityGuid",
					"Offerings", typeof(OfferingCollection), "FacilityGuid"));

				return relations;
			}
		}

		#endregion
	}
}