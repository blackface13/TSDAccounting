namespace TSD.AccountingSoft.WindowsForm.FormSystem
{
    partial class FrmXtraDbInfo
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
            this.gridDbInfo = new DevExpress.XtraGrid.GridControl();
            this.gridDbInfoView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridDbInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDbInfoView)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDbInfo
            // 
            this.gridDbInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDbInfo.Location = new System.Drawing.Point(0, 0);
            this.gridDbInfo.MainView = this.gridDbInfoView;
            this.gridDbInfo.Name = "gridDbInfo";
            this.gridDbInfo.Size = new System.Drawing.Size(768, 516);
            this.gridDbInfo.TabIndex = 1;
            this.gridDbInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridDbInfoView});
            // 
            // gridDbInfoView
            // 
            this.gridDbInfoView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridDbInfoView.GridControl = this.gridDbInfo;
            this.gridDbInfoView.Name = "gridDbInfoView";
            this.gridDbInfoView.OptionsBehavior.Editable = false;
            this.gridDbInfoView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridDbInfoView.OptionsView.ShowColumnHeaders = false;
            this.gridDbInfoView.OptionsView.ShowGroupPanel = false;
            this.gridDbInfoView.OptionsView.ShowIndicator = false;
            // 
            // FrmXtraDbInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 516);
            this.Controls.Add(this.gridDbInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmXtraDbInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin dữ liệu";
            this.Load += new System.EventHandler(this.FrmXtraDbInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDbInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDbInfoView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridDbInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridDbInfoView;
    }
}