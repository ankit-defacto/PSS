﻿/*  Generated by CodeGen written by Concord Mfg.
 * Transform file used: MoreEntityConversion (v0.1.0.0).xslt
 * Date generated: 3/28/2012 12:46:12 PM
 * CodeGen version: 0.1.0.0  */

using System;
using System.Collections.Generic;
using BE = ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;
using DC = ConcordMfg.PremierSeniorSolutions.WebService.DataContracts;

namespace ConcordMfg.PremierSeniorSolutions.WebService.EntityConversions
{
	public static class MoreEntityConversion
	{
		#region CityStateZip DataContracts to BusinessEntities
		public static BE.CityStateZip ToBusinessEntity(this DC.CityStateZip dcCityStateZip)
		{
			BE.CityStateZip cityStateZipResult = new BE.CityStateZip()
			{
				CityStateZipGuid = dcCityStateZip.CityStateZipGuid,
				City = dcCityStateZip.City,
				State = dcCityStateZip.State,
				ZipCode = dcCityStateZip.ZipCode,
			};

			return cityStateZipResult;
		}

		public static List<BE.CityStateZip> ToBusinessEntitiesList(this IEnumerable<DC.CityStateZip> dcCityStateZipList)
		{
			List<BE.CityStateZip> businessEntityList = new List<BE.CityStateZip>();
			foreach (DC.CityStateZip dcCityStateZip in dcCityStateZipList)
			{
				businessEntityList.Add(dcCityStateZip.ToBusinessEntity());
			}

			return businessEntityList;
		}
		#endregion


		#region CityStateZip BusinessEntities to DataContracts
		public static DC.CityStateZip ToDataContract(this BE.CityStateZip beCityStateZip)
		{
			DC.CityStateZip cityStateZipResult = new DC.CityStateZip()
			{
				CityStateZipGuid = beCityStateZip.CityStateZipGuid,
				City = beCityStateZip.City,
				State = beCityStateZip.State,
				ZipCode = beCityStateZip.ZipCode,
			};

			return cityStateZipResult;
		}

		public static List<DC.CityStateZip> ToDataContractList(this IEnumerable<BE.CityStateZip> beCityStateZipList)
		{
			List<DC.CityStateZip> dataContractList = new List<DC.CityStateZip>();
			foreach (BE.CityStateZip dcCityStateZip in beCityStateZipList)
			{
				dataContractList.Add(dcCityStateZip.ToDataContract());
			}

			return dataContractList;
		}
		#endregion


		#region CityStateZipWithFacility DataContracts to BusinessEntities
		public static BE.CityStateZipWithFacility ToBusinessEntity(this DC.CityStateZipWithFacility dcCityStateZipWithFacility)
		{
			BE.CityStateZipWithFacility resultCityStateZipWithFacility = new BE.CityStateZipWithFacility()
			{
				CityStateZipGuid = dcCityStateZipWithFacility.CityStateZipGuid,
				City = dcCityStateZipWithFacility.City,
				State = dcCityStateZipWithFacility.State,
				ZipCode = dcCityStateZipWithFacility.ZipCode,
				Facility_FacilityGuid = dcCityStateZipWithFacility.Facility_FacilityGuid,
			};

			return resultCityStateZipWithFacility;
		}

		public static List<BE.CityStateZipWithFacility> ToBusinessEntitiesList(this IEnumerable<DC.CityStateZipWithFacility> dcCityStateZipWithFacilityList)
		{
			List<BE.CityStateZipWithFacility> businessEntityList = new List<BE.CityStateZipWithFacility>();
			foreach (DC.CityStateZipWithFacility dcCityStateZipWithFacility in dcCityStateZipWithFacilityList)
			{
				businessEntityList.Add(dcCityStateZipWithFacility.ToBusinessEntity());
			}

			return businessEntityList;
		}
		#endregion


		#region CityStateZipWithFacility BusinessEntities to DataContracts
		public static DC.CityStateZipWithFacility ToDataContract(this BE.CityStateZipWithFacility beCityStateZipWithFacility)
		{
			DC.CityStateZipWithFacility resultCityStateZipWithFacility = new DC.CityStateZipWithFacility()
			{
				CityStateZipGuid = beCityStateZipWithFacility.CityStateZipGuid,
				City = beCityStateZipWithFacility.City,
				State = beCityStateZipWithFacility.State,
				ZipCode = beCityStateZipWithFacility.ZipCode,
				Facility_FacilityGuid = beCityStateZipWithFacility.Facility_FacilityGuid,
			};

			return resultCityStateZipWithFacility;
		}

		public static List<DC.CityStateZipWithFacility> ToDataContractList(this IEnumerable<BE.CityStateZipWithFacility> beCityStateZipWithFacilityList)
		{
			List<DC.CityStateZipWithFacility> dataContractList = new List<DC.CityStateZipWithFacility>();
			foreach (BE.CityStateZipWithFacility dcCityStateZipWithFacility in beCityStateZipWithFacilityList)
			{
				dataContractList.Add(dcCityStateZipWithFacility.ToDataContract());
			}

			return dataContractList;
		}
		#endregion
		#region Click DataContracts to BusinessEntities
		public static BE.Click ToBusinessEntity(this DC.Click dcClick)
		{
			BE.Click clickResult = new BE.Click()
			{
				ClickGuid = dcClick.ClickGuid,
				FacilityGuid = dcClick.FacilityGuid,
				ListingTypeGuid = dcClick.ListingTypeGuid,
				TimeStamp = dcClick.TimeStamp,
			};

			return clickResult;
		}

