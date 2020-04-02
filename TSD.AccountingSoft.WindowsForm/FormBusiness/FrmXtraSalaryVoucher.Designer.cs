namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    partial class FrmXtraSalaryVoucher
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
            this.btnShowVoucher = new System.Windows.Forms.Button();
            this.btnCancelSalary = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gridSalaryVoucher = new DevExpress.XtraGrid.GridControl();
            this.gridViewSalaryVoucher = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdlookUpEmployee = new DevExpress.XtraGrid.GridControl();
            this.gridViewEmployee = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridSalaryVoucher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSalaryVoucher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdlookUpEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShowVoucher
            // 
            this.btnShowVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShowVoucher.Location = new System.Drawing.Point(12, 396);
            this.btnShowVoucher.Name = "btnShowVoucher";
            this.btnShowVoucher.Size = new System.Drawing.Size(115, 25);
            this.btnShowVoucher.TabIndex = 0;
            this.btnShowVoucher.Text = "&Xem chứng từ lương";
            this.btnShowVoucher.UseVisualStyleBackColor = true;
            this.btnShowVoucher.Click += new System.EventHandler(this.btnShowVoucher_Click);
            // 
            // btnCancelSalary
            // 
            this.btnCancelSalary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelSalary.Location = new System.Drawing.Point(480, 396);
            this.btnCancelSalary.Name = "btnCancelSalary";
            this.btnCancelSalary.Size = new System.Drawing.Size(71, 25);
            this.btnCancelSalary.TabIndex = 1;
            this.btnCancelSalary.Text = "&Hủy tính";
            this.btnCancelSalary.UseVisualStyleBackColor = true;
            this.btnCancelSalary.Click += new System.EventHandler(this.btnCancelSalary_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(557, 396);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(62, 25);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Thoát";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gridSalaryVoucher
            // 
            this.gridSalaryVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSalaryVoucher.Location = new System.Drawing.Point(12, 31);
            this.gridSalaryVoucher.MainView = this.gridViewSalaryVoucher;
            this.gridSalaryVoucher.Name = "gridSalaryVoucher";
            this.gridSalaryVoucher.Size = new System.Drawing.Size(607, 155);
            this.gridSalaryVoucher.TabIndex = 3;
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
            // grdlookUpEmployee
            // 
            this.grdlookUpEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdlookUpEmployee.Location = new System.Drawing.Point(12, 211);
            this.grdlookUpEmployee.MainView = this.gridViewEmployee;
            this.grdlookUpEmployee.Name = "grdlookUpEmployee";
            this.grdlookUpEmployee.Size = new System.Drawing.Size(607, 179);
            this.grdlookUpEmployee.TabIndex = 4;
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
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 192);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Danh sách nhân viên trong chứng từ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Danh sách các chứng từ lương";
            // 
            // FrmXtraSalaryVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 433);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdlookUpEmployee);
            this.Controls.Add(this.gridSalaryVoucher);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancelSalary);
            this.Controls.Add(this.btnShowVoucher);
            this.Name = "FrmXtraSalaryVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Các chứng từ lương trong tháng";
            this.Load += new System.EventHandler(this.FrmXtraSalaryVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridSalaryVoucher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSalaryVoucher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdlookUpEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEmployee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowVoucher;
        private System.Windows.Forms.Button btnCancelSalary;
        private System.Windows.Forms.Button btnClose;
        private DevExpress.XtraGrid.GridControl gridSalaryVoucher;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSalaryVoucher;
        private DevExpress.XtraGrid.GridControl grdlookUpEmployee;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEmployee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}