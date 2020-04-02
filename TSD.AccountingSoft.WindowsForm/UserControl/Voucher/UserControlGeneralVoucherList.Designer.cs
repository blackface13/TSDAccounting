using TSD.Enum;

namespace TSD.AccountingSoft.WindowsForm.UserControl.Voucher
{
    partial class UserControlGeneralVoucherList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Location = new System.Drawing.Point(0, 52);
            this.splitContainerControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitContainerControl.Size = new System.Drawing.Size(835, 469);
            // 
            // UserControlGeneralVoucherList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.EventTime = new System.DateTime(2020, 1, 13, 16, 46, 13, 233);
            this.FormCaption = "Chứng từ chung";
            this.FormDetail = "FrmXtraGeneralVoucherDetail";
            this.Name = "UserControlGeneralVoucherList";
            this.NamespaceForm = "TSD.AccountingSoft.WindowsForm.FormBusiness";
            // 
            // popupMenu
            // 
            this.popupMenu.Manager = this.barToolManager;
            this.popupMenu.Name = "popupMenu";
            this.barToolManager.SetPopupContextMenu(this, this.popupMenu);
            this.Reference = "THÊM CHỨNG TỪ CHUNG - ID  - SỐ CT: ";
            this.RefTypeId = TSD.Enum.RefType.GeneralVoucher;
            this.TablePrimaryKey = "RefId";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.PopupMenu popupMenu;
    }
}
