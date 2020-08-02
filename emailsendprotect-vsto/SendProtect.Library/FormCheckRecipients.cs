using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SendProtect.Library
{
	public partial class frmCheckRecipients : Form
	{
		private bool _cancelSend = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="frmCheckRecipients"/> class.
		/// </summary>
		/// <param name="domainDict">The domain dictionary.</param>
		/// <param name="emailAttachments">The email attachments.</param>
		public frmCheckRecipients(List<string> domains, List<string> emailAttachments)
		{
			InitializeComponent();

			var assembly = System.Reflection.Assembly.GetExecutingAssembly();
			var version = assembly?.GetName().Version;
			if (version != null)
			{
				lblAppVersion.Text = $"Version {version.Major}.{version.Minor}";
			}

			this.PopulateListBox(lstCheckDomains, domains, "Address");

			if (emailAttachments != null && emailAttachments.Count > 0)
			{
				lblTitle.Text = "Please confirm by ticking each box that you want to send the listed Attachments to External.";
				splitContainer1.Panel2Collapsed = false;
				this.PopulateListBox(lstCheckAttachments, emailAttachments, "FileName");
			}
			else
			{
				lblTitle.Text = "Please confirm by ticking each box that you want to send the Mail to External.";
				splitContainer1.Panel2Collapsed = true;
			}
		}

		/// <summary>
		/// Gets the cancel send.
		/// </summary>
		/// <value>
		/// The cancel send.
		/// </value>
		public object CancelSend => _cancelSend;

		/// <summary>
		/// Checks all selected.
		/// </summary>
		/// <param name="OffsetAtt">The offset att.</param>
		/// <param name="OffsetDom">The offset DOM.</param>
		/// <returns></returns>
		private bool CheckAllSelected(int OffsetAtt, int OffsetDom)
		{
			return lstCheckAttachments.Items.Count == (lstCheckAttachments.CheckedItems.Count + OffsetAtt) &&
					lstCheckDomains.Items.Count == (lstCheckDomains.CheckedItems.Count + OffsetDom);
		}

		/// <summary>
		/// Handles the ItemChange event of the CheckBox control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="ItemCheckEventArgs"/> instance containing the event data.</param>
		private void CheckBox_ItemChange(object sender, ItemCheckEventArgs e)
		{
			WaitAction();
			if (e.NewValue != CheckState.Checked)
				this.btnCmdSend.Enabled = false;
			else
				this.btnCmdSend.Enabled = CheckIfDone((CheckedListBox)sender);

			EnableAction();
		}

		/// <summary>
		/// Checks if done.
		/// </summary>
		/// <param name="Sender">The sender.</param>
		/// <returns></returns>
		private bool CheckIfDone(CheckedListBox Sender)
		{
			if (Sender.Name == lstCheckAttachments.Name)
				return CheckAllSelected(1, 0);
			else if (Sender.Name == lstCheckDomains.Name)
				return CheckAllSelected(0, 1);
			else
				return CheckAllSelected(0, 0);
		}

		/// <summary>
		/// Commands the cancel click.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void CmdCancelClick(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Commands the send click.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void CmdSendClick(object sender, EventArgs e)
		{
			_cancelSend = false;
			this.Close();
		}

		/// <summary>
		/// Enables the action.
		/// </summary>
		private void EnableAction()
		{
			this.lstCheckDomains.CheckOnClick = true;
			this.lstCheckAttachments.CheckOnClick = true;
			Application.UseWaitCursor = false;
		}

		/// <summary>
		/// Populates the ListBox.
		/// </summary>
		/// <param name="ListBox">The ListBox.</param>
		/// <param name="array">The array.</param>
		/// <param name="name">The name.</param>
		private void PopulateListBox(CheckedListBox ListBox, List<string> lists, string name)
		{
			ListBox.DisplayMember = name;

			foreach (var item in lists)
				ListBox.Items.Add(item);
		}

		/// <summary>
		/// Waits the action.
		/// </summary>
		private void WaitAction()
		{
			this.lstCheckDomains.CheckOnClick = false;
			this.lstCheckAttachments.CheckOnClick = false;
			Application.UseWaitCursor = true;
		}
	}
}