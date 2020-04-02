namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    partial class FrmXtraExchangeRateDetail
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.memoDescription = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtToDate = new DevExpress.XtraEditors.DateEdit();
            this.dtFromDate = new DevExpress.XtraEditors.DateEdit();
            this.grdLookUpBudgetSourceID = new DevExpress.XtraEditors.LookUpEdit();
            this.txtExchangeRate = new DevExpress.XtraEditors.CalcEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.grdlookUpBudgetSource = new DevExpress.XtraGrid.GridControl();
            this.gridViewBudgetSource = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpBudgetSourceID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExchangeRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdlookUpBudgetSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBudgetSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(356, 328);
            this.btnSave.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(430, 328);
            this.btnExit.TabIndex = 3;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 328);
            this.btnHelp.TabIndex = 4;
            // 
            // groupboxMain
            // 
            this.groupboxMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxMain.Controls.Add(this.grdlookUpBudgetSource);
            this.groupboxMain.Controls.Add(this.txtExchangeRate);
            this.groupboxMain.Controls.Add(this.labelControl5);
            this.groupboxMain.Controls.Add(this.grdLookUpBudgetSourceID);
            this.groupboxMain.Controls.Add(this.dtToDate);
            this.groupboxMain.Controls.Add(this.dtFromDate);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.memoDescription);
            this.groupboxMain.Controls.Add(this.labelControl4);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(490, 288);
            this.groupboxMain.Text = "Thông tin chung";
            // 
            // chkIsActive
            // 
            this.chkIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIsActive.Location = new System.Drawing.Point(5, 302);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "Ngừng sử dụng";
            this.chkIsActive.Size = new System.Drawing.Size(96, 19);
            this.chkIsActive.TabIndex = 1;
            // 
            // memoDescription
            // 
            this.memoDescription.Location = new System.Drawing.Point(84, 168);
            this.memoDescription.Name = "memoDescription";
            this.memoDescription.Size = new System.Drawing.Size(397, 60);
            this.memoDescription.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(8, 171);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(57, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "&Diễn giải (*)";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 25);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(69, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "&Nguồn vốn (*)";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 237);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(57, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Từ ngày (*)";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(251, 237);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Đến ngày (*)";
            // 
            // dtToDate
            // 
            this.dtToDate.EditValue = new System.DateTime(2014, 4, 28, 15, 17, 45, 137);
            this.dtToDate.Location = new System.Drawing.Point(321, 234);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtToDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtToDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtToDate.Size = new System.Drawing.Size(160, 20);
            this.dtToDate.TabIndex = 3;
            // 
            // dtFromDate
            // 
            this.dtFromDate.EditValue = new System.DateTime(2014, 4, 28, 15, 44, 1, 0);
            this.dtFromDate.Location = new System.Drawing.Point(84, 234);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtFromDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtFromDate.Size = new System.Drawing.Size(160, 20);
            this.dtFromDate.TabIndex = 2;
            // 
            // grdLookUpBudgetSourceID
            // 
            this.grdLookUpBudgetSourceID.Location = new System.Drawing.Point(8, 122);
            this.grdLookUpBudgetSourceID.Name = "grdLookUpBudgetSourceID";
            this.grdLookUpBudgetSourceID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdLookUpBudgetSourceID.Properties.NullText = "";
            this.grdLookUpBudgetSourceID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.grdLookUpBudgetSourceID.Size = new System.Drawing.Size(10, 20);
            this.grdLookUpBudgetSourceID.TabIndex = 1;
            this.grdLookUpBudgetSourceID.Visible = false;
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.Location = new System.Drawing.Point(84, 260);
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, false, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtExchangeRate.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.txtExchangeRate.Properties.Tag = "ExchangeRate";
            this.txtExchangeRate.Size = new System.Drawing.Size(397, 20);
            this.txtExchangeRate.TabIndex = 4;
            this.txtExchangeRate.Tag = "ExchangeRate";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(9, 263);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(46, 13);
            this.labelControl5.TabIndex = 21;
            this.labelControl5.Text = "Tỷ giá (*)";
            // 
            // grdlookUpBudgetSource
            // 
            this.grdlookUpBudgetSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdlookUpBudgetSource.Location = new System.Drawing.Point(84, 24);
            this.grdlookUpBudgetSource.MainView = this.gridViewBudgetSource;
            this.grdlookUpBudgetSource.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.grdlookUpBudgetSource.Name = "grdlookUpBudgetSource";
            this.grdlookUpBudgetSource.Size = new System.Drawing.Size(397, 138);
            this.grdlookUpBudgetSource.TabIndex = 0;
            this.grdlookUpBudgetSource.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewBudgetSource});
            // 
            // gridViewBudgetSource
            // 
            this.gridViewBudgetSource.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridViewBudgetSource.GridControl = this.grdlookUpBudgetSource;
            this.gridViewBudgetSource.Name = "gridViewBudgetSource";
            this.gridViewBudgetSource.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewBudgetSource.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridViewBudgetSource.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewBudgetSource.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewBudgetSource.OptionsSelection.MultiSelect = true;
            this.gridViewBudgetSource.OptionsView.ShowGroupPanel = false;
            this.gridViewBudgetSource.OptionsView.ShowIndicator = false;
            this.gridViewBudgetSource.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewBudgetSource.CustomDrawColumnHeader += new DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventHandler(this.gridViewBudgetSource_CustomDrawColumnHeader);
            // 
            // FrmXtraExchangeRateDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 360);
            this.ComponentName = "Tỷ giá dự toáná";
            this.Controls.Add(this.chkIsActive);
            this.EventTime = new System.DateTime(2019, 11, 8, 17, 1, 29, 342);
            this.FormCaption = "tỷ giá dự toán";
            this.Name = "FrmXtraExchangeRateDetail";
            this.Reference = "THÊM TỶ GIÁ DỰ TOÁN - ID ";
            this.Text = "FrmXtraExchangeRateDetail";
            this.Load += new System.EventHandler(this.FrmXtraExchangeRateDetail_Load);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.chkIsActive, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpBudgetSourceID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExchangeRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdlookUpBudgetSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBudgetSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private DevExpress.XtraEditors.MemoEdit memoDescription;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtToDate;
        private DevExpress.XtraEditors.DateEdit dtFromDate;
        private DevExpress.XtraEditors.LookUpEdit grdLookUpBudgetSourceID;
        private DevExpress.XtraEditors.CalcEdit txtExchangeRate;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraGrid.GridControl grdlookUpBudgetSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewBudgetSource;
    }
}