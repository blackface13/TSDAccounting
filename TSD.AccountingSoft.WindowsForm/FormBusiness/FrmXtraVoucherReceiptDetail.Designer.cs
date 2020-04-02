using TSD.Enum;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    partial class FrmXtraVoucherReceiptDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmXtraVoucherReceiptDetail));
            this.txtTaxCode = new DevExpress.XtraEditors.TextEdit();
            this.labelTaxCode = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.txtDocumentInclude = new DevExpress.XtraEditors.TextEdit();
            this.chkIncludeCharge = new DevExpress.XtraEditors.CheckEdit();
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
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetailParallel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboExchangRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentInclude.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeCharge.Properties)).BeginInit();
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
            this.groupVoucher.Location = new System.Drawing.Point(916, 56);
            this.groupVoucher.Size = new System.Drawing.Size(210, 157);
            // 
            // groupObject
            // 
            this.groupObject.Controls.Add(this.chkIncludeCharge);
            this.groupObject.Controls.Add(this.txtDocumentInclude);
            this.groupObject.Controls.Add(this.label1);
            this.groupObject.Controls.Add(this.labelTaxCode);
            this.groupObject.Controls.Add(this.txtTaxCode);
            this.groupObject.Size = new System.Drawing.Size(904, 157);
            this.groupObject.Controls.SetChildIndex(this.txtTaxCode, 0);
            this.groupObject.Controls.SetChildIndex(this.labelTaxCode, 0);
            this.groupObject.Controls.SetChildIndex(this.label1, 0);
            this.groupObject.Controls.SetChildIndex(this.txtDocumentInclude, 0);
            this.groupObject.Controls.SetChildIndex(this.cboObjectCode, 0);
            this.groupObject.Controls.SetChildIndex(this.cboBank, 0);
            this.groupObject.Controls.SetChildIndex(this.lblBankAccount, 0);
            this.groupObject.Controls.SetChildIndex(this.cboObjectCategory, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl4, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl5, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl6, 0);
            this.groupObject.Controls.SetChildIndex(this.cboObjectName, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl7, 0);
            this.groupObject.Controls.SetChildIndex(this.txtAddress, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl9, 0);
            this.groupObject.Controls.SetChildIndex(this.txtContactName, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl8, 0);
            this.groupObject.Controls.SetChildIndex(this.txtDescription, 0);
            this.groupObject.Controls.SetChildIndex(this.chkIncludeCharge, 0);
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
            // 
            // dtPostDate
            // 
            this.dtPostDate.EditValue = new System.DateTime(2014, 3, 18, 19, 17, 56, 986);
            this.dtPostDate.Location = new System.Drawing.Point(73, 102);
            this.dtPostDate.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.dtPostDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtPostDate.Size = new System.Drawing.Size(122, 20);
            this.dtPostDate.EditValueChanged += new System.EventHandler(this.dtPostDate_EditValueChanged);
            // 
            // txtRefNo
            // 
            this.txtRefNo.Location = new System.Drawing.Point(73, 76);
            this.txtRefNo.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtRefNo.Size = new System.Drawing.Size(122, 20);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 131);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl3.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 105);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl2.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 79);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(10, 105);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl8.TabIndex = 12;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(101, 50);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtAddress.Size = new System.Drawing.Size(794, 20);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(9, 53);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            // 
            // cboObjectName
            // 
            this.cboObjectName.Location = new System.Drawing.Point(618, 24);
            this.cboObjectName.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.cboObjectName.Size = new System.Drawing.Size(277, 20);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(519, 27);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.labelControl6.Size = new System.Drawing.Size(84, 13);
            this.labelControl6.Text = "Tên đối tượng (*)";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(258, 27);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.labelControl5.Size = new System.Drawing.Size(80, 13);
            this.labelControl5.Text = "Mã đối tượng (*)";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(10, 27);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl4.Size = new System.Drawing.Size(85, 13);
            this.labelControl4.Text = "Loại đối tượng (*)";
            // 
            // txtContactName
            // 
            this.txtContactName.Location = new System.Drawing.Point(101, 76);
            this.txtContactName.Size = new System.Drawing.Size(411, 20);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(10, 79);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl9.TabIndex = 8;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(101, 102);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtDescription.Size = new System.Drawing.Size(794, 20);
            this.txtDescription.TabIndex = 6;
            // 
            // cboBank
            // 
            this.cboBank.Location = new System.Drawing.Point(101, 128);
            this.cboBank.Size = new System.Drawing.Size(150, 20);
            this.cboBank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboBank_KeyDown);
            // 
            // lblBankAccount
            // 
            this.lblBankAccount.Location = new System.Drawing.Point(10, 131);
            this.lblBankAccount.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            // 
            // cboObjectCode
            // 
            this.cboObjectCode.Location = new System.Drawing.Point(347, 24);
            this.cboObjectCode.Size = new System.Drawing.Size(165, 20);
            // 
            // cboObjectCategory
            // 
            this.cboObjectCategory.Location = new System.Drawing.Point(101, 24);
            this.cboObjectCategory.Size = new System.Drawing.Size(150, 20);
            // 
            // cboCurrency
            // 
            this.cboCurrency.Location = new System.Drawing.Point(73, 24);
            this.cboCurrency.Size = new System.Drawing.Size(122, 20);
            this.cboCurrency.EditValueChanged += new System.EventHandler(this.cboCurrency_EditValueChanged);
            // 
            // lbExchangeRate
            // 
            this.lbExchangeRate.Location = new System.Drawing.Point(9, 53);
            // 
            // lbCurrency
            // 
            this.lbCurrency.Location = new System.Drawing.Point(9, 27);
            // 
            // cboExchangRate
            // 
            this.cboExchangRate.Location = new System.Drawing.Point(73, 50);
            this.cboExchangRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.cboExchangRate.Size = new System.Drawing.Size(122, 20);
            // 
            // txtTaxCode
            // 
            this.txtTaxCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaxCode.Location = new System.Drawing.Point(873, 76);
            this.txtTaxCode.Name = "txtTaxCode";
            this.txtTaxCode.Size = new System.Drawing.Size(9, 20);
            this.txtTaxCode.TabIndex = 8;
            // 
            // labelTaxCode
            // 
            this.labelTaxCode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelTaxCode.Location = new System.Drawing.Point(805, 171);
            this.labelTaxCode.Name = "labelTaxCode";
            this.labelTaxCode.Size = new System.Drawing.Size(53, 13);
            this.labelTaxCode.TabIndex = 7;
            this.labelTaxCode.Text = "Mã số thuế";
            this.labelTaxCode.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(519, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Chứng từ đi kèm(*)";
            // 
            // txtDocumentInclude
            // 
            this.txtDocumentInclude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocumentInclude.Location = new System.Drawing.Point(618, 76);
            this.txtDocumentInclude.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtDocumentInclude.Name = "txtDocumentInclude";
            this.txtDocumentInclude.Size = new System.Drawing.Size(277, 20);
            this.txtDocumentInclude.TabIndex = 5;
            this.txtDocumentInclude.EditValueChanged += new System.EventHandler(this.txtDocumentInclude_EditValueChanged);
            // 
            // chkIncludeCharge
            // 
            this.chkIncludeCharge.Location = new System.Drawing.Point(258, 129);
            this.chkIncludeCharge.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.chkIncludeCharge.MenuManager = this.barToolManager;
            this.chkIncludeCharge.Name = "chkIncludeCharge";
            this.chkIncludeCharge.Properties.Caption = "Nhận dự toán";
            this.chkIncludeCharge.Size = new System.Drawing.Size(107, 19);
            this.chkIncludeCharge.TabIndex = 15;
            this.chkIncludeCharge.Visible = false;
            this.chkIncludeCharge.CheckedChanged += new System.EventHandler(this.chkIncludeCharge_CheckedChanged);
            // 
            // FrmXtraVoucherReceiptDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BaseRefTypeId = TSD.Enum.RefType.ReceiptCash;
            this.ClientSize = new System.Drawing.Size(1134, 734);
            this.EventTime = new System.DateTime(2020, 3, 16, 18, 36, 52, 419);
            this.FormCaption = "Phiếu thu";
            this.KeyValue = "RefId";
            this.Name = "FrmXtraVoucherReceiptDetail";
            this.Reference = "THÊM PHIẾU THU - ID RefId - SỐ CT: ";
            this.Text = "FrmXtraVoucherReceiptDetail";
            this.Load += new System.EventHandler(this.FrmXtraVoucherReceiptDetail_Load);
            this.Resize += new System.EventHandler(this.FrmXtraVoucherReceiptDetail_Resize);
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
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetailParallel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboExchangRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentInclude.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeCharge.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelTaxCode;
        private DevExpress.XtraEditors.TextEdit txtTaxCode;
        private DevExpress.XtraEditors.TextEdit txtDocumentInclude;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.CheckEdit chkIncludeCharge;
    }
}