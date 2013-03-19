using System;

namespace ConcordMfg.PremierSeniorSolutions.WebService.DataAccess.SQLServer
{
    internal static class ErrorCodes
    {
        public const byte ValidationError = 1;
        public const byte ConcurrencyViolationError = 2;
        public const int SqlUserRaisedError = 50000;
    }
}
	