		public static List<BE.Click> ToBusinessEntitiesList(this IEnumerable<DC.Click> dcClickList)
		{
			List<BE.Click> businessEntityList = new List<BE.Click>();
			foreach (DC.Click dcClick in dcClickList)
			{
				businessEntityList.Add(dcClick.ToBusinessEntity());
			}

			return businessEntityList;
		}
		#endregion


		#region Click BusinessEntities to DataContracts
		public static DC.Click ToDataContract(this BE.Click beClick)
		{
			DC.Click clickResult = new DC.Click()
			{
				ClickGuid = beClick.ClickGuid,
				FacilityGuid = beClick.FacilityGuid,
				ListingTypeGuid = beClick.ListingTypeGuid,
				TimeStamp = beClick.TimeStamp,
			};

			return clickResult;
		}

		public static List<DC.Click> ToDataContractList(this IEnumerable<BE.Click> beClickList)
		{
			List<DC.Click> dataContractList = new List<DC.Click>();
			foreach (BE.Click dcClick in beClickList)
			{
				dataContractList.Add(dcClick.ToDataContract());
			}

			return dataContractList;
		}
		#endregion

		#region Client DataContracts to BusinessEntities
		public static BE.Client ToBusinessEntity(this DC.Client dcClient)
		{
			BE.Client clientResult = new BE.Client()
			{
				ClientGuid = dcClient.ClientGuid,
				ClientID = dcClient.ClientID,
				ClientName = dcClient.ClientName,
				PhoneNumber = dcClient.PhoneNumber,
				Email = dcClient.Email,
				Address = dcClient.Address,
				CityStateZipGuid = dcClient.CityStateZipGuid,
				PaymentInfoGuid = dcClient.PaymentInfoGuid,
				FederatedID = dcClient.FederatedID,
				FederatedKey = dcClient.FederatedKey,
				FederatedIDProvider = dcClient.FederatedIDProvider,
				Username = dcClient.Username,
				HashedPassword = dcClient.HashedPassword,
			};

			return clientResult;
		}

		public static List<BE.Client> ToBusinessEntitiesList(this IEnumerable<DC.Client> dcClientList)
		{
			List<BE.Client> businessEntityList = new List<BE.Client>();
			foreach (DC.Client dcClient in dcClientList)
			{
				businessEntityList.Add(dcClient.ToBusinessEntity());
			}

			return businessEntityList;
		}
		#endregion


		#region Client BusinessEntities to DataContracts
		public static DC.Client ToDataContract(this BE.Client beClient)
		{
			DC.Client clientResult = new DC.Client()
			{
				ClientGuid = beClient.ClientGuid,
				ClientID = beClient.ClientID,
				ClientName = beClient.ClientName,
				PhoneNumber = beClient.PhoneNumber,
				Email = beClient.Email,
				Address = beClient.Address,
				CityStateZipGuid = beClient.CityStateZipGuid,
				PaymentInfoGuid = beClient.PaymentInfoGuid,
				FederatedID = beClient.FederatedID,
				FederatedKey = beClient.FederatedKey,
				FederatedIDProvider = beClient.FederatedIDProvider,
				Username = beClient.Username,
				HashedPassword = beClient.HashedPassword,
			};

			return clientResult;
		}

		public static List<DC.Client> ToDataContractList(this IEnumerable<BE.Client> beClientList)
		{
			List<DC.Client> dataContractList = new List<DC.Client>();
			foreach (BE.Client dcClient in beClientList)
			{
				dataContractList.Add(dcClient.ToDataContract());
			}

			return dataContractList;
		}
		#endregion

		#region ClientAudit DataContracts to BusinessEntities
		public static BE.ClientAudit ToBusinessEntity(this DC.ClientAudit dcClientAudit)
		{
			BE.ClientAudit clientAuditResult = new BE.ClientAudit()
			{
				ClientAuditGuid = dcClientAudit.ClientAuditGuid,
				ClientGuid = dcClientAudit.ClientGuid,
				ClientID = dcClientAudit.ClientID,
				ClientName = dcClientAudit.ClientName,
				PhoneNumber = dcClientAudit.PhoneNumber,
				Email = dcClientAudit.Email,
				Address = dcClientAudit.Address,
				CityStateZipGuid = dcClientAudit.CityStateZipGuid,
				PaymentInfoGuid = dcClientAudit.PaymentInfoGuid,
				FederatedID = dcClientAudit.FederatedID,
				FederatedKey = dcClientAudit.FederatedKey,
				FederatedIDProvider = dcClientAudit.FederatedIDProvider,
				Username = dcClientAudit.Username,
				HashedPassword = dcClientAudit.HashedPassword,
				DateModified = dcClientAudit.DateModified,
			};

			return clientAuditResult;
		}

		public static List<BE.ClientAudit> ToBusinessEntitiesList(this IEnumerable<DC.ClientAudit> dcClientAuditList)
		{
			List<BE.ClientAudit> businessEntityList = new List<BE.ClientAudit>();
			foreach (DC.ClientAudit dcClientAudit in dcClientAuditList)
			{
				businessEntityList.Add(dcClientAudit.ToBusinessEntity());
			}

			return businessEntityList;
		}
		#endregion


