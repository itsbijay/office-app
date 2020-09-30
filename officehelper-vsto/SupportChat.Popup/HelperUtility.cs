using System;
using System.Linq;

namespace SupportChat.Popup
{
	public class HelperUtility
	{
		public static string GetDataUrl(string url)
		{
			return $"data:text/html,<html><body><script>h=650,w=500,url='{url}';window.resizeTo(w,h);window.moveTo(screen.width/2-w/2,screen.height/2-h/2);window.location=url;</script></body></html>";
		}

		public static readonly string[] ValidProcesses = new string[] { "chrome", "msedge", "iexplore" };
		public static bool IsActiveProcess(Uri uri, string mainWindowTitle)
		{
			var processIdentifier = new string[] { $"https://{uri.Host}/", "Chat", "Chat Support", "Connect Support" };
			return processIdentifier.Any(x => (mainWindowTitle ?? "").Contains(x));
		}
	}
}
