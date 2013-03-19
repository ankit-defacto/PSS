﻿/*  Generated by CodeGen written by Concord Mfg.
 *  Transform file used: NamedBusinessEntity (v0.1.0.0).xslt
 *  Date generated: 3/28/2012 12:46:02 PM
 *  CodeGen version: 0.1.0.0  */

using System;
using System.Collections.Generic;

namespace ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities
{
    /// <summary>
    /// PaymentInfo Business Entity
    /// </summary>
    public partial class PaymentInfo : IComparer<PaymentInfo>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of PaymentInfo as a business entity.
        /// </summary>
        public PaymentInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of PaymentInfo as a business entity with its properties that are not auto assigned.
        /// </summary>
		/// <param name="paymentInfoGuid">Payment Info Guid</param>
		/// <param name="paymentInfoID">Payment Info ID</param>
		/// <param name="amazonToken">Amazon Token</param>
        public PaymentInfo(Guid paymentInfoGuid, int paymentInfoID, string amazonToken)
        {
			_paymentInfoGuid = paymentInfoGuid;
			_paymentInfoID = paymentInfoID;
			_amazonToken = amazonToken;
        }
        #endregion


        #region Overridden Methods
        public override string ToString()
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder();

            result.AppendFormat("PaymentInfoGuid: {0}. ", this.PaymentInfoGuid.ToString());
            result.AppendFormat("PaymentInfoID: {0}. ", this.PaymentInfoID.ToString());
            result.AppendFormat("AmazonToken: {0}. ", this.AmazonToken);

            return result.ToString();
        }
        #endregion


        #region IComparer<PaymentInfo> Members

        /// <summary>
        /// Compares two PaymentInfos. Compares PK and id fields separate from other fields.
        /// </summary>
        /// <param name="a">PaymentInfo A</param>
        /// <param name="b">PaymentInfo B</param>
        /// <returns>If the PK or ID are different, returns 1.
        /// If any other fields are different, returns -1.
        /// If all fields are identical, return 0.</returns>
        public int Compare(PaymentInfo a, PaymentInfo b)
        {
            if (a._paymentInfoGuid != b._paymentInfoGuid)
            { return 1; }

            if (a._paymentInfoID != b._paymentInfoID)
            { return 1; }

            if (a._amazonToken != b._amazonToken)
            { return -1; }

            return 0;
        }

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets or sets the Payment Info Guid.
        /// </summary>
		public Guid PaymentInfoGuid
		{
			get { return _paymentInfoGuid; }
			set { _paymentInfoGuid = value; }
		}
	
        /// <summary>
        /// Gets or sets the Payment Info ID.
        /// </summary>
		public int PaymentInfoID
		{
			get { return _paymentInfoID; }
			set { _paymentInfoID = value; }
		}
	
        /// <summary>
        /// Gets or sets the Amazon Token.
        /// </summary>
		public string AmazonToken
		{
			get { return _amazonToken; }
			set { _amazonToken = value; }
		}
	
        #endregion


        #region Private Fields

        /// <summary>
        /// The Payment Info Guid field.
        /// </summary>
		private Guid _paymentInfoGuid = Guid.Empty;

        /// <summary>
        /// The Payment Info ID field.
        /// </summary>
		private int _paymentInfoID = 0;

        /// <summary>
        /// The Amazon Token field.
        /// </summary>
		private string _amazonToken = null;

        #endregion
    }
  
}