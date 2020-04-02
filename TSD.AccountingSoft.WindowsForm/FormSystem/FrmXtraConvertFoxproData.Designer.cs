namespace TSD.AccountingSoft.WindowsForm.FormSystem
{
    partial class FrmXtraConvertFoxproData
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
            this.btnSelectFile = new DevExpress.XtraEditors.ButtonEdit();
            this.lstTableName = new DevExpress.XtraEditors.ListBoxControl();
            this.gridDetailData = new DevExpress.XtraGrid.GridControl();
            this.gridDetailDataView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.progressBarControl = new DevExpress.XtraEditors.ProgressBarControl();
            this.btnHelp = new DevExpress.XtraEditors.SimpleButton();
            this.btnConvert = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.dtBalanceDate = new DevExpress.XtraEditors.DateEdit();
            this.radioConvertOption = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lstConvertTable = new DevExpress.XtraEditors.ListBoxControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtConvertLog = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelectFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstTableName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailDataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtBalanceDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBalanceDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioConvertOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstConvertTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConvertLog.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile.Location = new System.Drawing.Point(7, 8);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnSelectFile.Size = new System.Drawing.Size(417, 20);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnSelectFile_ButtonClick);
            // 
            // lstTableName
            // 
            this.lstTableName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstTableName.Location = new System.Drawing.Point(-115, 55);
            this.lstTableName.Name = "lstTableName";
            this.lstTableName.Size = new System.Drawing.Size(39, 0);
            this.lstTableName.TabIndex = 1;
            this.lstTableName.SelectedIndexChanged += new System.EventHandler(this.lstTableConvert_SelectedIndexChanged);
            // 
            // gridDetailData
            // 
            this.gridDetailData.Location = new System.Drawing.Point(199, 56);
            this.gridDetailData.MainView = this.gridDetailDataView;
            this.gridDetailData.Name = "gridDetailData";
            this.gridDetailData.Size = new System.Drawing.Size(32, 43);
            this.gridDetailData.TabIndex = 2;
            this.gridDetailData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridDetailDataView});
            // 
            // gridDetailDataView
            // 
            this.gridDetailDataView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridDetailDataView.GridControl = this.gridDetailData;
            this.gridDetailDataView.Name = "gridDetailDataView";
            this.gridDetailDataView.OptionsBehavior.Editable = false;
            this.gridDetailDataView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridDetailDataView.OptionsView.ColumnAutoWidth = false;
            // 
            // progressBarControl
            // 
            this.progressBarControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarControl.Location = new System.Drawing.Point(7, 115);
            this.progressBarControl.Name = "progressBarControl";
            this.progressBarControl.Size = new System.Drawing.Size(417, 18);
            this.progressBarControl.TabIndex = 3;
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Location = new System.Drawing.Point(7, 147);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Text = "Trợ giúp";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvert.Location = new System.Drawing.Point(248, 147);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(91, 23);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "Thực hiện";
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(349, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Silver;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.dtBalanceDate);
            this.panelControl1.Controls.Add(this.radioConvertOption);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.lstTableName);
            this.panelControl1.Controls.Add(this.lstConvertTable);
            this.panelControl1.Location = new System.Drawing.Point(7, 32);
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(418, 77);
            this.panelControl1.TabIndex = 7;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(130, 47);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(176, 13);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Ngày bắt đầu lấy chứng từ phát sinh";
            // 
            // dtBalanceDate
            // 
            this.dtBalanceDate.EditValue = null;
            this.dtBalanceDate.Location = new System.Drawing.Point(312, 44);
            this.dtBalanceDate.Name = "dtBalanceDate";
            this.dtBalanceDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtBalanceDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtBalanceDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtBalanceDate.Size = new System.Drawing.Size(100, 20);
            this.dtBalanceDate.TabIndex = 8;
            // 
            // radioConvertOption
            // 
            this.radioConvertOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioConvertOption.Location = new System.Drawing.Point(2, 2);
            this.radioConvertOption.Name = "radioConvertOption";
            this.radioConvertOption.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioConvertOption.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "Chuyển đổi toàn bộ"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(2)), "Lấy số dư đầu kỳ")});
            this.radioConvertOption.Size = new System.Drawing.Size(414, 73);
            this.radioConvertOption.TabIndex = 7;
            this.radioConvertOption.SelectedIndexChanged += new System.EventHandler(this.radioConvertOption_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(-115, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Bảng dữ liệu";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl3.Location = new System.Drawing.Point(-115, -203);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(79, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Bảng chuyển đổi";
            // 
            // lstConvertTable
            // 
            this.lstConvertTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lstConvertTable.Location = new System.Drawing.Point(-115, -184);
            this.lstConvertTable.Name = "lstConvertTable";
            this.lstConvertTable.Size = new System.Drawing.Size(29, 27);
            this.lstConvertTable.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(199, 56);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(92, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Nhật ký chuyển đổi";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(204, 75);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(69, 13);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Chi tiết dữ liệu";
            // 
            // txtConvertLog
            // 
            this.txtConvertLog.Location = new System.Drawing.Point(204, 75);
            this.txtConvertLog.Name = "txtConvertLog";
            this.txtConvertLog.Size = new System.Drawing.Size(6, 27);
            this.txtConvertLog.TabIndex = 8;
            // 
            // FrmXtraConvertFoxproData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 177);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtConvertLog);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.progressBarControl);
            this.Controls.Add(this.gridDetailData);
            this.Controls.Add(this.btnSelectFile);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmXtraConvertFoxproData";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển đổi dữ liệu";
            this.Load += new System.EventHandler(this.FrmXtraConvertFoxproData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnSelectFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstTableName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailDataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtBalanceDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBalanceDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioConvertOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstConvertTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConvertLog.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ButtonEdit btnSelectFile;
        private DevExpress.XtraEditors.ListBoxControl lstTableName;
        private DevExpress.XtraGrid.GridControl gridDetailData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridDetailDataView;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl;
        private DevExpress.XtraEditors.SimpleButton btnHelp;
        private DevExpress.XtraEditors.SimpleButton btnConvert;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ListBoxControl lstConvertTable;
        private DevExpress.XtraEditors.RadioGroup radioConvertOption;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.MemoEdit txtConvertLog;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.DateEdit dtBalanceDate;
    }
}