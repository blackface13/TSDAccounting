using TSD.Enum;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    partial class FrmXtraGeneralVoucherDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmXtraGeneralVoucherDetail));
            this.label1 = new System.Windows.Forms.Label();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetailParallel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.groupVoucher.Location = new System.Drawing.Point(922, 58);
            this.groupVoucher.Size = new System.Drawing.Size(204, 103);
            // 
            // groupObject
            // 
            this.groupObject.Controls.Add(this.label1);
            this.groupObject.Location = new System.Drawing.Point(7, 58);
            this.groupObject.Size = new System.Drawing.Size(909, 103);
            this.groupObject.Text = "Thông tin chung";
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
            this.dtRefDate.Location = new System.Drawing.Point(74, 72);
            this.dtRefDate.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.dtRefDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtRefDate.Size = new System.Drawing.Size(122, 20);
            // 
            // dtPostDate
            // 
            this.dtPostDate.EditValue = new System.DateTime(2014, 3, 18, 19, 17, 56, 986);
            this.dtPostDate.Location = new System.Drawing.Point(74, 46);
            this.dtPostDate.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.dtPostDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtPostDate.Size = new System.Drawing.Size(122, 20);
            this.dtPostDate.EditValueChanged += new System.EventHandler(this.dtPostDate_EditValueChanged);
            // 
            // txtRefNo
            // 
            this.txtRefNo.Location = new System.Drawing.Point(74, 19);
            this.txtRefNo.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtRefNo.Size = new System.Drawing.Size(122, 20);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 75);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 49);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 23);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(5, 274);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(92, 211);
            this.txtAddress.Size = new System.Drawing.Size(901, 20);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(5, 214);
            // 
            // cboObjectName
            // 
            this.cboObjectName.Location = new System.Drawing.Point(513, 184);
            this.cboObjectName.Size = new System.Drawing.Size(901, 20);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(435, 187);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(266, 187);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(5, 187);
            // 
            // txtContactName
            // 
            this.txtContactName.Location = new System.Drawing.Point(92, 238);
            this.txtContactName.Size = new System.Drawing.Size(901, 20);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(5, 241);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(62, 20);
            this.txtDescription.Properties.AutoHeight = false;
            this.txtDescription.Properties.Mask.BeepOnError = true;
            this.txtDescription.Size = new System.Drawing.Size(842, 75);
            // 
            // cboBank
            // 
            this.cboBank.Location = new System.Drawing.Point(92, 297);
            // 
            // lblBankAccount
            // 
            this.lblBankAccount.Location = new System.Drawing.Point(5, 300);
            // 
            // cboObjectCode
            // 
            this.cboObjectCode.Location = new System.Drawing.Point(335, 184);
            // 
            // cboObjectCategory
            // 
            this.cboObjectCategory.Location = new System.Drawing.Point(92, 184);
            // 
            // cboCurrency
            // 
            this.cboCurrency.Location = new System.Drawing.Point(95, 136);
            // 
            // lbExchangeRate
            // 
            this.lbExchangeRate.Location = new System.Drawing.Point(12, 139);
            // 
            // lbCurrency
            // 
            this.lbCurrency.Location = new System.Drawing.Point(9, 139);
            // 
            // cboExchangRate
            // 
            this.cboExchangRate.Location = new System.Drawing.Point(95, 136);
            this.cboExchangRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Diễn giải";
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // FrmXtraGeneralVoucherDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BaseRefTypeId = TSD.Enum.RefType.GeneralVoucher;
            this.ClientSize = new System.Drawing.Size(1134, 626);
            this.EventTime = new System.DateTime(2020, 2, 6, 19, 36, 28, 713);
            this.FormCaption = "Chứng từ chung";
            this.KeyValue = "RefId";
            this.Name = "FrmXtraGeneralVoucherDetail";
            this.Reference = "THÊM CHỨNG TỪ CHUNG - ID RefId - SỐ CT: ";
            this.Text = "FrmXtraGeneralVoucherDetail";
            this.Load += new System.EventHandler(this.FrmXtraGeneralVoucherDetail_Load);
            this.Resize += new System.EventHandler(this.FrmXtraGeneralVoucherDetail_Resize);
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
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetailParallel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}