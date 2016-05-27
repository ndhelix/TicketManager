namespace TicketMan.Backoffice.Desktop.UI.dlg
{
    partial class DlgChangeLoginPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgChangeLoginPassword));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNewReg = new System.Windows.Forms.Label();
            this.txtLoginOld = new DevExpress.XtraEditors.TextEdit();
            this.txtNewReg = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginOld.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewReg.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(244, 74);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 27);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(172, 74);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(67, 27);
            this.btnOK.TabIndex = 22;
            this.btnOK.Text = "Save";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Логин";
            // 
            // lblNewReg
            // 
            this.lblNewReg.AutoSize = true;
            this.lblNewReg.Location = new System.Drawing.Point(8, 41);
            this.lblNewReg.Name = "lblNewReg";
            this.lblNewReg.Size = new System.Drawing.Size(50, 17);
            this.lblNewReg.TabIndex = 2;
            this.lblNewReg.Text = "Новый";
            // 
            // txtLoginOld
            // 
            this.txtLoginOld.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLoginOld.Location = new System.Drawing.Point(123, 10);
            this.txtLoginOld.Name = "txtLoginOld";
            this.txtLoginOld.Properties.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.txtLoginOld.Properties.Appearance.Options.UseBackColor = true;
            this.txtLoginOld.Properties.ReadOnly = true;
            this.txtLoginOld.Size = new System.Drawing.Size(185, 22);
            this.txtLoginOld.TabIndex = 3;
            // 
            // txtNewReg
            // 
            this.txtNewReg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewReg.Location = new System.Drawing.Point(123, 38);
            this.txtNewReg.Name = "txtNewReg";
            this.txtNewReg.Size = new System.Drawing.Size(185, 22);
            this.txtNewReg.TabIndex = 9;
            // 
            // DlgChangeLoginPassword
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(320, 109);
            this.Controls.Add(this.txtNewReg);
            this.Controls.Add(this.txtLoginOld);
            this.Controls.Add(this.lblNewReg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DlgChangeLoginPassword";
            this.Text = "Изменение";
            this.Load += new System.EventHandler(this.DlgChangeLoginPassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginOld.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewReg.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOK;
	private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lblNewReg;
	private DevExpress.XtraEditors.TextEdit txtLoginOld;
    private DevExpress.XtraEditors.TextEdit txtNewReg;
  }
}