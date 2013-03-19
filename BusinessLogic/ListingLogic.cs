using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE = ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;
using DA = ConcordMfg.PremierSeniorSolutions.WebService.DataAccess;
using ConcordMfg.PremierSeniorSolutions.WebService.EntityConversions;

namespace ConcordMfg.PremierSeniorSolutions.WebService.BusinessLogic
{
	public class ListingLogic
	{
		public BE.ListingViewModel GetListingByFacilityGuid(Guid facilityGuid)
		{
			DA.FacilityGateway facilityGateway = new DA.FacilityGateway();
			DA.Facility facility = facilityGateway.GetByPK(facilityGuid);

			// Validation of client.
			if (null == facility)
				return null;
			if (Guid.Empty == facility.CityStateZipGuid)
				return null;
			if (Guid.Empty == facility.ListingTypeGuid)
				return null;

			DA.CityStateZipGateway cityGateway = new DA.CityStateZipGateway();
			DA.CityStateZip cityStateZip = cityGateway.GetByPK(facility.CityStateZipGuid);

			// Validation of city state zip.
			if (null == cityStateZip)
				return null;

			DA.ListingTypeGateway listingGateway = new DA.ListingTypeGateway();
			DA.ListingType listingType = listingGateway.GetByPK(facility.ListingTypeGuid);

			// Validation of paymentInfo.
			if (null == listingType)
				return null;

			BE.ListingViewModel listing = EntityConversion.BuildListingViewModel(facility, cityStateZip, listingType);
			return listing;
		}

		public IEnumerable<BE.ListingViewModel> GetListingByClientGuid(Guid clientGuid)
		{
			DA.FacilityGateway facilityGateway = new DA.FacilityGateway();
			List<DA.Facility> facilities = facilityGateway.GetForClientByClientGuid(clientGuid);

			List<BE.ListingViewModel> listingVMs = new List<BE.ListingViewModel>();
			foreach (DA.Facility facility in facilities)
			{
				listingVMs.Add(this.GetListingByFacilityGuid(facility.FacilityGuid));
			}

			return listingVMs;
		}

        public IEnumerable<BE.FacilityAudit> GetListingsWithDateModifiedByClientGuid(Guid clientGuid)
        {
            var listings = this.GetListingByClientGuid(clientGuid);
            DA.FacilityAuditGateway facilityGateway = new DA.FacilityAuditGateway();
            List<BE.FacilityAudit> facilityAuditVMs = new List<BE.FacilityAudit>();
            foreach (var listing in listings)
            {
                //// find max date record
                var facilityMaxDate = facilityGateway.GetForFacilityByFacilityGuid(listing.FacilityGuid).Max(m => m.DateModified);
                //// get last audit record
                var facilityAuditLast = facilityGateway.GetForFacilityByFacilityGuid(listing.FacilityGuid).First(fa => fa.DateModified == facilityMaxDate);
                facilityAuditVMs.Add(facilityAuditLast.ToBusinessEntity());
            }

            return facilityAuditVMs;
        }

		public bool Delete(Guid facilityGuid, string email)
		{
			bool success = false;
			FacilityLogic facilityLogic = new FacilityLogic();
			BE.Facility facility = facilityLogic.GetFacilityByFacilityGuid(facilityGuid);
			ClientLogic clientLogic = new ClientLogic();
			BE.Client client = clientLogic.GetClientByClientGuid(facility.ClientGuid);
			if (client.Email == email)
			{
                // to delete facility first delete related records in FacilityPhoto and FacilityOffering
                // !!! in the existing business model transaction scope is hard to implement !!!
                FacilityOfferingLogic facilityOfferingLogic = new FacilityOfferingLogic();
                FacilityPhotoLogic facilityPhotoLogic = new FacilityPhotoLogic();
                OfferingLogic offeringLogic = new OfferingLogic();
                // delete related offerings
                var facilityOfferings = offeringLogic.GetOfferingsForFacility(facilityGuid);
                if (facilityOfferings.Count > 0)
                {
                    facilityOfferings.ForEach(fo =>
                    {
                        facilityOfferingLogic.DeleteFacilityOffering(
                            new BE.FacilityOffering { FacilityGuid = facilityGuid, OfferingGuid = fo.OfferingGuid }
                        );
                    });
                }
                // delete related photos
                var facilityPhotos = facilityPhotoLogic.GetFacilityPhotosForFacilityByFacilityGuid(facilityGuid);
                if (facilityPhotos.Count > 0)
                {
                    facilityPhotos.ForEach(fp => facilityPhotoLogic.DeleteFacilityPhoto(fp));
                }

				facilityLogic.DeleteFacility(facility);
				success = true;
			}

			return success;
		}
	}
}
