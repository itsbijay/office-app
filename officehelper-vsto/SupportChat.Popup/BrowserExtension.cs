using Microsoft.Win32;
using System.Diagnostics;
using System.IO;

namespace SupportChat.Popup
{
	public static class BrowserExtension
	{
		const string path32 = @"SOFTWARE\WOW6432Node\Clients\StartMenuInternet\{0}\shell\open\command";
		const string path64 = @"SOFTWARE\Clients\StartMenuInternet\{0}\shell\open\command";

		public static bool TryRun32(this IBrowser browser, string url)
		{
			return Run(browser, url, path32);
		}

		public static bool TryRun64(this IBrowser browser, string url)
		{
			return Run(browser, url, path64);
		}

		static bool Run(IBrowser browser, string url, string path)
		{
			try
			{
				using (RegistryKey key = Registry.LocalMachine.OpenSubKey(string.Format(path, browser.Name)))
				{
					if (key != null)
					{
						string filePath = ((key.GetValue(null) as string) ?? "").Trim('"');

						if (File.Exists(filePath))
						{
							browser.SetPath(filePath);
							browser.Run(url);
							return true;
						}
					}
				}
				return false;
			}
			catch (System.Exception ex)
			{
				var source = "Application";
				using (EventLog myLog = new EventLog())
				{
					myLog.Source = source;
					myLog.WriteEntry(ex.Message);
					myLog.WriteEntry(ex.StackTrace, EventLogEntryType.Error);
				}
				return false;
			}
		}
	}
}
