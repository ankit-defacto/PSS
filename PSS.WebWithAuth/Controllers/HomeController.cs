using System.Net.Mail;
using System.Web.Mvc;
using PSS.WebWithAuth.Infrastructure;
using PSS.WebWithAuth.Models;

namespace PSS.WebWithAuth.Controllers
{
	public partial class HomeController : PSSBaseController
	{
        public PartialViewResult TopMenu()
        {
            return PartialView("_TopMenuPartial");
        }
        public PartialViewResult AdminTopMenu()
        {
            return PartialView("_AdminTopMenuPartial");
        }

        [HttpGet]
        [HandleError]
		public virtual ActionResult Index()
		{
            return this.ShowCreate();
		}

        [HttpGet]
        [HandleError]
		public virtual ActionResult About()
		{
            return View();
		}

        [HttpGet]
        [HandleError]
		public virtual ActionResult Contact()
		{
            return View();
		}

        [HttpPost]
        [ValidateAntiForgeryToken(Salt = Configurations.AntiForgeryTokenSalt)]
        public ActionResult Contact(ContactMessage cmessage)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.SendContactForm(cmessage);
                    this.SendResponse(cmessage);
                    ViewBag.ThankYou = "Thank you for contacting us!";
                }
                catch (SmtpException se)
                {
                    ViewBag.ThankYou = se.Message;
                }
            }
            
            return View(cmessage);
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        // todo: move all filled data to resource or template file
        private void SendContactForm(ContactMessage cmessage)
        {
            cmessage.Subject = string.Format("Client message from {0}", cmessage.Email);
            MailSender sender = new MailSender("admin@premierseniorsolutions.com");
            sender.Send(cmessage.Subject, cmessage.Message);
        }

        private void SendResponse(ContactMessage cmessage)
        {
            string subject = "PSS - contact form received";
            string body = @"Thank you for contacting us!
Your information has been sent and we should be in touch with you soon.

Thank you,
The Premier Senior Solutions Team";
            MailSender sender = new MailSender(cmessage.Email);
            sender.Send(subject, body);
        }
	}
}