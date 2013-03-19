using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;
using System.ComponentModel.DataAnnotations;

namespace PSS.WebWithAuth.ViewModels
{
    public class SetFacilityPriceViewModel
    {
        public Guid ListingTypeGuid { get; set; }
        public string ListingTypeName { get; set; }

        [Range(0,999999999, ErrorMessage = "Price must be greater than 0 and less than 999999999 ")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Should be a valid money.")]
        public decimal ListingPrice { get; set; }

        public bool IsChecked { get; set; }
    }
}