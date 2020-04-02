namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    partial class FrmXtraOpeningFixedAssetEntryDetail
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
            this.grdDetail = new DevExpress.XtraGrid.GridControl();
            this.bindingSourceDetail = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.groupboxMain.Appearance.Options.UseBackColor = true;
            this.groupboxMain.Controls.Add(this.grdDetail);
            this.groupboxMain.Location = new System.Drawing.Point(8, 9);
            this.groupboxMain.Size = new System.Drawing.Size(726, 293);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(592, 309);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(664, 309);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 309);
            // 
            // grdDetail
            // 
            this.grdDetail.DataSource = this.bindingSourceDetail;
            this.grdDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDetail.Location = new System.Drawing.Point(2, 2);
            this.grdDetail.MainView = this.gridViewDetail;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.Size = new System.Drawing.Size(722, 289);
            this.grdDetail.TabIndex = 1;
            this.grdDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDetail});
            // 
            // gridViewDetail
            // 
            this.gridViewDetail.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewDetail.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewDetail.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridViewDetail.Appearance.TopNewRow.BackColor = System.Drawing.Color.Linen;
            this.gridViewDetail.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridViewDetail.Appearance.TopNewRow.Options.UseTextOptions = true;
            this.gridViewDetail.Appearance.TopNewRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridViewDetail.FixedLineWidth = 1;
            this.gridViewDetail.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridViewDetail.GridControl = this.grdDetail;
            this.gridViewDetail.Name = "gridViewDetail";
            this.gridViewDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewDetail.OptionsBehavior.Editable = false;
            this.gridViewDetail.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridViewDetail.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewDetail.OptionsView.ColumnAutoWidth = false;
            this.gridViewDetail.OptionsView.ShowGroupPanel = false;
            this.gridViewDetail.OptionsView.ShowIndicator = false;
            // 
            // FrmXtraOpeningFixedAssetEntryDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 340);
            this.ComponentName = "Số dư đầu kỳ TSCĐ";
            this.EventTime = new System.DateTime(2020, 2, 6, 19, 35, 50, 680);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.FormCaption = "Số dư đầu kỳ TSCĐ";
            this.MaximizeBox = true;
            this.Name = "FrmXtraOpeningFixedAssetEntryDetail";
            this.Reference = "THÊM SỐ DƯ ĐẦU KỲ TSCĐ - ID ";
            this.Text = "FrmXtraOpeningFixedAssetEntryDetail";
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraGrid.GridControl grdDetail;
        protected DevExpress.XtraGrid.Views.Grid.GridView gridViewDetail;
        protected System.Windows.Forms.BindingSource bindingSourceDetail;

    }
}