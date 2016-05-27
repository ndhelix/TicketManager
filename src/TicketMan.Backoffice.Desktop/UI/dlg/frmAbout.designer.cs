namespace TicketMan.Backoffice.Desktop
{
	partial class FrmAbout
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
			this.btnOK = new System.Windows.Forms.Button();
			this.lblDesktopLabel = new System.Windows.Forms.Label();
			this.lblVersion = new System.Windows.Forms.Label();
			this.lblApiVersion = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblUrl = new System.Windows.Forms.Label();
			this.lblSiteslug = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(281, 205);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(71, 30);
			this.btnOK.TabIndex = 10;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnOK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAbout_KeyDown);
			// 
			// lblDesktopLabel
			// 
			this.lblDesktopLabel.AutoSize = true;
			this.lblDesktopLabel.Font = new System.Drawing.Font("Corbel", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblDesktopLabel.Location = new System.Drawing.Point(50, 99);
			this.lblDesktopLabel.Name = "lblDesktopLabel";
			this.lblDesktopLabel.Size = new System.Drawing.Size(252, 23);
			this.lblDesktopLabel.TabIndex = 0;
			this.lblDesktopLabel.Text = "TicketMan Backoffice Desktop";
			// 
			// lblVersion
			// 
			this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblVersion.AutoSize = true;
			this.lblVersion.Location = new System.Drawing.Point(12, 191);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(62, 17);
			this.lblVersion.TabIndex = 0;
			this.lblVersion.Text = "Версия: ";
			// 
			// lblApiVersion
			// 
			this.lblApiVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblApiVersion.AutoSize = true;
			this.lblApiVersion.Location = new System.Drawing.Point(12, 214);
			this.lblApiVersion.Name = "lblApiVersion";
			this.lblApiVersion.Size = new System.Drawing.Size(86, 17);
			this.lblApiVersion.TabIndex = 0;
			this.lblApiVersion.Text = "Версия API: ";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::TicketMan.Backoffice.Desktop.Properties.Resources.TicketMan_logo;
			this.pictureBox1.Location = new System.Drawing.Point(30, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(313, 69);
			this.pictureBox1.TabIndex = 14;
			this.pictureBox1.TabStop = false;
			// 
			// lblUrl
			// 
			this.lblUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblUrl.AutoSize = true;
			this.lblUrl.Location = new System.Drawing.Point(12, 168);
			this.lblUrl.Name = "lblUrl";
			this.lblUrl.Size = new System.Drawing.Size(42, 17);
			this.lblUrl.TabIndex = 0;
			this.lblUrl.Text = "URL: ";
			// 
			// lblSiteslug
			// 
			this.lblSiteslug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblSiteslug.AutoSize = true;
			this.lblSiteslug.Location = new System.Drawing.Point(12, 145);
			this.lblSiteslug.Name = "lblSiteslug";
			this.lblSiteslug.Size = new System.Drawing.Size(65, 17);
			this.lblSiteslug.TabIndex = 0;
			this.lblSiteslug.Text = "SiteSlug: ";
			// 
			// FrmAbout
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(364, 247);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.lblApiVersion);
			this.Controls.Add(this.lblSiteslug);
			this.Controls.Add(this.lblUrl);
			this.Controls.Add(this.lblVersion);
			this.Controls.Add(this.lblDesktopLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "FrmAbout";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "О программе";
			this.Load += new System.EventHandler(this.FrmAbout_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAbout_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

    }

    #endregion

		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label lblDesktopLabel;
		private System.Windows.Forms.Label lblVersion;
		private System.Windows.Forms.Label lblApiVersion;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lblUrl;
		private System.Windows.Forms.Label lblSiteslug;
  }
}