		#region ClientAudit BusinessEntities to DataContracts
		public static DC.ClientAudit ToDataContract(this BE.ClientAudit beClientAudit)
		{
			DC.ClientAudit clientAuditResult = new DC.ClientAudit()
			{
				ClientAuditGuid = beClientAudit.ClientAuditGuid,
				ClientGuid = beClientAudit.ClientGuid,
				ClientID = beClientAudit.ClientID,
				ClientName = beClientAudit.ClientName,
				PhoneNumber = beClientAudit.PhoneNumber,
				Email = beClientAudit.Email,
				Address = beClientAudit.Address,
				CityStateZipGuid = beClientAudit.CityStateZipGuid,
				PaymentInfoGuid = beClientAudit.PaymentInfoGuid,
				FederatedID = beClientAudit.FederatedID,
				FederatedKey = beClientAudit.FederatedKey,
				FederatedIDProvider = beClientAudit.FederatedIDProvider,
				Username = beClientAudit.Username,
				HashedPassword = beClientAudit.HashedPassword,
				DateModified = beClientAudit.DateModified,
			};

			return clientAuditResult;
		}

		public static List<DC.ClientAudit> ToDataContractList(this IEnumerable<BE.ClientAudit> beClientAuditList)
		{
			List<DC.ClientAudit> dataContractList = new List<DC.ClientAudit>();
			foreach (BE.ClientAudit dcClientAudit in beClientAuditList)
			{
				dataContractList.Add(dcClientAudit.ToDataContract());
			}

			return dataContractList;
		}
		#endregion

		#region Facility DataContracts to BusinessEntities
		public static BE.Facility ToBusinessEntity(this DC.Facility dcFacility)
		{
			BE.Facility facilityResult = new BE.Facility()
			{
				FacilityGuid = dcFacility.FacilityGuid,
				FacilityID = dcFacility.FacilityID,
				FacilityName = dcFacility.FacilityName,
				Exerpt = dcFacility.Exerpt,
				Description = dcFacility.Description,
				Address = dcFacility.Address,
				CityStateZipGuid = dcFacility.CityStateZipGuid,
				PhoneNumber = dcFacility.PhoneNumber,
				Email = dcFacility.Email,
				Website = dcFacility.Website,
				ClientGuid = dcFacility.ClientGuid,
				ListingTypeGuid = dcFacility.ListingTypeGuid,
				PublicPhotoFileUri = dcFacility.PublicPhotoFileUri,
			};

			return facilityResult;
		}

		public static List<BE.Facility> ToBusinessEntitiesList(this IEnumerable<DC.Facility> dcFacilityList)
		{
			List<BE.Facility> businessEntityList = new List<BE.Facility>();
			foreach (DC.Facility dcFacility in dcFacilityList)
			{
				businessEntityList.Add(dcFacility.ToBusinessEntity());
			}

			return businessEntityList;
		}
		#endregion


		#region Facility BusinessEntities to DataContracts
		public static DC.Facility ToDataContract(this BE.Facility beFacility)
		{
			DC.Facility facilityResult = new DC.Facility()
			{
				FacilityGuid = beFacility.FacilityGuid,
				FacilityID = beFacility.FacilityID,
				FacilityName = beFacility.FacilityName,
				Exerpt = beFacility.Exerpt,
				Description = beFacility.Description,
				Address = beFacility.Address,
				CityStateZipGuid = beFacility.CityStateZipGuid,
				PhoneNumber = beFacility.PhoneNumber,
				Email = beFacility.Email,
				Website = beFacility.Website,
				ClientGuid = beFacility.ClientGuid,
				ListingTypeGuid = beFacility.ListingTypeGuid,
				PublicPhotoFileUri = beFacility.PublicPhotoFileUri,
			};

			return facilityResult;
		}

		public static List<DC.Facility> ToDataContractList(this IEnumerable<BE.Facility> beFacilityList)
		{
			List<DC.Facility> dataContractList = new List<DC.Facility>();
			foreach (BE.Facility dcFacility in beFacilityList)
			{
				dataContractList.Add(dcFacility.ToDataContract());
			}

			return dataContractList;
		}
		#endregion


		#region FacilityWithCityStateZip DataContracts to BusinessEntities
		public static BE.FacilityWithCityStateZip ToBusinessEntity(this DC.FacilityWithCityStateZip dcFacilityWithCityStateZip)
		{
			BE.FacilityWithCityStateZip resultFacilityWithCityStateZip = new BE.FacilityWithCityStateZip()
			{
				FacilityGuid = dcFacilityWithCityStateZip.FacilityGuid,
				FacilityID = dcFacilityWithCityStateZip.FacilityID,
				FacilityName = dcFacilityWithCityStateZip.FacilityName,
				Exerpt = dcFacilityWithCityStateZip.Exerpt,
				Description = dcFacilityWithCityStateZip.Description,
				Address = dcFacilityWithCityStateZip.Address,
				CityStateZipGuid = dcFacilityWithCityStateZip.CityStateZipGuid,
				PhoneNumber = dcFacilityWithCityStateZip.PhoneNumber,
				Email = dcFacilityWithCityStateZip.Email,
				Website = dcFacilityWithCityStateZip.Website,
				ClientGuid = dcFacilityWithCityStateZip.ClientGuid,
				ListingTypeGuid = dcFacilityWithCityStateZip.ListingTypeGuid,
				PublicPhotoFileUri = dcFacilityWithCityStateZip.PublicPhotoFileUri,
				CityStateZip_CityStateZipGuid = dcFacilityWithCityStateZip.CityStateZip_CityStateZipGuid,
			};

			return resultFacilityWithCityStateZip;
		}

