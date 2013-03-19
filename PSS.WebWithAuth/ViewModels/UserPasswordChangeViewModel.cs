using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace PSS.WebWithAuth.ViewModels
{
    public class UserPasswordChangeViewModel
    {
        //[Required]
       // public string UserName { get; set; }
        [Required] 
        public string Password { get; set; }

        [Required] //[StringLength(128),MinLength(6)]
        [RegularExpression(@"^.{6,128}$", ErrorMessage = "Should be min of 6 chars .")]
        public string NewPassword { get; set; }

        [Required][StringLength(128),MinLength(6,ErrorMessage = "Should be min of 6 chars .")]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }
}