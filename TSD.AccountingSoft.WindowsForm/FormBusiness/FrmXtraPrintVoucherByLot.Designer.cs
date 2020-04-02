namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    partial class FrmXtraPrintVoucherByLot
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
            this.components = new System.ComponentModel.Container();
            this.gridVoucherControl = new DevExpress.XtraGrid.GridControl();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridVoucherView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cboReportList = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnSetDefaultReport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridVoucherControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVoucherView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboReportList.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridVoucherControl
            // 
            this.gridVoucherControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridVoucherControl.DataSource = this.bindingSource;
            this.gridVoucherControl.Location = new System.Drawing.Point(10, 9);
            this.gridVoucherControl.MainView = this.gridVoucherView;
            this.gridVoucherControl.Name = "gridVoucherControl";
            this.gridVoucherControl.Size = new System.Drawing.Size(680, 321);
            this.gridVoucherControl.TabIndex = 0;
            this.gridVoucherControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridVoucherView});
            // 
            // gridVoucherView
            // 
            this.gridVoucherView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridVoucherView.GridControl = this.gridVoucherControl;
            this.gridVoucherView.Name = "gridVoucherView";
            this.gridVoucherView.OptionsDetail.EnableMasterViewMode = false;
            this.gridVoucherView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridVoucherView.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridVoucherView.OptionsView.ShowGroupPanel = false;
            this.gridVoucherView.OptionsView.ShowIndicator = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(510, 336);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(109, 43);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Xem";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(625, 336);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 43);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.cboReportList);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.btnSetDefaultReport);
            this.panelControl1.Location = new System.Drawing.Point(10, 336);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(494, 43);
            this.panelControl1.TabIndex = 4;
            // 
            // cboReportList
            // 
            this.cboReportList.Location = new System.Drawing.Point(75, 13);
            this.cboReportList.Name = "cboReportList";
            this.cboReportList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboReportList.Properties.NullText = "";
            this.cboReportList.Properties.ShowFooter = false;
            this.cboReportList.Properties.ShowHeader = false;
            this.cboReportList.Properties.ShowLines = false;
            this.cboReportList.Size = new System.Drawing.Size(292, 20);
            this.cboReportList.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Mẫu báo cáo";
            // 
            // btnSetDefaultReport
            // 
            this.btnSetDefaultReport.Location = new System.Drawing.Point(373, 10);
            this.btnSetDefaultReport.Name = "btnSetDefaultReport";
            this.btnSetDefaultReport.Size = new System.Drawing.Size(119, 23);
            this.btnSetDefaultReport.TabIndex = 5;
            this.btnSetDefaultReport.Text = "Đặt là mẫu ngầm định";
            this.btnSetDefaultReport.Click += new System.EventHandler(this.btnSetDefaultReport_Click);
            // 
            // FrmXtraPrintVoucherByLot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 385);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.gridVoucherControl);
            this.MinimizeBox = false;
            this.Name = "FrmXtraPrintVoucherByLot";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem chứng từ theo lô";
            this.Load += new System.EventHandler(this.FrmXtraPrintVoucherByLot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridVoucherControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVoucherView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboReportList.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridVoucherControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridVoucherView;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSetDefaultReport;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraEditors.LookUpEdit cboReportList;
    }
}