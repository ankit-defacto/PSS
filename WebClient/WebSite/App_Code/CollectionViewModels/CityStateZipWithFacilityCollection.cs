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
	/// The collection of CityStateZipWithFacility.
	/// </summary>
	public class CityStateZipWithFacilityCollection : CollectionBase, IHierarchicalList, IObjectRelations
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the CityStateZipWithFacilityCollection class for the UI tier.
		/// </summary>
		public CityStateZipWithFacilityCollection()
		{
		}

		/// <summary>
		/// Initializes a new instance of the CityStateZipWithFacilityCollection class for the UI tier
		/// given a list of cityStateZipsWithFacility.
		/// </summary>
		/// <param name="cityStateZipWithFacilityList">The cityStateZipsWithFacility.</param>
		public CityStateZipWithFacilityCollection(IEnumerable<CityStateZipWithFacility> cityStateZipWithFacilityList)
		{
			foreach (CityStateZipWithFacility cityStateZipWithFacility in cityStateZipWithFacilityList)
			{
				this.Add(cityStateZipWithFacility);
			}
		}

		#endregion

		#region Methods
		/// <summary>
		/// Adds a CityStateZipWithFacility to the collection.
		/// </summary>
		/// <param name="cityStateZipWithFacility">The cityStateZipWithFacility to add.</param>
		public void Add(CityStateZipWithFacility cityStateZipWithFacility)
		{
			//cityStateZipWithFacility.Owner = this;
			List.Add(cityStateZipWithFacility);
		}

		/// <summary>
		/// Removes CityStateZipWithFacility at the index offset.
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
		/// Removes CityStateZipWithFacility from the collection.
		/// </summary>
		/// <param name="cityStateZipWithFacility">The cityStateZipWithFacility to remove.</param>
		public void Remove(CityStateZipWithFacility cityStateZipWithFacility)
		{
			List.Remove(cityStateZipWithFacility);
		}

		/// <summary>
		/// Gets CityStateZipWithFacility at the index offset.
		/// </summary>
		/// <param name="index">The offset into the collection.</param>
		/// <returns>The cityStateZipWithFacility.</returns>
		public CityStateZipWithFacility Item(int index)
		{
			return List[index] as CityStateZipWithFacility;
		}

		/// <summary>
		/// Retrieves CityStateZipWithFacility for .
		/// </summary>
		
		/// <param name="cityStateZipGuid">City State Zip Guid</param>
		/// <param name="facilityGuid">Facility Guid</param>
		/// <returns>CityStateZipWithFacility that contains the identifiers.</returns>
		public CityStateZipWithFacility FindByID(Guid cityStateZipGuid, Guid facilityGuid)
		{
			foreach (CityStateZipWithFacility cityStateZipWithFacility in this.InnerList)
			{
				if (cityStateZipWithFacility.CityStateZipGuid == cityStateZipGuid && cityStateZipWithFacility.FacilityGuid == facilityGuid)
					return cityStateZipWithFacility;
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
			get { return typeof(CityStateZipWithFacility); }
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
					typeof(CityStateZipWithFacilityCollection), "FacilityGuid",
					"CityStateZips", typeof(CityStateZipCollection), "FacilityGuid"));

				return relations;
			}
		}

		#endregion
	}
}