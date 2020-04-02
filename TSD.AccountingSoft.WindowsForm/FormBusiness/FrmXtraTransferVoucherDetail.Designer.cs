using TSD.Enum;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    partial class FrmXtraTransferVoucherDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmXtraTransferVoucherDetail));
            this.txtGenveralDescription = new DevExpress.XtraEditors.MemoEdit();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.txtGenveralDescription.Properties)).BeginInit();
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
            this.groupVoucher.Size = new System.Drawing.Size(204, 103);
            // 
            // groupObject
            // 
            this.groupObject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupObject.Controls.Add(this.label1);
            this.groupObject.Controls.Add(this.txtGenveralDescription);
            this.groupObject.Size = new System.Drawing.Size(910, 103);
            this.groupObject.Text = "Thông tin chung";
            this.groupObject.Visible = false;
            this.groupObject.Controls.SetChildIndex(this.cboBank, 0);
            this.groupObject.Controls.SetChildIndex(this.txtDescription, 0);
            this.groupObject.Controls.SetChildIndex(this.cboObjectCategory, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl4, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl5, 0);
            this.groupObject.Controls.SetChildIndex(this.cboObjectCode, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl6, 0);
            this.groupObject.Controls.SetChildIndex(this.cboObjectName, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl7, 0);
            this.groupObject.Controls.SetChildIndex(this.txtAddress, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl9, 0);
            this.groupObject.Controls.SetChildIndex(this.txtContactName, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl8, 0);
            this.groupObject.Controls.SetChildIndex(this.txtGenveralDescription, 0);
            this.groupObject.Controls.SetChildIndex(this.lblBankAccount, 0);
            this.groupObject.Controls.SetChildIndex(this.label1, 0);
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
            this.dtRefDate.Location = new System.Drawing.Point(73, 76);
            this.dtRefDate.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.dtRefDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtRefDate.Size = new System.Drawing.Size(122, 20);
            this.dtRefDate.EditValueChanged += new System.EventHandler(this.dtRefDate_EditValueChanged);
            // 
            // dtPostDate
            // 
            this.dtPostDate.EditValue = new System.DateTime(2014, 3, 18, 19, 17, 56, 986);
            this.dtPostDate.Location = new System.Drawing.Point(73, 50);
            this.dtPostDate.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.dtPostDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtPostDate.Size = new System.Drawing.Size(122, 20);
            this.dtPostDate.EditValueChanged += new System.EventHandler(this.dtPostDate_EditValueChanged);
            // 
            // txtRefNo
            // 
            this.txtRefNo.Location = new System.Drawing.Point(73, 24);
            this.txtRefNo.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtRefNo.Size = new System.Drawing.Size(122, 20);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 79);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 53);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 27);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(18, 254);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(105, 191);
            this.txtAddress.Size = new System.Drawing.Size(902, 20);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(18, 194);
            // 
            // cboObjectName
            // 
            this.cboObjectName.Location = new System.Drawing.Point(526, 164);
            this.cboObjectName.Size = new System.Drawing.Size(902, 20);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(448, 167);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(279, 167);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(18, 167);
            // 
            // txtContactName
            // 
            this.txtContactName.Location = new System.Drawing.Point(105, 218);
            this.txtContactName.Size = new System.Drawing.Size(902, 20);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(18, 221);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(105, 251);
            this.txtDescription.Size = new System.Drawing.Size(902, 20);
            // 
            // cboBank
            // 
            this.cboBank.Location = new System.Drawing.Point(105, 277);
            // 
            // lblBankAccount
            // 
            this.lblBankAccount.Location = new System.Drawing.Point(18, 280);
            // 
            // cboObjectCode
            // 
            this.cboObjectCode.Location = new System.Drawing.Point(348, 164);
            // 
            // cboObjectCategory
            // 
            this.cboObjectCategory.Location = new System.Drawing.Point(105, 164);
            // 
            // cboCurrency
            // 
            // 
            // cboExchangRate
            // 
            this.cboExchangRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            // 
            // txtGenveralDescription
            // 
            this.txtGenveralDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGenveralDescription.Location = new System.Drawing.Point(56, 24);
            this.txtGenveralDescription.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtGenveralDescription.Name = "txtGenveralDescription";
            this.txtGenveralDescription.Size = new System.Drawing.Size(845, 72);
            this.txtGenveralDescription.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Diễn giải";
            // 
            // FrmXtraTransferVoucherDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BaseRefTypeId = TSD.Enum.RefType.GeneralVoucher;
            this.ClientSize = new System.Drawing.Size(1134, 626);
            this.EventTime = new System.DateTime(2020, 2, 27, 15, 5, 45, 32);
            this.FormCaption = "Chứng từ kết chuyển cuối năm";
            this.KeyValue = "RefId";
            this.Name = "FrmXtraTransferVoucherDetail";
            this.Reference = "THÊM CHỨNG TỪ KẾT CHUYỂN CUỐI NĂM - ID RefId - SỐ CT: ";
            this.Text = "FrmXtraGeneralVoucherDetail";
            this.Load += new System.EventHandler(this.FrmXtraTransferVoucherDetail_Load);
            this.Resize += new System.EventHandler(this.FrmXtraTransferVoucherDetail_Resize);
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
            ((System.ComponentModel.ISupportInitialize)(this.txtGenveralDescription.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit txtGenveralDescription;
        private DevExpress.XtraEditors.LabelControl label1;
    }
}