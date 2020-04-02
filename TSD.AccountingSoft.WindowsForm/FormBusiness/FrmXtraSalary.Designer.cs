namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    partial class FrmXtraSalary
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdLookUpCurrency = new DevExpress.XtraEditors.LookUpEdit();
            this.txtRefNo = new DevExpress.XtraEditors.TextEdit();
            this.dtRefDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtRateCurrency = new DevExpress.XtraEditors.SpinEdit();
            this.chkSelectAll = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioBothTypeMonth = new System.Windows.Forms.RadioButton();
            this.radioRoundTypeMonth = new System.Windows.Forms.RadioButton();
            this.radioRetaiTypelMonth = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioDidEmployee = new System.Windows.Forms.RadioButton();
            this.radioDidNotEmloyee = new System.Windows.Forms.RadioButton();
            this.grdLookUpDepartment = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.grdlookUpEmployee = new DevExpress.XtraGrid.GridControl();
            this.gridViewEmploy = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.lblLoaiLuong = new DevExpress.XtraEditors.LabelControl();
            this.picDaTinh = new DevExpress.XtraEditors.PictureEdit();
            this.lblPhong = new DevExpress.XtraEditors.LabelControl();
            this.lblLoai = new DevExpress.XtraEditors.LabelControl();
            this.lblHoTen = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.gridSalary = new DevExpress.XtraGrid.GridControl();
            this.gridViewSalary = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnCalSalary = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnShowVoucher = new DevExpress.XtraEditors.SimpleButton();
            this.btnRecordBook = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpCurrency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRefDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRefDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateCurrency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdlookUpEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEmploy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDaTinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSalary)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.grdLookUpCurrency);
            this.groupControl1.Controls.Add(this.txtRefNo);
            this.groupControl1.Controls.Add(this.dtRefDate);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtRateCurrency);
            this.groupControl1.Location = new System.Drawing.Point(8, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(760, 80);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Thông tin chung";
            // 
            // grdLookUpCurrency
            // 
            this.grdLookUpCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLookUpCurrency.Location = new System.Drawing.Point(416, 22);
            this.grdLookUpCurrency.Name = "grdLookUpCurrency";
            this.grdLookUpCurrency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdLookUpCurrency.Properties.NullText = "";
            this.grdLookUpCurrency.Size = new System.Drawing.Size(336, 20);
            this.grdLookUpCurrency.TabIndex = 3;
            this.grdLookUpCurrency.EditValueChanged += new System.EventHandler(this.grdLookUpCurrency_EditValueChanged);
            // 
            // txtRefNo
            // 
            this.txtRefNo.Location = new System.Drawing.Point(104, 48);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.Size = new System.Drawing.Size(256, 20);
            this.txtRefNo.TabIndex = 5;
            // 
            // dtRefDate
            // 
            this.dtRefDate.EditValue = null;
            this.dtRefDate.Location = new System.Drawing.Point(104, 22);
            this.dtRefDate.Name = "dtRefDate";
            this.dtRefDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtRefDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtRefDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtRefDate.Size = new System.Drawing.Size(256, 20);
            this.dtRefDate.TabIndex = 1;
            this.dtRefDate.Enter += new System.EventHandler(this.dtRefDate_Enter);
            this.dtRefDate.Leave += new System.EventHandler(this.dtRefDate_Leave);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(369, 52);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(29, 13);
            this.labelControl6.TabIndex = 6;
            this.labelControl6.Text = "&Tỷ giá";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(368, 26);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(40, 13);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "&Loại tiền";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(9, 52);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(76, 13);
            this.labelControl9.TabIndex = 4;
            this.labelControl9.Text = "&Số chứng từ (*)";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(89, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "&Ngày chứng từ (*)";
            // 
            // txtRateCurrency
            // 
            this.txtRateCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRateCurrency.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtRateCurrency.Location = new System.Drawing.Point(416, 48);
            this.txtRateCurrency.Name = "txtRateCurrency";
            this.txtRateCurrency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtRateCurrency.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtRateCurrency.Properties.Mask.EditMask = "f4";
            this.txtRateCurrency.Size = new System.Drawing.Size(336, 20);
            this.txtRateCurrency.TabIndex = 7;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSelectAll.Location = new System.Drawing.Point(8, 345);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Properties.Caption = "Chọn tất";
            this.chkSelectAll.Size = new System.Drawing.Size(64, 19);
            this.chkSelectAll.TabIndex = 3;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 101);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Phòng ban";
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.Name = "applicationMenu1";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl2.Controls.Add(this.groupBox2);
            this.groupControl2.Controls.Add(this.groupBox1);
            this.groupControl2.Controls.Add(this.grdLookUpDepartment);
            this.groupControl2.Controls.Add(this.grdlookUpEmployee);
            this.groupControl2.Controls.Add(this.chkSelectAll);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Location = new System.Drawing.Point(8, 88);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(285, 367);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "groupControl2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioBothTypeMonth);
            this.groupBox2.Controls.Add(this.radioRoundTypeMonth);
            this.groupBox2.Controls.Add(this.radioRetaiTypelMonth);
            this.groupBox2.Location = new System.Drawing.Point(5, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 39);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // radioBothTypeMonth
            // 
            this.radioBothTypeMonth.AutoSize = true;
            this.radioBothTypeMonth.Location = new System.Drawing.Point(210, 14);
            this.radioBothTypeMonth.Name = "radioBothTypeMonth";
            this.radioBothTypeMonth.Size = new System.Drawing.Size(55, 17);
            this.radioBothTypeMonth.TabIndex = 17;
            this.radioBothTypeMonth.Text = "Cả hai";
            this.radioBothTypeMonth.UseVisualStyleBackColor = true;
            this.radioBothTypeMonth.Visible = false;
            this.radioBothTypeMonth.CheckedChanged += new System.EventHandler(this.radioCalcType_CheckedChanged);
            // 
            // radioRoundTypeMonth
            // 
            this.radioRoundTypeMonth.AutoSize = true;
            this.radioRoundTypeMonth.Checked = true;
            this.radioRoundTypeMonth.Location = new System.Drawing.Point(5, 14);
            this.radioRoundTypeMonth.Name = "radioRoundTypeMonth";
            this.radioRoundTypeMonth.Size = new System.Drawing.Size(100, 17);
            this.radioRoundTypeMonth.TabIndex = 16;
            this.radioRoundTypeMonth.TabStop = true;
            this.radioRoundTypeMonth.Text = "SHP Tròn tháng";
            this.radioRoundTypeMonth.UseVisualStyleBackColor = true;
            this.radioRoundTypeMonth.CheckedChanged += new System.EventHandler(this.radioCalcType_CheckedChanged);
            // 
            // radioRetaiTypelMonth
            // 
            this.radioRetaiTypelMonth.AutoSize = true;
            this.radioRetaiTypelMonth.Location = new System.Drawing.Point(114, 14);
            this.radioRetaiTypelMonth.Name = "radioRetaiTypelMonth";
            this.radioRetaiTypelMonth.Size = new System.Drawing.Size(89, 17);
            this.radioRetaiTypelMonth.TabIndex = 15;
            this.radioRetaiTypelMonth.Text = "SHP Lẻ tháng";
            this.radioRetaiTypelMonth.UseVisualStyleBackColor = true;
            this.radioRetaiTypelMonth.CheckedChanged += new System.EventHandler(this.radioCalcType_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioDidEmployee);
            this.groupBox1.Controls.Add(this.radioDidNotEmloyee);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 39);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // radioDidEmployee
            // 
            this.radioDidEmployee.AutoSize = true;
            this.radioDidEmployee.Checked = true;
            this.radioDidEmployee.Location = new System.Drawing.Point(5, 14);
            this.radioDidEmployee.Name = "radioDidEmployee";
            this.radioDidEmployee.Size = new System.Drawing.Size(77, 17);
            this.radioDidEmployee.TabIndex = 16;
            this.radioDidEmployee.TabStop = true;
            this.radioDidEmployee.Text = "NV đã tính ";
            this.radioDidEmployee.UseVisualStyleBackColor = true;
            this.radioDidEmployee.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // radioDidNotEmloyee
            // 
            this.radioDidNotEmloyee.AutoSize = true;
            this.radioDidNotEmloyee.Location = new System.Drawing.Point(88, 14);
            this.radioDidNotEmloyee.Name = "radioDidNotEmloyee";
            this.radioDidNotEmloyee.Size = new System.Drawing.Size(86, 17);
            this.radioDidNotEmloyee.TabIndex = 15;
            this.radioDidNotEmloyee.Text = "NV chưa tính";
            this.radioDidNotEmloyee.UseVisualStyleBackColor = true;
            this.radioDidNotEmloyee.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // grdLookUpDepartment
            // 
            this.grdLookUpDepartment.EditValue = "";
            this.grdLookUpDepartment.Location = new System.Drawing.Point(64, 98);
            this.grdLookUpDepartment.Name = "grdLookUpDepartment";
            this.grdLookUpDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdLookUpDepartment.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null)});
            this.grdLookUpDepartment.Size = new System.Drawing.Size(212, 20);
            this.grdLookUpDepartment.TabIndex = 11;
            this.grdLookUpDepartment.EditValueChanged += new System.EventHandler(this.grdLookUpDepartment_EditValueChanged);
            // 
            // grdlookUpEmployee
            // 
            this.grdlookUpEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdlookUpEmployee.Location = new System.Drawing.Point(8, 124);
            this.grdlookUpEmployee.MainView = this.gridViewEmploy;
            this.grdlookUpEmployee.Name = "grdlookUpEmployee";
            this.grdlookUpEmployee.Size = new System.Drawing.Size(268, 217);
            this.grdlookUpEmployee.TabIndex = 2;
            this.grdlookUpEmployee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEmploy});
            this.grdlookUpEmployee.Click += new System.EventHandler(this.grdlookUpEmployee_Click);
            // 
            // gridViewEmploy
            // 
            this.gridViewEmploy.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridViewEmploy.GridControl = this.grdlookUpEmployee;
            this.gridViewEmploy.Name = "gridViewEmploy";
            this.gridViewEmploy.OptionsBehavior.Editable = false;
            this.gridViewEmploy.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewEmploy.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridViewEmploy.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewEmploy.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewEmploy.OptionsSelection.MultiSelect = true;
            this.gridViewEmploy.OptionsView.ShowGroupPanel = false;
            this.gridViewEmploy.OptionsView.ShowIndicator = false;
            this.gridViewEmploy.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewEmploy.Click += new System.EventHandler(this.gridViewEmploy_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.Controls.Add(this.lblLoaiLuong);
            this.groupControl3.Controls.Add(this.picDaTinh);
            this.groupControl3.Controls.Add(this.lblPhong);
            this.groupControl3.Controls.Add(this.lblLoai);
            this.groupControl3.Controls.Add(this.lblHoTen);
            this.groupControl3.Controls.Add(this.labelControl8);
            this.groupControl3.Controls.Add(this.labelControl7);
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Controls.Add(this.gridSalary);
            this.groupControl3.Location = new System.Drawing.Point(299, 88);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.ShowCaption = false;
            this.groupControl3.Size = new System.Drawing.Size(470, 367);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "groupControl3";
            // 
            // lblLoaiLuong
            // 
            this.lblLoaiLuong.Location = new System.Drawing.Point(56, 68);
            this.lblLoaiLuong.Name = "lblLoaiLuong";
            this.lblLoaiLuong.Size = new System.Drawing.Size(0, 13);
            this.lblLoaiLuong.TabIndex = 10;
            // 
            // picDaTinh
            // 
            this.picDaTinh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picDaTinh.EditValue = global::TSD.AccountingSoft.WindowsForm.Properties.Resources.DaTinh;
            this.picDaTinh.Location = new System.Drawing.Point(191, 40);
            this.picDaTinh.Name = "picDaTinh";
            this.picDaTinh.Size = new System.Drawing.Size(100, 32);
            this.picDaTinh.TabIndex = 9;
            // 
            // lblPhong
            // 
            this.lblPhong.Location = new System.Drawing.Point(288, 40);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(0, 13);
            this.lblPhong.TabIndex = 8;
            // 
            // lblLoai
            // 
            this.lblLoai.Location = new System.Drawing.Point(56, 68);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(0, 13);
            this.lblLoai.TabIndex = 7;
            // 
            // lblHoTen
            // 
            this.lblHoTen.Location = new System.Drawing.Point(56, 44);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(0, 13);
            this.lblHoTen.TabIndex = 6;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(8, 68);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(23, 13);
            this.labelControl8.TabIndex = 4;
            this.labelControl8.Text = "Loại:";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(8, 44);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(36, 13);
            this.labelControl7.TabIndex = 3;
            this.labelControl7.Text = "Họ tên:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Location = new System.Drawing.Point(169, 8);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(77, 18);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "Phiếu SHP";
            // 
            // gridSalary
            // 
            this.gridSalary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSalary.Location = new System.Drawing.Point(8, 90);
            this.gridSalary.MainView = this.gridViewSalary;
            this.gridSalary.Name = "gridSalary";
            this.gridSalary.Size = new System.Drawing.Size(456, 269);
            this.gridSalary.TabIndex = 0;
            this.gridSalary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSalary});
            // 
            // gridViewSalary
            // 
            this.gridViewSalary.GridControl = this.gridSalary;
            this.gridViewSalary.Name = "gridViewSalary";
            this.gridViewSalary.OptionsBehavior.Editable = false;
            this.gridViewSalary.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewSalary.OptionsView.ShowGroupPanel = false;
            this.gridViewSalary.OptionsView.ShowIndicator = false;
            // 
            // btnCalSalary
            // 
            this.btnCalSalary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCalSalary.Location = new System.Drawing.Point(8, 463);
            this.btnCalSalary.Name = "btnCalSalary";
            this.btnCalSalary.Size = new System.Drawing.Size(75, 23);
            this.btnCalSalary.TabIndex = 3;
            this.btnCalSalary.Text = "Tính lương";
            this.btnCalSalary.Click += new System.EventHandler(this.btnCalSalary_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(692, 463);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Kết thúc";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnShowVoucher
            // 
            this.btnShowVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowVoucher.Location = new System.Drawing.Point(525, 463);
            this.btnShowVoucher.Name = "btnShowVoucher";
            this.btnShowVoucher.Size = new System.Drawing.Size(160, 23);
            this.btnShowVoucher.TabIndex = 6;
            this.btnShowVoucher.Text = "&Xem các chứng từ trong tháng";
            this.btnShowVoucher.Click += new System.EventHandler(this.btnShowVoucherIsPostedDate_Click);
            // 
            // btnRecordBook
            // 
            this.btnRecordBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRecordBook.Location = new System.Drawing.Point(89, 463);
            this.btnRecordBook.Name = "btnRecordBook";
            this.btnRecordBook.Size = new System.Drawing.Size(77, 23);
            this.btnRecordBook.TabIndex = 9;
            this.btnRecordBook.Text = "Ghi sổ";
            this.btnRecordBook.Click += new System.EventHandler(this.btnPosted_Click);
            // 
            // FrmXtraSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 495);
            this.Controls.Add(this.btnRecordBook);
            this.Controls.Add(this.btnShowVoucher);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCalSalary);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.MinimumSize = new System.Drawing.Size(606, 457);
            this.Name = "FrmXtraSalary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tính SHP";
            this.Load += new System.EventHandler(this.FrmXtraSalary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpCurrency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRefDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRefDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateCurrency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLookUpDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdlookUpEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEmploy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDaTinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSalary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chkSelectAll;
        private DevExpress.XtraEditors.TextEdit txtRefNo;
        private DevExpress.XtraEditors.DateEdit dtRefDate;
        private DevExpress.XtraEditors.LookUpEdit grdLookUpCurrency;
        private DevExpress.XtraGrid.GridControl grdlookUpEmployee;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEmploy;
        private DevExpress.XtraGrid.GridControl gridSalary;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSalary;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl lblPhong;
        private DevExpress.XtraEditors.LabelControl lblLoai;
        private DevExpress.XtraEditors.LabelControl lblHoTen;
        private DevExpress.XtraEditors.SimpleButton btnCalSalary;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnShowVoucher;
        private DevExpress.XtraEditors.PictureEdit picDaTinh;
        private DevExpress.XtraEditors.LabelControl lblLoaiLuong;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.CheckedComboBoxEdit grdLookUpDepartment;
        private DevExpress.XtraEditors.SpinEdit txtRateCurrency;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioRoundTypeMonth;
        private System.Windows.Forms.RadioButton radioRetaiTypelMonth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioDidEmployee;
        private System.Windows.Forms.RadioButton radioDidNotEmloyee;
        private System.Windows.Forms.RadioButton radioBothTypeMonth;
        private DevExpress.XtraEditors.SimpleButton btnRecordBook;
    }
}