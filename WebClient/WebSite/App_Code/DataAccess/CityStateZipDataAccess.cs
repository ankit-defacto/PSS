﻿/*  Generated by CodeGen written by Concord Mfg.
 *  Transform file used: BEDataAccess (v0.1.0.0).xslt
 *  Date generated: 3/28/2012 12:46:16 PM
 *  CodeGen version: 0.1.0.0  */

using System;
using System.ComponentModel;
using ConcordMfg.PremierSeniorSolutions.Client.Tools;
using SP = ConcordMfg.PremierSeniorSolutions.WebService.Client;

namespace ConcordMfg.PremierSeniorSolutions.Client.ViewModels
{
	/// <summary>
	/// Access the data for the CityStateZip class.
	/// </summary>
	// [DataObject]
	public partial class DataAccess
	{
		#region Fields
		private static SP.CityStateZipSvc.CityStateZipClient _cityStateZipClient =
			new SP.CityStateZipSvc.CityStateZipClient();
		#endregion


		#region Methods
		/// <summary>
		/// Retrieves CityStateZip from the web service.
		/// </summary>
		/// <returns>A list of all cityStateZip.</returns>
		[DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
		public static CityStateZipCollection GetCityStateZips()
		{
			// Call the service for data.
			SP.CityStateZipSvc.CityStateZip[] cityStateZips = _cityStateZipClient.GetAllCityStateZip();
			// Convert the service proxy object to a View Model object.
			CityStateZipCollection result = new CityStateZipCollection(cityStateZips.ToViewModels());
			return result;
		}

		/// <summary>
		/// Retrieves CityStateZip from the web service.
		/// </summary>
		/// <returns>A list of all cityStateZip.</returns>
		[DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
		public static CityStateZipCollection GetCityStateZipsWithUndefined()
		{
			// Call the service for data.
			SP.CityStateZipSvc.CityStateZip[] cityStateZips = _cityStateZipClient.GetAllCityStateZipWithUndefined();
			// Convert the service proxy object to a View Model object.
			CityStateZipCollection result = new CityStateZipCollection(cityStateZips.ToViewModels());
			return result;
		}

		/// <summary>
		/// Retrieves a CityStateZip from the web service.
		/// </summary>
		/// <param name="cityStateZipGuidStr">The identifier of the CityStateZip to retrieve.</param>
		/// <returns>A CityStateZip.</returns>
		[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
		public static CityStateZip GetCityStateZip(string cityStateZipGuidStr)
		{
			// Convert the string into a guid.
			Guid cityStateZipGuid = new Guid(cityStateZipGuidStr);
			// Call the sister method.
			return GetCityStateZip(cityStateZipGuid);
		}

		/// <summary>
		/// Retrieves a CityStateZip from the web service.
		/// </summary>
		/// <param name="cityStateZipGuid">The identifier of the CityStateZip to retrieve.</param>
		/// <returns>A CityStateZip.</returns>
		[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
		public static CityStateZip GetCityStateZip(Guid cityStateZipGuid)
		{
			// Call the service for data.
			SP.CityStateZipSvc.CityStateZip cityStateZip = _cityStateZipClient.GetCityStateZipByCityStateZipGuid(cityStateZipGuid);
			// Convert and return the service proxy object to a view model object.
			return cityStateZip.ToViewModel();
		}

		/// <summary>
		/// Inserts CityStateZip through the web service.
		/// </summary>
		/// <param name="cityStateZip">CityStateZip to insert.</param>
		/// <returns>1, if the insert was successful; otherwise, 0.</returns>
		[DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
		public static int InsertCityStateZip(CityStateZipViewModel cityStateZip)
		{
			if (null == cityStateZip)
			{
				throw new Exception("Cannot insert CityStateZip. The cityStateZip object was null. Cannot be empty.");
			}

			try
			{
				// Convert the view model object to a service proxy object.
				SP.CityStateZipSvc.CityStateZip request = cityStateZip.ToModel();

				// Call the service insert method.
				_cityStateZipClient.InsertCityStateZip(request);

				return 1;
			}
			catch (System.ServiceModel.FaultException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		[DataObjectMethod(DataObjectMethodType.Insert)]
		public static int InsertCityStateZip(string city, string state, string zipCode)
		{
			try 
			{
				// Create the service proxy object and populate it.
				SP.CityStateZipSvc.CityStateZip request = new SP.CityStateZipSvc.CityStateZip();

				request.CityStateZipGuid = Guid.Empty;
				request.City = city;
				request.State = state;
				request.ZipCode = zipCode;

				// Call the service insert method.
				_cityStateZipClient.InsertCityStateZip(request);

				return 1;
			}
			catch (System.ServiceModel.FaultException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Updates CityStateZip through the web service.
		/// </summary>
		/// <param name="cityStateZip">CityStateZip to update.</param>
		/// <returns>1, if the update was successful; otherwise, 0.</returns>
		[DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
		public static int UpdateCityStateZip(CityStateZipViewModel cityStateZip)
		{
			try
			{
				// Convert the view model object to a service proxy object.
				SP.CityStateZipSvc.CityStateZip request = cityStateZip.ToModel();

				// Call the service update method.
				_cityStateZipClient.UpdateCityStateZip(request);

				return 1;
			}
			catch (System.ServiceModel.FaultException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Deletes CityStateZip through the web service.
		/// </summary>
		/// <param name="cityStateZip">CityStateZip to delete.</param>
		/// <returns>1, if the delete was successful; otherwise, 0.</returns>
		[DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
		public static int DeleteCityStateZip(CityStateZipViewModel cityStateZip)
		{
			try
			{
				// Convert the view model object to a service proxy object.
				SP.CityStateZipSvc.CityStateZip request = cityStateZip.ToModel();

				// Call the service delete method.
				_cityStateZipClient.DeleteCityStateZip(request);

				return 1;
			}
			catch (System.ServiceModel.FaultException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		#endregion


		#region Facility Methods
		/// <summary>
		/// Retrieves Facility for a CityStateZip from the web service.
		/// </summary>
		/// <returns>A list of cityStateZips of the facility.</returns>
		[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
		public static CityStateZipCollection GetCityStateZipsForFacility(string facilityGuidStr)
		{
			Guid facilityGuid = new Guid(facilityGuidStr);
			try
			{
				CityStateZipCollection result = DataAccess.GetCityStateZipsForFacility(facilityGuid);
				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Retrieves Facility for a CityStateZip from the web service.
		/// </summary>
		/// <param name="facilityGuid">Facility Guid</param>
		/// <returns>A list of cityStateZips of the facility.</returns>
		[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
		public static CityStateZipCollection GetCityStateZipsForFacility(Guid facilityGuid)
		{
			SP.CityStateZipSvc.CityStateZip[] cityStateZips = _cityStateZipClient.GetCityStateZipsForFacility(facilityGuid);
			CityStateZipCollection result = new CityStateZipCollection(cityStateZips.ToViewModels());
		return result;
		}

		/// <summary>
		/// Retrieves CityStateZips for a Facility from the web service.
		/// </summary>
		/// <param name="facilityGuid">Facility Guid</param>
		/// <returns>A list of cityStateZips not of the facility.</returns>
		[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
		public static CityStateZipCollection GetCityStateZipsNotForFacility(Guid facilityGuid)
		{
			SP.CityStateZipSvc.CityStateZip[] cityStateZips = _cityStateZipClient.GetCityStateZipsNotForFacility(facilityGuid);
			CityStateZipCollection result = new CityStateZipCollection(cityStateZips.ToViewModels());
			return result;
		}

		
		/// <summary>
		/// Adds a facility to the cityStateZip.
		/// </summary>
		/// <param name="cityStateZipGuid">City State Zip Guid</param>
		/// <param name="facilityGuid">Facility Guid</param>
		/// <returns>true, if successful; otherwise, false.</returns>
		public static bool AddFacilityToCityStateZip(Guid cityStateZipGuid, Guid facilityGuid)
		{
			try
			{
				_cityStateZipClient.AddFacilityToCityStateZip(cityStateZipGuid, facilityGuid);
				return true;
			}
			catch (System.ServiceModel.FaultException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Deletes a facility from a cityStateZip.
		/// </summary>
		/// <param name="cityStateZipGuid">City State Zip Guid</param>
		/// <param name="facilityGuid">Facility Guid</param>
		/// <returns>true, if successful; otherwise, false.</returns>
		public static bool DeleteFacilityFromCityStateZip(Guid cityStateZipGuid, Guid facilityGuid)
		{
			try
			{
				_cityStateZipClient.DeleteFacilityFromCityStateZip(cityStateZipGuid, facilityGuid);
				return true;
			}
			catch (System.ServiceModel.FaultException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		#endregion

	}
}