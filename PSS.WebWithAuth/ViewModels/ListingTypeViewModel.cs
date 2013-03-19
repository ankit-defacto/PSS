using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace PSS.WebWithAuth.ViewModels
{
    public class ListingTypeViewModel
    {

        [Required]
        public Guid ListingTypeGuid { get; set; }

        [Required]
        public string ListingTypeName { get; set; }

        [Required]
        [Range(0.01, 999999999, ErrorMessage = "Price must be greater than 0 and less than 999999999 ")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Should be a valid money.")]
        public decimal ListingTypePrice { get; set; }
     
    }
}