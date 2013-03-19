using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Configuration;

namespace PSS.WebWithAuth
{
	public class GitApiClient
	{        
		public static string FederatedSuccess = "federatedSuccess";
		public static string FederatedError = "federatedError";

		private readonly string _verifyUrl = "https://www.googleapis.com/identitytoolkit/v1/relyingparty/verifyAssertion?key=";
		private string _apiKey;

        public GitApiClient()
        {
            _apiKey = GoogleApiKey;
        }

		public GitApiClient(string apiKey)
		{
			_apiKey = apiKey;
		}

        //plamen: common location for these settings
        public static string GoogleApiKey
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("GoogleApiKey");
            }
        }

        public static string GitCallbackUrl
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("GitCallbackUrl");
            }
        }

		private string GitVerifyPost()
		{
			string result = "";
			try
			{
				Uri address = new Uri(_verifyUrl + _apiKey);

				HttpRequest request = HttpContext.Current.Request;

				HttpWebRequest gitWebRequest = WebRequest.Create(address) as HttpWebRequest;
				gitWebRequest.Method = "POST";
				gitWebRequest.ContentType = "application/json";

				StreamReader requestReader = new StreamReader(request.InputStream);

				var requestBody = requestReader.ReadToEnd();

				string myRequestUri = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority.TrimEnd('/'), request.RawUrl);

				var verifyRequestData = new { requestUri = myRequestUri, postBody = requestBody };

				byte[] gitRequestData = UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(verifyRequestData));

				using (Stream stream = gitWebRequest.GetRequestStream())
				{
					stream.Write(gitRequestData, 0, gitRequestData.Length);
				}

				using (HttpWebResponse response = gitWebRequest.GetResponse() as HttpWebResponse)
				{
					// Get the response stream  
					StreamReader responseReader = new StreamReader(response.GetResponseStream());
					result = responseReader.ReadToEnd();
				}
			}
			catch (WebException web)
			{
				throw new Exception("An error occurred while verifying the IDP response", web);
			}

			return result;

		}

		public GitAssertion Verify()
		{
			var result = GitVerifyPost();

			return JsonConvert.DeserializeObject<GitAssertion>(result);
		}

	}
}