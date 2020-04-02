namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    partial class FrmXtraSalaryPostedVoucher
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
            this.grdlookUpEmployee = new DevExpress.XtraGrid.GridControl();
            this.gridViewEmployee = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridSalaryVoucher = new DevExpress.XtraGrid.GridControl();
            this.gridViewSalaryVoucher = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPostedVoucher = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelCalc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdlookUpEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSalaryVoucher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSalaryVoucher)).BeginInit();
            this.SuspendLayout();
            // 
            // grdlookUpEmployee
            // 
            this.grdlookUpEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdlookUpEmployee.Location = new System.Drawing.Point(12, 211);
            this.grdlookUpEmployee.MainView = this.gridViewEmployee;
            this.grdlookUpEmployee.Name = "grdlookUpEmployee";
            this.grdlookUpEmployee.Size = new System.Drawing.Size(630, 205);
            this.grdlookUpEmployee.TabIndex = 6;
            this.grdlookUpEmployee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEmployee});
            // 
            // gridViewEmployee
            // 
            this.gridViewEmployee.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridViewEmployee.GridControl = this.grdlookUpEmployee;
            this.gridViewEmployee.Name = "gridViewEmployee";
            this.gridViewEmployee.OptionsBehavior.Editable = false;
            this.gridViewEmployee.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewEmployee.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridViewEmployee.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewEmployee.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewEmployee.OptionsSelection.MultiSelect = true;
            this.gridViewEmployee.OptionsView.ShowGroupPanel = false;
            this.gridViewEmployee.OptionsView.ShowIndicator = false;
            this.gridViewEmployee.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridSalaryVoucher
            // 
            this.gridSalaryVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSalaryVoucher.Location = new System.Drawing.Point(12, 31);
            this.gridSalaryVoucher.MainView = this.gridViewSalaryVoucher;
            this.gridSalaryVoucher.Name = "gridSalaryVoucher";
            this.gridSalaryVoucher.Size = new System.Drawing.Size(630, 155);
            this.gridSalaryVoucher.TabIndex = 5;
            this.gridSalaryVoucher.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSalaryVoucher});
            // 
            // gridViewSalaryVoucher
            // 
            this.gridViewSalaryVoucher.GridControl = this.gridSalaryVoucher;
            this.gridViewSalaryVoucher.Name = "gridViewSalaryVoucher";
            this.gridViewSalaryVoucher.OptionsBehavior.Editable = false;
            this.gridViewSalaryVoucher.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewSalaryVoucher.OptionsView.ShowGroupPanel = false;
            this.gridViewSalaryVoucher.OptionsView.ShowIndicator = false;
            this.gridViewSalaryVoucher.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewSalaryVoucher_RowClick);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(580, 422);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(62, 25);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "&Thoát";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPostedVoucher
            // 
            this.btnPostedVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPostedVoucher.Location = new System.Drawing.Point(12, 422);
            this.btnPostedVoucher.Name = "btnPostedVoucher";
            this.btnPostedVoucher.Size = new System.Drawing.Size(71, 25);
            this.btnPostedVoucher.TabIndex = 7;
            this.btnPostedVoucher.Text = "&Ghi sổ";
            this.btnPostedVoucher.UseVisualStyleBackColor = true;
            this.btnPostedVoucher.Click += new System.EventHandler(this.btnPostedVoucher_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Chọn chứng từ ghi sổ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 192);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nhân viên tính cho chứng từ";
            // 
            // btnCancelCalc
            // 
            this.btnCancelCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelCalc.Location = new System.Drawing.Point(471, 422);
            this.btnCancelCalc.Name = "btnCancelCalc";
            this.btnCancelCalc.Size = new System.Drawing.Size(103, 25);
            this.btnCancelCalc.TabIndex = 11;
            this.btnCancelCalc.Text = "&Hủy tính lương";
            this.btnCancelCalc.UseVisualStyleBackColor = true;
            this.btnCancelCalc.Click += new System.EventHandler(this.btnCancelCalc_Click);
            // 
            // FrmXtraSalaryPostedVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 459);
            this.Controls.Add(this.btnCancelCalc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPostedVoucher);
            this.Controls.Add(this.grdlookUpEmployee);
            this.Controls.Add(this.gridSalaryVoucher);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmXtraSalaryPostedVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn chứng từ chưa ghi sổ";
            this.Load += new System.EventHandler(this.FrmXtraSalaryPostedVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdlookUpEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSalaryVoucher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSalaryVoucher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdlookUpEmployee;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEmployee;
        private DevExpress.XtraGrid.GridControl gridSalaryVoucher;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSalaryVoucher;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPostedVoucher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelCalc;
    }
}