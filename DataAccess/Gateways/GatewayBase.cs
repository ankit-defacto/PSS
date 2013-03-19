
namespace ConcordMfg.PremierSeniorSolutions.WebService.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class GatewayBase
    {
        public virtual PSS2012DataContext DataContext
        {
            get
            {
                return new PSS2012DataContext(Config.PSS2012ConnectionString);
            }
        }
    }
}