using SHDocVw;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SupportChat.Popup
{
	public class InternetExplorerBrowser : IBrowser
	{
		[DllImport("user32.dll", SetLastError = true)]
		static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool SetForegroundWindow(IntPtr hWnd);

		public string Path { get; set; }
		public string Name => "IEXPLORE.EXE";

		public void Run(string url)
		{
			var ieUrl = (object)url;
			var sHeight = Screen.PrimaryScreen.Bounds.Height;
			var sWidth = Screen.PrimaryScreen.Bounds.Width;

			var IE = new InternetExplorer
			{
				ToolBar = 0,
				StatusBar = false,
				AddressBar = false,
				MenuBar = false,
				Height = ((sHeight * 70) / 100),
				Width = ((sWidth * 40) / 100),
				Visible = true
			};

			IE.Navigate2(ref ieUrl);
			SetForegroundWindow((IntPtr)IE.HWND);

			this.ChatWindowMonitor((IntPtr)IE.HWND, new Uri(url));
		}

		private void ChatWindowMonitor(IntPtr hWnd, Uri uri)
		{
			var processId = (uint)0;
			Process process = null;

			while (true)
			{
				try
				{
					GetWindowThreadProcessId(hWnd, out processId);
					process = Process.GetProcessById((int)processId);
					Thread.Sleep(2 * 1000);
				}
				catch
				{
					var activeIE = Process.GetProcessesByName("iexplore");
					process = activeIE?.FirstOrDefault(p => HelperUtility.IsActiveProcess(uri, p.MainWindowTitle));
					if (process != null)
					{
						hWnd = process.Handle;
					}
					else
					{
						Environment.Exit(1);
						return;
					}
				}
			}
		}

		public void SetPath(string path)
		{
			this.Path = path;
		}
	}
}
