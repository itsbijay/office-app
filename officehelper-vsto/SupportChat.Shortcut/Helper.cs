using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SupportChat.Shortcut
{
	public static class Helper
	{
		public static bool Ping(string url)
		{
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			var request = (HttpWebRequest)WebRequest.Create(url);
			{
				request.Timeout = 15000;
				request.Method = "GET";
				request.UseDefaultCredentials = true;
				request.PreAuthenticate = true;
				request.Credentials = CredentialCache.DefaultCredentials;
			}

			try
			{
				using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
				{
					return response.StatusCode == HttpStatusCode.OK;
				}
			}
			catch (WebException)
			{
				return false;
			}
		}
	}
}
