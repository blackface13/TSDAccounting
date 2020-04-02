namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    internal partial class FrmXtraAccountingObjectDetail
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
            this.cbIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtAcountingObjectCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtAccountingObjectName = new DevExpress.XtraEditors.TextEdit();
            this.txtAddress = new DevExpress.XtraEditors.TextEdit();
            this.txtBankAccount = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtBankName = new DevExpress.XtraEditors.TextEdit();
            this.gridAccountingObjectCategoryId = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridAccountingObjectCategoryIdView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAcountingObjectCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountingObjectName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccountingObjectCategoryId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccountingObjectCategoryIdView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(329, 226);
            this.btnSave.TabIndex = 100;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(405, 226);
            this.btnExit.TabIndex = 101;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(9, 226);
            this.btnHelp.TabIndex = 102;
            // 
            // groupboxMain
            // 
            this.groupboxMain.Controls.Add(this.txtBankName);
            this.groupboxMain.Controls.Add(this.labelControl6);
            this.groupboxMain.Controls.Add(this.labelControl5);
            this.groupboxMain.Controls.Add(this.labelControl4);
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.txtBankAccount);
            this.groupboxMain.Controls.Add(this.txtAddress);
            this.groupboxMain.Controls.Add(this.txtAccountingObjectName);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.txtAcountingObjectCode);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Controls.Add(this.gridAccountingObjectCategoryId);
            this.groupboxMain.Size = new System.Drawing.Size(466, 185);
            this.groupboxMain.Text = "Thông tin chung";
            // 
            // cbIsActive
            // 
            this.cbIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIsActive.EditValue = true;
            this.cbIsActive.Location = new System.Drawing.Point(7, 201);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Properties.Caption = "Được sử dụng";
            this.cbIsActive.Size = new System.Drawing.Size(468, 19);
            this.cbIsActive.TabIndex = 99;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 53);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(80, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mã đối tượng (*)";
            // 
            // txtAcountingObjectCode
            // 
            this.txtAcountingObjectCode.Location = new System.Drawing.Point(100, 50);
            this.txtAcountingObjectCode.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtAcountingObjectCode.Name = "txtAcountingObjectCode";
            this.txtAcountingObjectCode.Size = new System.Drawing.Size(160, 20);
            this.txtAcountingObjectCode.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 27);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(85, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Loại đối tượng (*)";
            // 
            // txtAccountingObjectName
            // 
            this.txtAccountingObjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountingObjectName.Location = new System.Drawing.Point(100, 76);
            this.txtAccountingObjectName.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtAccountingObjectName.Name = "txtAccountingObjectName";
            this.txtAccountingObjectName.Size = new System.Drawing.Size(357, 20);
            this.txtAccountingObjectName.TabIndex = 2;
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(100, 102);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(357, 20);
            this.txtAddress.TabIndex = 4;
            // 
            // txtBankAccount
            // 
            this.txtBankAccount.Location = new System.Drawing.Point(100, 128);
            this.txtBankAccount.Name = "txtBankAccount";
            this.txtBankAccount.Size = new System.Drawing.Size(160, 20);
            this.txtBankAccount.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 79);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(84, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Tên đối tượng (*)";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(9, 105);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(32, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Địa chỉ";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(9, 131);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(66, 13);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "TK ngân hàng";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(9, 157);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(52, 13);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "Ngân hàng";
            // 
            // txtBankName
            // 
            this.txtBankName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBankName.Location = new System.Drawing.Point(100, 154);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(357, 20);
            this.txtBankName.TabIndex = 6;
            // 
            // gridAccountingObjectCategoryId
            // 
            this.gridAccountingObjectCategoryId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridAccountingObjectCategoryId.Location = new System.Drawing.Point(100, 24);
            this.gridAccountingObjectCategoryId.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.gridAccountingObjectCategoryId.Name = "gridAccountingObjectCategoryId";
            this.gridAccountingObjectCategoryId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridAccountingObjectCategoryId.Properties.NullText = "";
            this.gridAccountingObjectCategoryId.Properties.View = this.gridAccountingObjectCategoryIdView;
            this.gridAccountingObjectCategoryId.Size = new System.Drawing.Size(357, 20);
            this.gridAccountingObjectCategoryId.TabIndex = 0;
            this.gridAccountingObjectCategoryId.EditValueChanged += new System.EventHandler(this.gridAccountingObjectCategoryId_EditValueChanged);
            // 
            // gridAccountingObjectCategoryIdView
            // 
            this.gridAccountingObjectCategoryIdView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridAccountingObjectCategoryIdView.Name = "gridAccountingObjectCategoryIdView";
            this.gridAccountingObjectCategoryIdView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridAccountingObjectCategoryIdView.OptionsView.ShowGroupPanel = false;
            // 
            // FrmXtraAccountingObjectDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.ComponentName = "Đối tượng";
            this.Controls.Add(this.cbIsActive);
            this.EventTime = new System.DateTime(2019, 11, 26, 9, 55, 13, 679);
            this.FormCaption = "đối tượng";
            this.Name = "FrmXtraAccountingObjectDetail";
            this.Reference = "THÊM ĐỐI TƯỢNG - ID ";
            this.TableCode = "AccountingObject";
            this.Text = "FrmXtraAccountingObjectDetail";
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.groupboxMain, 0);
            this.Controls.SetChildIndex(this.cbIsActive, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAcountingObjectCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountingObjectName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccountingObjectCategoryId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAccountingObjectCategoryIdView)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion
        private DevExpress.XtraEditors.CheckEdit cbIsActive;
        private DevExpress.XtraEditors.TextEdit txtBankName;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtBankAccount;
        private DevExpress.XtraEditors.TextEdit txtAddress;
        private DevExpress.XtraEditors.TextEdit txtAccountingObjectName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtAcountingObjectCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GridLookUpEdit gridAccountingObjectCategoryId;
        private DevExpress.XtraGrid.Views.Grid.GridView gridAccountingObjectCategoryIdView;
    }
}