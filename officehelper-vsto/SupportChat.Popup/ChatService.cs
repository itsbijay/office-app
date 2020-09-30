using System.Collections.Generic;
using System.Diagnostics;

namespace SupportChat.Popup
{
	public partial class ChatService
	{
		private List<IBrowser> _browserList { get; set; }

		public ChatService()
		{
			_browserList = new List<IBrowser>() { new MicrosoftEdgeBrowser(), new ChromeBrowser(), new InternetExplorerBrowser() };
		}

		public void Run(string url)
		{
			foreach (var browser in _browserList)
			{
				if (browser.TryRun32(url))
					return;

				if (browser.TryRun64(url))
					return;
			}

			Process.Start(url);
		}
	}
}