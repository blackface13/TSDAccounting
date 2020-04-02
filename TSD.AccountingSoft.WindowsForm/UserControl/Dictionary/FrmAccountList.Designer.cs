namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    partial class FrmAccountList
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
            this.grdlookUpAccount = new DevExpress.XtraGrid.GridControl();
            this.gridViewAccount = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdlookUpAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.grdlookUpAccount);
            this.groupboxMain.Size = new System.Drawing.Size(484, 434);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(335, 451);
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(416, 451);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 451);
            // 
            // grdlookUpAccount
            // 
            this.grdlookUpAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdlookUpAccount.Location = new System.Drawing.Point(11, 13);
            this.grdlookUpAccount.MainView = this.gridViewAccount;
            this.grdlookUpAccount.Name = "grdlookUpAccount";
            this.grdlookUpAccount.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCheck});
            this.grdlookUpAccount.Size = new System.Drawing.Size(462, 416);
            this.grdlookUpAccount.TabIndex = 4;
            this.grdlookUpAccount.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewAccount});
            // 
            // gridViewAccount
            // 
            this.gridViewAccount.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridViewAccount.GridControl = this.grdlookUpAccount;
            this.gridViewAccount.Name = "gridViewAccount";
            this.gridViewAccount.OptionsBehavior.Editable = false;
            this.gridViewAccount.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewAccount.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridViewAccount.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewAccount.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewAccount.OptionsSelection.MultiSelect = true;
            this.gridViewAccount.OptionsView.ColumnAutoWidth = false;
            this.gridViewAccount.OptionsView.ShowAutoFilterRow = true;
            this.gridViewAccount.OptionsView.ShowGroupPanel = false;
            this.gridViewAccount.OptionsView.ShowIndicator = false;
            this.gridViewAccount.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewAccount.Click += new System.EventHandler(this.gridViewAccount_Click);
            // 
            // repCheck
            // 
            this.repCheck.AutoHeight = false;
            this.repCheck.Name = "repCheck";
            // 
            // FrmAccountList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 485);
            this.Name = "FrmAccountList";
            this.Text = "Danh sách tài khoản";
            this.Load += new System.EventHandler(this.FrmAccountList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdlookUpAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl grdlookUpAccount;
        public DevExpress.XtraGrid.Views.Grid.GridView gridViewAccount;
        public DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheck;
    }
}