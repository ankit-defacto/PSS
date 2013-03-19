
namespace ConcordMfg.PremierSeniorSolutions.WebService.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Configuration;

    /// <summary>
    /// plamen
    /// Common configuration class
    /// </summary>
    public class Config
    {
        public static string PSS2012ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["PSS2012ConnectionString"].ConnectionString;
            }
        }
    }
}