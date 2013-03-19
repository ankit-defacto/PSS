﻿/*  Generated by CodeGen written by Concord Mfg.
 * Transform file used: BEException (v0.1.0.0).xslt
 * Date generated: 3/28/2012 12:46:03 PM
 * CodeGen version: 0.1.0.0  */

using System;

namespace ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities
{
	public class CityStateZipException : Exception
	{
		protected CityStateZipException()
			: this(null, null)
		{ }

		protected CityStateZipException(string message)
			: this(message, null)
		{ }

		protected CityStateZipException(string message, CityStateZip cityStateZip)
			: base(message)
		{
			this.CityStateZip = cityStateZip;
		}

		public CityStateZip CityStateZip
		{
			get;
			set;
		}
	}

	public class CityStateZipNotFoundException : CityStateZipException
	{
		public CityStateZipNotFoundException(Guid cityStateZipGuid)
			: base()
		{
			this.CityStateZipGuid = cityStateZipGuid;
		}

		public override string Message
		{
			get
			{
				return string.Format("Could not find CityStateZip in the database with the following IDs: CityStateZipGuid:{0}.", CityStateZipGuid);
			}
		}

		public Guid CityStateZipGuid
		{
			get;
			set;
		}
	}

	public class CityStateZipAlreadyExistsException : CityStateZipException
	{
		public CityStateZipAlreadyExistsException(CityStateZip cityStateZip)
			: base(null, cityStateZip)
		{ }

		public override string Message
		{
			get
			{
				return string.Format("CityStateZip already exists in the database: {0}", CityStateZip.ToString());
			}
		}
	}
}
	