using System;

namespace SendProtect.Library
{
	/// <summary>
	/// AppItemSend
	/// </summary>
	public static class AppItemSend
	{
		/// <summary>
		/// Called when [send].
		/// </summary>
		/// <param name="item">The item.</param>
		/// <param name="cancel">if set to <c>true</c> [cancel].</param>
		public static void OnSend(dynamic item, ref bool cancel)
		{
			cancel = true;
			var domains = OutlookUtility.GetExternalDomains(item);
			if (domains == null || domains.Count <= 0)
			{
				cancel = false;
				return;
			}

			var attachments = OutlookUtility.GetAttachments(item);
			using (var popup = new frmCheckRecipients(domains, attachments))
			{
				try
				{
					popup.ShowDialog();
					cancel = (bool)popup.CancelSend;
				}
				catch
				{
					item.Save();
					cancel = false;
					throw;
				}
			}

			GC.Collect();
		}
	}
}