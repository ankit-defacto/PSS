
namespace ConcordMfg.PremierSeniorSolutions.WebService.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public partial class Offering
    {
        public static Expression<Func<Offering, bool>> ContainsOfferings(IEnumerable<Offering> offerings)
        {
            var predicate = PredicateBuilder.False<Offering>();
            foreach (var offering in offerings)
            {
                var offeringguid = offering.OfferingGuid;
                predicate = predicate.Or(p => p.OfferingGuid == offeringguid);
            }

            return predicate;
        }
    }
}