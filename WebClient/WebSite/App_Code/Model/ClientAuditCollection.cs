﻿/*  Generated by CodeGen written by Concord Mfg.
 * Transform file used: BECollection (v0.1.0.0).xslt
 * Date generated: 3/28/2012 12:46:15 PM
 * CodeGen version: 0.1.0.0  */

using System;
using System.Collections;
using System.Collections.Generic;
using ISNet.WebUI.DataSource;
using ConcordMfg.PremierSeniorSolutions.WebService.Client.ClientAuditSvc;

namespace ConcordMfg.PremierSeniorSolutions.Client.Models
{
	/// <summary>
	/// The collection of ClientAudit.
	/// </summary>
	public class ClientAuditCollection : CollectionBase, IHierarchicalList, IObjectRelations
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the ClientAuditCollection class for the UI tier.
		/// </summary>
		public ClientAuditCollection()
		{
		}

		/// <summary>
		/// Initializes a new instance of the ClientAuditCollection class for the UI tier
		/// given a list of clientAudits.
		/// </summary>
		/// <param name="clientAudits">List of clientAudits.</param>
		public ClientAuditCollection(IEnumerable<ClientAudit> clientAudits)
		{
			foreach (ClientAudit clientAudit in clientAudits)
			{
				this.Add(clientAudit);
			}
		}

		#endregion

		#region Methods
		/// <summary>
		/// Adds a ClientAudit to the collection.
		/// </summary>
		/// <param name="clientAudit">The clientAudit to add.</param>
		public void Add(ClientAudit clientAudit)
		{
			//clientAudit.Owner = this;
			List.Add(clientAudit);
		}

		/// <summary>
		/// Removes ClientAudit at the index offset.
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
		/// Removes ClientAudit from the collection.
		/// </summary>
		/// <param name="clientAudit">The clientAudit to remove.</param>
		public void Remove(ClientAudit clientAudit)
		{
			List.Remove(clientAudit);
		}

		/// <summary>
		/// Gets ClientAudit at the index offset.
		/// </summary>
		/// <param name="index">The offset into the collection.</param>
		/// <returns>The clientAudit.</returns>
		public ClientAudit Item(int index)
		{
			return List[index] as ClientAudit;
		}

		/// <summary>
		/// Retrieves ClientAudit for clientAuditGuid.
		/// </summary>
		/// <param name="clientAuditGuid">Client Audit Guid</param>
		/// <returns>ClientAudit that contains the identifier.</returns>
		public ClientAudit FindByID(Guid clientAuditGuid)
		{
			foreach (ClientAudit clientAudit in this.InnerList)
			{
				if (clientAudit.ClientAuditGuid == clientAuditGuid)
					return clientAudit;
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
			get { return typeof(ClientAudit); }
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

				// Joins for Children


				return relations;
			}
		}

		#endregion
	}
}