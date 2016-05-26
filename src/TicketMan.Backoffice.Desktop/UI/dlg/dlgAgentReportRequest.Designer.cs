namespace TicketMan.Backoffice.Desktop.UI.dlg
{
  partial class DlgAgentReportRequest
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgAgentReportRequest));
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.calFrom = new DevExpress.XtraEditors.DateEdit();
			this.label2 = new System.Windows.Forms.Label();
			this.calTo = new DevExpress.XtraEditors.DateEdit();
			this.label3 = new System.Windows.Forms.Label();
			this.cbFormat = new DevExpress.XtraEditors.LookUpEdit();
			((System.ComponentModel.ISupportInitialize)(this.calFrom.Properties.VistaTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.calFrom.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.calTo.Properties.VistaTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.calTo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbFormat.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(151, 122);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(66, 27);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(79, 122);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(67, 27);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(17, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "C";
			// 
			// calFrom
			// 
			this.calFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.calFrom.EditValue = null;
			this.calFrom.Location = new System.Drawing.Point(50, 10);
			this.calFrom.Name = "calFrom";
			this.calFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
			this.calFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.calFrom.Properties.ValidateOnEnterKey = true;
			this.calFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.calFrom.Size = new System.Drawing.Size(168, 22);
			this.calFrom.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(25, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "По";
			// 
			// calTo
			// 
			this.calTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.calTo.EditValue = null;
			this.calTo.Location = new System.Drawing.Point(50, 38);
			this.calTo.Name = "calTo";
			this.calTo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
			this.calTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.calTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.calTo.Size = new System.Drawing.Size(168, 22);
			this.calTo.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Формат";
			// 
			// cbFormat
			// 
			this.cbFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbFormat.Location = new System.Drawing.Point(72, 77);
			this.cbFormat.Name = "cbFormat";
			this.cbFormat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cbFormat.Size = new System.Drawing.Size(145, 22);
			this.cbFormat.TabIndex = 54;
			// 
			// DlgAgentReportRequest
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(227, 157);
			this.Controls.Add(this.cbFormat);
			this.Controls.Add(this.calTo);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.calFrom);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DlgAgentReportRequest";
			this.Text = "Параметры отчета";
			this.Load += new System.EventHandler(this.DlgAgentReportRequest_Load);
			((System.ComponentModel.ISupportInitialize)(this.calFrom.Properties.VistaTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.calFrom.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.calTo.Properties.VistaTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.calTo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbFormat.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label label1;
		private DevExpress.XtraEditors.DateEdit calFrom;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraEditors.DateEdit calTo;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.LookUpEdit cbFormat;
  }
}