		public static List<BE.FacilityWithCityStateZip> ToBusinessEntitiesList(this IEnumerable<DC.FacilityWithCityStateZip> dcFacilityWithCityStateZipList)
		{
			List<BE.FacilityWithCityStateZip> businessEntityList = new List<BE.FacilityWithCityStateZip>();
			foreach (DC.FacilityWithCityStateZip dcFacilityWithCityStateZip in dcFacilityWithCityStateZipList)
			{
				businessEntityList.Add(dcFacilityWithCityStateZip.ToBusinessEntity());
			}

			return businessEntityList;
		}
		#endregion


		#region FacilityWithCityStateZip BusinessEntities to DataContracts
		public static DC.FacilityWithCityStateZip ToDataContract(this BE.FacilityWithCityStateZip beFacilityWithCityStateZip)
		{
			DC.FacilityWithCityStateZip resultFacilityWithCityStateZip = new DC.FacilityWithCityStateZip()
			{
				FacilityGuid = beFacilityWithCityStateZip.FacilityGuid,
				FacilityID = beFacilityWithCityStateZip.FacilityID,
				FacilityName = beFacilityWithCityStateZip.FacilityName,
				Exerpt = beFacilityWithCityStateZip.Exerpt,
				Description = beFacilityWithCityStateZip.Description,
				Address = beFacilityWithCityStateZip.Address,
				CityStateZipGuid = beFacilityWithCityStateZip.CityStateZipGuid,
				PhoneNumber = beFacilityWithCityStateZip.PhoneNumber,
				Email = beFacilityWithCityStateZip.Email,
				Website = beFacilityWithCityStateZip.Website,
				ClientGuid = beFacilityWithCityStateZip.ClientGuid,
				ListingTypeGuid = beFacilityWithCityStateZip.ListingTypeGuid,
				PublicPhotoFileUri = beFacilityWithCityStateZip.PublicPhotoFileUri,
				CityStateZip_CityStateZipGuid = beFacilityWithCityStateZip.CityStateZip_CityStateZipGuid,
			};

			return resultFacilityWithCityStateZip;
		}

		public static List<DC.FacilityWithCityStateZip> ToDataContractList(this IEnumerable<BE.FacilityWithCityStateZip> beFacilityWithCityStateZipList)
		{
			List<DC.FacilityWithCityStateZip> dataContractList = new List<DC.FacilityWithCityStateZip>();
			foreach (BE.FacilityWithCityStateZip dcFacilityWithCityStateZip in beFacilityWithCityStateZipList)
			{
				dataContractList.Add(dcFacilityWithCityStateZip.ToDataContract());
			}

			return dataContractList;
		}
		#endregion

		#region FacilityWithOffering DataContracts to BusinessEntities
		public static BE.FacilityWithOffering ToBusinessEntity(this DC.FacilityWithOffering dcFacilityWithOffering)
		{
			BE.FacilityWithOffering resultFacilityWithOffering = new BE.FacilityWithOffering()
			{
				FacilityGuid = dcFacilityWithOffering.FacilityGuid,
				FacilityID = dcFacilityWithOffering.FacilityID,
				FacilityName = dcFacilityWithOffering.FacilityName,
				Exerpt = dcFacilityWithOffering.Exerpt,
				Description = dcFacilityWithOffering.Description,
				Address = dcFacilityWithOffering.Address,
				CityStateZipGuid = dcFacilityWithOffering.CityStateZipGuid,
				PhoneNumber = dcFacilityWithOffering.PhoneNumber,
				Email = dcFacilityWithOffering.Email,
				Website = dcFacilityWithOffering.Website,
				ClientGuid = dcFacilityWithOffering.ClientGuid,
				ListingTypeGuid = dcFacilityWithOffering.ListingTypeGuid,
				PublicPhotoFileUri = dcFacilityWithOffering.PublicPhotoFileUri,
				Offering_OfferingGuid = dcFacilityWithOffering.Offering_OfferingGuid,
				FacilityOffering_IsChecked = dcFacilityWithOffering.FacilityOffering_IsChecked,
			};

			return resultFacilityWithOffering;
		}

		public static List<BE.FacilityWithOffering> ToBusinessEntitiesList(this IEnumerable<DC.FacilityWithOffering> dcFacilityWithOfferingList)
		{
			List<BE.FacilityWithOffering> businessEntityList = new List<BE.FacilityWithOffering>();
			foreach (DC.FacilityWithOffering dcFacilityWithOffering in dcFacilityWithOfferingList)
			{
				businessEntityList.Add(dcFacilityWithOffering.ToBusinessEntity());
			}

			return businessEntityList;
		}
		#endregion


