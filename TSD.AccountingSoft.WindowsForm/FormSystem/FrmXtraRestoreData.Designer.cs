namespace TSD.AccountingSoft.WindowsForm.FormSystem
{
    partial class FrmXtraRestoreData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmXtraRestoreData));
            this.groupboxMain = new DevExpress.XtraEditors.GroupControl();
            this.chkIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtDatabaseName = new DevExpress.XtraEditors.TextEdit();
            this.txtDatabaseNewPath = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnSelectFile = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.imgMain = new DevExpress.Utils.ImageCollection(this.components);
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnHelp = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).BeginInit();
            this.groupboxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabaseName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabaseNewPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelectFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMain)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxMain
            // 
            this.groupboxMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupboxMain.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupboxMain.AppearanceCaption.Options.UseFont = true;
            this.groupboxMain.Controls.Add(this.chkIsActive);
            this.groupboxMain.Controls.Add(this.labelControl3);
            this.groupboxMain.Controls.Add(this.txtDatabaseName);
            this.groupboxMain.Controls.Add(this.txtDatabaseNewPath);
            this.groupboxMain.Controls.Add(this.labelControl2);
            this.groupboxMain.Controls.Add(this.btnSelectFile);
            this.groupboxMain.Controls.Add(this.labelControl1);
            this.groupboxMain.Location = new System.Drawing.Point(8, 0);
            this.groupboxMain.Name = "groupboxMain";
            this.groupboxMain.Size = new System.Drawing.Size(376, 120);
            this.groupboxMain.TabIndex = 1;
            this.groupboxMain.Text = "Tùy chọn chung";
            // 
            // chkIsActive
            // 
            this.chkIsActive.Location = new System.Drawing.Point(85, 96);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Properties.Caption = "Cho phép ghi đè lên cơ sở dữ liệu đã có";
            this.chkIsActive.Size = new System.Drawing.Size(280, 19);
            this.chkIsActive.TabIndex = 6;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(8, 76);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(69, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Tên tệp tin (*)";
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatabaseName.Location = new System.Drawing.Point(88, 72);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(280, 20);
            this.txtDatabaseName.TabIndex = 5;
            // 
            // txtDatabaseNewPath
            // 
            this.txtDatabaseNewPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatabaseNewPath.Location = new System.Drawing.Point(88, 48);
            this.txtDatabaseNewPath.Name = "txtDatabaseNewPath";
            this.txtDatabaseNewPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDatabaseNewPath.Size = new System.Drawing.Size(280, 20);
            this.txtDatabaseNewPath.TabIndex = 3;
            this.txtDatabaseNewPath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtDatabaseNewPath_ButtonClick);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(8, 52);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Phục hồi tới (*)";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile.Location = new System.Drawing.Point(88, 24);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnSelectFile.Size = new System.Drawing.Size(280, 20);
            this.btnSelectFile.TabIndex = 1;
            this.btnSelectFile.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnSelectFile_ButtonClick);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(8, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(71, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Phục hồi từ (*)";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImageIndex = 0;
            this.btnCancel.ImageList = this.imgMain;
            this.btnCancel.Location = new System.Drawing.Point(304, 128);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // imgMain
            // 
            this.imgMain.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgMain.ImageStream")));
            this.imgMain.Images.SetKeyName(0, "HUY-BO.png");
            this.imgMain.Images.SetKeyName(1, "KET-THUC.png");
            this.imgMain.Images.SetKeyName(2, "TRO-GIUP.png");
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImageIndex = 1;
            this.btnOk.ImageList = this.imgMain;
            this.btnOk.Location = new System.Drawing.Point(216, 128);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 25);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Đồng ý";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.ImageIndex = 2;
            this.btnHelp.ImageList = this.imgMain;
            this.btnHelp.Location = new System.Drawing.Point(8, 128);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(80, 25);
            this.btnHelp.TabIndex = 7;
            this.btnHelp.Text = "Trợ giúp";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // FrmXtraRestoreData
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(392, 158);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.groupboxMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmXtraRestoreData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phục hồi cơ sở dữ liệu";
            this.Load += new System.EventHandler(this.FrmXtraRestoreData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupboxMain)).EndInit();
            this.groupboxMain.ResumeLayout(false);
            this.groupboxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabaseName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDatabaseNewPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelectFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.GroupControl groupboxMain;
        private DevExpress.XtraEditors.ButtonEdit btnSelectFile;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit txtDatabaseNewPath;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtDatabaseName;
        private DevExpress.XtraEditors.CheckEdit chkIsActive;
        public DevExpress.XtraEditors.SimpleButton btnCancel;
        public DevExpress.XtraEditors.SimpleButton btnOk;
        public DevExpress.XtraEditors.SimpleButton btnHelp;
        private DevExpress.Utils.ImageCollection imgMain;
    }
}