using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace SupportChat.Popup
{
	class Program
	{
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool SetForegroundWindow(IntPtr hWnd);

		[STAThread]
		static void Main(string[] args)
		{
			var url = @"https://chat.google.com";
			if (args != null && args.Length > 0)
				url = args[0];

			var assemblyName = Assembly.GetExecutingAssembly().FullName;
			using (Mutex mutex = new Mutex(true, assemblyName, out bool createdNew))
			{
				if (createdNew)
				{

					var ribbon = new ChatService();
					ribbon.Run(url);
				}
				else
				{
					if (url != null)
					{
						var uri = new Uri(url);
						var processes = Process.GetProcesses();

						var process = processes?.FirstOrDefault(p => HelperUtility.ValidProcesses.Contains(p.ProcessName) && HelperUtility.IsActiveProcess(uri, p.MainWindowTitle));
						if (process != null)
							SetForegroundWindow(process.MainWindowHandle);
					}
				}
			}
		}
	}
}
