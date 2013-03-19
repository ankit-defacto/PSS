﻿/*  Generated by CodeGen written by Concord Mfg.
 *  Transform file used: BEServiceImplementation (v0.1.0.0).xslt
 *  Date generated: 3/28/2012 12:46:11 PM
 *  CodeGen version: 0.1.0.0  */

using System;
using System.Collections.Generic;
using System.ServiceModel;
using BE = ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;
using BL = ConcordMfg.PremierSeniorSolutions.WebService.BusinessLogic;
using DC = ConcordMfg.PremierSeniorSolutions.WebService.DataContracts;
using FC = ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts;
using SC = ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts;
using ConcordMfg.PremierSeniorSolutions.WebService.EntityConversions;


namespace ConcordMfg.PremierSeniorSolutions.WebService.ServiceImplementation
{
	[ServiceBehavior(Name = "PaymentInfoAudit", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01")]
	public class PaymentInfoAudit : SC.IPaymentInfoAudit
	{
		#region IPaymentInfoAudit Members
		public List<DC.PaymentInfoAudit> GetAllPaymentInfoAudit()
		{
			try
			{
				BL.PaymentInfoAuditLogic paymentInfoAuditLogic = new BL.PaymentInfoAuditLogic();
				List<BE.PaymentInfoAudit> entities = paymentInfoAuditLogic.GetAllPaymentInfoAudit();
				List<DC.PaymentInfoAudit> response = entities.ToDataContractList();
				return response;
			}
			catch (Exception ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = "Unable to retrieve paymentInfoAudit data.";
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		public List<DC.PaymentInfoAudit> GetAllPaymentInfoAuditWithUndefined()
		{
			try
			{
				BL.PaymentInfoAuditLogic paymentInfoAuditLogic = new BL.PaymentInfoAuditLogic();
				List<BE.PaymentInfoAudit> entities = paymentInfoAuditLogic.GetAllPaymentInfoAuditWithUndefined();
				List<DC.PaymentInfoAudit> response = entities.ToDataContractList();
				return response;
			}
			catch (Exception ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = "Unable to retrieve paymentInfoAudit data.";
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		public DC.PaymentInfoAudit GetPaymentInfoAuditByPaymentInfoAuditGuid(Guid paymentInfoAuditGuid)
		{
			try
			{
				BL.PaymentInfoAuditLogic paymentInfoAuditLogic = new BL.PaymentInfoAuditLogic();
				BE.PaymentInfoAudit entity = paymentInfoAuditLogic.GetPaymentInfoAuditByPaymentInfoAuditGuid(paymentInfoAuditGuid);
				DC.PaymentInfoAudit response = entity.ToDataContract();
				return response;
			}
			catch (BE.PaymentInfoAuditNotFoundException ex)
			{
				FC.PaymentInfoAuditFault fault = new FC.PaymentInfoAuditFault();
				fault.PaymentInfoAuditGuid = ex.PaymentInfoAuditGuid;
				fault.ErrorMessage = "PaymentInfoAudit does not exsist in the database.";
				throw new FaultException<FC.PaymentInfoAuditFault>(fault,
					new FaultReason(ex.Message));
			}
			catch (Exception ex)
			{
				FC.PaymentInfoAuditFault fault = new FC.PaymentInfoAuditFault();
				fault.ErrorMessage = "Could not retrieve a specific PaymentInfoAudit for unknown reasons.";
				throw new FaultException<FC.PaymentInfoAuditFault>(fault,
					new FaultReason(ex.Message));
			}
		}

		public void InsertPaymentInfoAudit(DC.PaymentInfoAudit request)
		{
			try
			{
				BL.PaymentInfoAuditLogic paymentInfoAuditLogic = new BL.PaymentInfoAuditLogic();
				BE.PaymentInfoAudit entity = request.ToBusinessEntity();
				paymentInfoAuditLogic.InsertPaymentInfoAudit(entity);
			}
			catch (BE.PaymentInfoAuditAlreadyExistsException ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = String.Format(
					"Unable to insert Payment Info Audit data. Data: {0}",
					request.ToBusinessEntity().ToString());
	
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		public void UpdatePaymentInfoAudit(DC.PaymentInfoAudit request)
		{
			try
			{
				BL.PaymentInfoAuditLogic paymentInfoAuditLogic = new BL.PaymentInfoAuditLogic();
				BE.PaymentInfoAudit entity = request.ToBusinessEntity();
				paymentInfoAuditLogic.UpdatePaymentInfoAudit(entity);
			}
			catch (BE.PaymentInfoAuditNotFoundException ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = String.Format(
					"Unable to update Payment Info Audit data. Data: {0}",
					request.ToBusinessEntity().ToString());
	
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		public void DeletePaymentInfoAudit(DC.PaymentInfoAudit request)
		{
			try
			{
				BL.PaymentInfoAuditLogic paymentInfoAuditLogic = new BL.PaymentInfoAuditLogic();
				BE.PaymentInfoAudit entity = request.ToBusinessEntity();
				paymentInfoAuditLogic.DeletePaymentInfoAudit(entity);
			}
			catch (BE.PaymentInfoAuditNotFoundException ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = String.Format(
					"Unable to delete Payment Info Audit data. Data: {0}",
					request.ToBusinessEntity().ToString());
	
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		public List<DC.PaymentInfoAudit> GetPaymentInfoAuditsForPaymentInfoByPaymentInfoGuid(Guid paymentInfoGuid)
		{
			try
			{
				BL.PaymentInfoAuditLogic paymentInfoAuditLogic = new BL.PaymentInfoAuditLogic();
				List<BE.PaymentInfoAudit> entities = paymentInfoAuditLogic.GetPaymentInfoAuditsForPaymentInfoByPaymentInfoGuid(paymentInfoGuid);
				List<DC.PaymentInfoAudit> response = entities.ToDataContractList();
				return response;
			}
			catch (BE.PaymentInfoAuditException ex)
			{
				FC.DefaultFaultContract fault = new FC.DefaultFaultContract();
				fault.ErrorMessage = string.Format("Unable to find a PaymentInfoAudit with the given PaymentInfo");
				throw new FaultException<FC.DefaultFaultContract>(fault,
					new FaultReason(ex.Message));
			}
		}

		#endregion
	}
}