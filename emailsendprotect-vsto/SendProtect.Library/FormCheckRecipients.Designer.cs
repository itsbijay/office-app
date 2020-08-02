namespace SendProtect.Library
{
    partial class frmCheckRecipients
    {
        #region Windows Form Designer generated code

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
			this.Label4 = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
			this.btnCmdSend = new System.Windows.Forms.Button();
			this.btnCmdCancel = new System.Windows.Forms.Button();
			this.lstCheckAttachments = new System.Windows.Forms.CheckedListBox();
			this.lstCheckDomains = new System.Windows.Forms.CheckedListBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.label1 = new System.Windows.Forms.Label();
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.lblAppVersion = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Dock = System.Windows.Forms.DockStyle.Top;
			this.Label4.Font = new System.Drawing.Font("Arial Narrow", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Label4.Location = new System.Drawing.Point(0, 0);
			this.Label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(68, 17);
			this.Label4.TabIndex = 16;
			this.Label4.Text = "Attachments";
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Arial Narrow", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lblTitle.Location = new System.Drawing.Point(11, 11);
			this.lblTitle.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(444, 17);
			this.lblTitle.TabIndex = 14;
			this.lblTitle.Text = "Please confirm by ticking each box that you want to send the listed Attachments t" +
    "o External.";
			// 
			// btnCmdSend
			// 
			this.btnCmdSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCmdSend.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnCmdSend.Enabled = false;
			this.btnCmdSend.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnCmdSend.Location = new System.Drawing.Point(460, 315);
			this.btnCmdSend.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
			this.btnCmdSend.Name = "btnCmdSend";
			this.btnCmdSend.Size = new System.Drawing.Size(66, 28);
			this.btnCmdSend.TabIndex = 4;
			this.btnCmdSend.Text = "Send";
			this.btnCmdSend.UseVisualStyleBackColor = true;
			this.btnCmdSend.Click += new System.EventHandler(this.CmdSendClick);
			// 
			// btnCmdCancel
			// 
			this.btnCmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCmdCancel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btnCmdCancel.Location = new System.Drawing.Point(386, 315);
			this.btnCmdCancel.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
			this.btnCmdCancel.Name = "btnCmdCancel";
			this.btnCmdCancel.Size = new System.Drawing.Size(66, 28);
			this.btnCmdCancel.TabIndex = 3;
			this.btnCmdCancel.Text = "Cancel";
			this.btnCmdCancel.UseVisualStyleBackColor = true;
			// 
			// lstCheckAttachments
			// 
			this.lstCheckAttachments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstCheckAttachments.CheckOnClick = true;
			this.lstCheckAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstCheckAttachments.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lstCheckAttachments.ForeColor = System.Drawing.Color.DarkBlue;
			this.lstCheckAttachments.IntegralHeight = false;
			this.lstCheckAttachments.Location = new System.Drawing.Point(0, 17);
			this.lstCheckAttachments.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
			this.lstCheckAttachments.Name = "lstCheckAttachments";
			this.lstCheckAttachments.Size = new System.Drawing.Size(359, 241);
			this.lstCheckAttachments.Sorted = true;
			this.lstCheckAttachments.TabIndex = 2;
			this.lstCheckAttachments.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckBox_ItemChange);
			// 
			// lstCheckDomains
			// 
			this.lstCheckDomains.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstCheckDomains.CheckOnClick = true;
			this.lstCheckDomains.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstCheckDomains.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lstCheckDomains.ForeColor = System.Drawing.Color.DarkBlue;
			this.lstCheckDomains.IntegralHeight = false;
			this.lstCheckDomains.Location = new System.Drawing.Point(0, 17);
			this.lstCheckDomains.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
			this.lstCheckDomains.Name = "lstCheckDomains";
			this.lstCheckDomains.Size = new System.Drawing.Size(153, 241);
			this.lstCheckDomains.Sorted = true;
			this.lstCheckDomains.TabIndex = 1;
			this.lstCheckDomains.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckBox_ItemChange);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(2, 3);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.lstCheckDomains);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.lstCheckAttachments);
			this.splitContainer1.Panel2.Controls.Add(this.Label4);
			this.splitContainer1.Size = new System.Drawing.Size(515, 258);
			this.splitContainer1.SplitterDistance = 153;
			this.splitContainer1.SplitterWidth = 3;
			this.splitContainer1.TabIndex = 17;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Arial Narrow", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 17);
			this.label1.TabIndex = 16;
			this.label1.Text = "Domains";
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel.AutoSize = true;
			this.tableLayoutPanel.ColumnCount = 1;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel.Controls.Add(this.splitContainer1, 0, 0);
			this.tableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			this.tableLayoutPanel.Location = new System.Drawing.Point(8, 39);
			this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 1;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(519, 264);
			this.tableLayoutPanel.TabIndex = 18;
			// 
			// lblAppVersion
			// 
			this.lblAppVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblAppVersion.AutoSize = true;
			this.lblAppVersion.Font = new System.Drawing.Font("Arial Narrow", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lblAppVersion.Location = new System.Drawing.Point(9, 322);
			this.lblAppVersion.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.lblAppVersion.Name = "lblAppVersion";
			this.lblAppVersion.Size = new System.Drawing.Size(0, 17);
			this.lblAppVersion.TabIndex = 19;
			// 
			// frmCheckRecipients
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 22F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.CancelButton = this.btnCmdCancel;
			this.ClientSize = new System.Drawing.Size(536, 355);
			this.Controls.Add(this.lblAppVersion);
			this.Controls.Add(this.tableLayoutPanel);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.btnCmdSend);
			this.Controls.Add(this.btnCmdCancel);
			this.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.MinimumSize = new System.Drawing.Size(514, 402);
			this.Name = "frmCheckRecipients";
			this.Text = "Send Protect";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tableLayoutPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.Button btnCmdSend;
        internal System.Windows.Forms.Button btnCmdCancel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        internal System.Windows.Forms.CheckedListBox lstCheckDomains;
        internal System.Windows.Forms.CheckedListBox lstCheckAttachments;
		internal System.Windows.Forms.Label lblAppVersion;
	}
}