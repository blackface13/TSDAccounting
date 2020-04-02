using TSD.Enum;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    partial class FrmXtraAccountTranferVoucherDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmXtraAccountTranferVoucherDetail));
            this.grdAccountTranfer = new DevExpress.XtraGrid.GridControl();
            this.grdViewAccountTranfer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtAccountTranferDescription = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.grdAccountTranfer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewAccountTranfer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountTranferDescription.Properties)).BeginInit();
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
            this.groupVoucher.Location = new System.Drawing.Point(895, 56);
            this.groupVoucher.Size = new System.Drawing.Size(204, 130);
            // 
            // groupObject
            // 
            this.groupObject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupObject.Controls.Add(this.grdAccountTranfer);
            this.groupObject.Controls.Add(this.txtAccountTranferDescription);
            this.groupObject.Controls.Add(this.labelControl10);
            this.groupObject.Location = new System.Drawing.Point(8, 56);
            this.groupObject.Size = new System.Drawing.Size(883, 130);
            this.groupObject.Text = "Thông tin chung";
            this.groupObject.Controls.SetChildIndex(this.cboObjectCategory, 0);
            this.groupObject.Controls.SetChildIndex(this.cboObjectCode, 0);
            this.groupObject.Controls.SetChildIndex(this.cboBank, 0);
            this.groupObject.Controls.SetChildIndex(this.txtDescription, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl4, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl5, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl6, 0);
            this.groupObject.Controls.SetChildIndex(this.cboObjectName, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl7, 0);
            this.groupObject.Controls.SetChildIndex(this.txtAddress, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl9, 0);
            this.groupObject.Controls.SetChildIndex(this.txtContactName, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl10, 0);
            this.groupObject.Controls.SetChildIndex(this.labelControl8, 0);
            this.groupObject.Controls.SetChildIndex(this.txtAccountTranferDescription, 0);
            this.groupObject.Controls.SetChildIndex(this.lblBankAccount, 0);
            this.groupObject.Controls.SetChildIndex(this.grdAccountTranfer, 0);
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
            this.dtRefDate.Location = new System.Drawing.Point(73, 102);
            this.dtRefDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtRefDate.Size = new System.Drawing.Size(123, 20);
            // 
            // dtPostDate
            // 
            this.dtPostDate.EditValue = new System.DateTime(2014, 3, 18, 19, 17, 56, 986);
            this.dtPostDate.Location = new System.Drawing.Point(73, 76);
            this.dtPostDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtPostDate.Size = new System.Drawing.Size(123, 20);
            this.dtPostDate.Validated += new System.EventHandler(this.dtPostDate_Validated);
            // 
            // txtRefNo
            // 
            this.txtRefNo.Location = new System.Drawing.Point(73, 50);
            this.txtRefNo.Size = new System.Drawing.Size(123, 20);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 105);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 79);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 53);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(17, 147);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(104, 140);
            this.txtAddress.Size = new System.Drawing.Size(875, 20);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(17, 144);
            // 
            // cboObjectName
            // 
            this.cboObjectName.Location = new System.Drawing.Point(515, 140);
            this.cboObjectName.Size = new System.Drawing.Size(875, 20);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(442, 143);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(252, 143);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(17, 144);
            // 
            // txtContactName
            // 
            this.txtContactName.Location = new System.Drawing.Point(104, 140);
            this.txtContactName.Size = new System.Drawing.Size(875, 20);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(17, 144);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(104, 141);
            this.txtDescription.Size = new System.Drawing.Size(875, 20);
            // 
            // cboBank
            // 
            // 
            // cboObjectCode
            // 
            this.cboObjectCode.Location = new System.Drawing.Point(342, 140);
            // 
            // cboObjectCategory
            // 
            this.cboObjectCategory.Location = new System.Drawing.Point(104, 140);
            // 
            // cboCurrency
            // 
            this.cboCurrency.Location = new System.Drawing.Point(73, 24);
            this.cboCurrency.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.cboCurrency.Size = new System.Drawing.Size(123, 20);
            // 
            // lbExchangeRate
            // 
            this.lbExchangeRate.Location = new System.Drawing.Point(9, 131);
            // 
            // lbCurrency
            // 
            this.lbCurrency.Location = new System.Drawing.Point(9, 27);
            this.lbCurrency.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            // 
            // cboExchangRate
            // 
            this.cboExchangRate.Location = new System.Drawing.Point(73, 130);
            this.cboExchangRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.cboExchangRate.Size = new System.Drawing.Size(123, 20);
            // 
            // grdAccountTranfer
            // 
            this.grdAccountTranfer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAccountTranfer.Location = new System.Drawing.Point(699, 24);
            this.grdAccountTranfer.MainView = this.grdViewAccountTranfer;
            this.grdAccountTranfer.MenuManager = this.barToolManager;
            this.grdAccountTranfer.Name = "grdAccountTranfer";
            this.grdAccountTranfer.Size = new System.Drawing.Size(175, 16);
            this.grdAccountTranfer.TabIndex = 18;
            this.grdAccountTranfer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewAccountTranfer});
            this.grdAccountTranfer.Visible = false;
            // 
            // grdViewAccountTranfer
            // 
            this.grdViewAccountTranfer.GridControl = this.grdAccountTranfer;
            this.grdViewAccountTranfer.Name = "grdViewAccountTranfer";
            this.grdViewAccountTranfer.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grdViewAccountTranfer.OptionsView.ShowDetailButtons = false;
            this.grdViewAccountTranfer.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.grdViewAccountTranfer.OptionsView.ShowGroupPanel = false;
            this.grdViewAccountTranfer.OptionsView.ShowIndicator = false;
            // 
            // txtAccountTranferDescription
            // 
            this.txtAccountTranferDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountTranferDescription.Location = new System.Drawing.Point(56, 24);
            this.txtAccountTranferDescription.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtAccountTranferDescription.Name = "txtAccountTranferDescription";
            this.txtAccountTranferDescription.Size = new System.Drawing.Size(818, 98);
            this.txtAccountTranferDescription.TabIndex = 15;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(9, 27);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(40, 13);
            this.labelControl10.TabIndex = 1;
            this.labelControl10.Text = "Diển giải";
            // 
            // FrmXtraAccountTranferVoucherDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BaseRefTypeId = TSD.Enum.RefType.AccountTranferVourcher;
            this.ClientSize = new System.Drawing.Size(1107, 626);
            this.EventTime = new System.DateTime(2019, 11, 27, 14, 45, 54, 486);
            this.FormCaption = "Chứng từ kết chuyển";
            this.KeyValue = "RefId";
            this.Name = "FrmXtraAccountTranferVoucherDetail";
            this.Reference = "THÊM CHỨNG TỪ KẾT CHUYỂN - ID RefId - SỐ CT: ";
            this.Text = "FrmXtraAccountTranferVoucherDetail";
            this.Load += new System.EventHandler(this.FrmXtraAccountTranferVoucherDetail_Load);
            this.Resize += new System.EventHandler(this.FrmXtraAccountTranferVoucherDetail_Resize);
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
            ((System.ComponentModel.ISupportInitialize)(this.grdAccountTranfer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewAccountTranfer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountTranferDescription.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraGrid.GridControl grdAccountTranfer;
        protected DevExpress.XtraGrid.Views.Grid.GridView grdViewAccountTranfer;
        private DevExpress.XtraEditors.MemoEdit txtAccountTranferDescription;

    }
}