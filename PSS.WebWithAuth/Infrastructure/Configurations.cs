
using System.Configuration;
namespace PSS.WebWithAuth.Infrastructure
{
    /// <summary>
    /// PSS MVC Configurations
    /// contains styling
    /// </summary>
    public class Configurations
    {
        /// <summary>
        /// Antiforgery token salt
        /// </summary>
        public const string AntiForgeryTokenSalt = "pss";

        /// <summary>
        /// Image replacement for bad urls
        /// </summary>
        public const string EMPTYIMAGEURL = "~/Content/Images/home-default.jpeg";

        /// <summary>
        /// Home icon image url
        /// </summary>
        public const string ICONHOME = "~/Content/Images/home_icon.png";

        /// <summary>
        /// Arrow icon image url
        /// </summary>
        public const string ICONARROW = "~/Content/Images/darrow.png";

        /// <summary>
        /// Gets upload handler root path
        /// </summary>
        public static string UploadHandlerRoot
        {
            get
            {
                string uploadhandlerroot = ConfigurationManager.AppSettings.Get("UploadHandlerRoot");
                return string.IsNullOrEmpty(uploadhandlerroot) ? "/Upload/" : uploadhandlerroot + "/Upload/";
            }
        }
    }
}