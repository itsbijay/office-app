using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ms = Microsoft.Office.Interop.Outlook;

namespace SendProtect.Library
{
	public static class OutlookUtility
	{
		/// <summary>
		/// The allowed domain, replace your allowed domain here
		/// </summary>
		private static readonly string ALLOWED_DOMAIN = @"gmail";


		private static readonly string ALLOWED_DOMAIN_PATTERN = @"(@|\.){1}" + ALLOWED_DOMAIN + ".(com|net)$";
		private static readonly string[] ALLOWED_IMG_EXTENTIONS = { "gif", "jpg", "png", "webp", "tif", "tiff", "jpeg", "jif", "jfif", "jp2", "jpx", "j2k", "j2c" };
		private static readonly string PR_SMTP_ADDRESS = "http://schemas.microsoft.com/mapi/proptag/0x39FE001E";

		/// <summary>
		/// Gets the external domains.
		/// </summary>
		/// <param name="mailItem">The mail item.</param>
		/// <returns></returns>
		public static IList<string> GetExternalDomains(dynamic mailItem)
		{
			var recipients = mailItem.Recipients;
			if (recipients.Count <= 0) return null;

			var domains = new List<string>();

			foreach (ms.Recipient recipient in recipients)
			{
				if (recipient != null && recipient.DisplayType == ms.OlDisplayType.olUser)
				{
					var email = (string)null; try { email = recipient.PropertyAccessor.GetProperty(PR_SMTP_ADDRESS)?.ToString(); } catch { }

					if (email != null && !Regex.IsMatch(email, ALLOWED_DOMAIN_PATTERN, RegexOptions.IgnoreCase))
					{
						var tempArr = email.Split('@');
						if (tempArr.Length == 2)
						{
							var domainName = tempArr[1]?.ToLower();
							if (false == string.IsNullOrWhiteSpace(domainName))
								if (false == domains.Any(x => x == domainName))
									domains.Add(domainName);
						}

					}
				}
			}

			return domains;
		}

		/// <summary>
		/// Gets the attachments.
		/// </summary>
		/// <param name="mail">The mail.</param>
		/// <returns></returns>
		public static IList<string> GetAttachments(dynamic mail)
		{
			var attachments = new List<string>();
			if (mail?.Attachments != null)
			{
				foreach (ms.Attachment attachment in mail.Attachments)
				{
					var fileName = attachment?.DisplayName;
					if (fileName != null && !ALLOWED_IMG_EXTENTIONS.Any(f => fileName.EndsWith(f, StringComparison.InvariantCultureIgnoreCase)))
						attachments.Add(attachment.DisplayName);
				}
			}

			return attachments;
		}
	}
}