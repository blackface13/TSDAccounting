namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    partial class FrmLedgerAccountingS104H
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
            this.dateTimeRangeV1 = new DateTimeRangeBlockDev.DateTimeRangeV();
            this.treeListBudgetSource = new DevExpress.XtraTreeList.TreeList();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtOpenDate = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListBudgetSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtOpenDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtOpenDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.dtOpenDate);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.treeListBudgetSource);
            this.groupboxMain.Controls.Add(this.dateTimeRangeV1);
            this.groupboxMain.Size = new System.Drawing.Size(541, 399);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(392, 416);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(473, 416);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(7, 416);
            // 
            // dateTimeRangeV1
            // 
            this.dateTimeRangeV1.DateRangePeriodMode = DateTimeRangeBlockDev.Helper.DateRangeMode.All;
            this.dateTimeRangeV1.FromDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.FromDateLabelText = "Từ ngày";
            this.dateTimeRangeV1.InitSelectedIndex = 0;
            this.dateTimeRangeV1.Location = new System.Drawing.Point(5, 5);
            this.dateTimeRangeV1.MinimumSize = new System.Drawing.Size(290, 70);
            this.dateTimeRangeV1.Name = "dateTimeRangeV1";
            this.dateTimeRangeV1.PeriodLabelText = "Kỳ báo cáo";
            this.dateTimeRangeV1.Size = new System.Drawing.Size(304, 70);
            this.dateTimeRangeV1.TabIndex = 0;
            this.dateTimeRangeV1.ToDate = new System.DateTime(((long)(0)));
            this.dateTimeRangeV1.ToDateLabelText = "Đến ngày";
            // 
            // treeListBudgetSource
            // 
            this.treeListBudgetSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeListBudgetSource.KeyFieldName = "BudgetSourceId";
            this.treeListBudgetSource.Location = new System.Drawing.Point(5, 104);
            this.treeListBudgetSource.Name = "treeListBudgetSource";
            this.treeListBudgetSource.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.treeListBudgetSource.OptionsSelection.InvertSelection = true;
            this.treeListBudgetSource.OptionsSelection.MultiSelect = true;
            this.treeListBudgetSource.OptionsView.ShowCheckBoxes = true;
            this.treeListBudgetSource.OptionsView.ShowIndicator = false;
            this.treeListBudgetSource.ParentFieldName = "ParentId";
            this.treeListBudgetSource.Size = new System.Drawing.Size(531, 290);
            this.treeListBudgetSource.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 81);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Ngày mở sổ";
            // 
            // dtOpenDate
            // 
            this.dtOpenDate.EditValue = null;
            this.dtOpenDate.Location = new System.Drawing.Point(78, 78);
            this.dtOpenDate.Name = "dtOpenDate";
            this.dtOpenDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtOpenDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtOpenDate.Size = new System.Drawing.Size(223, 20);
            this.dtOpenDate.TabIndex = 4;
            // 
            // FrmLedgerAccountingS104H
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 450);
            this.Name = "FrmLedgerAccountingS104H";
            this.Text = "FrmLedgerAccountingS104H";
            this.Load += new System.EventHandler(this.FrmLedgerAccountingS104H_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListBudgetSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtOpenDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtOpenDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRangeV1;
        private DevExpress.XtraTreeList.TreeList treeListBudgetSource;
        private DevExpress.XtraEditors.DateEdit dtOpenDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}