		#region FacilityWithOffering BusinessEntities to DataContracts
		public static DC.FacilityWithOffering ToDataContract(this BE.FacilityWithOffering beFacilityWithOffering)
		{
			DC.FacilityWithOffering resultFacilityWithOffering = new DC.FacilityWithOffering()
			{
				FacilityGuid = beFacilityWithOffering.FacilityGuid,
				FacilityID = beFacilityWithOffering.FacilityID,
				FacilityName = beFacilityWithOffering.FacilityName,
				Exerpt = beFacilityWithOffering.Exerpt,
				Description = beFacilityWithOffering.Description,
				Address = beFacilityWithOffering.Address,
				CityStateZipGuid = beFacilityWithOffering.CityStateZipGuid,
				PhoneNumber = beFacilityWithOffering.PhoneNumber,
				Email = beFacilityWithOffering.Email,
				Website = beFacilityWithOffering.Website,
				ClientGuid = beFacilityWithOffering.ClientGuid,
				ListingTypeGuid = beFacilityWithOffering.ListingTypeGuid,
				PublicPhotoFileUri = beFacilityWithOffering.PublicPhotoFileUri,
				Offering_OfferingGuid = beFacilityWithOffering.Offering_OfferingGuid,
				FacilityOffering_IsChecked = beFacilityWithOffering.FacilityOffering_IsChecked,
			};

			return resultFacilityWithOffering;
		}

		public static List<DC.FacilityWithOffering> ToDataContractList(this IEnumerable<BE.FacilityWithOffering> beFacilityWithOfferingList)
		{
			List<DC.FacilityWithOffering> dataContractList = new List<DC.FacilityWithOffering>();
			foreach (BE.FacilityWithOffering dcFacilityWithOffering in beFacilityWithOfferingList)
			{
				dataContractList.Add(dcFacilityWithOffering.ToDataContract());
			}

			return dataContractList;
		}
		#endregion
		#region FacilityAudit DataContracts to BusinessEntities
		public static BE.FacilityAudit ToBusinessEntity(this DC.FacilityAudit dcFacilityAudit)
		{
			BE.FacilityAudit facilityAuditResult = new BE.FacilityAudit()
			{
				FacilityAuditGuid = dcFacilityAudit.FacilityAuditGuid,
				FacilityGuid = dcFacilityAudit.FacilityGuid,
				FacilityID = dcFacilityAudit.FacilityID,
				FacilityName = dcFacilityAudit.FacilityName,
				Exerpt = dcFacilityAudit.Exerpt,
				Description = dcFacilityAudit.Description,
				Address = dcFacilityAudit.Address,
				CityStateZipGuid = dcFacilityAudit.CityStateZipGuid,
				PhoneNumber = dcFacilityAudit.PhoneNumber,
				Email = dcFacilityAudit.Email,
				Website = dcFacilityAudit.Website,
				ClientGuid = dcFacilityAudit.ClientGuid,
				ListingTypeGuid = dcFacilityAudit.ListingTypeGuid,
				PublicPhotoFileUri = dcFacilityAudit.PublicPhotoFileUri,
				DateModified = dcFacilityAudit.DateModified,
			};

			return facilityAuditResult;
		}

		public static List<BE.FacilityAudit> ToBusinessEntitiesList(this IEnumerable<DC.FacilityAudit> dcFacilityAuditList)
		{
			List<BE.FacilityAudit> businessEntityList = new List<BE.FacilityAudit>();
			foreach (DC.FacilityAudit dcFacilityAudit in dcFacilityAuditList)
			{
				businessEntityList.Add(dcFacilityAudit.ToBusinessEntity());
			}

			return businessEntityList;
		}
		#endregion


		#region FacilityAudit BusinessEntities to DataContracts
		public static DC.FacilityAudit ToDataContract(this BE.FacilityAudit beFacilityAudit)
		{
			DC.FacilityAudit facilityAuditResult = new DC.FacilityAudit()
			{
				FacilityAuditGuid = beFacilityAudit.FacilityAuditGuid,
				FacilityGuid = beFacilityAudit.FacilityGuid,
				FacilityID = beFacilityAudit.FacilityID,
				FacilityName = beFacilityAudit.FacilityName,
				Exerpt = beFacilityAudit.Exerpt,
				Description = beFacilityAudit.Description,
				Address = beFacilityAudit.Address,
				CityStateZipGuid = beFacilityAudit.CityStateZipGuid,
				PhoneNumber = beFacilityAudit.PhoneNumber,
				Email = beFacilityAudit.Email,
				Website = beFacilityAudit.Website,
				ClientGuid = beFacilityAudit.ClientGuid,
				ListingTypeGuid = beFacilityAudit.ListingTypeGuid,
				PublicPhotoFileUri = beFacilityAudit.PublicPhotoFileUri,
				DateModified = beFacilityAudit.DateModified,
			};

			return facilityAuditResult;
		}

		public static List<DC.FacilityAudit> ToDataContractList(this IEnumerable<BE.FacilityAudit> beFacilityAuditList)
		{
			List<DC.FacilityAudit> dataContractList = new List<DC.FacilityAudit>();
			foreach (BE.FacilityAudit dcFacilityAudit in beFacilityAuditList)
			{
				dataContractList.Add(dcFacilityAudit.ToDataContract());
			}

			return dataContractList;
		}
		#endregion

		#region FacilityLocationCriteria DataContracts to BusinessEntities
		public static BE.FacilityLocationCriteria ToBusinessEntity(this DC.FacilityLocationCriteria dcFacilityLocationCriteria)
		{
			BE.FacilityLocationCriteria facilityLocationCriteriaResult = new BE.FacilityLocationCriteria()
			{
				FacilityGuid = dcFacilityLocationCriteria.FacilityGuid,
				CityStateZipGuid = dcFacilityLocationCriteria.CityStateZipGuid,
			};

			return facilityLocationCriteriaResult;
		}

