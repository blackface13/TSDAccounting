namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    partial class FrmXtraBudgetChapterDetail
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
            this.txtBudgetChapterCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtBudgetChapterName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.memoDescription = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetChapterCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetChapterName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDescription.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(232, 213);
            this.btnSave.Size = new System.Drawing.Size(72, 25);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(309, 213);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(5, 213);
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.memoDescription);
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.txtBudgetChapterName);
            this.groupboxMain.Controls.Add(this.txtBudgetChapterCode);
            this.groupboxMain.Location = new System.Drawing.Point(8, 6);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(376, 170);
            this.groupboxMain.Text = "Thông tin chung";
            // 
            // txtBudgetChapterCode
            // 
            this.txtBudgetChapterCode.Location = new System.Drawing.Point(88, 24);
            this.txtBudgetChapterCode.Name = "txtBudgetChapterCode";
            this.txtBudgetChapterCode.Size = new System.Drawing.Size(140, 20);
            this.txtBudgetChapterCode.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "&Mã chương (*)";
            // 
            // txtBudgetChapterName
            // 
            this.txtBudgetChapterName.Location = new System.Drawing.Point(88, 48);
            this.txtBudgetChapterName.Name = "txtBudgetChapterName";
            this.txtBudgetChapterName.Size = new System.Drawing.Size(280, 20);
            this.txtBudgetChapterName.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 52);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "&Tên chương (*)";
            // 
            // chkIsActive
            // 
            this.chkIsActive.EditValue = true;
            this.chkIsActive.Location = new System.Drawing.Point(5, 184);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "Được sử dụng";
            this.chkIsActive.Size = new System.Drawing.Size(91, 19);
            this.chkIsActive.TabIndex = 0;
            // 
            // memoDescription
            // 
            this.memoDescription.Location = new System.Drawing.Point(88, 72);
            this.memoDescription.Name = "memoDescription";
            this.memoDescription.Size = new System.Drawing.Size(280, 88);
            this.memoDescription.TabIndex = 8;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 75);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(40, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "&Diễn giải";
            // 
            // FrmXtraBudgetChapterDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 243);
            this.ComponentName = "Danh mục chương";
            this.Controls.Add(this.chkIsActive);
            this.EventTime = new System.DateTime(2019, 11, 7, 14, 37, 2, 126);
            this.FormCaption = "Danh mục chương";
            this.Name = "FrmXtraBudgetChapterDetail";
            this.Reference = "THÊM DANH MỤC CHƯƠNG - ID ";
            this.Text = "FrmXtraBudgetChapterDetail";
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.chkIsActive, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetChapterCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBudgetChapterName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDescription.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtBudgetChapterCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtBudgetChapterName;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        private DevExpress.XtraEditors.MemoEdit memoDescription;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}