using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PSS.WebWithAuth.ViewModels
{
    public class LogInViewModel
    {
        [Required(ErrorMessage = "Email can't be empty!")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Invalid email-address!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password can't be empty!")]
        public string Password { get; set; }
    }
}