		public static List<BE.FacilityLocationCriteria> ToBusinessEntitiesList(this IEnumerable<DC.FacilityLocationCriteria> dcFacilityLocationCriteriaList)
		{
			List<BE.FacilityLocationCriteria> businessEntityList = new List<BE.FacilityLocationCriteria>();
			foreach (DC.FacilityLocationCriteria dcFacilityLocationCriteria in dcFacilityLocationCriteriaList)
			{
				businessEntityList.Add(dcFacilityLocationCriteria.ToBusinessEntity());
			}

			return businessEntityList;
		}
		#endregion


		#region FacilityLocationCriteria BusinessEntities to DataContracts
		public static DC.FacilityLocationCriteria ToDataContract(this BE.FacilityLocationCriteria beFacilityLocationCriteria)
		{
			DC.FacilityLocationCriteria facilityLocationCriteriaResult = new DC.FacilityLocationCriteria()
			{
				FacilityGuid = beFacilityLocationCriteria.FacilityGuid,
				CityStateZipGuid = beFacilityLocationCriteria.CityStateZipGuid,
			};

			return facilityLocationCriteriaResult;
		}

		public static List<DC.FacilityLocationCriteria> ToDataContractList(this IEnumerable<BE.FacilityLocationCriteria> beFacilityLocationCriteriaList)
		{
			List<DC.FacilityLocationCriteria> dataContractList = new List<DC.FacilityLocationCriteria>();
			foreach (BE.FacilityLocationCriteria dcFacilityLocationCriteria in beFacilityLocationCriteriaList)
			{
				dataContractList.Add(dcFacilityLocationCriteria.ToDataContract());
			}

			return dataContractList;
		}
		#endregion

		#region FacilityOffering DataContracts to BusinessEntities
		public static BE.FacilityOffering ToBusinessEntity(this DC.FacilityOffering dcFacilityOffering)
		{
			BE.FacilityOffering facilityOfferingResult = new BE.FacilityOffering()
			{
				FacilityGuid = dcFacilityOffering.FacilityGuid,
				OfferingGuid = dcFacilityOffering.OfferingGuid,
				IsChecked = dcFacilityOffering.IsChecked,
			};

			return facilityOfferingResult;
		}

		public static List<BE.FacilityOffering> ToBusinessEntitiesList(this IEnumerable<DC.FacilityOffering> dcFacilityOfferingList)
		{
			List<BE.FacilityOffering> businessEntityList = new List<BE.FacilityOffering>();
			foreach (DC.FacilityOffering dcFacilityOffering in dcFacilityOfferingList)
			{
				businessEntityList.Add(dcFacilityOffering.ToBusinessEntity());
			}

			return businessEntityList;
		}
		#endregion


		#region FacilityOffering BusinessEntities to DataContracts
		public static DC.FacilityOffering ToDataContract(this BE.FacilityOffering beFacilityOffering)
		{
			DC.FacilityOffering facilityOfferingResult = new DC.FacilityOffering()
			{
				FacilityGuid = beFacilityOffering.FacilityGuid,
				OfferingGuid = beFacilityOffering.OfferingGuid,
				IsChecked = beFacilityOffering.IsChecked,
			};

			return facilityOfferingResult;
		}

		public static List<DC.FacilityOffering> ToDataContractList(this IEnumerable<BE.FacilityOffering> beFacilityOfferingList)
		{
			List<DC.FacilityOffering> dataContractList = new List<DC.FacilityOffering>();
			foreach (BE.FacilityOffering dcFacilityOffering in beFacilityOfferingList)
			{
				dataContractList.Add(dcFacilityOffering.ToDataContract());
			}

			return dataContractList;
		}
		#endregion

		#region ListingType DataContracts to BusinessEntities
		public static BE.ListingType ToBusinessEntity(this DC.ListingType dcListingType)
		{
			BE.ListingType listingTypeResult = new BE.ListingType()
			{
				ListingTypeGuid = dcListingType.ListingTypeGuid,
				ListingTypeName = dcListingType.ListingTypeName,
			};

			return listingTypeResult;
		}

		public static List<BE.ListingType> ToBusinessEntitiesList(this IEnumerable<DC.ListingType> dcListingTypeList)
		{
			List<BE.ListingType> businessEntityList = new List<BE.ListingType>();
			foreach (DC.ListingType dcListingType in dcListingTypeList)
			{
				businessEntityList.Add(dcListingType.ToBusinessEntity());
			}

			return businessEntityList;
		}
		#endregion


		#region ListingType BusinessEntities to DataContracts
		public static DC.ListingType ToDataContract(this BE.ListingType beListingType)
		{
			DC.ListingType listingTypeResult = new DC.ListingType()
			{
				ListingTypeGuid = beListingType.ListingTypeGuid,
				ListingTypeName = beListingType.ListingTypeName,
			};

			return listingTypeResult;
		}

		public static List<DC.ListingType> ToDataContractList(this IEnumerable<BE.ListingType> beListingTypeList)
		{
			List<DC.ListingType> dataContractList = new List<DC.ListingType>();
			foreach (BE.ListingType dcListingType in beListingTypeList)
			{
				dataContractList.Add(dcListingType.ToDataContract());
			}

			return dataContractList;
		}
		#endregion

