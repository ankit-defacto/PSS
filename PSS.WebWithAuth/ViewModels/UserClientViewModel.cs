using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PSS.WebWithAuth.ViewModels
{
    public class UserClientViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        [Display(Name = "Email", Prompt = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Email Address should be a valid email.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50,MinimumLength=4,ErrorMessage="length should be in between 4 - 50")]
        public string Passowrd { get; set; }

        [Required]
        [Display(Name = "Company Name", Prompt = "Company Name")]
        public string ClientName { get; set; }

        [Required]
        [Display(Name = "Phone Number", Prompt = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        [RegularExpression(@"\d{10}", ErrorMessage = "Must contain numeric value of length 10")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Address", Prompt = "Address")]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "City", Prompt = "City")]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "State", Prompt = "State")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip code", Prompt = "Zip code")]
        [RegularExpression(@"\d{5}", ErrorMessage = "Enter number value up to 5 digits")]    
        public string ZipCode { get; set; }

        [UIHint("ActiveNotActive")]
        [Display(Name = "Account paused")]
        public bool PauseAccount { get; set; }
    }
}