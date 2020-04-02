namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    partial class FrmXtraStockDetail
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
            this.txtStockCode = new DevExpress.XtraEditors.TextEdit();
            this.txtStockName = new DevExpress.XtraEditors.TextEdit();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.chkActive = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStockCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStockName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(329, 227);
            this.btnSave.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(405, 227);
            this.btnExit.TabIndex = 3;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(9, 227);
            this.btnHelp.TabIndex = 4;
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.label3);
            this.groupboxMain.Controls.Add(this.txtDescription);
            this.groupboxMain.Controls.Add(this.txtStockName);
            this.groupboxMain.Controls.Add(this.label2);
            this.groupboxMain.Controls.Add(this.label1);
            this.groupboxMain.Controls.Add(this.txtStockCode);
            this.groupboxMain.ShowCaption = true;
            this.groupboxMain.Size = new System.Drawing.Size(466, 187);
            this.groupboxMain.Text = "Thông tin chung";
            // 
            // txtStockCode
            // 
            this.txtStockCode.Location = new System.Drawing.Point(70, 24);
            this.txtStockCode.Name = "txtStockCode";
            this.txtStockCode.Size = new System.Drawing.Size(160, 20);
            this.txtStockCode.TabIndex = 2;
            // 
            // txtStockName
            // 
            this.txtStockName.Location = new System.Drawing.Point(70, 50);
            this.txtStockName.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtStockName.Name = "txtStockName";
            this.txtStockName.Size = new System.Drawing.Size(387, 20);
            this.txtStockName.TabIndex = 4;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(70, 76);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(387, 106);
            this.txtDescription.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "&Mã kho (*)";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên &kho (*)";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mô &tả";
            // 
            // chkActive
            // 
            this.chkActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkActive.EditValue = true;
            this.chkActive.Location = new System.Drawing.Point(7, 202);
            this.chkActive.Name = "chkActive";
            this.chkActive.Properties.Caption = "Đượ&c sử dụng";
            this.chkActive.Size = new System.Drawing.Size(94, 19);
            this.chkActive.TabIndex = 1;
            // 
            // FrmXtraStockDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.ComponentName = "Kho";
            this.Controls.Add(this.chkActive);
            this.EventTime = new System.DateTime(2019, 11, 8, 13, 34, 15, 680);
            this.FormCaption = "Kho";
            this.Name = "FrmXtraStockDetail";
            this.Reference = "THÊM KHO - ID ";
            this.TableCode = "Stock";
            this.Text = "FrmXtraStockDetail";
            this.Controls.SetChildIndex(this.chkActive, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStockCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStockName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl label3;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private DevExpress.XtraEditors.TextEdit txtStockName;
        private DevExpress.XtraEditors.TextEdit txtStockCode;
        private DevExpress.XtraEditors.CheckEdit chkActive;
    }
}