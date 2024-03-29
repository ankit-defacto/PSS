﻿/*  Generated by CodeGen written by Concord Mfg.
 *  Transform file used: BEServiceContract (v0.0.7.0).xslt
 *  Date generated: 3/28/2012 12:46:09 PM
 *  CodeGen version: 0.1.0.0  */

using System;
using System.ServiceModel;

namespace ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts
{
    [ServiceContract(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01",
        Name = "ICityStateZip", SessionMode = SessionMode.Allowed)]
    public interface ICityStateZip
    {
        /// <summary>
        /// Implementation of this method gets all cityStateZip objects.
        /// </summary>
        /// <returns>All cityStateZip objects.</returns>
        /// <remarks>This method is an operations contract.</remarks>
        [FaultContract(typeof(ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts.DefaultFaultContract))]
        [OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "GetAllCityStateZip")]
        System.Collections.Generic.List<ConcordMfg.PremierSeniorSolutions.WebService.DataContracts.CityStateZip> GetAllCityStateZip();

        /// <summary>
        /// Implementation of this method gets all cityStateZip objects plus an undefined cityStateZip.
        /// </summary>
        /// <returns>All cityStateZip objects.</returns>
        /// <remarks>This method is an operations contract.</remarks>
        [FaultContract(typeof(ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts.DefaultFaultContract))]
        [OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "GetAllCityStateZipWithUndefined")]
        System.Collections.Generic.List<ConcordMfg.PremierSeniorSolutions.WebService.DataContracts.CityStateZip> GetAllCityStateZipWithUndefined();

        /// <summary>
        /// Implementation of this method gets the cityStateZip object given a cityStateZip identifier.
        /// </summary>
		/// <param name="cityStateZipGuid">City State Zip Guid</param>
        /// <returns>The cityStateZip object.</returns>
        /// <remarks>This method is an operations contract.</remarks>
        [FaultContract(typeof(ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts.CityStateZipFault))]
        [OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "GetCityStateZipByCityStateZipGuid")]
        ConcordMfg.PremierSeniorSolutions.WebService.DataContracts.CityStateZip GetCityStateZipByCityStateZipGuid(Guid cityStateZipGuid);

        /// <summary>
        /// Implementation of this method inserts a cityStateZip object.
        /// </summary>
        /// <param name="cityStateZip">The cityStateZip object to insert.</param>
        /// <remarks>This method is an operations contract.</remarks>
        [FaultContract(typeof(ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts.DefaultFaultContract))]
        [OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "InsertCityStateZip")]
        void InsertCityStateZip(ConcordMfg.PremierSeniorSolutions.WebService.DataContracts.CityStateZip cityStateZip);

        /// <summary>
        /// Implementation of this method updates a cityStateZip object.
        /// </summary>
        /// <param name="cityStateZip">The cityStateZip object to update.</param>
        /// <remarks>This method is an operations contract.</remarks>
        [FaultContract(typeof(ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts.DefaultFaultContract))]
        [OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "UpdateCityStateZip")]
        void UpdateCityStateZip(ConcordMfg.PremierSeniorSolutions.WebService.DataContracts.CityStateZip cityStateZip);

        /// <summary>
        /// Implementation of this method deletes a cityStateZip object.
        /// </summary>
        /// <param name="cityStateZip">The cityStateZip object to delete.</param>
        /// <remarks>This method is an operations contract.</remarks>
        [FaultContract(typeof(ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts.DefaultFaultContract))]
        [OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "DeleteCityStateZip")]
        void DeleteCityStateZip(ConcordMfg.PremierSeniorSolutions.WebService.DataContracts.CityStateZip cityStateZip);

        /// <summary>
        /// Implementation of this method gets a list of cityStateZips associated to a facility.
        /// </summary>
		/// <param name="facilityGuid">Facility Guid</param>
        /// <returns>The list of cityStateZips associated with the facility.</returns>
        /// <remarks><para>The return value does not include the facility identifier.</para>
        /// <para>This method is an operations contract.</para></remarks>
        [FaultContract(typeof(ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts.FacilityFault))]
        [OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "GetCityStateZipsForFacility")]
        System.Collections.Generic.List<ConcordMfg.PremierSeniorSolutions.WebService.DataContracts.CityStateZip> GetCityStateZipsForFacility(Guid facilityGuid);

        /// <summary>
        /// Implementation of this method gets list of cityStateZips not associated with a facility.
        /// </summary>
		/// <param name="facilityGuid">Facility Guid</param>
        /// <returns>The list of cityStateZips not associated with the facility.</returns>
        /// <remarks><para>The return value does not include the facility identifier.</para>
        /// <para>This method is an operations contract.</para></remarks>
        [FaultContract(typeof(ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts.FacilityFault))]
        [OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "GetCityStateZipsNotForFacility")]
        System.Collections.Generic.List<ConcordMfg.PremierSeniorSolutions.WebService.DataContracts.CityStateZip> GetCityStateZipsNotForFacility(Guid facilityGuid);

        /// <summary>
        /// Implementation of this method associates a cityStateZip to a facility.
        /// </summary>
		/// <param name="cityStateZipGuid">City State Zip Guid</param>
		/// <param name="facilityGuid">Facility Guid</param>
        /// <remarks>This method is an operations contract.</remarks>
        [FaultContract(typeof(ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts.FacilityLocationCriteriaFault))]
        [OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "AddFacilityToCityStateZip")]
        void AddFacilityToCityStateZip(Guid cityStateZipGuid, Guid facilityGuid);

        /// <summary>
        /// Implementation of this method deletes an association of cityStateZip to a facility.
        /// </summary>
		/// <param name="cityStateZipGuid">City State Zip Guid</param>
		/// <param name="facilityGuid">Facility Guid</param>
        /// <remarks>This method is an operations contract.</remarks>
        [FaultContract(typeof(ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts.FacilityLocationCriteriaFault))]
        [OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "DeleteFacilityFromCityStateZip")]
        void DeleteFacilityFromCityStateZip(Guid cityStateZipGuid, Guid facilityGuid);
	}
}
	