using System.Management.Automation;

namespace SupportChat.Popup
{
	public class ChromeBrowser : IBrowser
	{
		public string Path { get; set; }
		public string Name => "Google Chrome";

		public void Run(string url)
		{
			var appUrl = HelperUtility.GetDataUrl(url);
			var query = $@"
							$user = ""--user-data-dir=C:\MAINTENANCE\PervasiveChatChrome""
							$mode = ""--chrome-frame""
							$size = ""--window-size=650,500""
							$url = ""--app={appUrl}""
							$app = Start-Process '{this.Path}' -ArgumentList $user, $mode, $size, $url -passthru
							Wait-Process $app.Id
						";

			using (var ps = PowerShell.Create())
			{
				ps.AddScript(query);
				ps.Invoke();
			}
		}


		public void SetPath(string path)
		{
			this.Path = path;
		}
	}
}
