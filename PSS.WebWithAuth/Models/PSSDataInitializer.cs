
namespace PSS.WebWithAuth.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;
    using ConcordMfg.PremierSeniorSolutions.WebService.BusinessLogic;

    /// <summary>
    /// Initialize empty PSS database with static data
    /// </summary>
    public class PSSDataInitializer
    {
        public static void Initialize()
        {
            var initializer = new PSSDataInitializer();
            initializer.InitializeListingTypes();
            initializer.InitializeTypesOfCare();
        }

        private void InitializeListingTypes()
        {
            ListingTypeLogic ltl = new ListingTypeLogic();
            var listingTypes = ltl.GetAllListingType();
            if (listingTypes.Count < 2)
            {
                listingTypes = new List<ListingType>()
                {
                    new ListingType { ListingTypeName = "Standard Listing " ,ListingTypePrice=Convert.ToDecimal(.99)},
                    new ListingType { ListingTypeName = "Premier Listing ",ListingTypePrice=Convert.ToDecimal(2.50) }
                };
                // insert listing types
                listingTypes.ForEach(lt => ltl.InsertListingType(lt));
            }
        }

        private void InitializeTypesOfCare()
        {
            OfferingLogic ologic = new OfferingLogic();
            var offeringList = ologic.GetAllOffering();
            if (offeringList.Count == 0)
            {
                var typeofcarelist = new List<Offering>();
                typeofcarelist.Add(
                    new Offering { OfferingName = "Adult Family Home/ Residential Care" }
                );
                typeofcarelist.Add(
                    new Offering { OfferingName = "Assisted Living Facility" }
                );
                typeofcarelist.Add(
                   new Offering { OfferingName = "Skilled Nursing Facility" }
                );
                typeofcarelist.Add(
                   new Offering { OfferingName = "Home Care" }
                );
                typeofcarelist.Add(
                   new Offering { OfferingName = "Retirement Community" }
                );
                typeofcarelist.Add(
                   new Offering { OfferingName = "Independent Living Facility" }
                );
                typeofcarelist.Add(
                   new Offering { OfferingName = "Independent Caregivers" }
                );
                // insert offering types (types of care)
                typeofcarelist.ForEach(tc => ologic.InsertOffering(tc));
            }
        }
    }
}