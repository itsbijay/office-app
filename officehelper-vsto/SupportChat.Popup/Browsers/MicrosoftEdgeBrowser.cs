using System;
using System.Management.Automation;
using System.Runtime.InteropServices;

namespace SupportChat.Popup
{
	public class MicrosoftEdgeBrowser : IBrowser
	{
		[DllImport("user32.dll", SetLastError = true)]
		static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

		public string Path { get; set; }
		public string Name => "Microsoft Edge";

		public void Run(string url)
		{
			var appUrl = HelperUtility.GetDataUrl(url);
			var query = $@"
							$user = ""--user-data-dir=C:\MAINTENANCE\PervasiveChatEdge""
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