		#region Offering DataContracts to BusinessEntities
		public static BE.Offering ToBusinessEntity(this DC.Offering dcOffering)
		{
			BE.Offering offeringResult = new BE.Offering()
			{
				OfferingGuid = dcOffering.OfferingGuid,
				OfferingID = dcOffering.OfferingID,
				OfferingName = dcOffering.OfferingName,
			};

			return offeringResult;
		}

		public static List<BE.Offering> ToBusinessEntitiesList(this IEnumerable<DC.Offering> dcOfferingList)
		{
			List<BE.Offering> businessEntityList = new List<BE.Offering>();
			foreach (DC.Offering dcOffering in dcOfferingList)
			{
				businessEntityList.Add(dcOffering.ToBusinessEntity());
			}

			return businessEntityList;
		}
		#endregion


		#region Offering BusinessEntities to DataContracts
		public static DC.Offering ToDataContract(this BE.Offering beOffering)
		{
			DC.Offering offeringResult = new DC.Offering()
			{
				OfferingGuid = beOffering.OfferingGuid,
				OfferingID = beOffering.OfferingID,
				OfferingName = beOffering.OfferingName,
			};

			return offeringResult;
		}

		public static List<DC.Offering> ToDataContractList(this IEnumerable<BE.Offering> beOfferingList)
		{
			List<DC.Offering> dataContractList = new List<DC.Offering>();
			foreach (BE.Offering dcOffering in beOfferingList)
			{
				dataContractList.Add(dcOffering.ToDataContract());
			}

			return dataContractList;
		}
		#endregion


		#region OfferingWithFacility DataContracts to BusinessEntities
		public static BE.OfferingWithFacility ToBusinessEntity(this DC.OfferingWithFacility dcOfferingWithFacility)
		{
			BE.OfferingWithFacility resultOfferingWithFacility = new BE.OfferingWithFacility()
			{
				OfferingGuid = dcOfferingWithFacility.OfferingGuid,
				OfferingID = dcOfferingWithFacility.OfferingID,
				OfferingName = dcOfferingWithFacility.OfferingName,
				Facility_FacilityGuid = dcOfferingWithFacility.Facility_FacilityGuid,
				FacilityOffering_IsChecked = dcOfferingWithFacility.FacilityOffering_IsChecked,
			};

			return resultOfferingWithFacility;
		}

		public static List<BE.OfferingWithFacility> ToBusinessEntitiesList(this IEnumerable<DC.OfferingWithFacility> dcOfferingWithFacilityList)
		{
			List<BE.OfferingWithFacility> businessEntityList = new List<BE.OfferingWithFacility>();
			foreach (DC.OfferingWithFacility dcOfferingWithFacility in dcOfferingWithFacilityList)
			{
				businessEntityList.Add(dcOfferingWithFacility.ToBusinessEntity());
			}

			return businessEntityList;
		}
		#endregion


		#region OfferingWithFacility BusinessEntities to DataContracts
		public static DC.OfferingWithFacility ToDataContract(this BE.OfferingWithFacility beOfferingWithFacility)
		{
			DC.OfferingWithFacility resultOfferingWithFacility = new DC.OfferingWithFacility()
			{
				OfferingGuid = beOfferingWithFacility.OfferingGuid,
				OfferingID = beOfferingWithFacility.OfferingID,
				OfferingName = beOfferingWithFacility.OfferingName,
				Facility_FacilityGuid = beOfferingWithFacility.Facility_FacilityGuid,
				FacilityOffering_IsChecked = beOfferingWithFacility.FacilityOffering_IsChecked,
			};

			return resultOfferingWithFacility;
		}

		public static List<DC.OfferingWithFacility> ToDataContractList(this IEnumerable<BE.OfferingWithFacility> beOfferingWithFacilityList)
		{
			List<DC.OfferingWithFacility> dataContractList = new List<DC.OfferingWithFacility>();
			foreach (BE.OfferingWithFacility dcOfferingWithFacility in beOfferingWithFacilityList)
			{
				dataContractList.Add(dcOfferingWithFacility.ToDataContract());
			}

			return dataContractList;
		}
		#endregion
		#region PaymentInfo DataContracts to BusinessEntities
		public static BE.PaymentInfo ToBusinessEntity(this DC.PaymentInfo dcPaymentInfo)
		{
			BE.PaymentInfo paymentInfoResult = new BE.PaymentInfo()
			{
				PaymentInfoGuid = dcPaymentInfo.PaymentInfoGuid,
				PaymentInfoID = dcPaymentInfo.PaymentInfoID,
				AmazonToken = dcPaymentInfo.AmazonToken,
			};

			return paymentInfoResult;
		}

		public static List<BE.PaymentInfo> ToBusinessEntitiesList(this IEnumerable<DC.PaymentInfo> dcPaymentInfoList)
		{
			List<BE.PaymentInfo> businessEntityList = new List<BE.PaymentInfo>();
			foreach (DC.PaymentInfo dcPaymentInfo in dcPaymentInfoList)
			{
				businessEntityList.Add(dcPaymentInfo.ToBusinessEntity());
			}

			return businessEntityList;
		}
		#endregion


		#region PaymentInfo BusinessEntities to DataContracts
		public static DC.PaymentInfo ToDataContract(this BE.PaymentInfo bePaymentInfo)
		{
			DC.PaymentInfo paymentInfoResult = new DC.PaymentInfo()
			{
				PaymentInfoGuid = bePaymentInfo.PaymentInfoGuid,
				PaymentInfoID = bePaymentInfo.PaymentInfoID,
				AmazonToken = bePaymentInfo.AmazonToken,
			};

			return paymentInfoResult;
		}

