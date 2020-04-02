namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    partial class FrmC30BB2
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
            this.grdDetail = new DevExpress.XtraGrid.GridControl();
            this.gridViewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridtemp = new DevExpress.XtraGrid.GridControl();
            this.grdTempView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridtemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTempView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.grdDetail);
            this.groupboxMain.Size = new System.Drawing.Size(684, 324);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(538, 344);
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(618, 344);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(8, 344);
            // 
            // grdDetail
            // 
            this.grdDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDetail.Location = new System.Drawing.Point(8, 8);
            this.grdDetail.MainView = this.gridViewDetail;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.Size = new System.Drawing.Size(662, 303);
            this.grdDetail.TabIndex = 0;
            this.grdDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDetail});
            // 
            // gridViewDetail
            // 
            this.gridViewDetail.GridControl = this.grdDetail;
            this.gridViewDetail.Name = "gridViewDetail";
            this.gridViewDetail.OptionsView.ShowGroupPanel = false;
            this.gridViewDetail.OptionsView.ShowIndicator = false;
            // 
            // gridtemp
            // 
            this.gridtemp.Location = new System.Drawing.Point(304, 344);
            this.gridtemp.MainView = this.grdTempView;
            this.gridtemp.Name = "gridtemp";
            this.gridtemp.Size = new System.Drawing.Size(32, 16);
            this.gridtemp.TabIndex = 8;
            this.gridtemp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdTempView});
            this.gridtemp.Visible = false;
            // 
            // grdTempView
            // 
            this.grdTempView.GridControl = this.gridtemp;
            this.grdTempView.Name = "grdTempView";
            // 
            // FrmC30BB2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 378);
            this.Controls.Add(this.gridtemp);
            this.Name = "FrmC30BB2";
            this.Text = "FrmC30BB";
            this.Load += new System.EventHandler(this.FrmC30BB2_Load);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.gridtemp, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridtemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTempView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDetail;
        private DevExpress.XtraGrid.GridControl gridtemp;
        private DevExpress.XtraGrid.Views.Grid.GridView grdTempView;
    }
}