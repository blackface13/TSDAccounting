namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    internal partial class FrmXtraCustomerDetail
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
            this.lbCode = new DevExpress.XtraEditors.LabelControl();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.txtFullName = new DevExpress.XtraEditors.TextEdit();
            this.txtAddress = new DevExpress.XtraEditors.TextEdit();
            this.lbAddress = new DevExpress.XtraEditors.LabelControl();
            this.grbContactInfo = new DevExpress.XtraEditors.GroupControl();
            this.lbBankId = new DevExpress.XtraEditors.LabelControl();
            this.txtBankAccount = new DevExpress.XtraEditors.TextEdit();
            this.lbBankAccount = new DevExpress.XtraEditors.LabelControl();
            this.txtTaxCode = new DevExpress.XtraEditors.TextEdit();
            this.lbTaxCode = new DevExpress.XtraEditors.LabelControl();
            this.txtFax = new DevExpress.XtraEditors.TextEdit();
            this.lbFax = new DevExpress.XtraEditors.LabelControl();
            this.txtContactReg = new DevExpress.XtraEditors.TextEdit();
            this.lbContactReg = new DevExpress.XtraEditors.LabelControl();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.lbEmail = new DevExpress.XtraEditors.LabelControl();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.lbPhone = new DevExpress.XtraEditors.LabelControl();
            this.txtMobile = new DevExpress.XtraEditors.TextEdit();
            this.lbMobile = new DevExpress.XtraEditors.LabelControl();
            this.txtWebsite = new DevExpress.XtraEditors.TextEdit();
            this.lbWebsite = new DevExpress.XtraEditors.LabelControl();
            this.txtProvince = new DevExpress.XtraEditors.TextEdit();
            this.lbProvince = new DevExpress.XtraEditors.LabelControl();
            this.txtCity = new DevExpress.XtraEditors.TextEdit();
            this.lbCity = new DevExpress.XtraEditors.LabelControl();
            this.txtZipCode = new DevExpress.XtraEditors.TextEdit();
            this.lbZipCode = new DevExpress.XtraEditors.LabelControl();
            this.txtArea = new DevExpress.XtraEditors.TextEdit();
            this.lbArea = new DevExpress.XtraEditors.LabelControl();
            this.txtCountry = new DevExpress.XtraEditors.TextEdit();
            this.lbCountry = new DevExpress.XtraEditors.LabelControl();
            this.txtContactName = new DevExpress.XtraEditors.TextEdit();
            this.lbContactName = new DevExpress.XtraEditors.LabelControl();
            this.luBankId = new DevExpress.XtraEditors.GridLookUpEdit();
            this.luBankView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cbIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.lbCustomerName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbContactInfo)).BeginInit();
            this.grbContactInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactReg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWebsite.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProvince.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZipCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCountry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luBankId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luBankView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(409, 315);
            this.btnSave.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(490, 315);
            this.btnExit.TabIndex = 4;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 315);
            this.btnHelp.TabIndex = 5;
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.lbCustomerName);
            this.groupboxMain.Controls.Add(this.txtAddress);
            this.groupboxMain.Controls.Add(this.lbAddress);
            this.groupboxMain.Controls.Add(this.txtFullName);
            this.groupboxMain.Controls.Add(this.txtCode);
            this.groupboxMain.Controls.Add(this.lbCode);
            this.groupboxMain.Location = new System.Drawing.Point(8, 6);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(560, 74);
            // 
            // lbCode
            // 
            this.lbCode.Location = new System.Drawing.Point(8, 27);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(47, 13);
            this.lbCode.TabIndex = 0;
            this.lbCode.Text = "&Mã KH (*)";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(64, 24);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(91, 20);
            this.txtCode.TabIndex = 1;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(216, 24);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(336, 20);
            this.txtFullName.TabIndex = 3;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(64, 48);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(488, 20);
            this.txtAddress.TabIndex = 5;
            // 
            // lbAddress
            // 
            this.lbAddress.Location = new System.Drawing.Point(8, 50);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(32, 13);
            this.lbAddress.TabIndex = 4;
            this.lbAddress.Text = "Đị&a chỉ";
            // 
            // grbContactInfo
            // 
            this.grbContactInfo.Controls.Add(this.lbBankId);
            this.grbContactInfo.Controls.Add(this.txtBankAccount);
            this.grbContactInfo.Controls.Add(this.lbBankAccount);
            this.grbContactInfo.Controls.Add(this.txtTaxCode);
            this.grbContactInfo.Controls.Add(this.lbTaxCode);
            this.grbContactInfo.Controls.Add(this.txtFax);
            this.grbContactInfo.Controls.Add(this.lbFax);
            this.grbContactInfo.Controls.Add(this.txtContactReg);
            this.grbContactInfo.Controls.Add(this.lbContactReg);
            this.grbContactInfo.Controls.Add(this.txtEmail);
            this.grbContactInfo.Controls.Add(this.lbEmail);
            this.grbContactInfo.Controls.Add(this.txtPhone);
            this.grbContactInfo.Controls.Add(this.lbPhone);
            this.grbContactInfo.Controls.Add(this.txtMobile);
            this.grbContactInfo.Controls.Add(this.lbMobile);
            this.grbContactInfo.Controls.Add(this.txtWebsite);
            this.grbContactInfo.Controls.Add(this.lbWebsite);
            this.grbContactInfo.Controls.Add(this.txtProvince);
            this.grbContactInfo.Controls.Add(this.lbProvince);
            this.grbContactInfo.Controls.Add(this.txtCity);
            this.grbContactInfo.Controls.Add(this.lbCity);
            this.grbContactInfo.Controls.Add(this.txtZipCode);
            this.grbContactInfo.Controls.Add(this.lbZipCode);
            this.grbContactInfo.Controls.Add(this.txtArea);
            this.grbContactInfo.Controls.Add(this.lbArea);
            this.grbContactInfo.Controls.Add(this.txtCountry);
            this.grbContactInfo.Controls.Add(this.lbCountry);
            this.grbContactInfo.Controls.Add(this.txtContactName);
            this.grbContactInfo.Controls.Add(this.lbContactName);
            this.grbContactInfo.Controls.Add(this.luBankId);
            this.grbContactInfo.Location = new System.Drawing.Point(8, 88);
            this.grbContactInfo.Name = "grbContactInfo";
            this.grbContactInfo.Size = new System.Drawing.Size(560, 195);
            this.grbContactInfo.TabIndex = 1;
            // 
            // lbBankId
            // 
            this.lbBankId.Location = new System.Drawing.Point(218, 172);
            this.lbBankId.Name = "lbBankId";
            this.lbBankId.Size = new System.Drawing.Size(52, 13);
            this.lbBankId.TabIndex = 28;
            this.lbBankId.Text = "N&gân hàng";
            // 
            // txtBankAccount
            // 
            this.txtBankAccount.Location = new System.Drawing.Point(288, 144);
            this.txtBankAccount.Name = "txtBankAccount";
            this.txtBankAccount.Size = new System.Drawing.Size(264, 20);
            this.txtBankAccount.TabIndex = 25;
            // 
            // lbBankAccount
            // 
            this.lbBankAccount.Location = new System.Drawing.Point(218, 146);
            this.lbBankAccount.Name = "lbBankAccount";
            this.lbBankAccount.Size = new System.Drawing.Size(63, 13);
            this.lbBankAccount.TabIndex = 24;
            this.lbBankAccount.Text = "Tài khoản N&H";
            // 
            // txtTaxCode
            // 
            this.txtTaxCode.Location = new System.Drawing.Point(80, 168);
            this.txtTaxCode.Name = "txtTaxCode";
            this.txtTaxCode.Size = new System.Drawing.Size(132, 20);
            this.txtTaxCode.TabIndex = 27;
            // 
            // lbTaxCode
            // 
            this.lbTaxCode.Location = new System.Drawing.Point(8, 170);
            this.lbTaxCode.Name = "lbTaxCode";
            this.lbTaxCode.Size = new System.Drawing.Size(53, 13);
            this.lbTaxCode.TabIndex = 26;
            this.lbTaxCode.Text = "Mã &số thuế";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(456, 72);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(96, 20);
            this.txtFax.TabIndex = 13;
            // 
            // lbFax
            // 
            this.lbFax.Location = new System.Drawing.Point(432, 74);
            this.lbFax.Name = "lbFax";
            this.lbFax.Size = new System.Drawing.Size(18, 13);
            this.lbFax.TabIndex = 12;
            this.lbFax.Text = "&Fax";
            // 
            // txtContactReg
            // 
            this.txtContactReg.Location = new System.Drawing.Point(288, 24);
            this.txtContactReg.Name = "txtContactReg";
            this.txtContactReg.Size = new System.Drawing.Size(264, 20);
            this.txtContactReg.TabIndex = 3;
            // 
            // lbContactReg
            // 
            this.lbContactReg.Location = new System.Drawing.Point(218, 28);
            this.lbContactReg.Name = "lbContactReg";
            this.lbContactReg.Size = new System.Drawing.Size(52, 13);
            this.lbContactReg.TabIndex = 2;
            this.lbContactReg.Text = "&Chức danh";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(80, 48);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(133, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // lbEmail
            // 
            this.lbEmail.Location = new System.Drawing.Point(8, 52);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(24, 13);
            this.lbEmail.TabIndex = 4;
            this.lbEmail.Text = "&Email";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(80, 72);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(133, 20);
            this.txtPhone.TabIndex = 9;
            // 
            // lbPhone
            // 
            this.lbPhone.Location = new System.Drawing.Point(8, 75);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(49, 13);
            this.lbPhone.TabIndex = 8;
            this.lbPhone.Text = "Điệ&n thoại";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(288, 72);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(136, 20);
            this.txtMobile.TabIndex = 11;
            // 
            // lbMobile
            // 
            this.lbMobile.Location = new System.Drawing.Point(218, 72);
            this.lbMobile.Name = "lbMobile";
            this.lbMobile.Size = new System.Drawing.Size(36, 13);
            this.lbMobile.TabIndex = 10;
            this.lbMobile.Text = "&Di động";
            // 
            // txtWebsite
            // 
            this.txtWebsite.Location = new System.Drawing.Point(288, 48);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(264, 20);
            this.txtWebsite.TabIndex = 7;
            // 
            // lbWebsite
            // 
            this.lbWebsite.Location = new System.Drawing.Point(218, 52);
            this.lbWebsite.Name = "lbWebsite";
            this.lbWebsite.Size = new System.Drawing.Size(39, 13);
            this.lbWebsite.TabIndex = 6;
            this.lbWebsite.Text = "&Website";
            // 
            // txtProvince
            // 
            this.txtProvince.Location = new System.Drawing.Point(80, 96);
            this.txtProvince.Name = "txtProvince";
            this.txtProvince.Size = new System.Drawing.Size(133, 20);
            this.txtProvince.TabIndex = 15;
            // 
            // lbProvince
            // 
            this.lbProvince.Location = new System.Drawing.Point(8, 98);
            this.lbProvince.Name = "lbProvince";
            this.lbProvince.Size = new System.Drawing.Size(61, 13);
            this.lbProvince.TabIndex = 14;
            this.lbProvince.Text = "&Quận/Huyện";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(288, 96);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(264, 20);
            this.txtCity.TabIndex = 17;
            // 
            // lbCity
            // 
            this.lbCity.Location = new System.Drawing.Point(218, 100);
            this.lbCity.Name = "lbCity";
            this.lbCity.Size = new System.Drawing.Size(54, 13);
            this.lbCity.TabIndex = 16;
            this.lbCity.Text = "Tỉnh/Thành";
            // 
            // txtZipCode
            // 
            this.txtZipCode.Location = new System.Drawing.Point(80, 120);
            this.txtZipCode.Name = "txtZipCode";
            this.txtZipCode.Size = new System.Drawing.Size(133, 20);
            this.txtZipCode.TabIndex = 19;
            // 
            // lbZipCode
            // 
            this.lbZipCode.Location = new System.Drawing.Point(8, 120);
            this.lbZipCode.Name = "lbZipCode";
            this.lbZipCode.Size = new System.Drawing.Size(41, 13);
            this.lbZipCode.TabIndex = 18;
            this.lbZipCode.Text = "Mã &vùng";
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(288, 120);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(264, 20);
            this.txtArea.TabIndex = 21;
            // 
            // lbArea
            // 
            this.lbArea.Location = new System.Drawing.Point(218, 124);
            this.lbArea.Name = "lbArea";
            this.lbArea.Size = new System.Drawing.Size(39, 13);
            this.lbArea.TabIndex = 20;
            this.lbArea.Text = "&Khu vực";
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(80, 144);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(133, 20);
            this.txtCountry.TabIndex = 23;
            // 
            // lbCountry
            // 
            this.lbCountry.Location = new System.Drawing.Point(8, 144);
            this.lbCountry.Name = "lbCountry";
            this.lbCountry.Size = new System.Drawing.Size(42, 13);
            this.lbCountry.TabIndex = 22;
            this.lbCountry.Text = "Quốc gia";
            // 
            // txtContactName
            // 
            this.txtContactName.Location = new System.Drawing.Point(80, 24);
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.Size = new System.Drawing.Size(133, 20);
            this.txtContactName.TabIndex = 1;
            // 
            // lbContactName
            // 
            this.lbContactName.Location = new System.Drawing.Point(8, 28);
            this.lbContactName.Name = "lbContactName";
            this.lbContactName.Size = new System.Drawing.Size(63, 13);
            this.lbContactName.TabIndex = 0;
            this.lbContactName.Text = "&Người liên lạc";
            // 
            // luBankId
            // 
            this.luBankId.Location = new System.Drawing.Point(288, 168);
            this.luBankId.Name = "luBankId";
            this.luBankId.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.luBankId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.luBankId.Properties.NullText = "";
            this.luBankId.Properties.View = this.luBankView;
            this.luBankId.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.luBankId_Properties_ButtonClick);
            this.luBankId.Size = new System.Drawing.Size(264, 20);
            this.luBankId.TabIndex = 29;
            // 
            // luBankView
            // 
            this.luBankView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.luBankView.Name = "luBankView";
            this.luBankView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.luBankView.OptionsView.ShowGroupPanel = false;
            // 
            // cbIsActive
            // 
            this.cbIsActive.Location = new System.Drawing.Point(5, 290);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Properties.Caption = "Ngừng theo dõi";
            this.cbIsActive.Size = new System.Drawing.Size(114, 19);
            this.cbIsActive.TabIndex = 2;
            // 
            // lbCustomerName
            // 
            this.lbCustomerName.Location = new System.Drawing.Point(160, 27);
            this.lbCustomerName.Name = "lbCustomerName";
            this.lbCustomerName.Size = new System.Drawing.Size(51, 13);
            this.lbCustomerName.TabIndex = 2;
            this.lbCustomerName.Text = "&Tên KH (*)";
            // 
            // FrmXtraCustomerDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 350);
            this.ComponentName = "Khách hàng";
            this.Controls.Add(this.grbContactInfo);
            this.Controls.Add(this.cbIsActive);
            this.EventTime = new System.DateTime(2019, 11, 7, 15, 3, 32, 291);
            this.FormCaption = "khách hàng";
            this.Name = "FrmXtraCustomerDetail";
            this.Reference = "THÊM KHÁCH HÀNG - ID ";
            this.Text = "FrmCustomer";
            this.Controls.SetChildIndex(this.cbIsActive, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.grbContactInfo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbContactInfo)).EndInit();
            this.grbContactInfo.ResumeLayout(false);
            this.grbContactInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactReg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMobile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWebsite.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProvince.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZipCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCountry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luBankId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luBankView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbCode;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.TextEdit txtAddress;
        private DevExpress.XtraEditors.LabelControl lbAddress;
        private DevExpress.XtraEditors.TextEdit txtFullName;
        private DevExpress.XtraEditors.GroupControl grbContactInfo;
        private DevExpress.XtraEditors.LabelControl lbBankId;
        private DevExpress.XtraEditors.TextEdit txtBankAccount;
        private DevExpress.XtraEditors.LabelControl lbBankAccount;
        private DevExpress.XtraEditors.TextEdit txtTaxCode;
        private DevExpress.XtraEditors.LabelControl lbTaxCode;
        private DevExpress.XtraEditors.TextEdit txtFax;
        private DevExpress.XtraEditors.LabelControl lbFax;
        private DevExpress.XtraEditors.CheckEdit cbIsActive;
        private DevExpress.XtraEditors.TextEdit txtContactReg;
        private DevExpress.XtraEditors.LabelControl lbContactReg;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.LabelControl lbEmail;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.LabelControl lbPhone;
        private DevExpress.XtraEditors.TextEdit txtMobile;
        private DevExpress.XtraEditors.LabelControl lbMobile;
        private DevExpress.XtraEditors.TextEdit txtWebsite;
        private DevExpress.XtraEditors.LabelControl lbWebsite;
        private DevExpress.XtraEditors.TextEdit txtProvince;
        private DevExpress.XtraEditors.LabelControl lbProvince;
        private DevExpress.XtraEditors.TextEdit txtCity;
        private DevExpress.XtraEditors.LabelControl lbCity;
        private DevExpress.XtraEditors.TextEdit txtZipCode;
        private DevExpress.XtraEditors.LabelControl lbZipCode;
        private DevExpress.XtraEditors.TextEdit txtArea;
        private DevExpress.XtraEditors.LabelControl lbArea;
        private DevExpress.XtraEditors.TextEdit txtCountry;
        private DevExpress.XtraEditors.LabelControl lbCountry;
        private DevExpress.XtraEditors.TextEdit txtContactName;
        private DevExpress.XtraEditors.LabelControl lbContactName;
        private DevExpress.XtraEditors.LabelControl lbCustomerName;
        private DevExpress.XtraEditors.GridLookUpEdit luBankId;
        private DevExpress.XtraGrid.Views.Grid.GridView luBankView;
    }
}