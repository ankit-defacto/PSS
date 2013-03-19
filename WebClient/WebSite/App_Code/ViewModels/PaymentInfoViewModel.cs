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
	/// View Model for Payment Info (PaymentInfo).
	/// </summary>
	public class PaymentInfoViewModel : NotifyPropertyChangedBaseWithOwner
	{
		#region Private Fields
		protected Guid _paymentInfoGuid = Guid.Empty;
		protected int _paymentInfoID = 0;
		protected string _amazonToken = null;


		#endregion


		#region Constructors
		public PaymentInfoViewModel()
		{
		}

		public PaymentInfoViewModel(Guid paymentInfoGuid, int paymentInfoID, string amazonToken)
		{
			this.PaymentInfoGuid = paymentInfoGuid;
			this.PaymentInfoID = paymentInfoID;
			this.AmazonToken = amazonToken;
		}
		#endregion


		#region Private GetAndSet Methods
		#endregion


		#region Public Properties

		public Guid PaymentInfoGuid
		{
			get { return _paymentInfoGuid; }
			set
			{
				_paymentInfoGuid = value;
				RaisePropertyChanged("PaymentInfoGuid");
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