		public static List<DC.PaymentInfo> ToDataContractList(this IEnumerable<BE.PaymentInfo> bePaymentInfoList)
		{
			List<DC.PaymentInfo> dataContractList = new List<DC.PaymentInfo>();
			foreach (BE.PaymentInfo dcPaymentInfo in bePaymentInfoList)
			{
				dataContractList.Add(dcPaymentInfo.ToDataContract());
			}

			return dataContractList;
		}
		#endregion

		#region PaymentInfoAudit DataContracts to BusinessEntities
		public static BE.PaymentInfoAudit ToBusinessEntity(this DC.PaymentInfoAudit dcPaymentInfoAudit)
		{
			BE.PaymentInfoAudit paymentInfoAuditResult = new BE.PaymentInfoAudit()
			{
				PaymentInfoAuditGuid = dcPaymentInfoAudit.PaymentInfoAuditGuid,
				PaymentInfoGuid = dcPaymentInfoAudit.PaymentInfoGuid,
				PaymentInfoID = dcPaymentInfoAudit.PaymentInfoID,
				AmazonToken = dcPaymentInfoAudit.AmazonToken,
				DateModified = dcPaymentInfoAudit.DateModified,
			};

			return paymentInfoAuditResult;
		}

		public static List<BE.PaymentInfoAudit> ToBusinessEntitiesList(this IEnumerable<DC.PaymentInfoAudit> dcPaymentInfoAuditList)
		{
			List<BE.PaymentInfoAudit> businessEntityList = new List<BE.PaymentInfoAudit>();
			foreach (DC.PaymentInfoAudit dcPaymentInfoAudit in dcPaymentInfoAuditList)
			{
				businessEntityList.Add(dcPaymentInfoAudit.ToBusinessEntity());
			}

			return businessEntityList;
		}
		#endregion


		#region PaymentInfoAudit BusinessEntities to DataContracts
		public static DC.PaymentInfoAudit ToDataContract(this BE.PaymentInfoAudit bePaymentInfoAudit)
		{
			DC.PaymentInfoAudit paymentInfoAuditResult = new DC.PaymentInfoAudit()
			{
				PaymentInfoAuditGuid = bePaymentInfoAudit.PaymentInfoAuditGuid,
				PaymentInfoGuid = bePaymentInfoAudit.PaymentInfoGuid,
				PaymentInfoID = bePaymentInfoAudit.PaymentInfoID,
				AmazonToken = bePaymentInfoAudit.AmazonToken,
				DateModified = bePaymentInfoAudit.DateModified,
			};

			return paymentInfoAuditResult;
		}

		public static List<DC.PaymentInfoAudit> ToDataContractList(this IEnumerable<BE.PaymentInfoAudit> bePaymentInfoAuditList)
		{
			List<DC.PaymentInfoAudit> dataContractList = new List<DC.PaymentInfoAudit>();
			foreach (BE.PaymentInfoAudit dcPaymentInfoAudit in bePaymentInfoAuditList)
			{
				dataContractList.Add(dcPaymentInfoAudit.ToDataContract());
			}

			return dataContractList;
		}
		#endregion

		#region FacilityPhoto DataContracts to BusinessEntities
		public static BE.FacilityPhoto ToBusinessEntity(this DC.FacilityPhoto dcFacilityPhoto)
		{
			BE.FacilityPhoto facilityPhotoResult = new BE.FacilityPhoto()
			{
				FacilityPhotoGuid = dcFacilityPhoto.FacilityPhotoGuid,
				PhotoUri = dcFacilityPhoto.PhotoUri,
				FacilityGuid = dcFacilityPhoto.FacilityGuid,
			};

			return facilityPhotoResult;
		}

		public static List<BE.FacilityPhoto> ToBusinessEntitiesList(this IEnumerable<DC.FacilityPhoto> dcFacilityPhotoList)
		{
			List<BE.FacilityPhoto> businessEntityList = new List<BE.FacilityPhoto>();
			foreach (DC.FacilityPhoto dcFacilityPhoto in dcFacilityPhotoList)
			{
				businessEntityList.Add(dcFacilityPhoto.ToBusinessEntity());
			}

			return businessEntityList;
		}
		#endregion


		#region FacilityPhoto BusinessEntities to DataContracts
		public static DC.FacilityPhoto ToDataContract(this BE.FacilityPhoto beFacilityPhoto)
		{
			DC.FacilityPhoto facilityPhotoResult = new DC.FacilityPhoto()
			{
				FacilityPhotoGuid = beFacilityPhoto.FacilityPhotoGuid,
				PhotoUri = beFacilityPhoto.PhotoUri,
				FacilityGuid = beFacilityPhoto.FacilityGuid,
			};

			return facilityPhotoResult;
		}

		public static List<DC.FacilityPhoto> ToDataContractList(this IEnumerable<BE.FacilityPhoto> beFacilityPhotoList)
		{
			List<DC.FacilityPhoto> dataContractList = new List<DC.FacilityPhoto>();
			foreach (BE.FacilityPhoto dcFacilityPhoto in beFacilityPhotoList)
			{
				dataContractList.Add(dcFacilityPhoto.ToDataContract());
			}

			return dataContractList;
		}
		#endregion

	}
}