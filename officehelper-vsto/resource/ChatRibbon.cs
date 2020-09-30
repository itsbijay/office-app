#define IgnorePopup
using Microsoft.Office.Core;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;

namespace SupportChat
{
	public enum ApplicationType
	{
		none,
		excel,
		word,
		outlook,
		powerpoint,
		publisher
	}

	public static class Path
	{
		public static string Icon { get { return $"chat.png"; } }
		public static string ButtonConfiguration { get { return $"SupportChat.xml"; } }

		public static string AssemblyDirectory
		{
			get
			{
				string codeBase = Assembly.GetExecutingAssembly().CodeBase;
				UriBuilder uri = new UriBuilder(codeBase);
				string path = Uri.UnescapeDataString(uri.Path);
				return System.IO.Path.GetDirectoryName(path);
			}
		}
	}

	[ComVisible(true)]
	public partial class ChatRibbon : IRibbonExtensibility
	{

		private ApplicationType applicationType;

		private IRibbonUI ribbon;

		public ChatRibbon(ApplicationType _applicationType)
		{
			this.applicationType = _applicationType;
		}

		#region IRibbonExtensibility Members

		public string GetCustomUI(string ribbonID)
		{
			return this.GetFileResource(Path.ButtonConfiguration);
		}

		#endregion

		#region Ribbon Callbacks
		public void Ribbon_Load(Office.IRibbonUI ribbonUI)
		{
			this.ribbon = ribbonUI;
		}

		#endregion

		#region Helpers
		public Bitmap GetImage(IRibbonControl control)
		{
			var stream = this.GetAssemblyResource(Path.Icon);
			if (stream == null)
			{
				MessageBox.Show("Unable to locate chat image file chat.png", "Failed to load Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}

			return new Bitmap(stream);
		}

		#endregion

		public void OnTextButton(Office.IRibbonControl control)
		{
			if (string.IsNullOrWhiteSpace(control.Tag))
			{
				MessageBox.Show("Please configure Chat Url in SupportChat.xml file", "Url not configured", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var url = string.Format(control.Tag, this.applicationType.ToString());
			this.Run(url);
		}

		public void Run(string url)
		{
			var exe = System.IO.Path.Combine(Path.AssemblyDirectory, "SupportChat.Popup.exe");

			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo
				{
					CreateNoWindow = false,
					UseShellExecute = false,
					FileName = exe,
					WindowStyle = ProcessWindowStyle.Hidden,
					Arguments = url
				};
				Process.Start(startInfo);
			}
			catch (Exception e)
			{
				var source = "Application";
				using (EventLog myLog = new EventLog())
				{
					myLog.Source = source;
					myLog.WriteEntry($"Failed to run {exe} - {e.Message}");
					myLog.WriteEntry(e.StackTrace, EventLogEntryType.Error);
				}
			}
		}

		private Stream GetAssemblyResource(string resName)
		{
			Assembly asm = Assembly.GetExecutingAssembly();
			return asm.GetManifestResourceStream("SupportChat." + resName);
		}

		private string GetFileResource(string resName)
		{
			var path = System.IO.Path.Combine(Path.AssemblyDirectory, "SupportChat.xml");
			return File.ReadAllText(path);
		}
	}
}
