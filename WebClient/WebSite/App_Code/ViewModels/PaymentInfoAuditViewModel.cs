﻿/*	Generated by CodeGen written by Concord Mfg
 *  Transform file used: BEViewModel (v0.1.0.0).xslt
 *  Date generated: 3/28/2012 12:46:16 PM
 *  CodeGen version: 0.1.0.0  */

using System;
using System.Collections.Generic;
using ConcordMfg.PremierSeniorSolutions.Client.Models;


namespace ConcordMfg.PremierSeniorSolutions.Client.ViewModels
{
	/// <summary>
	/// View Model for Payment Info Audit (PaymentInfoAudit).
	/// </summary>
	public class PaymentInfoAuditViewModel : NotifyPropertyChangedBaseWithOwner
	{
		#region Private Fields
		protected Guid _paymentInfoAuditGuid = Guid.Empty;
		protected Guid _paymentInfoGuid = Guid.Empty;
		protected int _paymentInfoID = 0;
		protected string _amazonToken = null;
		protected DateTime _dateModified = default(DateTime);

		private string _paymentInfoGuid_PaymentInfo_AmazonToken = null;

		private PaymentInfoViewModel _paymentInfoGuid_PaymentInfo = null;
		#endregion


		#region Constructors
		public PaymentInfoAuditViewModel()
		{
		}

		public PaymentInfoAuditViewModel(Guid paymentInfoAuditGuid, Guid paymentInfoGuid, int paymentInfoID, string amazonToken, DateTime dateModified)
		{
			this.PaymentInfoAuditGuid = paymentInfoAuditGuid;
			this.PaymentInfoGuid = paymentInfoGuid;
			this.PaymentInfoID = paymentInfoID;
			this.AmazonToken = amazonToken;
			this.DateModified = dateModified;
		}
		#endregion


		#region Private GetAndSet Methods

		private void GetAndSetPaymentInfoGuid_PaymentInfo(Guid paymentInfoGuid)
		{
			if (Guid.Empty != paymentInfoGuid &&
				(null == _paymentInfoGuid_PaymentInfo || _paymentInfoGuid_PaymentInfo.PaymentInfoGuid != paymentInfoGuid))
			{
				try
				{
					this.PaymentInfoGuid_PaymentInfo = DataAccess.GetPaymentInfo(paymentInfoGuid);
					this.PaymentInfoGuid_PaymentInfo_AmazonToken = _paymentInfoGuid_PaymentInfo.AmazonToken;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}
		#endregion


		#region Public Properties

		public Guid PaymentInfoAuditGuid
		{
			get { return _paymentInfoAuditGuid; }
			set
			{
				_paymentInfoAuditGuid = value;
				RaisePropertyChanged("PaymentInfoAuditGuid");
			}
		}

		public Guid PaymentInfoGuid
		{
			get { return _paymentInfoGuid; }
			set
			{
				_paymentInfoGuid = value;
				RaisePropertyChanged("PaymentInfoGuid");
				this.GetAndSetPaymentInfoGuid_PaymentInfo(value);
			}
		}

		public int PaymentInfoID
		{
			get { return _paymentInfoID; }
			set
			{
				_paymentInfoID = value;
				RaisePropertyChanged("PaymentInfoID");
			}
		}

		public string AmazonToken
		{
			get { return _amazonToken; }
			set
			{
				_amazonToken = value;
				RaisePropertyChanged("AmazonToken");
			}
		}

		public DateTime DateModified
		{
			get { return _dateModified; }
			set
			{
				_dateModified = value;
				RaisePropertyChanged("DateModified");
			}
		}

		public string PaymentInfoGuid_PaymentInfo_AmazonToken
		{
			get
			{ return _paymentInfoGuid_PaymentInfo_AmazonToken; }
			set
			{
				if (Guid.Empty != value)
				{
					_paymentInfoGuid_PaymentInfo_AmazonToken = value;
					RaisePropertyChanged("PaymentInfoGuid_PaymentInfo_AmazonToken");
				}
			}
		}

		/// <summary>
		/// Gets and sets Payment Info related through PaymentInfoGuid.
		/// </summary>
		public PaymentInfoViewModel PaymentInfoGuid_PaymentInfo
		{
			get
			{
				if (Guid.Empty != _paymentInfoGuid && null == _paymentInfoGuid_PaymentInfo)
				{ this.GetAndSetPaymentInfoGuid_PaymentInfo(_paymentInfoGuid); }
				return _paymentInfoGuid_PaymentInfo;
			}
			set
			{
				if (Guid.Empty != value)
				{
					_paymentInfoGuid_PaymentInfo = value;
					RaisePropertyChanged("PaymentInfoGuid_PaymentInfo");
				}
			}
		}

		public string PaymentInfoGuidPDC
		{
			get
			{
				if (null == this.PaymentInfoGuid_PaymentInfo || this.PaymentInfoGuid == Guid.Empty)
					return "*Unassigned*";
				return this.PaymentInfoGuid_PaymentInfo.PDC;
			}
			set { ; }
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
			return AmazonToken;
		}
		#endregion
	}
}