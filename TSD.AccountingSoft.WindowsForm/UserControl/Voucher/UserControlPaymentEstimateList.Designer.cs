using TSD.Enum;

namespace TSD.AccountingSoft.WindowsForm.UserControl.Voucher
{
    partial class UserControlPaymentEstimateList
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
            this.bandedGridViewDetail = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridViewDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitContainerControl.SplitterPosition = 260;
            // 
            // bandedGridViewDetail
            // 
            this.bandedGridViewDetail.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.bandedGridViewDetail.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridViewDetail.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bandedGridViewDetail.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Black;
            this.bandedGridViewDetail.Appearance.ViewCaption.Options.UseForeColor = true;
            this.bandedGridViewDetail.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.bandedGridViewDetail.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.bandedGridViewDetail.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.bandedGridViewDetail.GridControl = this.gridDetail;
            this.bandedGridViewDetail.Name = "bandedGridViewDetail";
            this.bandedGridViewDetail.OptionsBehavior.Editable = false;
            this.bandedGridViewDetail.OptionsCustomization.AllowQuickHideColumns = false;
            this.bandedGridViewDetail.OptionsNavigation.EnterMoveNextColumn = true;
            this.bandedGridViewDetail.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.bandedGridViewDetail.OptionsView.ColumnAutoWidth = false;
            this.bandedGridViewDetail.OptionsView.ShowGroupPanel = false;
            this.bandedGridViewDetail.OptionsView.ShowIndicator = false;
            this.bandedGridViewDetail.OptionsView.ShowViewCaption = true;
            this.bandedGridViewDetail.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow;
            this.bandedGridViewDetail.ViewCaption = "Chi tiết chứng từ";
            // 
            // popupMenu
            // 
            this.popupMenu.Manager = this.barToolManager;
            this.popupMenu.Name = "popupMenu";
            // 
            // UserControlPaymentEstimateList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.EventTime = new System.DateTime(2019, 11, 14, 9, 33, 46, 783);
            this.FormCaption = "Phiếu chi";
            this.FormDetail = "FrmXtraPaymentEstimateDetail";
            this.Name = "UserControlPaymentEstimateList";
            this.NamespaceForm = "TSD.AccountingSoft.WindowsForm.FormBusiness";
            this.barToolManager.SetPopupContextMenu(this, this.popupMenu);
            this.Reference = "THÊM PHIẾU CHI - ID  - SỐ CT: ";
            this.RefTypeId = TSD.Enum.RefType.PaymentEstimate;
            this.TablePrimaryKey = "RefId";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridViewDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridViewDetail;
        private DevExpress.XtraBars.PopupMenu popupMenu;
    }
}
