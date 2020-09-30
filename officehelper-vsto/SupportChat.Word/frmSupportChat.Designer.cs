using System;
using System.Windows.Forms;

namespace SupportChat
{
	partial class frmSupportChat
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.wbChatPage = new System.Windows.Forms.WebBrowser();
			this.SuspendLayout();
			// 
			// wbChatPage
			// 
			this.wbChatPage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wbChatPage.Location = new System.Drawing.Point(0, 0);
			this.wbChatPage.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbChatPage.Name = "wbChatPage";
			this.wbChatPage.Size = new System.Drawing.Size(795, 473);
			this.wbChatPage.TabIndex = 0;
			this.wbChatPage.Url = new System.Uri("C:\\Git\\EUTX.PervasiveChat\\PervasiveChat\\VSTO\\SupportChat.Word\\bin\\Debug\\a.ht" +
        "ml", System.UriKind.Absolute);
			// 
			// frmSupportChat
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(795, 473);
			this.Controls.Add(this.wbChatPage);
			this.Name = "frmSupportChat";
			this.Text = "EY Support Chat";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.WebBrowser wbChatPage;
	}
}