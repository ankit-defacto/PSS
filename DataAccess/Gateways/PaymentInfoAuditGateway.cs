﻿/*  Generated by CodeGen written by Concord Mfg.
 * Transform file used: BEGateway (v0.2.0.0).xslt
 * Date generated: 3/28/2012 12:46:00 PM
 * CodeGen version: 0.2.0.0  */

using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConcordMfg.PremierSeniorSolutions.WebService.DataAccess
{
	public class PaymentInfoAuditGateway : GatewayBase, IPaymentInfoAuditGateway
	{
		#region IPaymentInfoAuditGateway Members
		public IOrderedQueryable<PaymentInfoAudit> GetAll()
		{
			try
			{
				using (PSS2012DataContext context = this.DataContext)
				{
					return context.PaymentInfoAudits.OrderBy(paymentInfoAudit => paymentInfoAudit.AmazonToken);
				}
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				throw this.HandleSqlException(ex);
			}
		}

		public List<PaymentInfoAudit> GetAllWithUndefined()
		{
			PaymentInfoAudit undefinedPaymentInfoAudit = new PaymentInfoAudit()
			{
				PaymentInfoAuditGuid = Guid.Empty,
				PaymentInfoGuid = Guid.Empty,
				PaymentInfoID = 0,
				AmazonToken = "Undefined",
				DateModified = default(DateTime),
			};

			List<PaymentInfoAudit> response = this.GetAll().ToList();
			response.Add(undefinedPaymentInfoAudit);

			return response;
		}

		public PaymentInfoAudit GetByPK(Guid paymentInfoAuditGuid)
		{
			if (Guid.Empty == paymentInfoAuditGuid)
			{ return new PaymentInfoAudit(); }

			try
			{
				PaymentInfoAudit daPaymentInfoAudit = new PaymentInfoAudit();
				using (PSS2012DataContext context = this.DataContext)
				{
					daPaymentInfoAudit = (
						from items in context.PaymentInfoAudits
						where items.PaymentInfoAuditGuid == paymentInfoAuditGuid
						select items).SingleOrDefault();
				}

				if (null == daPaymentInfoAudit)
				{
					throw new DataAccessException("PaymentInfoAudit no longer exists.");
				}

				return daPaymentInfoAudit;
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				throw this.HandleSqlException(ex);
			}
		}

		/// <summary>
		/// Inserts paymentInfoAudit business entity into the data store.
		/// </summary>
		/// <param name="entity">The paymentInfoAudit business entity to insert.</param>
		/// <returns>The paymentInfoAudit identifier.</returns>
		public PaymentInfoAudit Insert(PaymentInfoAudit entity)
		{
			//@@NEW - changed return type to entity type.
			try
			{
				using (PSS2012DataContext context = DataContext)
				{
					entity.PaymentInfoAuditGuid = Guid.NewGuid();
					//@@NEW - atuo assign values.
					entity.DateModified = DateTime.Now;

					context.PaymentInfoAudits.InsertOnSubmit(entity);
					context.SubmitChanges();
				}

				//@@NEW - returning full entity.
				return entity;
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				throw this.HandleSqlException(ex);
			}
		}

		//@@NEW - These methods don't belong in an Audit table.
		//public void Update(PaymentInfoAudit entity)
		//{
		//    if (Guid.Empty == entity.PaymentInfoAuditGuid)
		//        throw new PrimaryKeyMissingException("PaymentInfoAudit", entity, "update");

		//    try
		//    {
		//        using (PSS2012DataContext context = DataContext)
		//        {
		//            // Get the entity to update.
		//            PaymentInfoAudit paymentInfoAuditToUpdate = GetByPK(entity.PaymentInfoAuditGuid);


		//            // Set the new values.
		//            paymentInfoAuditToUpdate.PaymentInfoGuid = entity.PaymentInfoGuid;
		//            paymentInfoAuditToUpdate.PaymentInfoID = entity.PaymentInfoID;
		//            paymentInfoAuditToUpdate.AmazonToken = entity.AmazonToken;
		//            paymentInfoAuditToUpdate.DateModified = entity.DateModified;

		//            // Perform the update.
		//            context.SubmitChanges();
		//        }
		//    }
		//    catch (System.Data.SqlClient.SqlException ex)
		//    {
		//        throw this.HandleSqlException(ex);
		//    }
		//    catch (Exception ex)
		//    {
		//        throw ex;
		//    }
		//}

		//public void Delete(Guid paymentInfoAuditGuid)
		//{
		//    if (Guid.Empty == paymentInfoAuditGuid)
		//        throw new PrimaryKeyMissingException("PaymentInfoAudit", paymentInfoAuditGuid, "delete");


		//    try
		//    {
		//        using (PSS2012DataContext context = DataContext)
		//        {
		//            // Get the entity to delete.
		//            PaymentInfoAudit paymentInfoAuditToDelete = GetByPK(paymentInfoAuditGuid);

		//            // Peform the delete.
		//            context.PaymentInfoAudits.DeleteOnSubmit(paymentInfoAuditToDelete);
		//            context.SubmitChanges();
		//        }
		//    }
		//    catch (System.Data.SqlClient.SqlException ex)
		//    {
		//        throw this.HandleSqlException(ex);
		//    }
		//    catch (Exception ex)
		//    {
		//        throw ex;
		//    }
		//}

		public IOrderedQueryable<PaymentInfoAudit> GetForPaymentInfoByPaymentInfoGuid(Guid paymentInfoGuid)
		{
			try
			{
				using (PSS2012DataContext context = DataContext)
				{
					// Get the entity to delete.
					return
						(from items in context.PaymentInfoAudits
						 where items.PaymentInfoGuid == paymentInfoGuid
						 select items).OrderBy(paymentInfoAudit => paymentInfoAudit.AmazonToken);
				}
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				throw this.HandleSqlException(ex);
			}
		}
		#endregion


		#region Private Handle Exception Methods
		private Exception HandleSqlException(System.Data.SqlClient.SqlException ex)
		{
			if (ex.Message.Contains("An error has occurred while establishing a connection to the server.  When connecting to SQL Server 2005, this failure may be caused by the fact that under the default settings SQL Server does not allow remote connections."))
			{
				return new Exception("Could not establish a connection to SQL Server. See inner exception for more details. Perhaps Windows Firewall has blocked the connection to SQL Server. Check online resources to find out how to allow port exceptions.", ex);
			}
			else if (ex.Message.Contains("Invalid object name 'dbo.PaymentInfoAudit'"))
			{
				return new TableDoesNotExistException("PSS2012", "PaymentInfoAudit", ex);
			}
			else if (ex.Message.Contains("Invalid column name"))
			{
				return new ColumnDoesNotExistException("PSS2012", "PaymentInfoAudit", ex);
			}
			else if (ex.Message.Contains("String or binary data would be truncated"))
			{
				return new DataAccessException("String or number is too long or too big for the database.", ex);
			}
			else if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
			{
				Regex errorRx = new Regex("The DELETE statement conflicted with the REFERENCE constraint \"(?<constraint>[\\x20-\\x7E-[\"]]{1,})\". The conflict occurred in database \"(?<db>[\\x20-\\x7E-[\"]]{1,50})\", table \"dbo.(?<jtn>[\\x20-\\x7E-[\"]]{1,50})\"");
				Match errorMatch = errorRx.Match(ex.Message);
				if (errorMatch.Success)
				{
					return new RowReferencedElsewhereException(errorMatch.Groups["db"].Value, "PaymentInfoAudit", errorMatch.Groups["jtn"].Value, ex);
				}
				else
				{ return ex; }
			}
			else
			{
				return ex;
			}
		}
		#endregion
	}
}