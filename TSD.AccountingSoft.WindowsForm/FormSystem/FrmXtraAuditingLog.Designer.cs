namespace TSD.AccountingSoft.WindowsForm.FormSystem
{
    partial class FrmXtraAuditingLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmXtraAuditingLog));
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lookUpUser = new DevExpress.XtraEditors.LookUpEdit();
            this.grdLookUpRefType = new DevExpress.XtraEditors.LookUpEdit();
            this.checkEditAllRefType = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditAllUser = new DevExpress.XtraEditors.CheckEdit();
            this.btnFilter = new DevExpress.XtraEditors.SimpleButton();
            this.dateTimeRangeV = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.grdMain = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpRefType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditAllRefType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditAllUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.lookUpUser);
            this.groupControl2.Controls.Add(this.grdLookUpRefType);
            this.groupControl2.Controls.Add(this.checkEditAllRefType);
            this.groupControl2.Controls.Add(this.checkEditAllUser);
            this.groupControl2.Controls.Add(this.btnFilter);
            this.groupControl2.Controls.Add(this.dateTimeRangeV);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Location = new System.Drawing.Point(6, 6);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(784, 64);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Tùy chọn";
            // 
            // lookUpUser
            // 
            this.lookUpUser.Location = new System.Drawing.Point(86, 11);
            this.lookUpUser.Name = "lookUpUser";
            this.lookUpUser.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.lookUpUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.lookUpUser.Properties.NullText = "";
            this.lookUpUser.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpUser.Size = new System.Drawing.Size(128, 20);
            this.lookUpUser.TabIndex = 0;
            // 
            // grdLookUpRefType
            // 
            this.grdLookUpRefType.Location = new System.Drawing.Point(86, 36);
            this.grdLookUpRefType.Name = "grdLookUpRefType";
            this.grdLookUpRefType.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.grdLookUpRefType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.grdLookUpRefType.Properties.NullText = "";
            this.grdLookUpRefType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdLookUpRefType.Size = new System.Drawing.Size(128, 20);
            this.grdLookUpRefType.TabIndex = 1;
            // 
            // checkEditAllRefType
            // 
            this.checkEditAllRefType.Location = new System.Drawing.Point(220, 37);
            this.checkEditAllRefType.Name = "checkEditAllRefType";
            this.checkEditAllRefType.Properties.Caption = "Chọn tất";
            this.checkEditAllRefType.Size = new System.Drawing.Size(75, 19);
            this.checkEditAllRefType.TabIndex = 3;
            this.checkEditAllRefType.CheckedChanged += new System.EventHandler(this.checkEditAllRefType_CheckedChanged);
            // 
            // checkEditAllUser
            // 
            this.checkEditAllUser.Location = new System.Drawing.Point(220, 12);
            this.checkEditAllUser.Name = "checkEditAllUser";
            this.checkEditAllUser.Properties.Caption = "Chọn tất";
            this.checkEditAllUser.Size = new System.Drawing.Size(75, 19);
            this.checkEditAllUser.TabIndex = 3;
            this.checkEditAllUser.CheckedChanged += new System.EventHandler(this.checkEditAllUser_CheckedChanged);
            // 
            // btnFilter
            // 
            this.btnFilter.Image = global::TSD.AccountingSoft.WindowsForm.Properties.Resources.filter1;
            this.btnFilter.Location = new System.Drawing.Point(629, 9);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(130, 47);
            this.btnFilter.TabIndex = 0;
            this.btnFilter.Text = "Lọc dữ liệu";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dateTimeRangeV
            // 
            this.dateTimeRangeV.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.dateTimeRangeV.Appearance.Options.UseBackColor = true;
            this.dateTimeRangeV.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.All;
            this.dateTimeRangeV.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV.InitSelectedIndex = 0;
            this.dateTimeRangeV.Location = new System.Drawing.Point(320, -3);
            this.dateTimeRangeV.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV.Name = "dateTimeRangeV";
            this.dateTimeRangeV.PeriodLabelText = "Thời gian";
            this.dateTimeRangeV.Size = new System.Drawing.Size(295, 70);
            this.dateTimeRangeV.TabIndex = 2;
            this.dateTimeRangeV.ToDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV.ToDateLabelText = "Đến ngày";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(10, 40);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(39, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Phân hệ";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(10, 13);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(70, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Người sử dụng";
            // 
            // grdMain
            // 
            this.grdMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdMain.Location = new System.Drawing.Point(6, 79);
            this.grdMain.MainView = this.gridView;
            this.grdMain.Name = "grdMain";
            this.grdMain.Size = new System.Drawing.Size(784, 453);
            this.grdMain.TabIndex = 12;
            this.grdMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView.GridControl = this.grdMain;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridView.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            // 
            // FrmXtraAuditingLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 535);
            this.Controls.Add(this.grdMain);
            this.Controls.Add(this.groupControl2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmXtraAuditingLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhật ký truy cập";
            this.Load += new System.EventHandler(this.FrmXtraAuditingLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpRefType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditAllRefType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditAllUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.CheckEdit checkEditAllRefType;
        private DevExpress.XtraEditors.CheckEdit checkEditAllUser;
        private DevExpress.XtraEditors.SimpleButton btnFilter;
        public DevExpress.XtraGrid.GridControl grdMain;
        protected DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.LookUpEdit grdLookUpRefType;
        private DevExpress.XtraEditors.LookUpEdit lookUpUser;
    }
}