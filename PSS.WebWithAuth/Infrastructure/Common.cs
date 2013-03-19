
namespace PSS.WebWithAuth.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Web;

    /// <summary>
    /// Common utilities class
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// Validate argument for null
        /// </summary>
        /// <typeparam name="T">Argument type</typeparam>
        /// <param name="argument">The argument</param>
        /// <param name="paramName">Argument name to display in exception</param>
        public static void ValidateArgument<T>(T argument, string paramName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(paramName, string.Format("{0} not supplied", argument.GetType()));
            }
        }

        /// <summary>
        /// Brute clean string to display in a script (use only for testing or workarounds)
        /// </summary>
        /// <param name="input">String input</param>
        /// <returns>"Cleaned" string</returns>
        public static string CleanForJavascript(this string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return input.Replace("\n", "<br/>")
                .Replace("\r", "<br/>").Replace(@"\", @"\\")
                    .Replace("\"", "`").Replace("'", "`");
            }

            return input;
        }
    }
}