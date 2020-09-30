#define IgnorePopup

using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace SupportChat.Shortcut
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args != null && args.Any())
			{
				if (Uri.TryCreate(args[0], UriKind.RelativeOrAbsolute, out Uri path))
				{
					var url = path.ToString();
#if IgnorePopup
					Process.Start(url);
#else
					if (Helper.Ping(url))
					{
						Process.Start(url);
					}
					else
					{
						MessageBox.Show("EYRC is not connected, Please try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
#endif
				}
			}
		}
	}
}
