using System;

namespace ConcordMfg.PremierSeniorSolutions.Client.Tools
{
	/// <summary>
	/// Contains common methods including extention methods.
	/// </summary>
	public static class Common
	{
		/// <summary>
		/// Extracts an integer value from a QueryString.
		/// </summary>
		/// <param name="page">Web page</param>
		/// <param name="guidName">Name of the Guid field.</param>
		/// <returns>If the query string for idName is a number, the value of idName; otherwise 0.</returns>
		public static Guid GetID(System.Web.UI.Page page, string guidName)
		{
			try
			{
				string guidStr = page.Request.QueryString[guidName];
				return new Guid(guidStr);
			}
			catch
			{
				return Guid.Empty;
			}
		}
	}
}