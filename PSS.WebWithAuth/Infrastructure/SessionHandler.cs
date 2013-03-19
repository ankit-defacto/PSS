
namespace PSS.WebWithAuth.Infrastructure
{
    using System.Web;
    using PSS.WebWithAuth.Models;

    /// <summary>
    /// Common session storage class
    /// </summary>
    public class SessionHandler
    {
        // private constructor
        private SessionHandler() { }

        /// <summary>
        /// Gets current session or creates new
        /// </summary>
        public static SessionHandler Current
        {
            get
            {
                SessionHandler session = HttpContext.Current.Session["pss"] as SessionHandler;
                if (session == null)
                {
                    session = new SessionHandler();
                    HttpContext.Current.Session["pss"] = session;
                }

                return session;
            }
        }

        /// <summary>
        /// Gets session id
        /// </summary>
        public string SessionID { get { return HttpContext.Current.Session.SessionID; } }

        /// <summary>
        /// Gets or sets user geolocation (determined from IP)
        /// </summary>
        public PSSLocation UserGeolocation { get; set; }

        /// <summary>
        /// Gets or sets Gitkit assertion result
        /// </summary>
        public GitAssertion GitAssertion { get; set; }

        /// <summary>
        /// Gets or sets return url (generated on request to authenticated area)
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}