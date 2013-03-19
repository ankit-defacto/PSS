using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PSS.WebWithAuth.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult HttpError()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}
