namespace TSD.AccountingSoft.WindowsForm.FormSystem
{
    partial class FrmXtraExportData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        //private DateTimeRangeBlockDev.DateTimeRangeV dateTimeRange;

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
            this.btnExportData = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAuditPerson = new DevExpress.XtraEditors.TextEdit();
            this.txtCompanyName = new DevExpress.XtraEditors.TextEdit();
            this.txtPathXML = new DevExpress.XtraEditors.ButtonEdit();
            this.cboCheckData = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCompanyCode = new DevExpress.XtraEditors.TextEdit();
            this.yearPicker = new DevExpress.XtraEditors.DateEdit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAuditPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPathXML.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCheckData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearPicker.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearPicker.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportData
            // 
            this.btnExportData.ImageIndex = 0;
            this.btnExportData.Location = new System.Drawing.Point(242, 221);
            this.btnExportData.Name = "btnExportData";
            this.btnExportData.Size = new System.Drawing.Size(75, 23);
            this.btnExportData.TabIndex = 13;
            this.btnExportData.Text = "Export";
            this.btnExportData.Click += new System.EventHandler(this.btnExportData_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(333, 221);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAuditPerson);
            this.groupBox1.Controls.Add(this.txtCompanyName);
            this.groupBox1.Controls.Add(this.txtPathXML);
            this.groupBox1.Controls.Add(this.cboCheckData);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCompanyCode);
            this.groupBox1.Controls.Add(this.yearPicker);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 196);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // txtAuditPerson
            // 
            this.txtAuditPerson.EditValue = "";
            this.txtAuditPerson.Location = new System.Drawing.Point(125, 106);
            this.txtAuditPerson.Name = "txtAuditPerson";
            this.txtAuditPerson.Size = new System.Drawing.Size(264, 20);
            this.txtAuditPerson.TabIndex = 15;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.EditValue = "";
            this.txtCompanyName.Location = new System.Drawing.Point(125, 80);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(264, 20);
            this.txtCompanyName.TabIndex = 14;
            // 
            // txtPathXML
            // 
            this.txtPathXML.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPathXML.Location = new System.Drawing.Point(125, 158);
            this.txtPathXML.Name = "txtPathXML";
            this.txtPathXML.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtPathXML.Size = new System.Drawing.Size(264, 20);
            this.txtPathXML.TabIndex = 11;
            this.txtPathXML.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtPathXML_ButtonClick);
            // 
            // cboCheckData
            // 
            this.cboCheckData.EditValue = "";
            this.cboCheckData.Location = new System.Drawing.Point(125, 132);
            this.cboCheckData.Name = "cboCheckData";
            this.cboCheckData.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCheckData.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(1, "Dữ liệu quyết toán phần 1"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(2, "Dữ liệu quyết toán phần 2"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(3, "Dữ liệu lưu chuyển tiền tệ theo phương pháp gián tiếp"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(4, "Dữ liệu tình hình tài chính")});
            this.cboCheckData.Size = new System.Drawing.Size(264, 20);
            this.cboCheckData.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Cán bộ kiểm soát :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Đường dẫn lưu file (*):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Dữ liệu cần xuất (*):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên đơn vị (*):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã đơn vị (*):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Năm báo cáo(*) :";
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.EditValue = "";
            this.txtCompanyCode.Location = new System.Drawing.Point(125, 54);
            this.txtCompanyCode.Name = "txtCompanyCode";
            this.txtCompanyCode.Size = new System.Drawing.Size(264, 20);
            this.txtCompanyCode.TabIndex = 13;
            // 
            // yearPicker
            // 
            this.yearPicker.EditValue = "";
            this.yearPicker.Location = new System.Drawing.Point(125, 26);
            this.yearPicker.Name = "yearPicker";
            this.yearPicker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.yearPicker.Properties.Mask.EditMask = "yyyy";
            this.yearPicker.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.yearPicker.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView;
            this.yearPicker.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.yearPicker.Properties.VistaEditTime = DevExpress.Utils.DefaultBoolean.False;
            this.yearPicker.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.yearPicker.Size = new System.Drawing.Size(264, 20);
            this.yearPicker.TabIndex = 16;
            // 
            // FrmXtraExportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 261);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExportData);
            this.Name = "FrmXtraExportData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xuất khẩu dữ liệu";
            this.Load += new System.EventHandler(this.FrmXtraExportData_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAuditPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPathXML.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCheckData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearPicker.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearPicker.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnExportData;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.ButtonEdit txtPathXML;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.CheckedComboBoxEdit cboCheckData;
        private DevExpress.XtraEditors.TextEdit txtAuditPerson;
        private DevExpress.XtraEditors.TextEdit txtCompanyName;
        private DevExpress.XtraEditors.TextEdit txtCompanyCode;
        private DevExpress.XtraEditors.DateEdit yearPicker;
    }
}