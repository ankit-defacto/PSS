﻿/*  Generated by CodeGen written by Concord Mfg.
 * Transform file used: IJoinGateway (v0.2.0.0).xslt
 * Date generated: 3/28/2012 12:45:59 PM
 * CodeGen version: 0.2.0.0  */

using System;
using System.Linq;

namespace ConcordMfg.PremierSeniorSolutions.WebService.DataAccess
{
	public interface ICityStateZipWithFacilityGateway
	{
		IQueryable<CityStateZipWithFacility> GetAll();
		IQueryable<CityStateZipWithFacility> GetByCityStateZipGuid(Guid cityStateZipGuid);
		IQueryable<CityStateZipWithFacility> GetByFacilityGuid(Guid facilityGuid);
		void Update(CityStateZipWithFacility entity);

	}
}