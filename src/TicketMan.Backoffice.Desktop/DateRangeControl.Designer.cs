namespace TicketMan.Backoffice.Desktop
{
  partial class DateRangeControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.lookUpDate = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelDate = new DevExpress.XtraEditors.PanelControl();
            this.btnDateFilterApply = new DevExpress.XtraEditors.SimpleButton();
            this.dateEditTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDate)).BeginInit();
            this.panelDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lookUpDate
            // 
            this.lookUpDate.Location = new System.Drawing.Point(114, 1);
            this.lookUpDate.Name = "lookUpDate";
            this.lookUpDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpDate.Properties.NullText = "";
            this.lookUpDate.Size = new System.Drawing.Size(121, 22);
            this.lookUpDate.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 16);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Created on";
            // 
            // panelDate
            // 
            this.panelDate.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelDate.Controls.Add(this.btnDateFilterApply);
            this.panelDate.Controls.Add(this.dateEditTo);
            this.panelDate.Controls.Add(this.labelControl5);
            this.panelDate.Controls.Add(this.dateEditFrom);
            this.panelDate.Controls.Add(this.labelControl4);
            this.panelDate.Location = new System.Drawing.Point(3, 25);
            this.panelDate.Name = "panelDate";
            this.panelDate.Size = new System.Drawing.Size(294, 27);
            this.panelDate.TabIndex = 8;
            // 
            // btnDateFilterApply
            // 
            this.btnDateFilterApply.Location = new System.Drawing.Point(260, 2);
            this.btnDateFilterApply.Name = "btnDateFilterApply";
            this.btnDateFilterApply.Size = new System.Drawing.Size(29, 23);
            this.btnDateFilterApply.TabIndex = 7;
            this.btnDateFilterApply.Text = "OK";
            this.btnDateFilterApply.Click += new System.EventHandler(this.btnDateFilterApply_Click);
            // 
            // dateEditTo
            // 
            this.dateEditTo.EditValue = null;
            this.dateEditTo.Location = new System.Drawing.Point(147, 3);
            this.dateEditTo.Name = "dateEditTo";
            this.dateEditTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditTo.Size = new System.Drawing.Size(105, 22);
            this.dateEditTo.TabIndex = 5;
            this.dateEditTo.EditValueChanged += new System.EventHandler(this.dateEditTo_EditValueChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(128, 6);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(14, 16);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "по";
            // 
            // dateEditFrom
            // 
            this.dateEditFrom.EditValue = null;
            this.dateEditFrom.Location = new System.Drawing.Point(19, 3);
            this.dateEditFrom.Name = "dateEditFrom";
            this.dateEditFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditFrom.Size = new System.Drawing.Size(105, 22);
            this.dateEditFrom.TabIndex = 5;
            this.dateEditFrom.EditValueChanged += new System.EventHandler(this.dateEditFrom_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(2, 6);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(8, 16);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "С";
            // 
            // DateRangeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelDate);
            this.Controls.Add(this.lookUpDate);
            this.Controls.Add(this.labelControl1);
            this.Name = "DateRangeControl";
            this.Size = new System.Drawing.Size(297, 52);
            this.Load += new System.EventHandler(this.DateRangeControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDate)).EndInit();
            this.panelDate.ResumeLayout(false);
            this.panelDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraEditors.LookUpEdit lookUpDate;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.PanelControl panelDate;
    private DevExpress.XtraEditors.SimpleButton btnDateFilterApply;
    private DevExpress.XtraEditors.DateEdit dateEditTo;
    private DevExpress.XtraEditors.LabelControl labelControl5;
    private DevExpress.XtraEditors.DateEdit dateEditFrom;
    private DevExpress.XtraEditors.LabelControl labelControl4;

  }
}
