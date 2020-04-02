using TSD.Enum;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    partial class FrmXtraPaymentDepositDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmXtraPaymentDepositDetail));
            ((System.ComponentModel.ISupportInitialize)(this.imageToobarCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupVoucher)).BeginInit();
            this.groupVoucher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupObject)).BeginInit();
            this.groupObject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageToolbar24Collection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRefDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRefDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPostDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPostDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboObjectName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboObjectCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboObjectCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCurrency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboExchangRate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imageToobarCollection
            // 
            this.imageToobarCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageToobarCollection.ImageStream")));
            this.imageToobarCollection.Images.SetKeyName(0, "nav_blue_bottom.png");
            this.imageToobarCollection.Images.SetKeyName(1, "nav_blue_left.png");
            this.imageToobarCollection.Images.SetKeyName(2, "nav_blue_right.png");
            this.imageToobarCollection.Images.SetKeyName(3, "nav_blue_up.png");
            this.imageToobarCollection.Images.SetKeyName(4, "undo.png");
            this.imageToobarCollection.Images.SetKeyName(5, "order-add.png");
            this.imageToobarCollection.Images.SetKeyName(6, "order-delete.png");
            this.imageToobarCollection.Images.SetKeyName(7, "order-edit.png");
            this.imageToobarCollection.Images.SetKeyName(8, "order-print.png");
            this.imageToobarCollection.Images.SetKeyName(9, "help.png");
            this.imageToobarCollection.Images.SetKeyName(10, "stop.png");
            this.imageToobarCollection.Images.SetKeyName(11, "refresh_update.png");
            this.imageToobarCollection.Images.SetKeyName(12, "save.png");
            // 
            // groupVoucher
            // 
            this.groupVoucher.Location = new System.Drawing.Point(922, 56);
            this.groupVoucher.Size = new System.Drawing.Size(204, 155);
            // 
            // groupObject
            // 
            this.groupObject.Location = new System.Drawing.Point(8, 56);
            this.groupObject.Size = new System.Drawing.Size(908, 155);
            this.groupObject.Text = "Thông tin chung";
            // 
            // imageToolbar24Collection
            // 
            this.imageToolbar24Collection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageToolbar24Collection.ImageStream")));
            this.imageToolbar24Collection.Images.SetKeyName(0, "close_window.png");
            this.imageToolbar24Collection.Images.SetKeyName(1, "help.png");
            this.imageToolbar24Collection.Images.SetKeyName(2, "nav_green_bottom.png");
            this.imageToolbar24Collection.Images.SetKeyName(3, "nav_green_left.png");
            this.imageToolbar24Collection.Images.SetKeyName(4, "nav_green_right.png");
            this.imageToolbar24Collection.Images.SetKeyName(5, "nav_green_top.png");
            this.imageToolbar24Collection.Images.SetKeyName(6, "order-add.png");
            this.imageToolbar24Collection.Images.SetKeyName(7, "order-delete.png");
            this.imageToolbar24Collection.Images.SetKeyName(8, "order-edit.png");
            this.imageToolbar24Collection.Images.SetKeyName(9, "order-print.png");
            this.imageToolbar24Collection.Images.SetKeyName(10, "refresh_update.png");
            this.imageToolbar24Collection.Images.SetKeyName(11, "save.png");
            this.imageToolbar24Collection.Images.SetKeyName(12, "undo.png");
            this.imageToolbar24Collection.Images.SetKeyName(13, "clipboard_copy.png");
            // 
            // dtRefDate
            // 
            this.dtRefDate.EditValue = new System.DateTime(2014, 3, 18, 19, 18, 2, 581);
            this.dtRefDate.Location = new System.Drawing.Point(73, 128);
            this.dtRefDate.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.dtRefDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtRefDate.Size = new System.Drawing.Size(122, 20);
            this.dtRefDate.TabIndex = 11;
            this.dtRefDate.EditValueChanged += new System.EventHandler(this.dtRefDate_EditValueChanged);
            // 
            // dtPostDate
            // 
            this.dtPostDate.EditValue = new System.DateTime(2014, 3, 18, 19, 17, 56, 986);
            this.dtPostDate.Location = new System.Drawing.Point(73, 102);
            this.dtPostDate.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.dtPostDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtPostDate.Size = new System.Drawing.Size(122, 20);
            this.dtPostDate.TabIndex = 10;
            this.dtPostDate.EditValueChanged += new System.EventHandler(this.dtPostDate_EditValueChanged);
            // 
            // txtRefNo
            // 
            this.txtRefNo.Location = new System.Drawing.Point(73, 76);
            this.txtRefNo.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtRefNo.Size = new System.Drawing.Size(122, 20);
            this.txtRefNo.TabIndex = 9;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 131);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 105);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 79);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(9, 105);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl8.Size = new System.Drawing.Size(44, 13);
            this.labelControl8.Text = "Lý do gửi";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(83, 50);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtAddress.Size = new System.Drawing.Size(816, 20);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(9, 53);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            // 
            // cboObjectName
            // 
            this.cboObjectName.Location = new System.Drawing.Point(529, 24);
            this.cboObjectName.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.cboObjectName.Size = new System.Drawing.Size(370, 20);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl6.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl6.Location = new System.Drawing.Point(456, 27);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl5.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl5.Location = new System.Drawing.Point(235, 27);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(9, 27);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            // 
            // txtContactName
            // 
            this.txtContactName.Location = new System.Drawing.Point(83, 76);
            this.txtContactName.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtContactName.Size = new System.Drawing.Size(816, 20);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(9, 79);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl9.Size = new System.Drawing.Size(66, 13);
            this.labelControl9.Text = "Người rút tiền";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(83, 102);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtDescription.Size = new System.Drawing.Size(816, 20);
            // 
            // cboBank
            // 
            this.cboBank.Location = new System.Drawing.Point(83, 128);
            this.cboBank.Size = new System.Drawing.Size(145, 20);
            this.cboBank.TabIndex = 6;
            // 
            // lblBankAccount
            // 
            this.lblBankAccount.Location = new System.Drawing.Point(9, 131);
            this.lblBankAccount.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            // 
            // cboObjectCode
            // 
            this.cboObjectCode.Location = new System.Drawing.Point(304, 24);
            //this.cboObjectCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboObjectCode.Size = new System.Drawing.Size(145, 20);
            // 
            // cboObjectCategory
            // 
            this.cboObjectCategory.Location = new System.Drawing.Point(83, 24);
            this.cboObjectCategory.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboObjectCategory.Size = new System.Drawing.Size(145, 20);
            // 
            // cboCurrency
            // 
            this.cboCurrency.Location = new System.Drawing.Point(73, 24);
            this.cboCurrency.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.cboCurrency.Size = new System.Drawing.Size(122, 20);
            this.cboCurrency.TabIndex = 7;
            this.cboCurrency.EditValueChanged += new System.EventHandler(this.cboCurrency_EditValueChanged);
            // 
            // lbExchangeRate
            // 
            this.lbExchangeRate.Location = new System.Drawing.Point(9, 53);
            // 
            // lbCurrency
            // 
            this.lbCurrency.Location = new System.Drawing.Point(9, 27);
            this.lbCurrency.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            // 
            // cboExchangRate
            // 
            this.cboExchangRate.Location = new System.Drawing.Point(73, 50);
            this.cboExchangRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.cboExchangRate.Size = new System.Drawing.Size(122, 20);
            this.cboExchangRate.TabIndex = 8;
            // 
            // FrmXtraPaymentDepositDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BaseRefTypeId = TSD.Enum.RefType.PaymentDeposite;
            this.ClientSize = new System.Drawing.Size(1134, 626);
            this.EventTime = new System.DateTime(2019, 11, 21, 16, 31, 23, 547);
            this.FormCaption = "Chi tiền gửi";
            this.Name = "FrmXtraPaymentDepositDetail";
            this.Reference = "THÊM GIẤY BÁO NỢ - ID  - SỐ CT: ";
            this.Text = "FrmXtraPaymentDepositDetail";
            this.Load += new System.EventHandler(this.FrmXtraPaymentDepositDetail_Load);
            this.Resize += new System.EventHandler(this.FrmXtraPaymentDepositDetail_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.imageToobarCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupVoucher)).EndInit();
            this.groupVoucher.ResumeLayout(false);
            this.groupVoucher.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupObject)).EndInit();
            this.groupObject.ResumeLayout(false);
            this.groupObject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageToolbar24Collection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRefDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRefDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPostDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPostDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRefNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboObjectName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContactName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboObjectCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboObjectCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCurrency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboExchangRate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

    }
}
