using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSS.WebWithAuth
{
	public class GitAssertion
	{
		public string Kind { get; set; }
		public string Identifier { get; set; }
		public string Authority { get; set; }
		public string VerifiedEmail { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName { get; set; }
		public string NickName { get; set; }
		public string Language { get; set; }
		public string TimeZone { get; set; }
		public string ProfilePicture { get; set; }
	}
}