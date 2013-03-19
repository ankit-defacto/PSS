using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace PSS.WebWithAuth.ViewModels
{
    public class ClientCardInfoViewModel
    {
        [Required]
        public Guid ClientCardGuid { get; set; }

        [Required]
        public Guid ClientGuid { get; set; }

        [Required]
        public string CardType { get; set; }

        [Required(ErrorMessage = "Card-Holder Name is required")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Minimum 5 Character required", MinimumLength = 5)]
        public string CardHolderNameOnCard { get; set; }

        [Required]
        [RegularExpression(@"\d{8,20}", ErrorMessage = "Invalid card No")]
        public string CardNumber { get; set; }

        [Required]
        [RegularExpression(@"\d{3}", ErrorMessage = "Enter only 3 digits (XXX)")]
        public string CvvNumber { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "Invalid Month")]
        [RegularExpression(@"\d{1,2}", ErrorMessage = "Invalid month (eg. 08 for August)")]
        public Int16 ExpMonth { get; set; }

        [Required]
        [Range(2013, 2050, ErrorMessage = "Expiry year must be in between 2013 to 2050")]
        [RegularExpression(@"\d{4}", ErrorMessage = "Invalid Year (eg. 2019)")]
        public Int16 ExpYear { get; set; }
    }
}